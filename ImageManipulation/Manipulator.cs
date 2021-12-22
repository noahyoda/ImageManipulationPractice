using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageManipulation
{
    class Manipulator
    {

        public Manipulator()
        {

        }

        /// <summary>
        /// takes an image and a letter ordering of rgb and swaps the rgb colors
        /// of the image accordingly, returning a new image from the color swap
        /// of the original
        /// </summary>
        /// <param name="img"></param>
        /// <param name="rgbOrder"></param>
        /// <returns></returns>
        public Image RGBSwap(Image img, string rgbOrder)
        {
            Bitmap result = new Bitmap(img);
            rgbOrder = rgbOrder.ToLower();

            for (int i = 0; i < img.Width; i++)
            {
                for (int k = 0; k < img.Height; k++)
                {
                    Color currColor = result.GetPixel(i, k);
                    Color newColor = currColor;
                    switch (rgbOrder)
                    {
                        case "bgr":
                            newColor = Color.FromArgb(currColor.B, currColor.G, currColor.R);
                            break;
                        case "brg":
                            newColor = Color.FromArgb(currColor.B, currColor.R, currColor.G);
                            break;
                        case "grb":
                            newColor = Color.FromArgb(currColor.G, currColor.R, currColor.B);
                            break;
                        case "gbr":
                            newColor = Color.FromArgb(currColor.G, currColor.B, currColor.R);
                            break;
                        case "rbg":
                            newColor = Color.FromArgb(currColor.R, currColor.B, currColor.G);
                            break;
                        case "rgb":
                            break;
                    }
                    result.SetPixel(i, k, newColor);
                }
            }

            return result;
        }

        // Filters -------------------------------------------------------------
/*
 *      // under development, skip to line 139 for functional code
 *      
        public Image GaussianFilterMultiThreaded(Image img, int kernelSize)
        {
            Bitmap result = (Bitmap)img.Clone();
            int workDone = 0;
            Queue<int> colsToWork = new Queue<int>();
            for(int i = 0; i < img.Width; i++) { colsToWork.Enqueue(i); }

            List<Thread> threads = new List<Thread>();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            
            while(workDone < result.Width)
            {
                // busy loop to delay main thread 50ms
                while(watch.ElapsedMilliseconds < 50) { }

                // create threads
                while(threads.Count < 4)
                {
                    ThreadStuff curr = new ThreadStuff();
                    curr.img = (Bitmap)result.Clone();
                    curr.col = colsToWork.Dequeue();
                    curr.kernelSize = kernelSize;
                    threads.Add(new Thread(curr.ThreadAction));
                    threads[threads.Count - 1].Start();
                }

                // check threads for inactivity and update workk if inactive
                for(int i = 0; i < threads.Count; i++)
                {
                    // if thread is dead give it a new job
                    if (!threads[i].IsAlive)
                    {
                        ThreadStuff curr = new ThreadStuff();
                        curr.img = result;
                        curr.col = colsToWork.Dequeue();
                        curr.kernelSize = kernelSize;
                        threads[i] = new Thread(curr.ThreadAction);
                    }
                }
            }

            

            return result;
        }

        private class ThreadStuff
        {
            public Bitmap img;
            public int col;
            public int kernelSize;

            public void ThreadAction()
            {
                //for (int col = colStart; col < colEnd; col++)
                //{
                    for (int y = 0; y < img.Height; y++)
                    {
                        // curr pixel = avg of all pixels in current convolution kernel
                        // pass in top left, not center
                        img.SetPixel(col, y, kernelAvg(kernelSize, col - (kernelSize / 2), y - (kernelSize / 2), img));
                    }
                //}
            }
        }*/

        /// <summary>
        /// implements a gaussian filter upon the given image into the new returned
        /// image with a given kernel size
        /// </summary>
        /// <param name="img"></param>
        /// <param name="kernelSize"></param>
        /// <returns></returns>
        public Image GaussianFilter(Image img, int kernelSize)
        {
            Bitmap blurred = (Bitmap)img.Clone();

            // choose kernel size
            int size = kernelSize;
            // average every pixel in image
            for(int x = 0; x < blurred.Width; x++)
            {
                for(int y = 0; y < blurred.Height; y++)
                {
                    // curr pixel = avg of all pixels in current convolution kernel
                    // pass in top left, not center
                    blurred.SetPixel(x, y, kernelAvg(size, x - (size/2), y - (size/2), blurred));
                }
            }

            return blurred;
        }

        /// <summary>
        /// gets the kernel average at a coordinate given an image
        /// and the kernel width/heigh (square only)
        /// </summary>
        /// <param name="size">kernel size (width or heigh)</param>
        /// <param name="x">left most coord of kernel</param>
        /// <param name="y">top most coord of kernel</param>
        /// <param name="img">image to manipulate</param>
        /// <returns></returns>
        private static Color kernelAvg(int size, int x, int y, Bitmap img)
        {
            int r = 0;
            int g = 0;
            int b = 0;
            int tSize = 0;
            for(int i = 0; i < size; i++)
            {
                for(int k = 0; k < size; k++)
                {
                    int getX = x + i;
                    int getY = y + k;
                    // skip pixels out of bound
                    if (getX < 0 || getY < 0 || getX >= img.Width || getY >= img.Height)
                    {
                        continue;
                    }
                    Color pix = img.GetPixel(getX, getY);
                    r += pix.R;
                    g += pix.G;
                    b += pix.B;
                    tSize++;
                }
            }

            r /= tSize;
            g /= tSize;
            b /= tSize;
            
            return Color.FromArgb(r, g, b); ;
        }

    }
}

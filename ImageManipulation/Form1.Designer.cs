
namespace ImageManipulation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rgbOrder = new System.Windows.Forms.TextBox();
            this.orderLabel = new System.Windows.Forms.Label();
            this.blurButton = new System.Windows.Forms.Button();
            this.blurStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rgbOrder
            // 
            this.rgbOrder.Location = new System.Drawing.Point(718, 43);
            this.rgbOrder.Name = "rgbOrder";
            this.rgbOrder.Size = new System.Drawing.Size(46, 20);
            this.rgbOrder.TabIndex = 0;
            this.rgbOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rgbOrder_KeyDown);
            // 
            // orderLabel
            // 
            this.orderLabel.AutoSize = true;
            this.orderLabel.Location = new System.Drawing.Point(718, 27);
            this.orderLabel.Name = "orderLabel";
            this.orderLabel.Size = new System.Drawing.Size(49, 13);
            this.orderLabel.TabIndex = 1;
            this.orderLabel.Text = "rgb order";
            // 
            // blurButton
            // 
            this.blurButton.Location = new System.Drawing.Point(717, 111);
            this.blurButton.Name = "blurButton";
            this.blurButton.Size = new System.Drawing.Size(50, 23);
            this.blurButton.TabIndex = 2;
            this.blurButton.Text = "Blur";
            this.blurButton.UseVisualStyleBackColor = true;
            this.blurButton.Click += new System.EventHandler(this.blurButton_Click);
            // 
            // blurStatus
            // 
            this.blurStatus.AutoSize = true;
            this.blurStatus.Location = new System.Drawing.Point(719, 148);
            this.blurStatus.Name = "blurStatus";
            this.blurStatus.Size = new System.Drawing.Size(43, 13);
            this.blurStatus.TabIndex = 3;
            this.blurStatus.Text = "Waiting";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.blurStatus);
            this.Controls.Add(this.blurButton);
            this.Controls.Add(this.orderLabel);
            this.Controls.Add(this.rgbOrder);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rgbOrder;
        private System.Windows.Forms.Label orderLabel;
        private System.Windows.Forms.Button blurButton;
        private System.Windows.Forms.Label blurStatus;
    }
}


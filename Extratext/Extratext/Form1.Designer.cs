namespace Extratext
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
            this.canevas = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // canevas
            // 
            this.canevas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.canevas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.canevas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canevas.Location = new System.Drawing.Point(0, 0);
            this.canevas.Name = "canevas";
            this.canevas.Size = new System.Drawing.Size(541, 261);
            this.canevas.TabIndex = 0;
            this.canevas.Paint += new System.Windows.Forms.PaintEventHandler(this.canevas_Paint);
            this.canevas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canevas_MouseDown);
            this.canevas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canevas_MouseMove);
            this.canevas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canevas_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(541, 261);
            this.Controls.Add(this.canevas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel canevas;
    }
}


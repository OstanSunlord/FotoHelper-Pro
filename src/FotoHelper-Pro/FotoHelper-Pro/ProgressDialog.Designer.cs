namespace FotoHelper_Pro
{
    partial class ProgressDialog
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
            this.p_status = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.p_progressBar = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.p_status.SuspendLayout();
            this.p_progressBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_status
            // 
            this.p_status.Controls.Add(this.lblStatus);
            this.p_status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_status.Location = new System.Drawing.Point(0, 263);
            this.p_status.Name = "p_status";
            this.p_status.Size = new System.Drawing.Size(473, 42);
            this.p_status.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(12, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(449, 23);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "..";
            // 
            // p_progressBar
            // 
            this.p_progressBar.Controls.Add(this.progressBar);
            this.p_progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_progressBar.Location = new System.Drawing.Point(0, 222);
            this.p_progressBar.Name = "p_progressBar";
            this.p_progressBar.Size = new System.Drawing.Size(473, 41);
            this.p_progressBar.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(473, 41);
            this.progressBar.TabIndex = 0;
            // 
            // ProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 305);
            this.Controls.Add(this.p_progressBar);
            this.Controls.Add(this.p_status);
            this.Name = "ProgressDialog";
            this.Text = "ProgressDialog";
            this.p_status.ResumeLayout(false);
            this.p_progressBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_status;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel p_progressBar;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}
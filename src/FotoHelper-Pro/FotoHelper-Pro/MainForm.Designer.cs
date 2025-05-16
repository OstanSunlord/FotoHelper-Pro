namespace FotoHelper_Pro
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.p_top = new System.Windows.Forms.Panel();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.p_bund = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.flow_menu = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_OrganizeMyPhotos = new System.Windows.Forms.Button();
            this.btn_TagFilesAndFolder = new System.Windows.Forms.Button();
            this.p_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.p_bund.SuspendLayout();
            this.flow_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_top
            // 
            this.p_top.Controls.Add(this.pb_logo);
            this.p_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_top.Location = new System.Drawing.Point(0, 0);
            this.p_top.Name = "p_top";
            this.p_top.Size = new System.Drawing.Size(394, 117);
            this.p_top.TabIndex = 3;
            // 
            // pb_logo
            // 
            this.pb_logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_logo.Image = global::FotoHelper_Pro.Properties.Resources.solrod_logo_white;
            this.pb_logo.Location = new System.Drawing.Point(0, 0);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(394, 117);
            this.pb_logo.TabIndex = 1;
            this.pb_logo.TabStop = false;
            // 
            // p_bund
            // 
            this.p_bund.Controls.Add(this.btn_close);
            this.p_bund.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_bund.Location = new System.Drawing.Point(0, 404);
            this.p_bund.Name = "p_bund";
            this.p_bund.Size = new System.Drawing.Size(394, 46);
            this.p_bund.TabIndex = 4;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Location = new System.Drawing.Point(307, 11);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "Luk";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // flow_menu
            // 
            this.flow_menu.Controls.Add(this.btn_OrganizeMyPhotos);
            this.flow_menu.Controls.Add(this.btn_TagFilesAndFolder);
            this.flow_menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow_menu.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flow_menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flow_menu.Location = new System.Drawing.Point(0, 117);
            this.flow_menu.Name = "flow_menu";
            this.flow_menu.Size = new System.Drawing.Size(394, 287);
            this.flow_menu.TabIndex = 5;
            // 
            // btn_OrganizeMyPhotos
            // 
            this.btn_OrganizeMyPhotos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OrganizeMyPhotos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OrganizeMyPhotos.Location = new System.Drawing.Point(4, 3);
            this.btn_OrganizeMyPhotos.Name = "btn_OrganizeMyPhotos";
            this.btn_OrganizeMyPhotos.Size = new System.Drawing.Size(387, 46);
            this.btn_OrganizeMyPhotos.TabIndex = 0;
            this.btn_OrganizeMyPhotos.Text = "Organize My Photos";
            this.btn_OrganizeMyPhotos.UseVisualStyleBackColor = true;
            this.btn_OrganizeMyPhotos.Click += new System.EventHandler(this.btn_OrganizeMyPhotos_Click);
            // 
            // btn_TagFilesAndFolder
            // 
            this.btn_TagFilesAndFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_TagFilesAndFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TagFilesAndFolder.Location = new System.Drawing.Point(4, 55);
            this.btn_TagFilesAndFolder.Name = "btn_TagFilesAndFolder";
            this.btn_TagFilesAndFolder.Size = new System.Drawing.Size(387, 46);
            this.btn_TagFilesAndFolder.TabIndex = 1;
            this.btn_TagFilesAndFolder.Text = "Tag Files and Folder";
            this.btn_TagFilesAndFolder.UseVisualStyleBackColor = true;
            this.btn_TagFilesAndFolder.Click += new System.EventHandler(this.btn_TagFilesAndFolder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(51)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(394, 450);
            this.Controls.Add(this.flow_menu);
            this.Controls.Add(this.p_bund);
            this.Controls.Add(this.p_top);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FotoHelper Pro";
            this.p_top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.p_bund.ResumeLayout(false);
            this.flow_menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel p_top;
        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.Panel p_bund;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.FlowLayoutPanel flow_menu;
        private System.Windows.Forms.Button btn_OrganizeMyPhotos;
        private System.Windows.Forms.Button btn_TagFilesAndFolder;
    }
}


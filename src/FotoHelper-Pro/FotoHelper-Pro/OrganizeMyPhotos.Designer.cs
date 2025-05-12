namespace FotoHelper_Pro
{
    partial class OrganizeMyPhotos
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
            this.gb_Input = new System.Windows.Forms.GroupBox();
            this.btn_Search_light = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_lightroom = new System.Windows.Forms.TextBox();
            this.btn_Search_orig = new System.Windows.Forms.Button();
            this.lb_Source = new System.Windows.Forms.Label();
            this.tb_Source = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gb_destination = new System.Windows.Forms.GroupBox();
            this.btn_Search_desc = new System.Windows.Forms.Button();
            this.lb_destination = new System.Windows.Forms.Label();
            this.tb_destination = new System.Windows.Forms.TextBox();
            this.btn_luk = new System.Windows.Forms.Button();
            this.btn_run = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.gb_indstillinger = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_PriZeroCount_File = new System.Windows.Forms.TextBox();
            this.cb_AddImageId = new System.Windows.Forms.CheckBox();
            this.lb_PriZeroCount = new System.Windows.Forms.Label();
            this.tb_PriZeroCountFolder = new System.Windows.Forms.TextBox();
            this.cb_AddFolderId = new System.Windows.Forms.CheckBox();
            this.cb_Overwrite = new System.Windows.Forms.CheckBox();
            this.gb_Input.SuspendLayout();
            this.gb_destination.SuspendLayout();
            this.gb_indstillinger.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Input
            // 
            this.gb_Input.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Input.Controls.Add(this.btn_Search_light);
            this.gb_Input.Controls.Add(this.label1);
            this.gb_Input.Controls.Add(this.tb_lightroom);
            this.gb_Input.Controls.Add(this.btn_Search_orig);
            this.gb_Input.Controls.Add(this.lb_Source);
            this.gb_Input.Controls.Add(this.tb_Source);
            this.gb_Input.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gb_Input.Location = new System.Drawing.Point(16, 14);
            this.gb_Input.Margin = new System.Windows.Forms.Padding(4);
            this.gb_Input.Name = "gb_Input";
            this.gb_Input.Padding = new System.Windows.Forms.Padding(4);
            this.gb_Input.Size = new System.Drawing.Size(786, 112);
            this.gb_Input.TabIndex = 0;
            this.gb_Input.TabStop = false;
            this.gb_Input.Text = "Kilde";
            // 
            // btn_Search_light
            // 
            this.btn_Search_light.Image = global::FotoHelper_Pro.Properties.Resources.icons8_search_folder_23;
            this.btn_Search_light.Location = new System.Drawing.Point(731, 58);
            this.btn_Search_light.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Search_light.Name = "btn_Search_light";
            this.btn_Search_light.Size = new System.Drawing.Size(34, 30);
            this.btn_Search_light.TabIndex = 11;
            this.btn_Search_light.UseVisualStyleBackColor = true;
            this.btn_Search_light.Click += new System.EventHandler(this.btn_Search_light_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Lightroom Export:";
            // 
            // tb_lightroom
            // 
            this.tb_lightroom.Location = new System.Drawing.Point(174, 62);
            this.tb_lightroom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_lightroom.Name = "tb_lightroom";
            this.tb_lightroom.Size = new System.Drawing.Size(552, 22);
            this.tb_lightroom.TabIndex = 9;
            // 
            // btn_Search_orig
            // 
            this.btn_Search_orig.Image = global::FotoHelper_Pro.Properties.Resources.icons8_search_folder_23;
            this.btn_Search_orig.Location = new System.Drawing.Point(731, 23);
            this.btn_Search_orig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Search_orig.Name = "btn_Search_orig";
            this.btn_Search_orig.Size = new System.Drawing.Size(34, 30);
            this.btn_Search_orig.TabIndex = 8;
            this.btn_Search_orig.UseVisualStyleBackColor = true;
            this.btn_Search_orig.Click += new System.EventHandler(this.btn_Search_orig_Click);
            // 
            // lb_Source
            // 
            this.lb_Source.AutoSize = true;
            this.lb_Source.Location = new System.Drawing.Point(100, 30);
            this.lb_Source.Name = "lb_Source";
            this.lb_Source.Size = new System.Drawing.Size(56, 16);
            this.lb_Source.TabIndex = 7;
            this.lb_Source.Text = "Original:";
            // 
            // tb_Source
            // 
            this.tb_Source.Location = new System.Drawing.Point(174, 27);
            this.tb_Source.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_Source.Name = "tb_Source";
            this.tb_Source.Size = new System.Drawing.Size(552, 22);
            this.tb_Source.TabIndex = 6;
            // 
            // gb_destination
            // 
            this.gb_destination.Controls.Add(this.btn_Search_desc);
            this.gb_destination.Controls.Add(this.lb_destination);
            this.gb_destination.Controls.Add(this.tb_destination);
            this.gb_destination.Location = new System.Drawing.Point(16, 133);
            this.gb_destination.Name = "gb_destination";
            this.gb_destination.Size = new System.Drawing.Size(786, 78);
            this.gb_destination.TabIndex = 1;
            this.gb_destination.TabStop = false;
            this.gb_destination.Text = "Destination";
            // 
            // btn_Search_desc
            // 
            this.btn_Search_desc.Image = global::FotoHelper_Pro.Properties.Resources.icons8_search_folder_23;
            this.btn_Search_desc.Location = new System.Drawing.Point(731, 25);
            this.btn_Search_desc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Search_desc.Name = "btn_Search_desc";
            this.btn_Search_desc.Size = new System.Drawing.Size(34, 30);
            this.btn_Search_desc.TabIndex = 11;
            this.btn_Search_desc.UseVisualStyleBackColor = true;
            this.btn_Search_desc.Click += new System.EventHandler(this.btn_Search_desc_Click);
            // 
            // lb_destination
            // 
            this.lb_destination.AutoSize = true;
            this.lb_destination.Location = new System.Drawing.Point(45, 32);
            this.lb_destination.Name = "lb_destination";
            this.lb_destination.Size = new System.Drawing.Size(123, 16);
            this.lb_destination.TabIndex = 10;
            this.lb_destination.Text = "Destination Mappe:";
            // 
            // tb_destination
            // 
            this.tb_destination.Location = new System.Drawing.Point(174, 29);
            this.tb_destination.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_destination.Name = "tb_destination";
            this.tb_destination.Size = new System.Drawing.Size(552, 22);
            this.tb_destination.TabIndex = 9;
            // 
            // btn_luk
            // 
            this.btn_luk.Location = new System.Drawing.Point(727, 519);
            this.btn_luk.Name = "btn_luk";
            this.btn_luk.Size = new System.Drawing.Size(75, 23);
            this.btn_luk.TabIndex = 2;
            this.btn_luk.Text = "Luk";
            this.btn_luk.UseVisualStyleBackColor = true;
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(646, 519);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(75, 23);
            this.btn_run.TabIndex = 3;
            this.btn_run.Text = "Kø";
            this.btn_run.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(727, 519);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Luk";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(646, 519);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Kø";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // gb_indstillinger
            // 
            this.gb_indstillinger.Controls.Add(this.label2);
            this.gb_indstillinger.Controls.Add(this.tb_PriZeroCount_File);
            this.gb_indstillinger.Controls.Add(this.cb_AddImageId);
            this.gb_indstillinger.Controls.Add(this.lb_PriZeroCount);
            this.gb_indstillinger.Controls.Add(this.tb_PriZeroCountFolder);
            this.gb_indstillinger.Controls.Add(this.cb_AddFolderId);
            this.gb_indstillinger.Controls.Add(this.cb_Overwrite);
            this.gb_indstillinger.Location = new System.Drawing.Point(16, 217);
            this.gb_indstillinger.Name = "gb_indstillinger";
            this.gb_indstillinger.Size = new System.Drawing.Size(336, 154);
            this.gb_indstillinger.TabIndex = 4;
            this.gb_indstillinger.TabStop = false;
            this.gb_indstillinger.Text = "Indstillinger";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Forløbe Nul";
            // 
            // tb_PriZeroCount_File
            // 
            this.tb_PriZeroCount_File.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_PriZeroCount_File.Location = new System.Drawing.Point(285, 45);
            this.tb_PriZeroCount_File.Name = "tb_PriZeroCount_File";
            this.tb_PriZeroCount_File.Size = new System.Drawing.Size(45, 22);
            this.tb_PriZeroCount_File.TabIndex = 5;
            this.tb_PriZeroCount_File.Text = "4";
            this.tb_PriZeroCount_File.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_AddImageId
            // 
            this.cb_AddImageId.AutoSize = true;
            this.cb_AddImageId.Checked = true;
            this.cb_AddImageId.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_AddImageId.Location = new System.Drawing.Point(6, 47);
            this.cb_AddImageId.Name = "cb_AddImageId";
            this.cb_AddImageId.Size = new System.Drawing.Size(122, 20);
            this.cb_AddImageId.TabIndex = 4;
            this.cb_AddImageId.Text = "Tilføre billede Id";
            this.cb_AddImageId.UseVisualStyleBackColor = true;
            // 
            // lb_PriZeroCount
            // 
            this.lb_PriZeroCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_PriZeroCount.AutoSize = true;
            this.lb_PriZeroCount.Location = new System.Drawing.Point(202, 21);
            this.lb_PriZeroCount.Name = "lb_PriZeroCount";
            this.lb_PriZeroCount.Size = new System.Drawing.Size(77, 16);
            this.lb_PriZeroCount.TabIndex = 3;
            this.lb_PriZeroCount.Text = "Forløbe Nul";
            // 
            // tb_PriZeroCountFolder
            // 
            this.tb_PriZeroCountFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_PriZeroCountFolder.Location = new System.Drawing.Point(285, 15);
            this.tb_PriZeroCountFolder.Name = "tb_PriZeroCountFolder";
            this.tb_PriZeroCountFolder.Size = new System.Drawing.Size(45, 22);
            this.tb_PriZeroCountFolder.TabIndex = 2;
            this.tb_PriZeroCountFolder.Text = "2";
            this.tb_PriZeroCountFolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_AddFolderId
            // 
            this.cb_AddFolderId.AutoSize = true;
            this.cb_AddFolderId.Checked = true;
            this.cb_AddFolderId.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_AddFolderId.Location = new System.Drawing.Point(6, 21);
            this.cb_AddFolderId.Name = "cb_AddFolderId";
            this.cb_AddFolderId.Size = new System.Drawing.Size(115, 20);
            this.cb_AddFolderId.TabIndex = 1;
            this.cb_AddFolderId.Text = "Tilføre folder Id";
            this.cb_AddFolderId.UseVisualStyleBackColor = true;
            // 
            // cb_Overwrite
            // 
            this.cb_Overwrite.AutoSize = true;
            this.cb_Overwrite.Location = new System.Drawing.Point(6, 112);
            this.cb_Overwrite.Name = "cb_Overwrite";
            this.cb_Overwrite.Size = new System.Drawing.Size(154, 20);
            this.cb_Overwrite.TabIndex = 0;
            this.cb_Overwrite.Text = "Flyt i stedet for at kopi";
            this.cb_Overwrite.UseVisualStyleBackColor = true;
            // 
            // OrganizeMyPhotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(818, 554);
            this.Controls.Add(this.gb_indstillinger);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.btn_luk);
            this.Controls.Add(this.gb_destination);
            this.Controls.Add(this.gb_Input);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OrganizeMyPhotos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Organize My Photos";
            this.gb_Input.ResumeLayout(false);
            this.gb_Input.PerformLayout();
            this.gb_destination.ResumeLayout(false);
            this.gb_destination.PerformLayout();
            this.gb_indstillinger.ResumeLayout(false);
            this.gb_indstillinger.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_lightroom;
        private System.Windows.Forms.Button btn_Search_orig;
        private System.Windows.Forms.Label lb_Source;
        private System.Windows.Forms.TextBox tb_Source;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_Search_light;
        private System.Windows.Forms.GroupBox gb_destination;
        private System.Windows.Forms.Button btn_Search_desc;
        private System.Windows.Forms.Label lb_destination;
        private System.Windows.Forms.TextBox tb_destination;
        private System.Windows.Forms.Button btn_luk;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox gb_indstillinger;
        private System.Windows.Forms.CheckBox cb_Overwrite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_PriZeroCount_File;
        private System.Windows.Forms.CheckBox cb_AddImageId;
        private System.Windows.Forms.Label lb_PriZeroCount;
        private System.Windows.Forms.TextBox tb_PriZeroCountFolder;
        private System.Windows.Forms.CheckBox cb_AddFolderId;
    }
}
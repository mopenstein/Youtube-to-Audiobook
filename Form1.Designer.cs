namespace Youtube_Video_to_Audio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFFmpeg = new System.Windows.Forms.Button();
            this.txtFFMPEG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numBitrate = new System.Windows.Forms.NumericUpDown();
            this.picThumb = new System.Windows.Forms.PictureBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbProfiles = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkAuthor = new System.Windows.Forms.CheckBox();
            this.chkChapters = new System.Windows.Forms.CheckBox();
            this.chkVolume = new System.Windows.Forms.CheckBox();
            this.cmbSpeed = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFilters = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.btnLocalLoad = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnVolumeDetect = new System.Windows.Forms.Button();
            this.chkService = new System.Windows.Forms.CheckBox();
            this.cmbFetchers = new System.Windows.Forms.ComboBox();
            this.btnAddQueue = new System.Windows.Forms.Button();
            this.lstQueue = new System.Windows.Forms.ListBox();
            this.chkRandom = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBitrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumb)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(777, 308);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 40);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "Start";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSavePath
            // 
            this.btnSavePath.Location = new System.Drawing.Point(505, 37);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(50, 20);
            this.btnSavePath.TabIndex = 3;
            this.btnSavePath.Text = "...";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // txtSavePath
            // 
            this.txtSavePath.BackColor = System.Drawing.SystemColors.Window;
            this.txtSavePath.Location = new System.Drawing.Point(110, 38);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.ReadOnly = true;
            this.txtSavePath.Size = new System.Drawing.Size(389, 20);
            this.txtSavePath.TabIndex = 2;
            this.txtSavePath.Text = "C:\\ffmpeg\\output\\";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Output Location: ";
            // 
            // btnFFmpeg
            // 
            this.btnFFmpeg.Location = new System.Drawing.Point(505, 11);
            this.btnFFmpeg.Name = "btnFFmpeg";
            this.btnFFmpeg.Size = new System.Drawing.Size(50, 20);
            this.btnFFmpeg.TabIndex = 1;
            this.btnFFmpeg.Text = "...";
            this.btnFFmpeg.UseVisualStyleBackColor = true;
            this.btnFFmpeg.Click += new System.EventHandler(this.btnFFmpeg_Click);
            // 
            // txtFFMPEG
            // 
            this.txtFFMPEG.BackColor = System.Drawing.SystemColors.Window;
            this.txtFFMPEG.Location = new System.Drawing.Point(110, 12);
            this.txtFFMPEG.Name = "txtFFMPEG";
            this.txtFFMPEG.ReadOnly = true;
            this.txtFFMPEG.Size = new System.Drawing.Size(389, 20);
            this.txtFFMPEG.TabIndex = 0;
            this.txtFFMPEG.Text = "C:\\ffmpeg\\";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "FFMPEG Location: ";
            // 
            // txtDebug
            // 
            this.txtDebug.BackColor = System.Drawing.SystemColors.Window;
            this.txtDebug.Location = new System.Drawing.Point(8, 354);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ReadOnly = true;
            this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDebug.Size = new System.Drawing.Size(844, 169);
            this.txtDebug.TabIndex = 12;
            this.txtDebug.WordWrap = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 308);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(759, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(110, 64);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(366, 20);
            this.txtURL.TabIndex = 6;
            this.txtURL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtURL_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "YouTube URL:";
            // 
            // numMin
            // 
            this.numMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMin.Location = new System.Drawing.Point(123, 43);
            this.numMin.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMin.Name = "numMin";
            this.numMin.Size = new System.Drawing.Size(59, 26);
            this.numMin.TabIndex = 4;
            this.numMin.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numMin.ValueChanged += new System.EventHandler(this.numMin_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Max Length Per File :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "MINUTES";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(380, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "KBPS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(266, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Bitrate :";
            // 
            // numBitrate
            // 
            this.numBitrate.BackColor = System.Drawing.SystemColors.Window;
            this.numBitrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBitrate.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numBitrate.Location = new System.Drawing.Point(315, 43);
            this.numBitrate.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numBitrate.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numBitrate.Name = "numBitrate";
            this.numBitrate.ReadOnly = true;
            this.numBitrate.Size = new System.Drawing.Size(59, 26);
            this.numBitrate.TabIndex = 5;
            this.numBitrate.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.numBitrate.ValueChanged += new System.EventHandler(this.numBitrate_ValueChanged);
            // 
            // picThumb
            // 
            this.picThumb.BackColor = System.Drawing.Color.White;
            this.picThumb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picThumb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picThumb.Location = new System.Drawing.Point(429, 15);
            this.picThumb.Name = "picThumb";
            this.picThumb.Size = new System.Drawing.Size(109, 109);
            this.picThumb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picThumb.TabIndex = 25;
            this.picThumb.TabStop = false;
            this.picThumb.Click += new System.EventHandler(this.picThumb_Click);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(11, 337);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(760, 11);
            this.progressBar2.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmbProfiles);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.chkAuthor);
            this.groupBox1.Controls.Add(this.chkChapters);
            this.groupBox1.Controls.Add(this.chkVolume);
            this.groupBox1.Controls.Add(this.cmbSpeed);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtFilters);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numBitrate);
            this.groupBox1.Controls.Add(this.txtAuthor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numMin);
            this.groupBox1.Controls.Add(this.picThumb);
            this.groupBox1.Location = new System.Drawing.Point(15, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 191);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MP3 Info";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 22);
            this.button1.TabIndex = 38;
            this.button1.Text = "Save Profile";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cmbProfiles
            // 
            this.cmbProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfiles.Enabled = false;
            this.cmbProfiles.FormattingEnabled = true;
            this.cmbProfiles.Location = new System.Drawing.Point(55, 16);
            this.cmbProfiles.Name = "cmbProfiles";
            this.cmbProfiles.Size = new System.Drawing.Size(198, 21);
            this.cmbProfiles.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Profile:";
            // 
            // chkAuthor
            // 
            this.chkAuthor.AutoSize = true;
            this.chkAuthor.Location = new System.Drawing.Point(110, 134);
            this.chkAuthor.Name = "chkAuthor";
            this.chkAuthor.Size = new System.Drawing.Size(156, 17);
            this.chkAuthor.TabIndex = 35;
            this.chkAuthor.Text = "Include Author in File Name";
            this.chkAuthor.UseVisualStyleBackColor = true;
            this.chkAuthor.CheckedChanged += new System.EventHandler(this.chkAuthor_CheckedChanged);
            // 
            // chkChapters
            // 
            this.chkChapters.AutoSize = true;
            this.chkChapters.Checked = true;
            this.chkChapters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChapters.Location = new System.Drawing.Point(13, 134);
            this.chkChapters.Name = "chkChapters";
            this.chkChapters.Size = new System.Drawing.Size(90, 17);
            this.chkChapters.TabIndex = 34;
            this.chkChapters.Text = "Add Chapters";
            this.chkChapters.UseVisualStyleBackColor = true;
            this.chkChapters.CheckedChanged += new System.EventHandler(this.chkChapters_CheckedChanged);
            // 
            // chkVolume
            // 
            this.chkVolume.AutoSize = true;
            this.chkVolume.Location = new System.Drawing.Point(321, 85);
            this.chkVolume.Name = "chkVolume";
            this.chkVolume.Size = new System.Drawing.Size(102, 17);
            this.chkVolume.TabIndex = 33;
            this.chkVolume.Text = "Auto Volume Fix";
            this.chkVolume.UseVisualStyleBackColor = true;
            this.chkVolume.CheckedChanged += new System.EventHandler(this.chkVolume_CheckedChanged);
            // 
            // cmbSpeed
            // 
            this.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpeed.FormattingEnabled = true;
            this.cmbSpeed.Location = new System.Drawing.Point(357, 160);
            this.cmbSpeed.Name = "cmbSpeed";
            this.cmbSpeed.Size = new System.Drawing.Size(58, 21);
            this.cmbSpeed.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(262, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Playback Speed: x";
            // 
            // txtFilters
            // 
            this.txtFilters.Location = new System.Drawing.Point(57, 160);
            this.txtFilters.Name = "txtFilters";
            this.txtFilters.Size = new System.Drawing.Size(199, 20);
            this.txtFilters.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Filters:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(57, 108);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(361, 20);
            this.txtTitle.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Title:";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(57, 82);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(199, 20);
            this.txtAuthor.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Author:";
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Location = new System.Drawing.Point(8, 529);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(203, 17);
            this.chkLog.TabIndex = 11;
            this.chkLog.Text = "Log Everything (debug info, for nerds)";
            this.chkLog.UseVisualStyleBackColor = true;
            this.chkLog.CheckedChanged += new System.EventHandler(this.chkLog_CheckedChanged);
            // 
            // btnLocalLoad
            // 
            this.btnLocalLoad.Location = new System.Drawing.Point(505, 64);
            this.btnLocalLoad.Name = "btnLocalLoad";
            this.btnLocalLoad.Size = new System.Drawing.Size(50, 20);
            this.btnLocalLoad.TabIndex = 27;
            this.btnLocalLoad.Text = "...";
            this.btnLocalLoad.UseVisualStyleBackColor = true;
            this.btnLocalLoad.Click += new System.EventHandler(this.btnLocalLoad_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "MP4 Video (*.mp4)|*.mp4|All Files (*.*)|*.*";
            // 
            // btnVolumeDetect
            // 
            this.btnVolumeDetect.Location = new System.Drawing.Point(444, 529);
            this.btnVolumeDetect.Name = "btnVolumeDetect";
            this.btnVolumeDetect.Size = new System.Drawing.Size(111, 20);
            this.btnVolumeDetect.TabIndex = 28;
            this.btnVolumeDetect.Text = "TEST";
            this.btnVolumeDetect.UseVisualStyleBackColor = true;
            this.btnVolumeDetect.Visible = false;
            this.btnVolumeDetect.Click += new System.EventHandler(this.btnVolumeDetect_Click);
            // 
            // chkService
            // 
            this.chkService.AutoSize = true;
            this.chkService.Location = new System.Drawing.Point(23, 88);
            this.chkService.Name = "chkService";
            this.chkService.Size = new System.Drawing.Size(223, 17);
            this.chkService.TabIndex = 29;
            this.chkService.Text = "Use 3rd Party Service to fetch Video URL";
            this.chkService.UseVisualStyleBackColor = true;
            this.chkService.CheckedChanged += new System.EventHandler(this.chkService_CheckedChanged);
            // 
            // cmbFetchers
            // 
            this.cmbFetchers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFetchers.Enabled = false;
            this.cmbFetchers.FormattingEnabled = true;
            this.cmbFetchers.Location = new System.Drawing.Point(252, 86);
            this.cmbFetchers.Name = "cmbFetchers";
            this.cmbFetchers.Size = new System.Drawing.Size(166, 21);
            this.cmbFetchers.TabIndex = 30;
            this.cmbFetchers.SelectedIndexChanged += new System.EventHandler(this.cmbFetchers_SelectedIndexChanged);
            // 
            // btnAddQueue
            // 
            this.btnAddQueue.Location = new System.Drawing.Point(482, 64);
            this.btnAddQueue.Name = "btnAddQueue";
            this.btnAddQueue.Size = new System.Drawing.Size(20, 20);
            this.btnAddQueue.TabIndex = 31;
            this.btnAddQueue.Text = "+";
            this.btnAddQueue.UseVisualStyleBackColor = true;
            this.btnAddQueue.Click += new System.EventHandler(this.btnAddQueue_Click);
            // 
            // lstQueue
            // 
            this.lstQueue.FormattingEnabled = true;
            this.lstQueue.Location = new System.Drawing.Point(562, 12);
            this.lstQueue.Name = "lstQueue";
            this.lstQueue.Size = new System.Drawing.Size(290, 290);
            this.lstQueue.TabIndex = 32;
            // 
            // chkRandom
            // 
            this.chkRandom.AutoSize = true;
            this.chkRandom.Checked = true;
            this.chkRandom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRandom.Location = new System.Drawing.Point(424, 88);
            this.chkRandom.Name = "chkRandom";
            this.chkRandom.Size = new System.Drawing.Size(66, 17);
            this.chkRandom.TabIndex = 33;
            this.chkRandom.Text = "Random";
            this.chkRandom.UseVisualStyleBackColor = true;
            this.chkRandom.CheckedChanged += new System.EventHandler(this.chkRandom_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 556);
            this.Controls.Add(this.chkRandom);
            this.Controls.Add(this.lstQueue);
            this.Controls.Add(this.btnAddQueue);
            this.Controls.Add(this.cmbFetchers);
            this.Controls.Add(this.chkService);
            this.Controls.Add(this.btnVolumeDetect);
            this.Controls.Add(this.btnLocalLoad);
            this.Controls.Add(this.chkLog);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnSavePath);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFFmpeg);
            this.Controls.Add(this.txtFFMPEG);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "YouTube to Audio";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBitrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumb)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFFmpeg;
        private System.Windows.Forms.TextBox txtFFMPEG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numBitrate;
        private System.Windows.Forms.PictureBox picThumb;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.TextBox txtFilters;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLocalLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmbSpeed;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnVolumeDetect;
        private System.Windows.Forms.CheckBox chkVolume;
        private System.Windows.Forms.CheckBox chkAuthor;
        private System.Windows.Forms.CheckBox chkChapters;
        private System.Windows.Forms.CheckBox chkService;
        private System.Windows.Forms.ComboBox cmbFetchers;
        private System.Windows.Forms.Button btnAddQueue;
        private System.Windows.Forms.ListBox lstQueue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbProfiles;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkRandom;
    }
}


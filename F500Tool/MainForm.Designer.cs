namespace F500Tool
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openFirmware = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutButton = new System.Windows.Forms.ToolStripButton();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.RomTabPage = new System.Windows.Forms.TabPage();
            this.picturePreview = new System.Windows.Forms.PictureBox();
            this.filesListBox = new System.Windows.Forms.ListBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.extractButton = new System.Windows.Forms.ToolStripButton();
            this.packButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveRomButton = new System.Windows.Forms.ToolStripButton();
            this.BitmapsPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BitmapsList = new System.Windows.Forms.ListBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.RawData = new System.Windows.Forms.TabPage();
            this.hexTextBox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.decodedHexTextBox = new System.Windows.Forms.TextBox();
            this.bitmapPreview = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.RomTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.BitmapsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.RawData.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bitmapPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFirmware,
            this.toolStripSeparator2,
            this.aboutButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(610, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openFirmware
            // 
            this.openFirmware.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFirmware.Image = global::F500Tool.Properties.Resources.open;
            this.openFirmware.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFirmware.Name = "openFirmware";
            this.openFirmware.Size = new System.Drawing.Size(36, 36);
            this.openFirmware.Text = "Открыть файл прошивки";
            this.openFirmware.Click += new System.EventHandler(this.OpenFirmwareClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // aboutButton
            // 
            this.aboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutButton.Image = global::F500Tool.Properties.Resources.info;
            this.aboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(36, 36);
            this.aboutButton.Text = "toolStripButton1";
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // LogTextBox
            // 
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Location = new System.Drawing.Point(2, 2);
            this.LogTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(598, 436);
            this.LogTextBox.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.RomTabPage);
            this.tabControl1.Controls.Add(this.BitmapsPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 39);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(610, 466);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LogTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(602, 440);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Журнал";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // RomTabPage
            // 
            this.RomTabPage.Controls.Add(this.picturePreview);
            this.RomTabPage.Controls.Add(this.filesListBox);
            this.RomTabPage.Controls.Add(this.toolStrip2);
            this.RomTabPage.Location = new System.Drawing.Point(4, 22);
            this.RomTabPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RomTabPage.Name = "RomTabPage";
            this.RomTabPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RomTabPage.Size = new System.Drawing.Size(602, 447);
            this.RomTabPage.TabIndex = 1;
            this.RomTabPage.Text = "ROM";
            this.RomTabPage.UseVisualStyleBackColor = true;
            // 
            // picturePreview
            // 
            this.picturePreview.Location = new System.Drawing.Point(177, 37);
            this.picturePreview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picturePreview.Name = "picturePreview";
            this.picturePreview.Size = new System.Drawing.Size(100, 50);
            this.picturePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picturePreview.TabIndex = 3;
            this.picturePreview.TabStop = false;
            // 
            // filesListBox
            // 
            this.filesListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.filesListBox.FormattingEnabled = true;
            this.filesListBox.Location = new System.Drawing.Point(2, 41);
            this.filesListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.filesListBox.Name = "filesListBox";
            this.filesListBox.Size = new System.Drawing.Size(171, 404);
            this.filesListBox.TabIndex = 1;
            this.filesListBox.SelectedIndexChanged += new System.EventHandler(this.FilesListBoxSelectedIndexChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractButton,
            this.packButton,
            this.toolStripSeparator1,
            this.saveRomButton});
            this.toolStrip2.Location = new System.Drawing.Point(2, 2);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(598, 39);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // extractButton
            // 
            this.extractButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.extractButton.Image = global::F500Tool.Properties.Resources.extract;
            this.extractButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.extractButton.Name = "extractButton";
            this.extractButton.Size = new System.Drawing.Size(36, 36);
            this.extractButton.Text = "Извлечь файл";
            this.extractButton.Click += new System.EventHandler(this.ExtractButtonClick);
            // 
            // packButton
            // 
            this.packButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.packButton.Image = global::F500Tool.Properties.Resources.pack;
            this.packButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.packButton.Name = "packButton";
            this.packButton.Size = new System.Drawing.Size(36, 36);
            this.packButton.Text = "Заменить файл";
            this.packButton.Click += new System.EventHandler(this.PackButtonClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // saveRomButton
            // 
            this.saveRomButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveRomButton.Image = global::F500Tool.Properties.Resources.save;
            this.saveRomButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveRomButton.Name = "saveRomButton";
            this.saveRomButton.Size = new System.Drawing.Size(36, 36);
            this.saveRomButton.Text = "Сохранить ROM для прошивки";
            this.saveRomButton.Click += new System.EventHandler(this.SaveRomButtonClick);
            // 
            // BitmapsPage
            // 
            this.BitmapsPage.Controls.Add(this.splitContainer1);
            this.BitmapsPage.Location = new System.Drawing.Point(4, 22);
            this.BitmapsPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BitmapsPage.Name = "BitmapsPage";
            this.BitmapsPage.Size = new System.Drawing.Size(602, 447);
            this.BitmapsPage.TabIndex = 2;
            this.BitmapsPage.Text = "Bitmaps";
            this.BitmapsPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BitmapsList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(604, 449);
            this.splitContainer1.SplitterDistance = 353;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 2;
            // 
            // BitmapsList
            // 
            this.BitmapsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BitmapsList.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BitmapsList.FormattingEnabled = true;
            this.BitmapsList.Location = new System.Drawing.Point(0, 0);
            this.BitmapsList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BitmapsList.Name = "BitmapsList";
            this.BitmapsList.Size = new System.Drawing.Size(266, 450);
            this.BitmapsList.TabIndex = 0;
            this.BitmapsList.SelectedIndexChanged += new System.EventHandler(this.BitmapsListSelectedIndexChanged);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.RawData);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(337, 449);
            this.tabControl2.TabIndex = 2;
            // 
            // RawData
            // 
            this.RawData.Controls.Add(this.hexTextBox);
            this.RawData.Location = new System.Drawing.Point(4, 22);
            this.RawData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RawData.Name = "RawData";
            this.RawData.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RawData.Size = new System.Drawing.Size(329, 423);
            this.RawData.TabIndex = 0;
            this.RawData.Text = "RawData";
            this.RawData.UseVisualStyleBackColor = true;
            // 
            // hexTextBox
            // 
            this.hexTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexTextBox.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hexTextBox.Location = new System.Drawing.Point(2, 2);
            this.hexTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hexTextBox.Multiline = true;
            this.hexTextBox.Name = "hexTextBox";
            this.hexTextBox.Size = new System.Drawing.Size(327, 424);
            this.hexTextBox.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.decodedHexTextBox);
            this.tabPage3.Controls.Add(this.bitmapPreview);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Size = new System.Drawing.Size(329, 423);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Decoded";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // decodedHexTextBox
            // 
            this.decodedHexTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decodedHexTextBox.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decodedHexTextBox.Location = new System.Drawing.Point(2, 94);
            this.decodedHexTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.decodedHexTextBox.Multiline = true;
            this.decodedHexTextBox.Name = "decodedHexTextBox";
            this.decodedHexTextBox.Size = new System.Drawing.Size(327, 332);
            this.decodedHexTextBox.TabIndex = 2;
            // 
            // bitmapPreview
            // 
            this.bitmapPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.bitmapPreview.Location = new System.Drawing.Point(2, 2);
            this.bitmapPreview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bitmapPreview.Name = "bitmapPreview";
            this.bitmapPreview.Size = new System.Drawing.Size(326, 92);
            this.bitmapPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bitmapPreview.TabIndex = 3;
            this.bitmapPreview.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 505);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "F500Tool";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.RomTabPage.ResumeLayout(false);
            this.RomTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.BitmapsPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.RawData.ResumeLayout(false);
            this.RawData.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bitmapPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openFirmware;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage RomTabPage;
        private System.Windows.Forms.ListBox filesListBox;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton extractButton;
        private System.Windows.Forms.ToolStripButton packButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton saveRomButton;
        private System.Windows.Forms.PictureBox picturePreview;
        private System.Windows.Forms.TabPage BitmapsPage;
        private System.Windows.Forms.ListBox BitmapsList;
        private System.Windows.Forms.TextBox hexTextBox;
        private System.Windows.Forms.ToolStripButton aboutButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage RawData;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox decodedHexTextBox;
        private System.Windows.Forms.PictureBox bitmapPreview;
    }
}


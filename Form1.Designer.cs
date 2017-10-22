namespace WF_CRYPT
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupCrypt = new System.Windows.Forms.GroupBox();
            this.rbXOR = new System.Windows.Forms.RadioButton();
            this.rbCaesar = new System.Windows.Forms.RadioButton();
            this.groupType = new System.Windows.Forms.GroupBox();
            this.rbDecrypt = new System.Windows.Forms.RadioButton();
            this.rbCrypt = new System.Windows.Forms.RadioButton();
            this.groupKey = new System.Windows.Forms.GroupBox();
            this.rbFile = new System.Windows.Forms.RadioButton();
            this.rbString = new System.Windows.Forms.RadioButton();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelKey = new System.Windows.Forms.Label();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.buttonSource = new System.Windows.Forms.Button();
            this.buttonkey = new System.Windows.Forms.Button();
            this.labelIO = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupCrypt.SuspendLayout();
            this.groupType.SuspendLayout();
            this.groupKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupCrypt
            // 
            this.groupCrypt.Controls.Add(this.rbXOR);
            this.groupCrypt.Controls.Add(this.rbCaesar);
            this.groupCrypt.Location = new System.Drawing.Point(40, 10);
            this.groupCrypt.Name = "groupCrypt";
            this.groupCrypt.Size = new System.Drawing.Size(220, 80);
            this.groupCrypt.TabIndex = 0;
            this.groupCrypt.TabStop = false;
            this.groupCrypt.Text = "Method of crypt";
            // 
            // rbXOR
            // 
            this.rbXOR.AutoSize = true;
            this.rbXOR.Location = new System.Drawing.Point(6, 49);
            this.rbXOR.Name = "rbXOR";
            this.rbXOR.Size = new System.Drawing.Size(48, 17);
            this.rbXOR.TabIndex = 1;
            this.rbXOR.Text = "XOR";
            this.rbXOR.UseVisualStyleBackColor = true;
            this.rbXOR.CheckedChanged += new System.EventHandler(this.rbXOR_CheckedChanged);
            // 
            // rbCaesar
            // 
            this.rbCaesar.AutoSize = true;
            this.rbCaesar.Checked = true;
            this.rbCaesar.Location = new System.Drawing.Point(6, 26);
            this.rbCaesar.Name = "rbCaesar";
            this.rbCaesar.Size = new System.Drawing.Size(58, 17);
            this.rbCaesar.TabIndex = 0;
            this.rbCaesar.TabStop = true;
            this.rbCaesar.Text = "Caesar\r\n";
            this.rbCaesar.UseVisualStyleBackColor = true;
            this.rbCaesar.CheckedChanged += new System.EventHandler(this.rbCaesar_CheckedChanged);
            // 
            // groupType
            // 
            this.groupType.Controls.Add(this.rbDecrypt);
            this.groupType.Controls.Add(this.rbCrypt);
            this.groupType.Location = new System.Drawing.Point(280, 12);
            this.groupType.Name = "groupType";
            this.groupType.Size = new System.Drawing.Size(220, 80);
            this.groupType.TabIndex = 1;
            this.groupType.TabStop = false;
            this.groupType.Text = "Type crypt";
            // 
            // rbDecrypt
            // 
            this.rbDecrypt.AutoSize = true;
            this.rbDecrypt.Location = new System.Drawing.Point(6, 47);
            this.rbDecrypt.Name = "rbDecrypt";
            this.rbDecrypt.Size = new System.Drawing.Size(62, 17);
            this.rbDecrypt.TabIndex = 3;
            this.rbDecrypt.Text = "Decrypt";
            this.rbDecrypt.UseVisualStyleBackColor = true;
            // 
            // rbCrypt
            // 
            this.rbCrypt.AutoSize = true;
            this.rbCrypt.Checked = true;
            this.rbCrypt.Location = new System.Drawing.Point(6, 24);
            this.rbCrypt.Name = "rbCrypt";
            this.rbCrypt.Size = new System.Drawing.Size(49, 17);
            this.rbCrypt.TabIndex = 2;
            this.rbCrypt.TabStop = true;
            this.rbCrypt.Text = "Crypt";
            this.rbCrypt.UseVisualStyleBackColor = true;
            // 
            // groupKey
            // 
            this.groupKey.Controls.Add(this.rbFile);
            this.groupKey.Controls.Add(this.rbString);
            this.groupKey.Location = new System.Drawing.Point(520, 12);
            this.groupKey.Name = "groupKey";
            this.groupKey.Size = new System.Drawing.Size(220, 80);
            this.groupKey.TabIndex = 2;
            this.groupKey.TabStop = false;
            this.groupKey.Text = "Source of key";
            // 
            // rbFile
            // 
            this.rbFile.AutoSize = true;
            this.rbFile.Location = new System.Drawing.Point(6, 47);
            this.rbFile.Name = "rbFile";
            this.rbFile.Size = new System.Drawing.Size(121, 17);
            this.rbFile.TabIndex = 5;
            this.rbFile.Text = "Key from another file";
            this.rbFile.UseVisualStyleBackColor = true;
            this.rbFile.CheckedChanged += new System.EventHandler(this.rbFile_CheckedChanged);
            // 
            // rbString
            // 
            this.rbString.AutoSize = true;
            this.rbString.Checked = true;
            this.rbString.Location = new System.Drawing.Point(6, 24);
            this.rbString.Name = "rbString";
            this.rbString.Size = new System.Drawing.Size(94, 17);
            this.rbString.TabIndex = 4;
            this.rbString.TabStop = true;
            this.rbString.Text = "Key from string";
            this.rbString.UseVisualStyleBackColor = true;
            this.rbString.CheckedChanged += new System.EventHandler(this.rbString_CheckedChanged);
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(3, 134);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(95, 13);
            this.labelFile.TabIndex = 3;
            this.labelFile.Text = "Path to source file:";
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(3, 160);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(79, 13);
            this.labelKey.TabIndex = 4;
            this.labelKey.Text = "String with key:";
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(115, 130);
            this.textBoxSource.MaxLength = 256;
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(609, 20);
            this.textBoxSource.TabIndex = 5;
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(115, 156);
            this.textBoxKey.MaxLength = 256;
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(609, 20);
            this.textBoxKey.TabIndex = 6;
            // 
            // buttonSource
            // 
            this.buttonSource.Location = new System.Drawing.Point(730, 130);
            this.buttonSource.Name = "buttonSource";
            this.buttonSource.Size = new System.Drawing.Size(46, 19);
            this.buttonSource.TabIndex = 7;
            this.buttonSource.Text = "...";
            this.buttonSource.UseVisualStyleBackColor = true;
            this.buttonSource.Click += new System.EventHandler(this.buttonSource_Click);
            // 
            // buttonkey
            // 
            this.buttonkey.Enabled = false;
            this.buttonkey.Location = new System.Drawing.Point(730, 157);
            this.buttonkey.Name = "buttonkey";
            this.buttonkey.Size = new System.Drawing.Size(46, 19);
            this.buttonkey.TabIndex = 8;
            this.buttonkey.Text = "...";
            this.buttonkey.UseVisualStyleBackColor = true;
            this.buttonkey.Click += new System.EventHandler(this.buttonkey_Click);
            // 
            // labelIO
            // 
            this.labelIO.AutoSize = true;
            this.labelIO.Location = new System.Drawing.Point(0, 212);
            this.labelIO.Name = "labelIO";
            this.labelIO.Size = new System.Drawing.Size(90, 13);
            this.labelIO.TabIndex = 9;
            this.labelIO.Text = "Progress of IO file";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(97, 202);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(678, 32);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 10;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(97, 240);
            this.progressBar2.Maximum = 1000;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(678, 32);
            this.progressBar2.Step = 1;
            this.progressBar2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Progress of replace";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 296);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(760, 53);
            this.buttonStart.TabIndex = 13;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelIO);
            this.Controls.Add(this.buttonkey);
            this.Controls.Add(this.buttonSource);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.groupKey);
            this.Controls.Add(this.groupType);
            this.Controls.Add(this.groupCrypt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "C# Crypter by Igor Nebosenko";
            this.groupCrypt.ResumeLayout(false);
            this.groupCrypt.PerformLayout();
            this.groupType.ResumeLayout(false);
            this.groupType.PerformLayout();
            this.groupKey.ResumeLayout(false);
            this.groupKey.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupCrypt;
        private System.Windows.Forms.GroupBox groupType;
        private System.Windows.Forms.GroupBox groupKey;
        private System.Windows.Forms.RadioButton rbXOR;
        private System.Windows.Forms.RadioButton rbCaesar;
        private System.Windows.Forms.RadioButton rbDecrypt;
        private System.Windows.Forms.RadioButton rbCrypt;
        private System.Windows.Forms.RadioButton rbFile;
        private System.Windows.Forms.RadioButton rbString;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Button buttonSource;
        private System.Windows.Forms.Button buttonkey;
        private System.Windows.Forms.Label labelIO;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
    }
}


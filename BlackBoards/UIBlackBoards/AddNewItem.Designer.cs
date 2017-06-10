namespace UIBlackBoards
{
    partial class AddNewItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSize = new System.Windows.Forms.Label();
            this.labelFont = new System.Windows.Forms.Label();
            this.buttonTextBox = new System.Windows.Forms.Button();
            this.buttonPicture = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBoxFont = new System.Windows.Forms.ComboBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.labelText = new System.Windows.Forms.Label();
            this.buttonComeBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(18, 47);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(49, 13);
            this.labelSize.TabIndex = 25;
            this.labelSize.Text = "Tamaño:";
            // 
            // labelFont
            // 
            this.labelFont.AutoSize = true;
            this.labelFont.Location = new System.Drawing.Point(15, 4);
            this.labelFont.Name = "labelFont";
            this.labelFont.Size = new System.Drawing.Size(43, 13);
            this.labelFont.TabIndex = 24;
            this.labelFont.Text = "Fuente:";
            // 
            // buttonTextBox
            // 
            this.buttonTextBox.Location = new System.Drawing.Point(14, 273);
            this.buttonTextBox.Name = "buttonTextBox";
            this.buttonTextBox.Size = new System.Drawing.Size(120, 23);
            this.buttonTextBox.TabIndex = 23;
            this.buttonTextBox.Text = "Crear Cuadro Texto";
            this.buttonTextBox.UseVisualStyleBackColor = true;
            this.buttonTextBox.Click += new System.EventHandler(this.buttonTextBox_Click);
            // 
            // buttonPicture
            // 
            this.buttonPicture.Location = new System.Drawing.Point(14, 244);
            this.buttonPicture.Name = "buttonPicture";
            this.buttonPicture.Size = new System.Drawing.Size(121, 23);
            this.buttonPicture.TabIndex = 22;
            this.buttonPicture.Text = "Crear Foto";
            this.buttonPicture.UseVisualStyleBackColor = true;
            this.buttonPicture.Click += new System.EventHandler(this.buttonPicture_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(38, 130);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(69, 65);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 21;
            this.pictureBox.TabStop = false;
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Location = new System.Drawing.Point(15, 215);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(120, 23);
            this.buttonLoadFile.TabIndex = 20;
            this.buttonLoadFile.Text = "Cargar Archivo";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(73, 45);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(63, 20);
            this.numericUpDown1.TabIndex = 19;
            this.numericUpDown1.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // comboBoxFont
            // 
            this.comboBoxFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFont.FormattingEnabled = true;
            this.comboBoxFont.Location = new System.Drawing.Point(15, 19);
            this.comboBoxFont.Name = "comboBoxFont";
            this.comboBoxFont.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFont.TabIndex = 18;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(56, 88);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(80, 20);
            this.textBox.TabIndex = 27;
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(12, 88);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(34, 13);
            this.labelText.TabIndex = 28;
            this.labelText.Text = "Texto";
            // 
            // buttonComeBack
            // 
            this.buttonComeBack.Location = new System.Drawing.Point(14, 323);
            this.buttonComeBack.Name = "buttonComeBack";
            this.buttonComeBack.Size = new System.Drawing.Size(120, 23);
            this.buttonComeBack.TabIndex = 29;
            this.buttonComeBack.Text = "Volver";
            this.buttonComeBack.UseVisualStyleBackColor = true;
            this.buttonComeBack.Click += new System.EventHandler(this.buttonComeBack_Click);
            // 
            // AddNewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonComeBack);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.labelFont);
            this.Controls.Add(this.buttonTextBox);
            this.Controls.Add(this.buttonPicture);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.buttonLoadFile);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.comboBoxFont);
            this.Name = "AddNewItem";
            this.Size = new System.Drawing.Size(150, 349);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelFont;
        private System.Windows.Forms.Button buttonTextBox;
        private System.Windows.Forms.Button buttonPicture;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox comboBoxFont;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Button buttonComeBack;
    }
}

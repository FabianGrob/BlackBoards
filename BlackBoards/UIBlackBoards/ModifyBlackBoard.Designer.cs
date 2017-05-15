namespace UIBlackBoards
{
    partial class ModifyBlackBoard
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
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.labelWidth = new System.Windows.Forms.Label();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.buttonModifiyBlackBoard = new System.Windows.Forms.Button();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(47, 95);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(180, 20);
            this.textBoxWidth.TabIndex = 34;
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(3, 98);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(38, 13);
            this.labelWidth.TabIndex = 33;
            this.labelWidth.Text = "Ancho";
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(47, 64);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(180, 20);
            this.textBoxHeight.TabIndex = 32;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(3, 64);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(25, 13);
            this.labelHeight.TabIndex = 31;
            this.labelHeight.Text = "Alto";
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(3, 150);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(238, 192);
            this.richTextBoxDescription.TabIndex = 30;
            this.richTextBoxDescription.Text = "";
            // 
            // buttonModifiyBlackBoard
            // 
            this.buttonModifiyBlackBoard.Location = new System.Drawing.Point(6, 348);
            this.buttonModifiyBlackBoard.Name = "buttonModifiyBlackBoard";
            this.buttonModifiyBlackBoard.Size = new System.Drawing.Size(235, 23);
            this.buttonModifiyBlackBoard.TabIndex = 29;
            this.buttonModifiyBlackBoard.Text = "Modificar Pizarron";
            this.buttonModifiyBlackBoard.UseVisualStyleBackColor = true;
            this.buttonModifiyBlackBoard.Click += new System.EventHandler(this.buttonModifiyBlackBoard_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(3, 134);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(63, 13);
            this.labelDescription.TabIndex = 28;
            this.labelDescription.Text = "Descripcion";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(3, 29);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(44, 13);
            this.labelName.TabIndex = 27;
            this.labelName.Text = "Nombre";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(47, 29);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(180, 20);
            this.textBoxName.TabIndex = 26;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(3, 5);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(91, 13);
            this.labelTitle.TabIndex = 25;
            this.labelTitle.Text = "Modificar Pizarron";
            // 
            // ModifyBlackBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.buttonModifiyBlackBoard);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelTitle);
            this.Name = "ModifyBlackBoard";
            this.Size = new System.Drawing.Size(247, 375);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.Button buttonModifiyBlackBoard;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelTitle;
    }
}

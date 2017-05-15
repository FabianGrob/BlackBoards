namespace UIBlackBoards
{
    partial class AddNewBlackBoard
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
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.buttonCreateBlackBoard = new System.Windows.Forms.Button();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.labelWidth = new System.Windows.Forms.Label();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(3, 147);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(238, 192);
            this.richTextBoxDescription.TabIndex = 20;
            this.richTextBoxDescription.Text = "";
            // 
            // buttonCreateBlackBoard
            // 
            this.buttonCreateBlackBoard.Location = new System.Drawing.Point(6, 345);
            this.buttonCreateBlackBoard.Name = "buttonCreateBlackBoard";
            this.buttonCreateBlackBoard.Size = new System.Drawing.Size(235, 23);
            this.buttonCreateBlackBoard.TabIndex = 19;
            this.buttonCreateBlackBoard.Text = "Crear Pizarron";
            this.buttonCreateBlackBoard.UseVisualStyleBackColor = true;
            this.buttonCreateBlackBoard.Click += new System.EventHandler(this.buttonCreateBlackBoard_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(3, 131);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(63, 13);
            this.labelDescription.TabIndex = 18;
            this.labelDescription.Text = "Descripcion";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(3, 26);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(44, 13);
            this.labelName.TabIndex = 17;
            this.labelName.Text = "Nombre";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(47, 26);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(180, 20);
            this.textBoxName.TabIndex = 16;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(3, 2);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(73, 13);
            this.labelTitle.TabIndex = 15;
            this.labelTitle.Text = "Crear Pizarron";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(3, 61);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(25, 13);
            this.labelHeight.TabIndex = 21;
            this.labelHeight.Text = "Alto";
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(47, 61);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(180, 20);
            this.textBoxHeight.TabIndex = 22;
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(3, 95);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(38, 13);
            this.labelWidth.TabIndex = 23;
            this.labelWidth.Text = "Ancho";
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(47, 92);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(180, 20);
            this.textBoxWidth.TabIndex = 24;
            // 
            // AddNewBlackBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.buttonCreateBlackBoard);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelTitle);
            this.Name = "AddNewBlackBoard";
            this.Size = new System.Drawing.Size(244, 372);
            this.Load += new System.EventHandler(this.AddNewBlackBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.Button buttonCreateBlackBoard;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.TextBox textBoxWidth;
    }
}

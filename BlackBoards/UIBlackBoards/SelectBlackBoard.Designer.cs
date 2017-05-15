namespace UIBlackBoards
{
    partial class SelectBlackBoard
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
            this.listBoxBlackBoards = new System.Windows.Forms.ListBox();
            this.buttonRemoveBlackBoard = new System.Windows.Forms.Button();
            this.buttonModifyBlackBoard = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonVisualice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxBlackBoards
            // 
            this.listBoxBlackBoards.FormattingEnabled = true;
            this.listBoxBlackBoards.Location = new System.Drawing.Point(3, 29);
            this.listBoxBlackBoards.Name = "listBoxBlackBoards";
            this.listBoxBlackBoards.Size = new System.Drawing.Size(333, 251);
            this.listBoxBlackBoards.TabIndex = 0;
            this.listBoxBlackBoards.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // buttonRemoveBlackBoard
            // 
            this.buttonRemoveBlackBoard.Location = new System.Drawing.Point(4, 287);
            this.buttonRemoveBlackBoard.Name = "buttonRemoveBlackBoard";
            this.buttonRemoveBlackBoard.Size = new System.Drawing.Size(113, 23);
            this.buttonRemoveBlackBoard.TabIndex = 1;
            this.buttonRemoveBlackBoard.Text = "Eliminar Pizarron";
            this.buttonRemoveBlackBoard.UseVisualStyleBackColor = true;
            this.buttonRemoveBlackBoard.Click += new System.EventHandler(this.buttonRemoveBlackBoard_Click);
            // 
            // buttonModifyBlackBoard
            // 
            this.buttonModifyBlackBoard.Location = new System.Drawing.Point(261, 287);
            this.buttonModifyBlackBoard.Name = "buttonModifyBlackBoard";
            this.buttonModifyBlackBoard.Size = new System.Drawing.Size(75, 23);
            this.buttonModifyBlackBoard.TabIndex = 2;
            this.buttonModifyBlackBoard.Text = "Modificar Pizarron";
            this.buttonModifyBlackBoard.UseVisualStyleBackColor = true;
            this.buttonModifyBlackBoard.Click += new System.EventHandler(this.buttonModifyBlackBoard_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(4, 4);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(56, 13);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Pizarrones";
            // 
            // buttonVisualice
            // 
            this.buttonVisualice.Location = new System.Drawing.Point(134, 287);
            this.buttonVisualice.Name = "buttonVisualice";
            this.buttonVisualice.Size = new System.Drawing.Size(121, 23);
            this.buttonVisualice.TabIndex = 4;
            this.buttonVisualice.Text = "Visualizar Pizarron";
            this.buttonVisualice.UseVisualStyleBackColor = true;
            this.buttonVisualice.Click += new System.EventHandler(this.buttonVisualice_Click);
            // 
            // SelectBlackBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonVisualice);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonModifyBlackBoard);
            this.Controls.Add(this.buttonRemoveBlackBoard);
            this.Controls.Add(this.listBoxBlackBoards);
            this.Name = "SelectBlackBoard";
            this.Size = new System.Drawing.Size(339, 317);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxBlackBoards;
        private System.Windows.Forms.Button buttonRemoveBlackBoard;
        private System.Windows.Forms.Button buttonModifyBlackBoard;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonVisualice;
    }
}

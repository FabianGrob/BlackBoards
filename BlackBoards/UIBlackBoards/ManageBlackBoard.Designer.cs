namespace UIBlackBoards
{
    partial class ManageBlackBoard
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
            this.buttonCreateItem = new System.Windows.Forms.Button();
            this.buttonRemoveItem = new System.Windows.Forms.Button();
            this.buttonManageComment = new System.Windows.Forms.Button();
            this.buttonCleanBlackBoard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCreateItem
            // 
            this.buttonCreateItem.Location = new System.Drawing.Point(12, 19);
            this.buttonCreateItem.Name = "buttonCreateItem";
            this.buttonCreateItem.Size = new System.Drawing.Size(134, 23);
            this.buttonCreateItem.TabIndex = 0;
            this.buttonCreateItem.Text = "Crear Elemento";
            this.buttonCreateItem.UseVisualStyleBackColor = true;
            this.buttonCreateItem.Click += new System.EventHandler(this.buttonCreateItem_Click);
            // 
            // buttonRemoveItem
            // 
            this.buttonRemoveItem.Location = new System.Drawing.Point(12, 48);
            this.buttonRemoveItem.Name = "buttonRemoveItem";
            this.buttonRemoveItem.Size = new System.Drawing.Size(134, 23);
            this.buttonRemoveItem.TabIndex = 2;
            this.buttonRemoveItem.Text = "Eliminar Elemento";
            this.buttonRemoveItem.UseVisualStyleBackColor = true;
            // 
            // buttonManageComment
            // 
            this.buttonManageComment.Location = new System.Drawing.Point(12, 77);
            this.buttonManageComment.Name = "buttonManageComment";
            this.buttonManageComment.Size = new System.Drawing.Size(134, 23);
            this.buttonManageComment.TabIndex = 3;
            this.buttonManageComment.Text = "Gestionar Comentarios";
            this.buttonManageComment.UseVisualStyleBackColor = true;
            this.buttonManageComment.Click += new System.EventHandler(this.buttonManageComment_Click);
            // 
            // buttonCleanBlackBoard
            // 
            this.buttonCleanBlackBoard.Location = new System.Drawing.Point(12, 244);
            this.buttonCleanBlackBoard.Name = "buttonCleanBlackBoard";
            this.buttonCleanBlackBoard.Size = new System.Drawing.Size(134, 23);
            this.buttonCleanBlackBoard.TabIndex = 6;
            this.buttonCleanBlackBoard.Text = "Limpiar Pizarron";
            this.buttonCleanBlackBoard.UseVisualStyleBackColor = true;
            // 
            // ManageBlackBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCleanBlackBoard);
            this.Controls.Add(this.buttonManageComment);
            this.Controls.Add(this.buttonRemoveItem);
            this.Controls.Add(this.buttonCreateItem);
            this.Name = "ManageBlackBoard";
            this.Size = new System.Drawing.Size(162, 297);
            this.Load += new System.EventHandler(this.ManageBlackBoard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateItem;
        private System.Windows.Forms.Button buttonRemoveItem;
        private System.Windows.Forms.Button buttonManageComment;
        private System.Windows.Forms.Button buttonCleanBlackBoard;
    }
}

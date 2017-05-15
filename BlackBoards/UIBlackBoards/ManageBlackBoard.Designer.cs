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
            this.buttonModifyItem = new System.Windows.Forms.Button();
            this.buttonRemoveItem = new System.Windows.Forms.Button();
            this.buttonManageComment = new System.Windows.Forms.Button();
            this.buttonGoBack = new System.Windows.Forms.Button();
            this.buttonRemoveComment = new System.Windows.Forms.Button();
            this.buttonCleanBlackBoard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCreateItem
            // 
            this.buttonCreateItem.Location = new System.Drawing.Point(12, 30);
            this.buttonCreateItem.Name = "buttonCreateItem";
            this.buttonCreateItem.Size = new System.Drawing.Size(134, 23);
            this.buttonCreateItem.TabIndex = 0;
            this.buttonCreateItem.Text = "Crear Elemento";
            this.buttonCreateItem.UseVisualStyleBackColor = true;
            this.buttonCreateItem.Click += new System.EventHandler(this.buttonCreateItem_Click);
            // 
            // buttonModifyItem
            // 
            this.buttonModifyItem.Location = new System.Drawing.Point(12, 59);
            this.buttonModifyItem.Name = "buttonModifyItem";
            this.buttonModifyItem.Size = new System.Drawing.Size(134, 23);
            this.buttonModifyItem.TabIndex = 1;
            this.buttonModifyItem.Text = "Modificar Elemento";
            this.buttonModifyItem.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveItem
            // 
            this.buttonRemoveItem.Location = new System.Drawing.Point(12, 88);
            this.buttonRemoveItem.Name = "buttonRemoveItem";
            this.buttonRemoveItem.Size = new System.Drawing.Size(134, 23);
            this.buttonRemoveItem.TabIndex = 2;
            this.buttonRemoveItem.Text = "Eliminar Elemento";
            this.buttonRemoveItem.UseVisualStyleBackColor = true;
            // 
            // buttonManageComment
            // 
            this.buttonManageComment.Location = new System.Drawing.Point(12, 141);
            this.buttonManageComment.Name = "buttonManageComment";
            this.buttonManageComment.Size = new System.Drawing.Size(134, 23);
            this.buttonManageComment.TabIndex = 3;
            this.buttonManageComment.Text = "Gestionar Comentario";
            this.buttonManageComment.UseVisualStyleBackColor = true;
            // 
            // buttonGoBack
            // 
            this.buttonGoBack.Location = new System.Drawing.Point(12, 257);
            this.buttonGoBack.Name = "buttonGoBack";
            this.buttonGoBack.Size = new System.Drawing.Size(134, 23);
            this.buttonGoBack.TabIndex = 4;
            this.buttonGoBack.Text = "Volver";
            this.buttonGoBack.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveComment
            // 
            this.buttonRemoveComment.Location = new System.Drawing.Point(12, 170);
            this.buttonRemoveComment.Name = "buttonRemoveComment";
            this.buttonRemoveComment.Size = new System.Drawing.Size(134, 23);
            this.buttonRemoveComment.TabIndex = 5;
            this.buttonRemoveComment.Text = "Eliminar Comentario";
            this.buttonRemoveComment.UseVisualStyleBackColor = true;
            // 
            // buttonCleanBlackBoard
            // 
            this.buttonCleanBlackBoard.Location = new System.Drawing.Point(12, 228);
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
            this.Controls.Add(this.buttonRemoveComment);
            this.Controls.Add(this.buttonGoBack);
            this.Controls.Add(this.buttonManageComment);
            this.Controls.Add(this.buttonRemoveItem);
            this.Controls.Add(this.buttonModifyItem);
            this.Controls.Add(this.buttonCreateItem);
            this.Name = "ManageBlackBoard";
            this.Size = new System.Drawing.Size(162, 297);
            this.Load += new System.EventHandler(this.ManageBlackBoard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateItem;
        private System.Windows.Forms.Button buttonModifyItem;
        private System.Windows.Forms.Button buttonRemoveItem;
        private System.Windows.Forms.Button buttonManageComment;
        private System.Windows.Forms.Button buttonGoBack;
        private System.Windows.Forms.Button buttonRemoveComment;
        private System.Windows.Forms.Button buttonCleanBlackBoard;
    }
}

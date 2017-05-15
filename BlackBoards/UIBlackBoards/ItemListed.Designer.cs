namespace UIBlackBoards
{
    partial class ItemListed
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.buttonComment = new System.Windows.Forms.Button();
            this.buttonResolve = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxItems
            // 
            this.listBoxItems.FormattingEnabled = true;
            this.listBoxItems.Location = new System.Drawing.Point(21, 32);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(162, 212);
            this.listBoxItems.TabIndex = 0;
            // 
            // buttonComment
            // 
            this.buttonComment.Location = new System.Drawing.Point(108, 269);
            this.buttonComment.Name = "buttonComment";
            this.buttonComment.Size = new System.Drawing.Size(75, 23);
            this.buttonComment.TabIndex = 1;
            this.buttonComment.Text = "Comentar";
            this.buttonComment.UseVisualStyleBackColor = true;
            this.buttonComment.Click += new System.EventHandler(this.buttonComment_Click);
            // 
            // buttonResolve
            // 
            this.buttonResolve.Location = new System.Drawing.Point(108, 298);
            this.buttonResolve.Name = "buttonResolve";
            this.buttonResolve.Size = new System.Drawing.Size(75, 23);
            this.buttonResolve.TabIndex = 2;
            this.buttonResolve.Text = "Resolver";
            this.buttonResolve.UseVisualStyleBackColor = true;
            this.buttonResolve.Click += new System.EventHandler(this.buttonResolve_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(3, 298);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "Volver";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Elementos del Pizarrón";
            // 
            // ItemListed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonResolve);
            this.Controls.Add(this.buttonComment);
            this.Controls.Add(this.listBoxItems);
            this.Name = "ItemListed";
            this.Size = new System.Drawing.Size(204, 335);
            this.Load += new System.EventHandler(this.ItemListed_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxItems;
        private System.Windows.Forms.Button buttonComment;
        private System.Windows.Forms.Button buttonResolve;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label1;
    }
}

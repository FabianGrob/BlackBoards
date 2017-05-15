namespace UIBlackBoards
{
    partial class UserListForComments
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxAllUsers = new System.Windows.Forms.ListBox();
            this.buttonSelectUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(43, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione un usuario";
            // 
            // listBoxAllUsers
            // 
            this.listBoxAllUsers.FormattingEnabled = true;
            this.listBoxAllUsers.Location = new System.Drawing.Point(43, 38);
            this.listBoxAllUsers.Name = "listBoxAllUsers";
            this.listBoxAllUsers.Size = new System.Drawing.Size(134, 199);
            this.listBoxAllUsers.TabIndex = 4;
            // 
            // buttonSelectUser
            // 
            this.buttonSelectUser.Location = new System.Drawing.Point(46, 272);
            this.buttonSelectUser.Name = "buttonSelectUser";
            this.buttonSelectUser.Size = new System.Drawing.Size(131, 23);
            this.buttonSelectUser.TabIndex = 6;
            this.buttonSelectUser.Text = "Seleccionar";
            this.buttonSelectUser.UseVisualStyleBackColor = true;
            this.buttonSelectUser.Click += new System.EventHandler(this.buttonSelectUser_Click);
            // 
            // UserListForComments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSelectUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxAllUsers);
            this.Name = "UserListForComments";
            this.Size = new System.Drawing.Size(235, 309);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxAllUsers;
        private System.Windows.Forms.Button buttonSelectUser;
    }
}

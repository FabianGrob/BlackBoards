namespace UIBlackBoards
{
    partial class ResolvedCommentsByUser
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
            this.listBoxResolvedComments = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreationDAte = new System.Windows.Forms.Button();
            this.buttonModDate = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.buttonCommentingUser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxResolvedComments
            // 
            this.listBoxResolvedComments.FormattingEnabled = true;
            this.listBoxResolvedComments.Location = new System.Drawing.Point(49, 40);
            this.listBoxResolvedComments.Name = "listBoxResolvedComments";
            this.listBoxResolvedComments.Size = new System.Drawing.Size(324, 225);
            this.listBoxResolvedComments.TabIndex = 0;
            this.listBoxResolvedComments.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // buttonCreationDAte
            // 
            this.buttonCreationDAte.Location = new System.Drawing.Point(14, 338);
            this.buttonCreationDAte.Name = "buttonCreationDAte";
            this.buttonCreationDAte.Size = new System.Drawing.Size(113, 23);
            this.buttonCreationDAte.TabIndex = 2;
            this.buttonCreationDAte.Text = "Fecha creación";
            this.buttonCreationDAte.UseVisualStyleBackColor = true;
            this.buttonCreationDAte.Click += new System.EventHandler(this.buttonCreationDAte_Click);
            // 
            // buttonModDate
            // 
            this.buttonModDate.Location = new System.Drawing.Point(133, 338);
            this.buttonModDate.Name = "buttonModDate";
            this.buttonModDate.Size = new System.Drawing.Size(113, 23);
            this.buttonModDate.TabIndex = 3;
            this.buttonModDate.Text = "Fecha modificación";
            this.buttonModDate.UseVisualStyleBackColor = true;
            this.buttonModDate.Click += new System.EventHandler(this.buttonModDate_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(14, 312);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(232, 20);
            this.dateTimePicker.TabIndex = 4;
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(262, 312);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUsers.TabIndex = 5;
            // 
            // buttonCommentingUser
            // 
            this.buttonCommentingUser.Location = new System.Drawing.Point(262, 338);
            this.buttonCommentingUser.Name = "buttonCommentingUser";
            this.buttonCommentingUser.Size = new System.Drawing.Size(121, 23);
            this.buttonCommentingUser.TabIndex = 6;
            this.buttonCommentingUser.Text = "Usuario Comentador";
            this.buttonCommentingUser.UseVisualStyleBackColor = true;
            this.buttonCommentingUser.Click += new System.EventHandler(this.buttonCommentingUser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filtrar por:";
            // 
            // ResolvedCommentsByUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCommentingUser);
            this.Controls.Add(this.comboBoxUsers);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.buttonModDate);
            this.Controls.Add(this.buttonCreationDAte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxResolvedComments);
            this.Name = "ResolvedCommentsByUser";
            this.Size = new System.Drawing.Size(415, 375);
            this.Load += new System.EventHandler(this.ResolvedCommentsByUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxResolvedComments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCreationDAte;
        private System.Windows.Forms.Button buttonModDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.Button buttonCommentingUser;
        private System.Windows.Forms.Label label2;
    }
}

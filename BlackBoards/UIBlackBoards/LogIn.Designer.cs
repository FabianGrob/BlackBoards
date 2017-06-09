namespace UIBlackBoards
{
    partial class LogIn
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.Start = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxUsers.Location = new System.Drawing.Point(131, 56);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUsers.TabIndex = 0;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(293, 153);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 1;
            this.Start.Text = "Iniciar";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.start_Click);
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(12, 153);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(75, 23);
            this.Back.TabIndex = 2;
            this.Back.Text = "Salir";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.exit_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(131, 83);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(121, 20);
            this.textBoxPassword.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione un usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ingrese su contraseña";
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 186);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.comboBoxUsers);
            this.Name = "LogIn";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


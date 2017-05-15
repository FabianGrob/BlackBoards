namespace UIBlackBoards
{
    partial class ModifyUser
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLastN = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxSndPass = new System.Windows.Forms.TextBox();
            this.textBoxFstPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonModify = new System.Windows.Forms.Button();
            this.buttonGeneratePassword = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Apellio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Repetir contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Email";
            // 
            // textBoxLastN
            // 
            this.textBoxLastN.Location = new System.Drawing.Point(123, 166);
            this.textBoxLastN.Name = "textBoxLastN";
            this.textBoxLastN.Size = new System.Drawing.Size(117, 20);
            this.textBoxLastN.TabIndex = 16;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(123, 60);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(117, 20);
            this.textBoxEmail.TabIndex = 15;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(123, 140);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(117, 20);
            this.textBoxName.TabIndex = 14;
            // 
            // textBoxSndPass
            // 
            this.textBoxSndPass.Location = new System.Drawing.Point(123, 114);
            this.textBoxSndPass.Name = "textBoxSndPass";
            this.textBoxSndPass.Size = new System.Drawing.Size(117, 20);
            this.textBoxSndPass.TabIndex = 13;
            // 
            // textBoxFstPass
            // 
            this.textBoxFstPass.Location = new System.Drawing.Point(123, 88);
            this.textBoxFstPass.Name = "textBoxFstPass";
            this.textBoxFstPass.Size = new System.Drawing.Size(117, 20);
            this.textBoxFstPass.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Modificar usuario";
            // 
            // buttonModify
            // 
            this.buttonModify.Location = new System.Drawing.Point(71, 257);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(127, 23);
            this.buttonModify.TabIndex = 23;
            this.buttonModify.Text = "Modificar";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click_1);
            // 
            // buttonGeneratePassword
            // 
            this.buttonGeneratePassword.Location = new System.Drawing.Point(71, 228);
            this.buttonGeneratePassword.Name = "buttonGeneratePassword";
            this.buttonGeneratePassword.Size = new System.Drawing.Size(127, 23);
            this.buttonGeneratePassword.TabIndex = 24;
            this.buttonGeneratePassword.Text = "Generar contraseña";
            this.buttonGeneratePassword.UseVisualStyleBackColor = true;
            this.buttonGeneratePassword.Click += new System.EventHandler(this.buttonGeneratePassword_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(40, 202);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 25;
            // 
            // ModifyUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.buttonGeneratePassword);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLastN);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxSndPass);
            this.Controls.Add(this.textBoxFstPass);
            this.Name = "ModifyUser";
            this.Size = new System.Drawing.Size(260, 297);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLastN;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxSndPass;
        private System.Windows.Forms.TextBox textBoxFstPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Button buttonGeneratePassword;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}

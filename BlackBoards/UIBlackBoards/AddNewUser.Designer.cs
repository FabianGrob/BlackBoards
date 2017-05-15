namespace UIBlackBoards
{
    partial class AddNewUser
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
            this.CreateUser = new System.Windows.Forms.Button();
            this.checkBoxAdmin = new System.Windows.Forms.CheckBox();
            this.textBoxFstPass = new System.Windows.Forms.TextBox();
            this.textBoxSndPass = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxLastN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // CreateUser
            // 
            this.CreateUser.Location = new System.Drawing.Point(79, 375);
            this.CreateUser.Name = "CreateUser";
            this.CreateUser.Size = new System.Drawing.Size(149, 23);
            this.CreateUser.TabIndex = 0;
            this.CreateUser.Text = "Crear";
            this.CreateUser.UseVisualStyleBackColor = true;
            this.CreateUser.Click += new System.EventHandler(this.CreateUser_Click);
            // 
            // checkBoxAdmin
            // 
            this.checkBoxAdmin.AutoSize = true;
            this.checkBoxAdmin.Location = new System.Drawing.Point(128, 267);
            this.checkBoxAdmin.Name = "checkBoxAdmin";
            this.checkBoxAdmin.Size = new System.Drawing.Size(103, 17);
            this.checkBoxAdmin.TabIndex = 1;
            this.checkBoxAdmin.Text = "es Administrador";
            this.checkBoxAdmin.UseVisualStyleBackColor = true;
            // 
            // textBoxFstPass
            // 
            this.textBoxFstPass.Location = new System.Drawing.Point(128, 96);
            this.textBoxFstPass.Name = "textBoxFstPass";
            this.textBoxFstPass.Size = new System.Drawing.Size(117, 20);
            this.textBoxFstPass.TabIndex = 2;
            // 
            // textBoxSndPass
            // 
            this.textBoxSndPass.Location = new System.Drawing.Point(128, 122);
            this.textBoxSndPass.Name = "textBoxSndPass";
            this.textBoxSndPass.Size = new System.Drawing.Size(117, 20);
            this.textBoxSndPass.TabIndex = 3;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(128, 148);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(117, 20);
            this.textBoxName.TabIndex = 4;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(128, 68);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(117, 20);
            this.textBoxEmail.TabIndex = 5;
            // 
            // textBoxLastN
            // 
            this.textBoxLastN.Location = new System.Drawing.Point(128, 174);
            this.textBoxLastN.Name = "textBoxLastN";
            this.textBoxLastN.Size = new System.Drawing.Size(117, 20);
            this.textBoxLastN.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ingresar email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ingresar contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Repetir contraseña";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ingresar nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ingresar apellio";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(108, 16);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(71, 13);
            this.Title.TabIndex = 13;
            this.Title.Text = "Crear Usuario";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(24, 211);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(221, 20);
            this.dateTimePicker.TabIndex = 14;
            // 
            // AddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.Title);
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
            this.Controls.Add(this.checkBoxAdmin);
            this.Controls.Add(this.CreateUser);
            this.Name = "AddNewUser";
            this.Size = new System.Drawing.Size(312, 410);
            this.Load += new System.EventHandler(this.AddNewUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateUser;
        private System.Windows.Forms.CheckBox checkBoxAdmin;
        private System.Windows.Forms.TextBox textBoxFstPass;
        private System.Windows.Forms.TextBox textBoxSndPass;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxLastN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}

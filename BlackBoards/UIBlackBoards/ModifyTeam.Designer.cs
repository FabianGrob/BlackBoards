namespace UIBlackBoards
{
    partial class ModifyTeam
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
            this.textBoxCantMaxUsers = new System.Windows.Forms.TextBox();
            this.labelCantMaxUsers = new System.Windows.Forms.Label();
            this.buttonModifyTeam = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.labelSelectedUsers = new System.Windows.Forms.Label();
            this.labelAllUsers = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.listBoxSelectedUsers = new System.Windows.Forms.ListBox();
            this.listBoxAllUsers = new System.Windows.Forms.ListBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonDeleteUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(15, 304);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(227, 72);
            this.richTextBoxDescription.TabIndex = 27;
            this.richTextBoxDescription.Text = "";
            // 
            // textBoxCantMaxUsers
            // 
            this.textBoxCantMaxUsers.Location = new System.Drawing.Point(156, 64);
            this.textBoxCantMaxUsers.Name = "textBoxCantMaxUsers";
            this.textBoxCantMaxUsers.Size = new System.Drawing.Size(86, 20);
            this.textBoxCantMaxUsers.TabIndex = 26;
            // 
            // labelCantMaxUsers
            // 
            this.labelCantMaxUsers.AutoSize = true;
            this.labelCantMaxUsers.Location = new System.Drawing.Point(18, 64);
            this.labelCantMaxUsers.Name = "labelCantMaxUsers";
            this.labelCantMaxUsers.Size = new System.Drawing.Size(132, 13);
            this.labelCantMaxUsers.TabIndex = 25;
            this.labelCantMaxUsers.Text = "Cantidad Maxima Usuarios";
            // 
            // buttonModifyTeam
            // 
            this.buttonModifyTeam.Location = new System.Drawing.Point(21, 382);
            this.buttonModifyTeam.Name = "buttonModifyTeam";
            this.buttonModifyTeam.Size = new System.Drawing.Size(221, 23);
            this.buttonModifyTeam.TabIndex = 24;
            this.buttonModifyTeam.Text = "Modificar Equipo";
            this.buttonModifyTeam.UseVisualStyleBackColor = true;
            this.buttonModifyTeam.Click += new System.EventHandler(this.buttonModifyTeam_Click);
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(167, 168);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(75, 23);
            this.buttonAddUser.TabIndex = 23;
            this.buttonAddUser.Text = "Añadir";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // labelSelectedUsers
            // 
            this.labelSelectedUsers.AutoSize = true;
            this.labelSelectedUsers.Location = new System.Drawing.Point(21, 178);
            this.labelSelectedUsers.Name = "labelSelectedUsers";
            this.labelSelectedUsers.Size = new System.Drawing.Size(121, 13);
            this.labelSelectedUsers.TabIndex = 22;
            this.labelSelectedUsers.Text = "Usuarios Seleccionados";
            // 
            // labelAllUsers
            // 
            this.labelAllUsers.AutoSize = true;
            this.labelAllUsers.Location = new System.Drawing.Point(21, 90);
            this.labelAllUsers.Name = "labelAllUsers";
            this.labelAllUsers.Size = new System.Drawing.Size(95, 13);
            this.labelAllUsers.TabIndex = 21;
            this.labelAllUsers.Text = "Todos los usuarios";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(21, 288);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(63, 13);
            this.labelDescription.TabIndex = 20;
            this.labelDescription.Text = "Descripcion";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(18, 37);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(44, 13);
            this.labelName.TabIndex = 19;
            this.labelName.Text = "Nombre";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(62, 37);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(180, 20);
            this.textBoxName.TabIndex = 18;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // listBoxSelectedUsers
            // 
            this.listBoxSelectedUsers.FormattingEnabled = true;
            this.listBoxSelectedUsers.Location = new System.Drawing.Point(21, 194);
            this.listBoxSelectedUsers.Name = "listBoxSelectedUsers";
            this.listBoxSelectedUsers.Size = new System.Drawing.Size(221, 56);
            this.listBoxSelectedUsers.TabIndex = 17;
            // 
            // listBoxAllUsers
            // 
            this.listBoxAllUsers.FormattingEnabled = true;
            this.listBoxAllUsers.Location = new System.Drawing.Point(21, 106);
            this.listBoxAllUsers.Name = "listBoxAllUsers";
            this.listBoxAllUsers.Size = new System.Drawing.Size(221, 56);
            this.listBoxAllUsers.TabIndex = 16;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(18, 13);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(86, 13);
            this.labelTitle.TabIndex = 15;
            this.labelTitle.Text = "Modificar Equipo";
            // 
            // buttonDeleteUser
            // 
            this.buttonDeleteUser.Location = new System.Drawing.Point(167, 257);
            this.buttonDeleteUser.Name = "buttonDeleteUser";
            this.buttonDeleteUser.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteUser.TabIndex = 28;
            this.buttonDeleteUser.Text = "Eliminar";
            this.buttonDeleteUser.UseVisualStyleBackColor = true;
            this.buttonDeleteUser.Click += new System.EventHandler(this.buttonDeleteUser_Click);
            // 
            // ModifyTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDeleteUser);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.textBoxCantMaxUsers);
            this.Controls.Add(this.labelCantMaxUsers);
            this.Controls.Add(this.buttonModifyTeam);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.labelSelectedUsers);
            this.Controls.Add(this.labelAllUsers);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.listBoxSelectedUsers);
            this.Controls.Add(this.listBoxAllUsers);
            this.Controls.Add(this.labelTitle);
            this.Name = "ModifyTeam";
            this.Size = new System.Drawing.Size(256, 408);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.TextBox textBoxCantMaxUsers;
        private System.Windows.Forms.Label labelCantMaxUsers;
        private System.Windows.Forms.Button buttonModifyTeam;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Label labelSelectedUsers;
        private System.Windows.Forms.Label labelAllUsers;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ListBox listBoxSelectedUsers;
        private System.Windows.Forms.ListBox listBoxAllUsers;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonDeleteUser;
    }
}

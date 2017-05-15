namespace UIBlackBoards
{
    partial class AddNewTeam
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.listBoxAllUsers = new System.Windows.Forms.ListBox();
            this.listBoxSelectedUsers = new System.Windows.Forms.ListBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelAllUsers = new System.Windows.Forms.Label();
            this.labelSelectedUsers = new System.Windows.Forms.Label();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.buttonCreateTeam = new System.Windows.Forms.Button();
            this.labelCantMaxUsers = new System.Windows.Forms.Label();
            this.textBoxCantMaxUsers = new System.Windows.Forms.TextBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(20, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(68, 13);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Crear Equipo";
            this.labelTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBoxAllUsers
            // 
            this.listBoxAllUsers.FormattingEnabled = true;
            this.listBoxAllUsers.Location = new System.Drawing.Point(23, 102);
            this.listBoxAllUsers.Name = "listBoxAllUsers";
            this.listBoxAllUsers.Size = new System.Drawing.Size(221, 56);
            this.listBoxAllUsers.TabIndex = 1;
            this.listBoxAllUsers.SelectedIndexChanged += new System.EventHandler(this.listBoxAllUsers_SelectedIndexChanged);
            // 
            // listBoxSelectedUsers
            // 
            this.listBoxSelectedUsers.FormattingEnabled = true;
            this.listBoxSelectedUsers.Location = new System.Drawing.Point(23, 190);
            this.listBoxSelectedUsers.Name = "listBoxSelectedUsers";
            this.listBoxSelectedUsers.Size = new System.Drawing.Size(221, 56);
            this.listBoxSelectedUsers.TabIndex = 2;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(64, 33);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(180, 20);
            this.textBoxName.TabIndex = 3;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(20, 33);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(44, 13);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Nombre";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(23, 255);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(63, 13);
            this.labelDescription.TabIndex = 6;
            this.labelDescription.Text = "Descripcion";
            // 
            // labelAllUsers
            // 
            this.labelAllUsers.AutoSize = true;
            this.labelAllUsers.Location = new System.Drawing.Point(23, 86);
            this.labelAllUsers.Name = "labelAllUsers";
            this.labelAllUsers.Size = new System.Drawing.Size(95, 13);
            this.labelAllUsers.TabIndex = 7;
            this.labelAllUsers.Text = "Todos los usuarios";
            // 
            // labelSelectedUsers
            // 
            this.labelSelectedUsers.AutoSize = true;
            this.labelSelectedUsers.Location = new System.Drawing.Point(23, 174);
            this.labelSelectedUsers.Name = "labelSelectedUsers";
            this.labelSelectedUsers.Size = new System.Drawing.Size(121, 13);
            this.labelSelectedUsers.TabIndex = 8;
            this.labelSelectedUsers.Text = "Usuarios Seleccionados";
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(169, 164);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(75, 23);
            this.buttonAddUser.TabIndex = 9;
            this.buttonAddUser.Text = "Añadir";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // buttonCreateTeam
            // 
            this.buttonCreateTeam.Location = new System.Drawing.Point(23, 352);
            this.buttonCreateTeam.Name = "buttonCreateTeam";
            this.buttonCreateTeam.Size = new System.Drawing.Size(221, 23);
            this.buttonCreateTeam.TabIndex = 10;
            this.buttonCreateTeam.Text = "Crear Equipo";
            this.buttonCreateTeam.UseVisualStyleBackColor = true;
            this.buttonCreateTeam.Click += new System.EventHandler(this.buttonCreateTeam_Click);
            // 
            // labelCantMaxUsers
            // 
            this.labelCantMaxUsers.AutoSize = true;
            this.labelCantMaxUsers.Location = new System.Drawing.Point(20, 60);
            this.labelCantMaxUsers.Name = "labelCantMaxUsers";
            this.labelCantMaxUsers.Size = new System.Drawing.Size(132, 13);
            this.labelCantMaxUsers.TabIndex = 12;
            this.labelCantMaxUsers.Text = "Cantidad Maxima Usuarios";
            this.labelCantMaxUsers.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBoxCantMaxUsers
            // 
            this.textBoxCantMaxUsers.Location = new System.Drawing.Point(158, 60);
            this.textBoxCantMaxUsers.Name = "textBoxCantMaxUsers";
            this.textBoxCantMaxUsers.Size = new System.Drawing.Size(86, 20);
            this.textBoxCantMaxUsers.TabIndex = 13;
            this.textBoxCantMaxUsers.TextChanged += new System.EventHandler(this.textBoxCantMaxUsers_TextChanged);
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(17, 274);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(227, 72);
            this.richTextBoxDescription.TabIndex = 14;
            this.richTextBoxDescription.Text = "";
            // 
            // AddNewTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.textBoxCantMaxUsers);
            this.Controls.Add(this.labelCantMaxUsers);
            this.Controls.Add(this.buttonCreateTeam);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.labelSelectedUsers);
            this.Controls.Add(this.labelAllUsers);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.listBoxSelectedUsers);
            this.Controls.Add(this.listBoxAllUsers);
            this.Controls.Add(this.labelTitle);
            this.Name = "AddNewTeam";
            this.Size = new System.Drawing.Size(271, 378);
            this.Load += new System.EventHandler(this.AddNewTeam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ListBox listBoxAllUsers;
        private System.Windows.Forms.ListBox listBoxSelectedUsers;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelAllUsers;
        private System.Windows.Forms.Label labelSelectedUsers;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonCreateTeam;
        private System.Windows.Forms.Label labelCantMaxUsers;
        private System.Windows.Forms.TextBox textBoxCantMaxUsers;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
    }
}

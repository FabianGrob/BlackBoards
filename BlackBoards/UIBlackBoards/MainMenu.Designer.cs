namespace UIBlackBoards
{
    partial class MainMenu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCreateUser = new System.Windows.Forms.Button();
            this.buttonModifyUser = new System.Windows.Forms.Button();
            this.buttonCreateTeam = new System.Windows.Forms.Button();
            this.buttonModifyTeam = new System.Windows.Forms.Button();
            this.buttonManageBlackBoards = new System.Windows.Forms.Button();
            this.buttonBlackBoardsPerTeam = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.buttonCommentsInform = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCreateUser
            // 
            this.buttonCreateUser.Enabled = false;
            this.buttonCreateUser.Location = new System.Drawing.Point(23, 78);
            this.buttonCreateUser.Name = "buttonCreateUser";
            this.buttonCreateUser.Size = new System.Drawing.Size(112, 23);
            this.buttonCreateUser.TabIndex = 0;
            this.buttonCreateUser.Text = "Crear Usuario";
            this.buttonCreateUser.UseVisualStyleBackColor = true;
            this.buttonCreateUser.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonModifyUser
            // 
            this.buttonModifyUser.Enabled = false;
            this.buttonModifyUser.Location = new System.Drawing.Point(23, 107);
            this.buttonModifyUser.Name = "buttonModifyUser";
            this.buttonModifyUser.Size = new System.Drawing.Size(112, 23);
            this.buttonModifyUser.TabIndex = 1;
            this.buttonModifyUser.Text = "Modificar Usuario";
            this.buttonModifyUser.UseVisualStyleBackColor = true;
            this.buttonModifyUser.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonCreateTeam
            // 
            this.buttonCreateTeam.Enabled = false;
            this.buttonCreateTeam.Location = new System.Drawing.Point(23, 136);
            this.buttonCreateTeam.Name = "buttonCreateTeam";
            this.buttonCreateTeam.Size = new System.Drawing.Size(112, 23);
            this.buttonCreateTeam.TabIndex = 2;
            this.buttonCreateTeam.Text = "Crear Equipo";
            this.buttonCreateTeam.UseVisualStyleBackColor = true;
            this.buttonCreateTeam.Click += new System.EventHandler(this.buttonCreateTeam_Click);
            // 
            // buttonModifyTeam
            // 
            this.buttonModifyTeam.Enabled = false;
            this.buttonModifyTeam.Location = new System.Drawing.Point(23, 165);
            this.buttonModifyTeam.Name = "buttonModifyTeam";
            this.buttonModifyTeam.Size = new System.Drawing.Size(112, 23);
            this.buttonModifyTeam.TabIndex = 3;
            this.buttonModifyTeam.Text = "Modificar Equipo";
            this.buttonModifyTeam.UseVisualStyleBackColor = true;
            this.buttonModifyTeam.Click += new System.EventHandler(this.buttonModifyTeam_Click);
            // 
            // buttonManageBlackBoards
            // 
            this.buttonManageBlackBoards.Location = new System.Drawing.Point(23, 194);
            this.buttonManageBlackBoards.Name = "buttonManageBlackBoards";
            this.buttonManageBlackBoards.Size = new System.Drawing.Size(112, 23);
            this.buttonManageBlackBoards.TabIndex = 4;
            this.buttonManageBlackBoards.Text = "Gestión Pizarrones";
            this.buttonManageBlackBoards.UseVisualStyleBackColor = true;
            this.buttonManageBlackBoards.Click += new System.EventHandler(this.buttonCreatePizarron_Click);
            // 
            // buttonBlackBoardsPerTeam
            // 
            this.buttonBlackBoardsPerTeam.Location = new System.Drawing.Point(23, 298);
            this.buttonBlackBoardsPerTeam.Name = "buttonBlackBoardsPerTeam";
            this.buttonBlackBoardsPerTeam.Size = new System.Drawing.Size(112, 23);
            this.buttonBlackBoardsPerTeam.TabIndex = 5;
            this.buttonBlackBoardsPerTeam.Text = "Informe Pizarrones";
            this.buttonBlackBoardsPerTeam.UseVisualStyleBackColor = true;
            this.buttonBlackBoardsPerTeam.Click += new System.EventHandler(this.buttonBlackBoardsPerTeam_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(23, 327);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(112, 23);
            this.buttonLogOut.TabIndex = 6;
            this.buttonLogOut.Text = "Cerrar sesión";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Location = new System.Drawing.Point(164, 12);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(450, 449);
            this.panelContainer.TabIndex = 7;
            this.panelContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // buttonCommentsInform
            // 
            this.buttonCommentsInform.Location = new System.Drawing.Point(23, 269);
            this.buttonCommentsInform.Name = "buttonCommentsInform";
            this.buttonCommentsInform.Size = new System.Drawing.Size(112, 23);
            this.buttonCommentsInform.TabIndex = 8;
            this.buttonCommentsInform.Text = "Informe Comentarios";
            this.buttonCommentsInform.UseVisualStyleBackColor = true;
            this.buttonCommentsInform.Click += new System.EventHandler(this.buttonCommentsInform_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 473);
            this.Controls.Add(this.buttonCommentsInform);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.buttonBlackBoardsPerTeam);
            this.Controls.Add(this.buttonManageBlackBoards);
            this.Controls.Add(this.buttonModifyTeam);
            this.Controls.Add(this.buttonCreateTeam);
            this.Controls.Add(this.buttonModifyUser);
            this.Controls.Add(this.buttonCreateUser);
            this.Name = "MainMenu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateUser;
        private System.Windows.Forms.Button buttonModifyUser;
        private System.Windows.Forms.Button buttonCreateTeam;
        private System.Windows.Forms.Button buttonModifyTeam;
        private System.Windows.Forms.Button buttonManageBlackBoards;
        private System.Windows.Forms.Button buttonBlackBoardsPerTeam;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button buttonCommentsInform;
    }
}
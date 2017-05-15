namespace UIBlackBoards
{
    partial class BlackBoardsPerTeam
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.listBoxTeams = new System.Windows.Forms.ListBox();
            this.buttonChooseTeam = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(3, 16);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(48, 13);
            this.labelTitle.TabIndex = 6;
            this.labelTitle.Text = "Equipos:";
            // 
            // listBoxTeams
            // 
            this.listBoxTeams.FormattingEnabled = true;
            this.listBoxTeams.Location = new System.Drawing.Point(3, 37);
            this.listBoxTeams.Name = "listBoxTeams";
            this.listBoxTeams.Size = new System.Drawing.Size(236, 225);
            this.listBoxTeams.TabIndex = 5;
            // 
            // buttonChooseTeam
            // 
            this.buttonChooseTeam.Location = new System.Drawing.Point(68, 284);
            this.buttonChooseTeam.Name = "buttonChooseTeam";
            this.buttonChooseTeam.Size = new System.Drawing.Size(109, 23);
            this.buttonChooseTeam.TabIndex = 7;
            this.buttonChooseTeam.Text = "Seleccionar";
            this.buttonChooseTeam.UseVisualStyleBackColor = true;
            this.buttonChooseTeam.Click += new System.EventHandler(this.buttonChooseTeam_Click);
            // 
            // BlackBoardsPerTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonChooseTeam);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.listBoxTeams);
            this.Name = "BlackBoardsPerTeam";
            this.Size = new System.Drawing.Size(249, 331);
            this.Load += new System.EventHandler(this.BlackBoardsPerTeam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ListBox listBoxTeams;
        private System.Windows.Forms.Button buttonChooseTeam;
    }
}

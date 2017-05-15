namespace UIBlackBoards
{
    partial class TeamListByUser
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
            this.listBoxTeams = new System.Windows.Forms.ListBox();
            this.buttonCreateBlackBoard = new System.Windows.Forms.Button();
            this.buttonModifyBlackBoards = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(14, 21);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(48, 13);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = "Equipos:";
            // 
            // listBoxTeams
            // 
            this.listBoxTeams.FormattingEnabled = true;
            this.listBoxTeams.Location = new System.Drawing.Point(14, 42);
            this.listBoxTeams.Name = "listBoxTeams";
            this.listBoxTeams.Size = new System.Drawing.Size(236, 225);
            this.listBoxTeams.TabIndex = 7;
            // 
            // buttonCreateBlackBoard
            // 
            this.buttonCreateBlackBoard.Location = new System.Drawing.Point(256, 42);
            this.buttonCreateBlackBoard.Name = "buttonCreateBlackBoard";
            this.buttonCreateBlackBoard.Size = new System.Drawing.Size(136, 23);
            this.buttonCreateBlackBoard.TabIndex = 5;
            this.buttonCreateBlackBoard.Text = "Crear Pizarron";
            this.buttonCreateBlackBoard.UseVisualStyleBackColor = true;
            this.buttonCreateBlackBoard.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonModifyBlackBoards
            // 
            this.buttonModifyBlackBoards.Location = new System.Drawing.Point(257, 72);
            this.buttonModifyBlackBoards.Name = "buttonModifyBlackBoards";
            this.buttonModifyBlackBoards.Size = new System.Drawing.Size(135, 23);
            this.buttonModifyBlackBoards.TabIndex = 9;
            this.buttonModifyBlackBoards.Text = "Modificar Pizarrones";
            this.buttonModifyBlackBoards.UseVisualStyleBackColor = true;
            this.buttonModifyBlackBoards.Click += new System.EventHandler(this.buttonModifyBlackBoards_Click);
            // 
            // TeamListByUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonModifyBlackBoards);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.listBoxTeams);
            this.Controls.Add(this.buttonCreateBlackBoard);
            this.Name = "TeamListByUser";
            this.Size = new System.Drawing.Size(398, 317);
            this.Load += new System.EventHandler(this.TeamListByUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ListBox listBoxTeams;
        private System.Windows.Forms.Button buttonCreateBlackBoard;
        private System.Windows.Forms.Button buttonModifyBlackBoards;
    }
}

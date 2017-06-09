namespace UIBlackBoards
{
    partial class VisualizeBlackBoard
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDiscard = new System.Windows.Forms.Button();
            this.buttonCapture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(84, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDiscard
            // 
            this.buttonDiscard.Location = new System.Drawing.Point(3, 3);
            this.buttonDiscard.Name = "buttonDiscard";
            this.buttonDiscard.Size = new System.Drawing.Size(75, 23);
            this.buttonDiscard.TabIndex = 2;
            this.buttonDiscard.Text = "Descartar";
            this.buttonDiscard.UseVisualStyleBackColor = true;
            this.buttonDiscard.Click += new System.EventHandler(this.buttonDiscard_Click);
            // 
            // buttonCapture
            // 
            this.buttonCapture.Location = new System.Drawing.Point(166, 2);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(116, 23);
            this.buttonCapture.TabIndex = 3;
            this.buttonCapture.Text = "Tomar Captura";
            this.buttonCapture.UseVisualStyleBackColor = true;
            this.buttonCapture.Click += new System.EventHandler(this.button1_Click);
            // 
            // VisualizeBlackBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCapture);
            this.Controls.Add(this.buttonDiscard);
            this.Controls.Add(this.buttonSave);
            this.Name = "VisualizeBlackBoard";
            this.Size = new System.Drawing.Size(697, 484);
            
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDiscard;
        private System.Windows.Forms.Button buttonCapture;
    }
}

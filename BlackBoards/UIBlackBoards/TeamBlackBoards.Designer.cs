namespace UIBlackBoards
{
    partial class TeamBlackBoards
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
            this.listBoxBoards = new System.Windows.Forms.ListBox();
            this.buttonShowAll = new System.Windows.Forms.Button();
            this.buttonfilter = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxBoards
            // 
            this.listBoxBoards.FormattingEnabled = true;
            this.listBoxBoards.Location = new System.Drawing.Point(34, 23);
            this.listBoxBoards.Name = "listBoxBoards";
            this.listBoxBoards.Size = new System.Drawing.Size(335, 212);
            this.listBoxBoards.TabIndex = 0;
            // 
            // buttonShowAll
            // 
            this.buttonShowAll.Location = new System.Drawing.Point(21, 268);
            this.buttonShowAll.Name = "buttonShowAll";
            this.buttonShowAll.Size = new System.Drawing.Size(171, 23);
            this.buttonShowAll.TabIndex = 1;
            this.buttonShowAll.Text = "Mostrar todas las fechas";
            this.buttonShowAll.UseVisualStyleBackColor = true;
            this.buttonShowAll.Click += new System.EventHandler(this.buttonShowAll_Click);
            // 
            // buttonfilter
            // 
            this.buttonfilter.Location = new System.Drawing.Point(198, 268);
            this.buttonfilter.Name = "buttonfilter";
            this.buttonfilter.Size = new System.Drawing.Size(171, 23);
            this.buttonfilter.TabIndex = 2;
            this.buttonfilter.Text = "Filtrar por fecha seleccionada";
            this.buttonfilter.UseVisualStyleBackColor = true;
            this.buttonfilter.Click += new System.EventHandler(this.buttonfilter_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(161, 241);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(208, 20);
            this.dateTimePicker.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TeamBlackBoards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.buttonfilter);
            this.Controls.Add(this.buttonShowAll);
            this.Controls.Add(this.listBoxBoards);
            this.Name = "TeamBlackBoards";
            this.Size = new System.Drawing.Size(395, 345);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxBoards;
        private System.Windows.Forms.Button buttonShowAll;
        private System.Windows.Forms.Button buttonfilter;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button button1;
    }
}

namespace Binapsis.Presentacion.Editores.Win
{
    partial class EditorBase
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
            this.etiqueta = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // etiqueta
            // 
            this.etiqueta.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.etiqueta.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.etiqueta.Dock = System.Windows.Forms.DockStyle.Left;
            this.etiqueta.LineColor = System.Drawing.Color.DarkGoldenrod;
            this.etiqueta.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.etiqueta.LineVisible = true;
            this.etiqueta.Location = new System.Drawing.Point(0, 0);
            this.etiqueta.Name = "etiqueta";
            this.etiqueta.ShowLineShadow = false;
            this.etiqueta.Size = new System.Drawing.Size(80, 24);
            this.etiqueta.TabIndex = 0;
            // 
            // EditorBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.etiqueta);
            this.Name = "EditorBase";
            this.Size = new System.Drawing.Size(160, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl etiqueta;
    }
}

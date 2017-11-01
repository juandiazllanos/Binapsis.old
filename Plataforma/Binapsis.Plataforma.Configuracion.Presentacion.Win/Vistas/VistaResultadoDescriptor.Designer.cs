namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Vistas
{
    partial class VistaResultadoDescriptor
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
            this.Nombre = new Binapsis.Presentacion.Editores.Win.EditorTexto();
            this.Tipo = new Binapsis.Presentacion.Editores.Win.EditorTexto();
            this.Tabla = new Binapsis.Presentacion.Editores.Win.EditorTexto();
            this.Columna = new Binapsis.Presentacion.Editores.Win.EditorTexto();
            this.SuspendLayout();
            // 
            // Nombre
            // 
            this.Nombre.Etiqueta.Texto = "Nombre";
            this.Nombre.Location = new System.Drawing.Point(19, 20);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(282, 20);
            this.Nombre.TabIndex = 0;
            // 
            // Tipo
            // 
            this.Tipo.Etiqueta.Texto = "Tipo";
            this.Tipo.Location = new System.Drawing.Point(19, 46);
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(282, 20);
            this.Tipo.TabIndex = 1;
            // 
            // Tabla
            // 
            this.Tabla.Etiqueta.Texto = "Tabla";
            this.Tabla.Location = new System.Drawing.Point(19, 81);
            this.Tabla.Name = "Tabla";
            this.Tabla.Size = new System.Drawing.Size(282, 20);
            this.Tabla.TabIndex = 2;
            // 
            // Columna
            // 
            this.Columna.Etiqueta.Texto = "Columna";
            this.Columna.Location = new System.Drawing.Point(19, 107);
            this.Columna.Name = "Columna";
            this.Columna.Size = new System.Drawing.Size(282, 20);
            this.Columna.TabIndex = 3;
            // 
            // VistaResultadoDescriptor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Columna);
            this.Controls.Add(this.Tabla);
            this.Controls.Add(this.Tipo);
            this.Controls.Add(this.Nombre);
            this.Name = "VistaResultadoDescriptor";
            this.Size = new System.Drawing.Size(324, 156);
            this.ResumeLayout(false);

        }

        #endregion

        private Binapsis.Presentacion.Editores.Win.EditorTexto Nombre;
        private Binapsis.Presentacion.Editores.Win.EditorTexto Tipo;
        private Binapsis.Presentacion.Editores.Win.EditorTexto Tabla;
        private Binapsis.Presentacion.Editores.Win.EditorTexto Columna;
    }
}

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Vistas
{
    partial class VistaRelacion
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
            this.TablaPrincipal = new Binapsis.Presentacion.Editores.Win.EditorTexto();
            this.ColumnaPrincipal = new Binapsis.Presentacion.Editores.Win.EditorTexto();
            this.TablaSecundaria = new Binapsis.Presentacion.Editores.Win.EditorTexto();
            this.ColumnaSecundaria = new Binapsis.Presentacion.Editores.Win.EditorTexto();
            this.Tipo = new Binapsis.Presentacion.Editores.Win.EditorTexto();
            this.Propiedad = new Binapsis.Presentacion.Editores.Win.EditorTexto();
            this.SuspendLayout();
            // 
            // TablaPrincipal
            // 
            this.TablaPrincipal.Etiqueta.Ancho = 90;
            this.TablaPrincipal.Etiqueta.Texto = "Tabla principal";
            this.TablaPrincipal.Location = new System.Drawing.Point(31, 93);
            this.TablaPrincipal.Name = "TablaPrincipal";
            this.TablaPrincipal.Size = new System.Drawing.Size(342, 20);
            this.TablaPrincipal.TabIndex = 2;
            // 
            // ColumnaPrincipal
            // 
            this.ColumnaPrincipal.Etiqueta.Ancho = 90;
            this.ColumnaPrincipal.Etiqueta.Texto = "Columna principal";
            this.ColumnaPrincipal.Location = new System.Drawing.Point(31, 119);
            this.ColumnaPrincipal.Name = "ColumnaPrincipal";
            this.ColumnaPrincipal.Size = new System.Drawing.Size(342, 20);
            this.ColumnaPrincipal.TabIndex = 3;
            // 
            // TablaSecundaria
            // 
            this.TablaSecundaria.Etiqueta.Ancho = 90;
            this.TablaSecundaria.Etiqueta.Texto = "Tabla secundaria";
            this.TablaSecundaria.Location = new System.Drawing.Point(31, 145);
            this.TablaSecundaria.Name = "TablaSecundaria";
            this.TablaSecundaria.Size = new System.Drawing.Size(342, 20);
            this.TablaSecundaria.TabIndex = 4;
            // 
            // ColumnaSecundaria
            // 
            this.ColumnaSecundaria.Etiqueta.Ancho = 90;
            this.ColumnaSecundaria.Etiqueta.Texto = "Columna secund.";
            this.ColumnaSecundaria.Location = new System.Drawing.Point(31, 171);
            this.ColumnaSecundaria.Name = "ColumnaSecundaria";
            this.ColumnaSecundaria.Size = new System.Drawing.Size(342, 20);
            this.ColumnaSecundaria.TabIndex = 5;
            // 
            // Tipo
            // 
            this.Tipo.Etiqueta.Ancho = 90;
            this.Tipo.Etiqueta.Texto = "Tipo";
            this.Tipo.Location = new System.Drawing.Point(31, 27);
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(342, 20);
            this.Tipo.TabIndex = 0;
            // 
            // Propiedad
            // 
            this.Propiedad.Etiqueta.Ancho = 90;
            this.Propiedad.Etiqueta.Texto = "Propiedad";
            this.Propiedad.Location = new System.Drawing.Point(31, 53);
            this.Propiedad.Name = "Propiedad";
            this.Propiedad.Size = new System.Drawing.Size(342, 20);
            this.Propiedad.TabIndex = 1;
            // 
            // VistaRelacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Propiedad);
            this.Controls.Add(this.Tipo);
            this.Controls.Add(this.ColumnaSecundaria);
            this.Controls.Add(this.TablaSecundaria);
            this.Controls.Add(this.ColumnaPrincipal);
            this.Controls.Add(this.TablaPrincipal);
            this.Name = "VistaRelacion";
            this.Size = new System.Drawing.Size(410, 224);
            this.ResumeLayout(false);

        }

        #endregion

        private Binapsis.Presentacion.Editores.Win.EditorTexto TablaPrincipal;
        private Binapsis.Presentacion.Editores.Win.EditorTexto ColumnaPrincipal;
        private Binapsis.Presentacion.Editores.Win.EditorTexto TablaSecundaria;
        private Binapsis.Presentacion.Editores.Win.EditorTexto ColumnaSecundaria;
        private Binapsis.Presentacion.Editores.Win.EditorTexto Tipo;
        private Binapsis.Presentacion.Editores.Win.EditorTexto Propiedad;
    }
}

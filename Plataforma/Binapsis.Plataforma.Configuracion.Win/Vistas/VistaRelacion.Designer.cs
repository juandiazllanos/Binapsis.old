namespace Binapsis.Plataforma.Configuracion.Win.Vistas
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
            this.TablaPrincipal = new Binapsis.Presentacion.Win.EditorTexto();
            this.ColumnaPrincipal = new Binapsis.Presentacion.Win.EditorTexto();
            this.TablaSecundaria = new Binapsis.Presentacion.Win.EditorTexto();
            this.ColumnaSecundaria = new Binapsis.Presentacion.Win.EditorTexto();
            this.Tipo = new Binapsis.Presentacion.Win.EditorTexto();
            this.Propiedad = new Binapsis.Presentacion.Win.EditorTexto();
            this.Nombre = new Binapsis.Presentacion.Win.EditorTexto();
            this.SuspendLayout();
            // 
            // TablaPrincipal
            // 
            this.TablaPrincipal.Etiqueta.Ancho = 90;
            this.TablaPrincipal.Etiqueta.Texto = "Tabla principal";
            this.TablaPrincipal.Location = new System.Drawing.Point(32, 59);
            this.TablaPrincipal.Name = "TablaPrincipal";
            this.TablaPrincipal.Size = new System.Drawing.Size(287, 20);
            this.TablaPrincipal.TabIndex = 1;
            // 
            // ColumnaPrincipal
            // 
            this.ColumnaPrincipal.Etiqueta.Ancho = 90;
            this.ColumnaPrincipal.Etiqueta.Texto = "Columna principal";
            this.ColumnaPrincipal.Location = new System.Drawing.Point(32, 85);
            this.ColumnaPrincipal.Name = "ColumnaPrincipal";
            this.ColumnaPrincipal.Size = new System.Drawing.Size(287, 20);
            this.ColumnaPrincipal.TabIndex = 2;
            // 
            // TablaSecundaria
            // 
            this.TablaSecundaria.Etiqueta.Ancho = 90;
            this.TablaSecundaria.Etiqueta.Texto = "Tabla secundaria";
            this.TablaSecundaria.Location = new System.Drawing.Point(32, 111);
            this.TablaSecundaria.Name = "TablaSecundaria";
            this.TablaSecundaria.Size = new System.Drawing.Size(287, 20);
            this.TablaSecundaria.TabIndex = 3;
            // 
            // ColumnaSecundaria
            // 
            this.ColumnaSecundaria.Etiqueta.Ancho = 90;
            this.ColumnaSecundaria.Etiqueta.Texto = "Columna secund.";
            this.ColumnaSecundaria.Location = new System.Drawing.Point(32, 137);
            this.ColumnaSecundaria.Name = "ColumnaSecundaria";
            this.ColumnaSecundaria.Size = new System.Drawing.Size(287, 20);
            this.ColumnaSecundaria.TabIndex = 4;
            // 
            // Tipo
            // 
            this.Tipo.Etiqueta.Ancho = 90;
            this.Tipo.Etiqueta.Texto = "Tipo";
            this.Tipo.Location = new System.Drawing.Point(32, 175);
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(287, 20);
            this.Tipo.TabIndex = 5;
            // 
            // Propiedad
            // 
            this.Propiedad.Etiqueta.Ancho = 90;
            this.Propiedad.Etiqueta.Texto = "Propiedad";
            this.Propiedad.Location = new System.Drawing.Point(32, 201);
            this.Propiedad.Name = "Propiedad";
            this.Propiedad.Size = new System.Drawing.Size(287, 20);
            this.Propiedad.TabIndex = 6;
            // 
            // Nombre
            // 
            this.Nombre.Etiqueta.Ancho = 90;
            this.Nombre.Etiqueta.Texto = "Nombre";
            this.Nombre.Location = new System.Drawing.Point(32, 24);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(287, 20);
            this.Nombre.TabIndex = 0;
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
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.TablaPrincipal);
            this.Name = "VistaRelacion";
            this.Size = new System.Drawing.Size(352, 246);
            this.UsarReflexion = false;
            this.ResumeLayout(false);

        }

        #endregion

        private Presentacion.Win.EditorTexto TablaPrincipal;
        private Presentacion.Win.EditorTexto ColumnaPrincipal;
        private Presentacion.Win.EditorTexto TablaSecundaria;
        private Presentacion.Win.EditorTexto ColumnaSecundaria;
        private Presentacion.Win.EditorTexto Tipo;
        private Presentacion.Win.EditorTexto Propiedad;
        private Presentacion.Win.EditorTexto Nombre;
    }
}

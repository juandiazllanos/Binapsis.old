namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Vistas
{
    partial class VistaComando
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
            this.Sql = new Binapsis.Presentacion.Editores.Win.EditorTexto();
            this.ComandoTipo = new Binapsis.Presentacion.Editores.Win.EditorEnumeracion();
            this.SuspendLayout();
            // 
            // Nombre
            // 
            this.Nombre.Etiqueta.Texto = "Nombre";
            this.Nombre.Location = new System.Drawing.Point(20, 24);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(332, 20);
            this.Nombre.TabIndex = 0;
            // 
            // Sql
            // 
            this.Sql.Estilo = Binapsis.Presentacion.Editores.Win.Estilo.TextMemoEdit;
            this.Sql.Etiqueta.Texto = "Sql";
            this.Sql.Location = new System.Drawing.Point(20, 79);
            this.Sql.Name = "Sql";
            this.Sql.Size = new System.Drawing.Size(332, 142);
            this.Sql.TabIndex = 1;
            // 
            // ComandoTipo
            // 
            this.ComandoTipo.Estilo = Binapsis.Presentacion.Editores.Win.Estilo.EnumeracionEdit;
            this.ComandoTipo.Etiqueta.Texto = "Tipo";
            this.ComandoTipo.Location = new System.Drawing.Point(20, 50);
            this.ComandoTipo.Name = "ComandoTipo";
            this.ComandoTipo.Size = new System.Drawing.Size(332, 20);
            this.ComandoTipo.TabIndex = 2;
            // 
            // VistaComando
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ComandoTipo);
            this.Controls.Add(this.Sql);
            this.Controls.Add(this.Nombre);
            this.Name = "VistaComando";
            this.Size = new System.Drawing.Size(377, 253);
            this.ResumeLayout(false);

        }

        #endregion

        private Binapsis.Presentacion.Editores.Win.EditorTexto Nombre;
        private Binapsis.Presentacion.Editores.Win.EditorTexto Sql;
        private Binapsis.Presentacion.Editores.Win.EditorEnumeracion ComandoTipo;
    }
}

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Vistas
{
    partial class VistaUri
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
            Binapsis.Presentacion.Editores.Win.Boton boton1 = new Binapsis.Presentacion.Editores.Win.Boton();
            this.Ensamblado = new Binapsis.Presentacion.Editores.Win.EditorTextoBoton();
            this.Nombre = new Binapsis.Presentacion.Editores.Win.EditorTexto();
            this.SuspendLayout();
            // 
            // Ensamblado
            // 
            boton1.Image = null;
            boton1.Nombre = "seleccionarEnsambaldo";
            this.Ensamblado.Botones.Add(boton1);
            this.Ensamblado.Estilo = Binapsis.Presentacion.Editores.Win.Estilo.TextButtonEdit;
            this.Ensamblado.Etiqueta.Texto = "Ensamblado";
            this.Ensamblado.Location = new System.Drawing.Point(26, 24);
            this.Ensamblado.Name = "EditorBase";
            this.Ensamblado.Size = new System.Drawing.Size(299, 20);
            this.Ensamblado.TabIndex = 0;
            // 
            // Nombre
            // 
            this.Nombre.Etiqueta.Texto = "Nombre";
            this.Nombre.Location = new System.Drawing.Point(26, 51);
            this.Nombre.Name = "EditorTexto";
            this.Nombre.Size = new System.Drawing.Size(299, 20);
            this.Nombre.TabIndex = 1;
            // 
            // VistaUri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.Ensamblado);
            this.Name = "VistaUri";
            this.Size = new System.Drawing.Size(355, 105);
            this.ResumeLayout(false);

        }

        #endregion

        private Binapsis.Presentacion.Editores.Win.EditorTextoBoton Ensamblado;
        private Binapsis.Presentacion.Editores.Win.EditorTexto Nombre;
    }
}

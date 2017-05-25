namespace Binapsis.Plataforma.Configuracion.Win.Vistas
{
    partial class VistaPropiedad
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
            Binapsis.Presentacion.Win.Boton boton2 = new Binapsis.Presentacion.Win.Boton();
            this.Tipo = new Binapsis.Presentacion.Win.EditorTextoBoton();
            this.Nombre = new Binapsis.Presentacion.Win.EditorTexto();
            this.Alias = new Binapsis.Presentacion.Win.EditorTexto();
            this.ValorInicial = new Binapsis.Presentacion.Win.EditorTexto();
            this.Asociacion = new Binapsis.Presentacion.Win.EditorEnumeracion();
            this.Cardinalidad = new Binapsis.Presentacion.Win.EditorEnumeracion();
            this.Indice = new Binapsis.Presentacion.Win.EditorNumerico();
            this.SuspendLayout();
            // 
            // Tipo
            // 
            boton2.Image = null;
            boton2.Nombre = "seleccionarTipo";
            this.Tipo.Botones.Add(boton2);
            this.Tipo.Estilo = Binapsis.Presentacion.Win.Estilo.TextButtonEdit;
            this.Tipo.Etiqueta.Texto = "Tipo";
            this.Tipo.Location = new System.Drawing.Point(25, 78);
            this.Tipo.Name = "EditorBase";
            this.Tipo.Size = new System.Drawing.Size(306, 20);
            this.Tipo.TabIndex = 2;
            // 
            // Nombre
            // 
            this.Nombre.Etiqueta.Texto = "Nombre";
            this.Nombre.Location = new System.Drawing.Point(25, 26);
            this.Nombre.Name = "EditorTexto";
            this.Nombre.Size = new System.Drawing.Size(306, 20);
            this.Nombre.TabIndex = 0;
            // 
            // Alias
            // 
            this.Alias.Etiqueta.Texto = "Alias";
            this.Alias.Location = new System.Drawing.Point(25, 52);
            this.Alias.Name = "EditorTexto";
            this.Alias.Size = new System.Drawing.Size(306, 20);
            this.Alias.TabIndex = 1;
            // 
            // ValorInicial
            // 
            this.ValorInicial.Etiqueta.Texto = "Valor inicial";
            this.ValorInicial.Location = new System.Drawing.Point(25, 182);
            this.ValorInicial.Name = "EditorTexto";
            this.ValorInicial.Size = new System.Drawing.Size(306, 20);
            this.ValorInicial.TabIndex = 6;
            // 
            // Asociacion
            // 
            this.Asociacion.Estilo = Binapsis.Presentacion.Win.Estilo.EnumeracionEdit;
            this.Asociacion.Etiqueta.Texto = "Asociación";
            this.Asociacion.Location = new System.Drawing.Point(25, 104);
            this.Asociacion.Name = "EditorBase";
            this.Asociacion.Size = new System.Drawing.Size(306, 20);
            this.Asociacion.TabIndex = 3;
            // 
            // Cardinalidad
            // 
            this.Cardinalidad.Estilo = Binapsis.Presentacion.Win.Estilo.EnumeracionEdit;
            this.Cardinalidad.Etiqueta.Texto = "Cardinalidad";
            this.Cardinalidad.Location = new System.Drawing.Point(25, 130);
            this.Cardinalidad.Name = "EditorBase";
            this.Cardinalidad.Size = new System.Drawing.Size(306, 20);
            this.Cardinalidad.TabIndex = 4;
            // 
            // Indice
            // 
            this.Indice.Etiqueta.Texto = "Índice";
            this.Indice.Location = new System.Drawing.Point(25, 156);
            this.Indice.Name = "EditorTexto";
            this.Indice.Size = new System.Drawing.Size(306, 20);
            this.Indice.TabIndex = 5;
            // 
            // VistaPropiedad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Indice);
            this.Controls.Add(this.Cardinalidad);
            this.Controls.Add(this.Asociacion);
            this.Controls.Add(this.ValorInicial);
            this.Controls.Add(this.Alias);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.Tipo);
            this.Name = "VistaPropiedad";
            this.Size = new System.Drawing.Size(356, 240);
            this.ResumeLayout(false);

        }

        #endregion

        private Presentacion.Win.EditorTextoBoton Tipo;
        private Presentacion.Win.EditorTexto Nombre;
        private Presentacion.Win.EditorTexto Alias;
        private Presentacion.Win.EditorTexto ValorInicial;
        private Presentacion.Win.EditorEnumeracion Asociacion;
        private Presentacion.Win.EditorEnumeracion Cardinalidad;
        private Presentacion.Win.EditorNumerico Indice;
    }
}

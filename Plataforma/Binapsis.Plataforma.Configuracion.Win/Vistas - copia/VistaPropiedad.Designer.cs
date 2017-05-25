namespace Binapsis.Plataforma.Configuracion.Win.Vistas
{
    partial class VistaPropiedad
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Binapsis.Presentacion.Win.Boton boton2 = new Binapsis.Presentacion.Win.Boton();
            this.TipoAsociado = new Binapsis.Presentacion.Win.EditorTextoBoton();
            this.Nombre = new Binapsis.Presentacion.Win.EditorTexto();
            this.Alias = new Binapsis.Presentacion.Win.EditorTexto();
            this.ValorInicial = new Binapsis.Presentacion.Win.EditorTexto();
            this.Indice = new Binapsis.Presentacion.Win.EditorNumerico();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Indice);
            this.panel1.Controls.Add(this.ValorInicial);
            this.panel1.Controls.Add(this.Alias);
            this.panel1.Controls.Add(this.Nombre);
            this.panel1.Controls.Add(this.TipoAsociado);
            this.panel1.Size = new System.Drawing.Size(314, 207);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(236, 208);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(158, 208);
            // 
            // TipoAsociado
            // 
            boton2.Image = null;
            boton2.Nombre = "seleccionarTipo";
            this.TipoAsociado.Botones.Add(boton2);
            this.TipoAsociado.Estilo = Binapsis.Presentacion.Win.Estilo.TextButtonEdit;
            this.TipoAsociado.Etiqueta.Texto = "Tipo";
            this.TipoAsociado.Location = new System.Drawing.Point(23, 21);
            this.TipoAsociado.Name = "EditorBase";
            this.TipoAsociado.Size = new System.Drawing.Size(262, 20);
            this.TipoAsociado.TabIndex = 0;
            // 
            // Nombre
            // 
            this.Nombre.Etiqueta.Texto = "Nombre";
            this.Nombre.Location = new System.Drawing.Point(23, 47);
            this.Nombre.Name = "EditorTexto";
            this.Nombre.Size = new System.Drawing.Size(262, 20);
            this.Nombre.TabIndex = 1;
            // 
            // Alias
            // 
            this.Alias.Etiqueta.Texto = "Alias";
            this.Alias.Location = new System.Drawing.Point(23, 74);
            this.Alias.Name = "EditorTexto";
            this.Alias.Size = new System.Drawing.Size(262, 20);
            this.Alias.TabIndex = 2;
            // 
            // ValorInicial
            // 
            this.ValorInicial.Etiqueta.Texto = "Valor inicial";
            this.ValorInicial.Location = new System.Drawing.Point(23, 101);
            this.ValorInicial.Name = "EditorTexto";
            this.ValorInicial.Size = new System.Drawing.Size(262, 20);
            this.ValorInicial.TabIndex = 3;
            // 
            // Indice
            // 
            this.Indice.Estilo = Binapsis.Presentacion.Win.Estilo.IntegerEdit;
            this.Indice.Etiqueta.Texto = "Indice";
            this.Indice.Location = new System.Drawing.Point(23, 127);
            this.Indice.Name = "EditorTexto";
            this.Indice.Size = new System.Drawing.Size(262, 20);
            this.Indice.TabIndex = 4;
            // 
            // VistaPropiedad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 238);
            this.Name = "VistaPropiedad";
            this.Text = "Propiedad";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Presentacion.Win.EditorTextoBoton TipoAsociado;
        private Presentacion.Win.EditorTexto Nombre;
        private Presentacion.Win.EditorTexto Alias;
        private Presentacion.Win.EditorTexto ValorInicial;
        private Presentacion.Win.EditorNumerico Indice;
    }
}
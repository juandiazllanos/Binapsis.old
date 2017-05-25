namespace Binapsis.Plataforma.Configuracion.Win.Vistas
{
    partial class VistaTipo
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
            Binapsis.Presentacion.Win.Boton boton5 = new Binapsis.Presentacion.Win.Boton();
            Binapsis.Presentacion.Win.Boton boton6 = new Binapsis.Presentacion.Win.Boton();
            this.Base = new Binapsis.Presentacion.Win.EditorTextoBoton();
            this.Uri = new Binapsis.Presentacion.Win.EditorTextoBoton();
            this.Nombre = new Binapsis.Presentacion.Win.EditorTexto();
            this.Alias = new Binapsis.Presentacion.Win.EditorTexto();
            this.EsTipoDeDato = new Binapsis.Presentacion.Win.EditorBoolean();
            this.SuspendLayout();
            // 
            // Base
            // 
            boton5.Image = null;
            boton5.Nombre = "seleccionarBase";
            this.Base.Botones.Add(boton5);
            this.Base.Estilo = Binapsis.Presentacion.Win.Estilo.TextButtonEdit;
            this.Base.Etiqueta.Texto = "Base";
            this.Base.Location = new System.Drawing.Point(32, 27);
            this.Base.Name = "EditorBase";
            this.Base.Size = new System.Drawing.Size(323, 20);
            this.Base.TabIndex = 0;
            // 
            // Uri
            // 
            boton6.Image = null;
            boton6.Nombre = "seleccionarUri";
            this.Uri.Botones.Add(boton6);
            this.Uri.Estilo = Binapsis.Presentacion.Win.Estilo.TextButtonEdit;
            this.Uri.Etiqueta.Texto = "Uri";
            this.Uri.Location = new System.Drawing.Point(32, 53);
            this.Uri.Name = "EditorBase";
            this.Uri.Size = new System.Drawing.Size(323, 20);
            this.Uri.TabIndex = 1;
            // 
            // Nombre
            // 
            this.Nombre.Etiqueta.Texto = "Nombre";
            this.Nombre.Location = new System.Drawing.Point(32, 79);
            this.Nombre.Name = "EditorTexto";
            this.Nombre.Size = new System.Drawing.Size(323, 20);
            this.Nombre.TabIndex = 2;
            // 
            // Alias
            // 
            this.Alias.Etiqueta.Texto = "Alias";
            this.Alias.Location = new System.Drawing.Point(32, 105);
            this.Alias.Name = "EditorTexto";
            this.Alias.Size = new System.Drawing.Size(323, 20);
            this.Alias.TabIndex = 3;
            // 
            // EsTipoDeDato
            // 
            this.EsTipoDeDato.Estilo = Binapsis.Presentacion.Win.Estilo.CheckEdit;
            this.EsTipoDeDato.Etiqueta.Texto = "";
            this.EsTipoDeDato.Etiqueta.Visible = false;
            this.EsTipoDeDato.Location = new System.Drawing.Point(110, 131);
            this.EsTipoDeDato.Name = "EditorBoolean";
            this.EsTipoDeDato.Size = new System.Drawing.Size(160, 19);
            this.EsTipoDeDato.TabIndex = 5;
            this.EsTipoDeDato.Texto = "Es tipo de dato";
            // 
            // VistaTipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EsTipoDeDato);
            this.Controls.Add(this.Alias);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.Uri);
            this.Controls.Add(this.Base);
            this.Name = "VistaTipo";
            this.Size = new System.Drawing.Size(388, 178);
            this.ResumeLayout(false);

        }

        #endregion

        private Presentacion.Win.EditorTextoBoton Base;
        private Presentacion.Win.EditorTextoBoton Uri;
        private Presentacion.Win.EditorTexto Nombre;
        private Presentacion.Win.EditorTexto Alias;
        private Presentacion.Win.EditorBoolean EsTipoDeDato;
    }
}

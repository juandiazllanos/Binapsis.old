namespace Binapsis.Plataforma.Configuracion.Win.Vistas
{
    partial class VistaTipo
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
            Binapsis.Presentacion.Win.Boton boton4 = new Binapsis.Presentacion.Win.Boton();
            Binapsis.Presentacion.Win.Boton boton3 = new Binapsis.Presentacion.Win.Boton();
            this.Uri = new Binapsis.Presentacion.Win.EditorTextoBoton();
            this.BaseNombre = new Binapsis.Presentacion.Win.EditorTextoBoton();
            this.Nombre = new Binapsis.Presentacion.Win.EditorTexto();
            this.Alias = new Binapsis.Presentacion.Win.EditorTexto();
            this.EsTipoDeDato = new Binapsis.Presentacion.Win.EditorBoolean();
            this.BaseUri = new Binapsis.Presentacion.Win.EditorTexto();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BaseUri);
            this.panel1.Controls.Add(this.EsTipoDeDato);
            this.panel1.Controls.Add(this.Alias);
            this.panel1.Controls.Add(this.Nombre);
            this.panel1.Controls.Add(this.BaseNombre);
            this.panel1.Controls.Add(this.Uri);
            this.panel1.Size = new System.Drawing.Size(369, 177);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(291, 178);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(213, 178);
            // 
            // Uri
            // 
            boton4.Image = null;
            boton4.Nombre = "seleccionarUri";
            this.Uri.Botones.Add(boton4);
            this.Uri.Estilo = Binapsis.Presentacion.Win.Estilo.TextButtonEdit;
            this.Uri.Etiqueta.Texto = "Uri";
            this.Uri.Location = new System.Drawing.Point(28, 52);
            this.Uri.Name = "EditorBase";
            this.Uri.Size = new System.Drawing.Size(310, 20);
            this.Uri.TabIndex = 0;
            // 
            // BaseNombre
            // 
            boton3.Image = null;
            boton3.Nombre = "seleccionarBase";
            this.BaseNombre.Botones.Add(boton3);
            this.BaseNombre.Estilo = Binapsis.Presentacion.Win.Estilo.TextButtonEdit;
            this.BaseNombre.Etiqueta.Texto = "Base";
            this.BaseNombre.Etiqueta.Visible = false;
            this.BaseNombre.Location = new System.Drawing.Point(214, 26);
            this.BaseNombre.Name = "EditorBase";
            this.BaseNombre.Size = new System.Drawing.Size(124, 20);
            this.BaseNombre.TabIndex = 1;
            // 
            // Nombre
            // 
            this.Nombre.Etiqueta.Texto = "Nombre";
            this.Nombre.Location = new System.Drawing.Point(28, 78);
            this.Nombre.Name = "EditorTexto";
            this.Nombre.Size = new System.Drawing.Size(310, 20);
            this.Nombre.TabIndex = 2;
            // 
            // Alias
            // 
            this.Alias.Etiqueta.Texto = "Alias";
            this.Alias.Location = new System.Drawing.Point(28, 104);
            this.Alias.Name = "EditorTexto";
            this.Alias.Size = new System.Drawing.Size(310, 20);
            this.Alias.TabIndex = 3;
            // 
            // EsTipoDeDato
            // 
            this.EsTipoDeDato.Estilo = Binapsis.Presentacion.Win.Estilo.CheckEdit;
            this.EsTipoDeDato.Etiqueta.Texto = "";
            this.EsTipoDeDato.Etiqueta.Visible = false;
            this.EsTipoDeDato.Location = new System.Drawing.Point(107, 131);
            this.EsTipoDeDato.Name = "EditorBoolean";
            this.EsTipoDeDato.Size = new System.Drawing.Size(141, 19);
            this.EsTipoDeDato.TabIndex = 4;
            this.EsTipoDeDato.Texto = "Es tipo de dato";
            // 
            // BaseUri
            // 
            this.BaseUri.Etiqueta.Texto = "Base";
            this.BaseUri.Location = new System.Drawing.Point(28, 26);
            this.BaseUri.Name = "EditorTexto";
            this.BaseUri.Size = new System.Drawing.Size(180, 20);
            this.BaseUri.TabIndex = 5;
            // 
            // VistaTipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 208);
            this.Name = "VistaTipo";
            this.Text = "Tipo";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Presentacion.Win.EditorTextoBoton Uri;
        private Presentacion.Win.EditorTexto Alias;
        private Presentacion.Win.EditorTexto Nombre;
        private Presentacion.Win.EditorTextoBoton BaseNombre;
        private Presentacion.Win.EditorBoolean EsTipoDeDato;
        private Presentacion.Win.EditorTexto BaseUri;
    }
}
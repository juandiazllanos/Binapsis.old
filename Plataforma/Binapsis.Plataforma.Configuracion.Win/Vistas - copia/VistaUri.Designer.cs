namespace Binapsis.Plataforma.Configuracion.Win.Vistas
{
    partial class VistaUri
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
            Binapsis.Presentacion.Win.Boton boton1 = new Binapsis.Presentacion.Win.Boton();
            this.Nombre = new Binapsis.Presentacion.Win.EditorTexto();
            this.Ensamblado = new Binapsis.Presentacion.Win.EditorTextoBoton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Ensamblado);
            this.panel1.Controls.Add(this.Nombre);
            this.panel1.Size = new System.Drawing.Size(375, 100);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(297, 101);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(219, 101);
            // 
            // Nombre
            // 
            this.Nombre.Etiqueta.Texto = "Nombre";
            this.Nombre.Location = new System.Drawing.Point(34, 48);
            this.Nombre.Name = "EditorTexto";
            this.Nombre.Size = new System.Drawing.Size(302, 20);
            this.Nombre.TabIndex = 1;
            // 
            // Ensamblado
            // 
            boton1.Image = null;
            boton1.Nombre = "seleccionarEnsamblado";
            this.Ensamblado.Botones.Add(boton1);
            this.Ensamblado.Estilo = Binapsis.Presentacion.Win.Estilo.TextButtonEdit;
            this.Ensamblado.Etiqueta.Texto = "Ensamblado";
            this.Ensamblado.Location = new System.Drawing.Point(34, 22);
            this.Ensamblado.Name = "EditorBase";
            this.Ensamblado.Size = new System.Drawing.Size(302, 20);
            this.Ensamblado.TabIndex = 0;
            // 
            // VistaUri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 131);
            this.Name = "VistaUri";
            this.Text = "Uri";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Presentacion.Win.EditorTexto Nombre;
        private Presentacion.Win.EditorTextoBoton Ensamblado;
    }
}
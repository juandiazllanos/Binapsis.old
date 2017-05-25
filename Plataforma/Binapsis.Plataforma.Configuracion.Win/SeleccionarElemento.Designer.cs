namespace Binapsis.Plataforma.Configuracion.Win
{
    partial class SeleccionarElemento
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleccionarElemento));
            this.lvwElemento = new System.Windows.Forms.ListView();
            this.colValor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imagenes = new System.Windows.Forms.ImageList(this.components);
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwElemento
            // 
            this.lvwElemento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwElemento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwElemento.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colValor});
            this.lvwElemento.FullRowSelect = true;
            this.lvwElemento.GridLines = true;
            this.lvwElemento.HideSelection = false;
            this.lvwElemento.Location = new System.Drawing.Point(2, 3);
            this.lvwElemento.Name = "lvwElemento";
            this.lvwElemento.Size = new System.Drawing.Size(435, 222);
            this.lvwElemento.SmallImageList = this.imagenes;
            this.lvwElemento.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwElemento.TabIndex = 0;
            this.lvwElemento.UseCompatibleStateImageBehavior = false;
            this.lvwElemento.View = System.Windows.Forms.View.Details;
            // 
            // colValor
            // 
            this.colValor.Text = "Valor";
            this.colValor.Width = 413;
            // 
            // imagenes
            // 
            this.imagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenes.ImageStream")));
            this.imagenes.TransparentColor = System.Drawing.Color.Transparent;
            this.imagenes.Images.SetKeyName(0, "Configuracion");
            this.imagenes.Images.SetKeyName(1, "Ensamblado");
            this.imagenes.Images.SetKeyName(2, "Tipo");
            this.imagenes.Images.SetKeyName(3, "Uri");
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(280, 227);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 26);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(362, 227);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 26);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // SeleccionarElemento
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(439, 256);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lvwElemento);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SeleccionarElemento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwElemento;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ColumnHeader colValor;
        private System.Windows.Forms.ImageList imagenes;
    }
}
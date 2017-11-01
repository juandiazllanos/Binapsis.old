namespace Binapsis.Presentacion.Editores.Win
{
    partial class FormDialogo
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
            this.botonCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.botones = new System.Windows.Forms.Panel();
            this.botonOk = new DevExpress.XtraEditors.SimpleButton();
            this.botones.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonCancelar
            // 
            this.botonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCancelar.Location = new System.Drawing.Point(299, 3);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(76, 28);
            this.botonCancelar.TabIndex = 0;
            this.botonCancelar.Text = "Cancelar";
            // 
            // botones
            // 
            this.botones.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.botones.Controls.Add(this.botonOk);
            this.botones.Controls.Add(this.botonCancelar);
            this.botones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.botones.Location = new System.Drawing.Point(0, 245);
            this.botones.Name = "botones";
            this.botones.Size = new System.Drawing.Size(378, 34);
            this.botones.TabIndex = 2;
            // 
            // botonOk
            // 
            this.botonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botonOk.Location = new System.Drawing.Point(217, 3);
            this.botonOk.Name = "botonOk";
            this.botonOk.Size = new System.Drawing.Size(76, 28);
            this.botonOk.TabIndex = 0;
            this.botonOk.Text = "OK";
            // 
            // FormDialogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(378, 279);
            this.Controls.Add(this.botones);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.SkinName = "Office 2010 Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.Name = "FormDialogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.botones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton botonCancelar;
        private System.Windows.Forms.Panel botones;
        private DevExpress.XtraEditors.SimpleButton botonOk;
    }
}
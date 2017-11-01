namespace Binapsis.Consola.Win
{
    partial class WinMain
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
            this.barMain = new DevExpress.XtraBars.BarManager(this.components);
            this.menuMain = new DevExpress.XtraBars.Bar();
            this.estadoMain = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tabMain = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.skinMain = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.navegadorMain = new DevExpress.XtraNavBar.NavBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navegadorMain)).BeginInit();
            this.SuspendLayout();
            // 
            // barMain
            // 
            this.barMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.menuMain,
            this.estadoMain});
            this.barMain.DockControls.Add(this.barDockControlTop);
            this.barMain.DockControls.Add(this.barDockControlBottom);
            this.barMain.DockControls.Add(this.barDockControlLeft);
            this.barMain.DockControls.Add(this.barDockControlRight);
            this.barMain.Form = this;
            this.barMain.MainMenu = this.menuMain;
            this.barMain.MaxItemId = 1;
            this.barMain.StatusBar = this.estadoMain;
            // 
            // menuMain
            // 
            this.menuMain.BarName = "Main menu";
            this.menuMain.DockCol = 0;
            this.menuMain.DockRow = 0;
            this.menuMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.menuMain.OptionsBar.MultiLine = true;
            this.menuMain.OptionsBar.UseWholeRow = true;
            this.menuMain.Text = "Main menu";
            // 
            // estadoMain
            // 
            this.estadoMain.BarName = "Status bar";
            this.estadoMain.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.estadoMain.DockCol = 0;
            this.estadoMain.DockRow = 0;
            this.estadoMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.estadoMain.OptionsBar.AllowQuickCustomization = false;
            this.estadoMain.OptionsBar.DrawDragBorder = false;
            this.estadoMain.OptionsBar.UseWholeRow = true;
            this.estadoMain.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barMain;
            this.barDockControlTop.Size = new System.Drawing.Size(632, 22);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 349);
            this.barDockControlBottom.Manager = this.barMain;
            this.barDockControlBottom.Size = new System.Drawing.Size(632, 21);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Manager = this.barMain;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 327);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(632, 22);
            this.barDockControlRight.Manager = this.barMain;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 327);
            // 
            // tabMain
            // 
            this.tabMain.MdiParent = this;
            // 
            // skinMain
            // 
            this.skinMain.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // navegadorMain
            // 
            this.navegadorMain.ActiveGroup = null;
            this.navegadorMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.navegadorMain.Location = new System.Drawing.Point(0, 22);
            this.navegadorMain.Name = "navegadorMain";
            this.navegadorMain.OptionsNavPane.ExpandedWidth = 245;
            this.navegadorMain.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navegadorMain.Size = new System.Drawing.Size(245, 327);
            this.navegadorMain.TabIndex = 20;
            this.navegadorMain.Text = "navBarControl1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 370);
            this.Controls.Add(this.navegadorMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Name = "Main";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navegadorMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barMain;
        private DevExpress.XtraBars.Bar menuMain;
        private DevExpress.XtraBars.Bar estadoMain;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tabMain;
        private DevExpress.LookAndFeel.DefaultLookAndFeel skinMain;
        private DevExpress.XtraNavBar.NavBarControl navegadorMain;
    }
}
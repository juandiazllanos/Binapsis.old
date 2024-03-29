﻿using Binapsis.Presentacion.Editores.Win.Diseñadores;
using System.ComponentModel;
using System.Drawing.Design;
using System;
using DevExpress.XtraEditors;

namespace Binapsis.Presentacion.Editores.Win
{
    [ToolboxItem(true)]
    public partial class EditorFecha : EditorBase
    {
        public EditorFecha()
        {
            InitializeComponent();
        }
        
        protected override void Inicializar()
        {
            Estilo = Estilo.DateEdit;
        }
        
        [Browsable(true)]
        [DefaultValue(Estilo.DateEdit)]
        [Editor(typeof(TypeEditorEstiloFecha), typeof(UITypeEditor))]
        public override Estilo Estilo
        {
            get { return base.Estilo; }
            set { base.Estilo = value; }
        }
    }
}

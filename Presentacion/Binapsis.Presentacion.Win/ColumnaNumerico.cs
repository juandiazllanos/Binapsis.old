﻿using Binapsis.Presentacion.Win.Diseñadores;
using System.ComponentModel;
using System.Drawing.Design;

namespace Binapsis.Presentacion.Win
{
    public class ColumnaNumerico : ColumnaTexto
    {
        protected override void InicializarEstilo()
        {
            Estilo = Estilo.DecimalEdit;
        }

        [DefaultValue(Estilo.IntegerEdit)]
        [Editor(typeof(TypeEditorEstiloNumerico), typeof(UITypeEditor))]
        public override Estilo Estilo
        {
            get { return base.Estilo; }
            set { base.Estilo = value; }
        }
    }
}

﻿namespace Binapsis.Presentacion.Win.Estilos
{
    class EstiloEditorTextMemoEdit : EstiloEditorText
    {
        public EstiloEditorTextMemoEdit(EstiloBase estilo) 
            : base(estilo)
        {
        }
        
        public override int MaximoAlto
        {
            get { return 0; }
        }
    }
}
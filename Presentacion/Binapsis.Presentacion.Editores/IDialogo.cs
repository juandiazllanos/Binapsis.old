﻿namespace Binapsis.Presentacion.Editores
{
    public interface IDialogo
    {
        void Mostrar();
        void Mostrar(TerminarHandler terminar);
                
        ResultadoDialogo Resultado { get; }
    }

    public delegate void TerminarHandler(IDialogo dialogo);
}
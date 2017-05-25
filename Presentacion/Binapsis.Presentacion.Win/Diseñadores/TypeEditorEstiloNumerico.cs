namespace Binapsis.Presentacion.Win.Diseñadores
{
    internal class TypeEditorEstiloNumerico : TypeEditorEstilo
    {
        public TypeEditorEstiloNumerico() 
            : base(new Estilo[] { Estilo.DecimalEdit, Estilo.IntegerEdit })
        {
        }
    }
}

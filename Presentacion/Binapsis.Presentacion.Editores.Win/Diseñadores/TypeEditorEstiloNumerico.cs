namespace Binapsis.Presentacion.Editores.Win.Diseñadores
{
    internal class TypeEditorEstiloNumerico : TypeEditorEstilo
    {
        public TypeEditorEstiloNumerico() 
            : base(new Estilo[] { Estilo.DecimalEdit, Estilo.IntegerEdit })
        {
        }
    }
}

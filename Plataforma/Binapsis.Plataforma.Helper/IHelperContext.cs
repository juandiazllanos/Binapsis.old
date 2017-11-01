namespace Binapsis.Plataforma.Helper
{
    public interface IHelperContext
    {
        ICopyHelper     CopyHelper { get; }
        IDataFactory    DataFactory { get; }
        IDataHelper     DataHelper { get; }
        IDefaultValueHelper DefaultValueHelper { get; }
        IEqualityHelper EqualityHelper { get; }
        IKeyHelper      KeyHelper { get; }
        ITypeHelper     TypeHelper { get; }
    }
}

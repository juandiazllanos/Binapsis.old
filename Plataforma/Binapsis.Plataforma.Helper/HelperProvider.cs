namespace Binapsis.Plataforma.Helper
{
    public class HelperProvider
    {
        public static ICopyHelper CopyHelper
        {
            get => HelperContext?.CopyHelper;
        }

        public static IDataFactory DataFactory
        {
            get => HelperContext?.DataFactory;
        }

        public static IDataHelper DataHelper
        {
            get => HelperContext?.DataHelper;
        }

        public static IDefaultValueHelper DefaultValueHelper
        {
            get => HelperContext.DefaultValueHelper;
        }

        public static IEqualityHelper EqualityHelper
        {
            get => HelperContext?.EqualityHelper;
        }

        public static IKeyHelper KeyHelper
        {
            get => HelperContext.KeyHelper;
        }

        public static ITypeHelper TypeHelper
        {
            get => HelperContext?.TypeHelper;
        }

        public static IHelperContext HelperContext
        {
            get;
            set;
        }
    }
}

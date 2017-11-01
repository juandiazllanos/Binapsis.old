using System;
using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Helper;
using Binapsis.Plataforma.Helper.Impl;

namespace Binapsis.Plataforma
{
    public class HelperContext : IHelperContext
    {   
        Contexto _contexto;

        #region Constructores
        public HelperContext(string contexto)
        {            
            _contexto = HelperConfig.ObtenerContexto(contexto); 
                        
            TypeHelper = new TypeHelper();
            DataFactory = new DataFactory();

            CopyHelper = new CopyHelper(DataFactory);
            DataHelper = DataHelper.Instancia;
            DefaultValueHelper = new DefaultValueHelper();
            EqualityHelper = EqualityHelper.Instancia;
            KeyHelper = KeyHelper.Instancia;

            //HelperProvider.HelperContext = this;
        }
        #endregion 


        #region Propiedades
        public CopyHelper CopyHelper
        {
            get;
            private set;
        }

        public Contexto Contexto
        {
            get => _contexto;
        }

        public DataFactory DataFactory
        {
            get;
            private set;
        }

        public DataHelper DataHelper
        {
            get;
            private set;
        }

        public DefaultValueHelper DefaultValueHelper
        {
            get;
            private set;
        }

        public EqualityHelper EqualityHelper
        {
            get;
            private set;
        }

        public KeyHelper KeyHelper
        {
            get;
            private set;
        }
        
        public TypeHelper TypeHelper
        {
            get;
            private set;
        }
        #endregion


        #region IHelperContext
        ICopyHelper IHelperContext.CopyHelper
        {
            get => CopyHelper;
        }
        
        IDataFactory IHelperContext.DataFactory
        {
            get => DataFactory;
        }

        IDataHelper IHelperContext.DataHelper
        {
            get => DataHelper;
        }

        IDefaultValueHelper IHelperContext.DefaultValueHelper
        {
            get => DefaultValueHelper;
        }

        IEqualityHelper IHelperContext.EqualityHelper
        {
            get => EqualityHelper;
        }

        IKeyHelper IHelperContext.KeyHelper
        {
            get => KeyHelper;
        }

        ITypeHelper IHelperContext.TypeHelper
        {
            get => TypeHelper;
        }
        #endregion

    }
}

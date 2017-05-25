using Binapsis.Presentacion.Editores;
using Binapsis.Presentacion.Win.Estilos;
using DevExpress.XtraEditors.Repository;
using System.ComponentModel;
using System.Data;
using System;

namespace Binapsis.Presentacion.Win
{
    public class Columna : IEditorColumna
    {
        DataColumn _dataColumn;
        Estilo _estilo;
        RepositoryItem _repositorio;

        public Columna()
        {
            _dataColumn = new DataColumn();
            InicializarEstilo();
        }

        protected virtual void InicializarEstilo()
        {
            Estilo = Estilo.TextSimpleEdit;
        }

        
        private void EstablecerEstilo(Estilo estilo)
        {
            _estilo = estilo;
            EstablecerEstilo(FabricaEstilo.Instancia.Crear(_estilo));
        }

        private void EstablecerEstilo(EstiloBase estilo)
        {
            EstablecerRepositorio(estilo.Repositorio);
        }

        protected virtual void EstablecerRepositorio(RepositoryItem repositorio)
        {
            _repositorio = repositorio;
        }

        internal DataColumn DataColumn
        {
            get { return _dataColumn; }
        }

        [DefaultValue(Estilo.TextSimpleEdit)]
        public virtual Estilo Estilo
        {
            get { return _estilo; }
            set { EstablecerEstilo(value); }
        }

        public string Nombre
        {
            get { return _dataColumn.ColumnName; }
            set { _dataColumn.ColumnName = value; }
        }

        internal RepositoryItem Repositorio
        {
            get { return _repositorio; }
            set { EstablecerRepositorio(value); }
        }

        public string Texto
        {
            get { return _dataColumn.Caption; }
            set { _dataColumn.Caption = value; }
        }

        public int Indice
        {
            get { return _dataColumn.Table.Columns.IndexOf(_dataColumn); }
        }
    }
}

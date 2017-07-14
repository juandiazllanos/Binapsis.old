namespace Binapsis.Plataforma.Datos.Impl
{
    public class Comando : ComandoBase
    {
        public Comando()
        {
            Parametros = new Parametros();
        }

        public virtual void EstablecerParametro(string nombre, object valor)
        {
            if (Parametros.Existe(nombre))
                Parametros[nombre].Valor = valor;            
        }

        public virtual object ObtenerParametro(string nombre)
        {            
            return Parametros[nombre].Valor;
        }

        public virtual object ObtenerParametro(int indice)
        {
            return Parametros[indice];            
        }

        public override void Ejecutar()
        {
            //Contexto?.EjecutarComando(this);
        }

        public Parametros Parametros
        {
            get;
        }

        public string Sql
        {
            get;
            set;
        }

    }
}

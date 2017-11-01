namespace Binapsis.Consola.Definicion
{
    public class ConsolaInfo
    {
        public ConsolaInfo()
        {
            Acciones = new Acciones(this);
            Assemblies = new Assemblies(this);
            Consultas = new Consultas(this);
            Contenidos = new Contenidos(this);
            Modelos = new Modelos(this);
            Trabajos = new Trabajos(this);
            Types = new Types(this);
            Vistas = new Vistas(this);
        }

        public Acciones Acciones
        {
            get;
        }

        public Assemblies Assemblies
        {
            get;
        }

        public Consultas Consultas
        {
            get;
        }

        public Contenidos Contenidos
        {
            get;
        }
        
        public Modelos Modelos
        {
            get;
        }   
        
        public Trabajos Trabajos
        {
            get;
        }

        public Types Types
        {
            get;
        }

        public Vistas Vistas
        {
            get;
        }
    }
}

using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Configuracion.Serializacion;
using Binapsis.Plataforma.Serializacion;
using Binapsis.Plataforma.Serializacion.Xml;
using Binapsis.Plataforma.Test.Serializacion.Helpers;
using Binapsis.Plataforma.Test.Serializacion.Impl;
using Binapsis.Plataforma.Test.Serializacion.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Binapsis.Plataforma.Test.Serializacion
{
    [TestClass]
    public class EvaluarSerializacionTypes
    {
        [TestMethod, TestCategory("Serializacion Types")]
        public void EvaluarBaseTypesEnXml()
        {
            ISecuencia fichero = new FicheroImpl("config.xml");
            IEscritor escritor = new EscritorXml();            
            Config configSalida = FabricaConfig.Instancia.Crear();
            HelperConfig.Instancia.Construir(configSalida);
            Serializador serializador = new Serializador(fichero, escritor);
            
            serializador.Serializar(configSalida);

            fichero = new FicheroImpl("config.xml");
            ILector lector = new LectorXml();
            Config configEntrada = FabricaConfig.Instancia.Crear();
            Deserializador deserializador = new Deserializador(fichero, lector);
            deserializador.Deserializar(configEntrada);

            Assert.AreEqual(configSalida.Tipos.Longitud, configEntrada.Tipos.Longitud);

        }

        [TestMethod, TestCategory("Serializacion Types")]
        public void EvaluarEnsambladoEnBinario()
        {
            Ensamblado ensamSystem = Fabrica.Instancia.Crear<Ensamblado>();
            ensamSystem.Nombre = "System";

            // serializar 
            ISerializador serializador = new SerializacionBinario(ensamSystem);
            serializador.Serializar();

            byte[] output = serializador.Contenido;

            // deserializar
            IDeserializador deserializador = new DeserializacionBinario(typeof(Ensamblado));            
            deserializador.Deserializar(output);
            Ensamblado ensamRecuperado = (deserializador.Objeto as Ensamblado);

            Assert.AreEqual(ensamSystem.Nombre, ensamRecuperado.Nombre);
        }


        [TestMethod, TestCategory("Serializacion Types")]
        public void EvaluarEnsambladoEnXml()
        {
            Ensamblado ensamSystem = Fabrica.Instancia.Crear<Ensamblado>();
            ensamSystem.Nombre = "System";

            // serializar
            ISerializador serializador = new SerializacionXml(ensamSystem);
            serializador.Serializar();

            byte[] output = serializador.Contenido;

            // deserializar
            IDeserializador deserializador = new DeserializacionXml(typeof(Ensamblado));
            deserializador.Deserializar(output);
            Ensamblado ensamRecuperado = (deserializador.Objeto as Ensamblado);

            Assert.AreEqual(ensamSystem.Nombre, ensamRecuperado.Nombre);
        }


        [TestMethod, TestCategory("Serializacion Types")]
        public void EvaluarUriEnBinario()
        {
            Ensamblado ensamConfig = Fabrica.Instancia.Crear<Ensamblado>();
            ensamConfig.Nombre = "Binapsis.Plataforma.Configuracion";

            Uri uriConfig = Fabrica.Instancia.Crear<Uri>();
            uriConfig.Ensamblado = ensamConfig;
            uriConfig.Nombre = "Binapsis.Plataforma.Configuracion";

            //serializar
            ISerializador serializador = new SerializacionBinario(uriConfig);
            serializador.Serializar();

            byte[] output = serializador.Contenido;

            // deserializar
            IDeserializador deserializador = new DeserializacionBinario(typeof(Uri));
            deserializador.Deserializar(output);

            Uri uriRecuperado = (deserializador.Objeto as Uri);

            Assert.AreEqual(uriConfig.Ensamblado.Nombre, uriRecuperado.Ensamblado.Nombre);
            Assert.AreEqual(uriConfig.Nombre, uriRecuperado.Nombre);
        }
    }
}

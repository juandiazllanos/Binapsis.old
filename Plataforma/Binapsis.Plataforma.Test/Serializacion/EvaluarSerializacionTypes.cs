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
            ILector lector = new LectorXml(FabricaConfiguracion.Instancia);
            Config configEntrada = FabricaConfig.Instancia.Crear();
            Deserializador deserializador = new Deserializador(fichero, lector);
            deserializador.Deserializar(configEntrada);

            Assert.AreEqual(configSalida.Tipos.Longitud, configEntrada.Tipos.Longitud);

        }

        [TestMethod, TestCategory("Serializacion Types")]
        public void EvaluarEnsambladoEnBinario()
        {
            Ensamblado ensamSystem = FabricaConfiguracion.Instancia.CrearEnsamblado("System");

            // serializar 
            SerializacionBase<Ensamblado> serializador = new SerializacionBinario<Ensamblado>(ensamSystem);
            serializador.Serializar();

            byte[] output = serializador.Contenido;

            // deserializar
            DeserializacionBase<Ensamblado> deserializador = new DeserializacionBinario<Ensamblado>();            
            deserializador.Deserializar(output);

            Assert.AreEqual(ensamSystem.Nombre, serializador.Objeto.Nombre);
        }


        [TestMethod, TestCategory("Serializacion Types")]
        public void EvaluarEnsambladoEnXml()
        {
            Ensamblado ensamSystem = FabricaConfiguracion.Instancia.CrearEnsamblado("System");

            // serializar
            SerializacionBase<Ensamblado> serializador = new SerializacionXml<Ensamblado>(ensamSystem);
            serializador.Serializar();

            byte[] output = serializador.Contenido;

            // deserializar
            DeserializacionBase<Ensamblado> deserializador = new DeserializacionXml<Ensamblado>();
            deserializador.Deserializar(output);

            Assert.AreEqual(ensamSystem.Nombre, serializador.Objeto.Nombre);
        }


        [TestMethod, TestCategory("Serializacion Types")]
        public void EvaluarUriEnBinario()
        {
            Ensamblado ensamConfig = FabricaConfiguracion.Instancia.CrearEnsamblado("Binapsis.Plataforma.Configuracion");
            Uri uriConfig = FabricaConfiguracion.Instancia.CrearUri(ensamConfig, "Binapsis.Plataforma.Configuracion");

            //serializar
            SerializacionBase<Uri> serializador = new SerializacionBinario<Uri>(uriConfig);
            serializador.Serializar();

            byte[] output = serializador.Contenido;

            // deserializar
            DeserializacionBase<Uri> deserializador = new DeserializacionBinario<Uri>();
            deserializador.Deserializar(output);

            Assert.AreEqual(uriConfig.Ensamblado.Nombre, serializador.Objeto.Ensamblado.Nombre);
            Assert.AreEqual(uriConfig.Nombre, serializador.Objeto.Nombre);
        }
    }
}

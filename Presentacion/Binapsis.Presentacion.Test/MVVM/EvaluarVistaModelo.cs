using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binapsis.Presentacion.MVVM.Mapeo;
using Binapsis.Presentacion.Test.MVVM.Impl;
using Binapsis.Presentacion.MVVM;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Test;
using Binapsis.Plataforma.Notificaciones.Impl;
using Binapsis.Presentacion.Editores;
using System.Reflection;
using System;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Presentacion.Test.MVVM
{
    [TestClass]
    public class EvaluarVistaModelo
    {
        [TestMethod, TestCategory("Evaluar Presentacion MVVM")]
        public void EstablecerMapeoPropiedad()
        {
            EditorObjeto editor = new EditorObjeto() { Nombre = "EditorObjeto" };
            EditorObjeto editorReferencia = new EditorObjeto() { Nombre = "EditorReferencia" };
            EditorColeccion editorColeccion = new EditorColeccion() { Nombre = "EditorColeccion" };
            

            MapeoTipo mapeo = new MapeoTipo();
            MapeoTipo mapeoReferencia = new MapeoTipo();
            MapeoTipo mapeoColeccion = new MapeoTipo();

            mapeoReferencia.Establecer("atributoBoolean", editorReferencia.EditorBoolean);
            mapeoReferencia.Establecer("atributoByte", editorReferencia.EditorByte);
            mapeoReferencia.Establecer("atributoChar", editorReferencia.EditorChar);
            mapeoReferencia.Establecer("atributoDateTime", editorReferencia.EditorDateTime);
            mapeoReferencia.Establecer("atributoDecimal", editorReferencia.EditorDecimal);
            mapeoReferencia.Establecer("atributoDouble", editorReferencia.EditorDouble);
            mapeoReferencia.Establecer("atributoFloat", editorReferencia.EditorFloat);
            mapeoReferencia.Establecer("atributoInteger", editorReferencia.EditorInteger);
            mapeoReferencia.Establecer("atributoLong", editorReferencia.EditorLong);
            mapeoReferencia.Establecer("atributoSByte", editorReferencia.EditorSByte);
            mapeoReferencia.Establecer("atributoShort", editorReferencia.EditorShort);
            mapeoReferencia.Establecer("atributoString", editorReferencia.EditorString);
            mapeoReferencia.Establecer("atributoUInteger", editorReferencia.EditorUInteger);
            mapeoReferencia.Establecer("atributoULong", editorReferencia.EditorULong);
            mapeoReferencia.Establecer("atributoUShort", editorReferencia.EditorUShort);

            mapeoColeccion.Establecer("atributoBoolean", editorColeccion.ColumnaBoolean);
            mapeoColeccion.Establecer("atributoByte", editorColeccion.ColumnaByte);
            mapeoColeccion.Establecer("atributoChar", editorColeccion.ColumnaChar);
            mapeoColeccion.Establecer("atributoDateTime", editorColeccion.ColumnaDateTime);
            mapeoColeccion.Establecer("atributoDecimal", editorColeccion.ColumnaDecimal);
            mapeoColeccion.Establecer("atributoDouble", editorColeccion.ColumnaDouble);
            mapeoColeccion.Establecer("atributoFloat", editorColeccion.ColumnaFloat);
            mapeoColeccion.Establecer("atributoInteger", editorColeccion.ColumnaInteger);
            mapeoColeccion.Establecer("atributoLong", editorColeccion.ColumnaLong);
            mapeoColeccion.Establecer("atributoSByte", editorColeccion.ColumnaSByte);
            mapeoColeccion.Establecer("atributoShort", editorColeccion.ColumnaShort);
            mapeoColeccion.Establecer("atributoString", editorColeccion.ColumnaString);
            mapeoColeccion.Establecer("atributoUInteger", editorColeccion.ColumnaUInteger);
            mapeoColeccion.Establecer("atributoULong", editorColeccion.ColumnaULong);
            mapeoColeccion.Establecer("atributoUShort", editorColeccion.ColumnaUShort);

            mapeo.Establecer("atributoBoolean", editor.EditorBoolean);
            mapeo.Establecer("atributoByte", editor.EditorByte);
            mapeo.Establecer("atributoChar", editor.EditorChar);
            mapeo.Establecer("atributoDateTime", editor.EditorDateTime);
            mapeo.Establecer("atributoDecimal", editor.EditorDecimal);
            mapeo.Establecer("atributoDouble", editor.EditorDouble);
            mapeo.Establecer("atributoFloat", editor.EditorFloat);
            mapeo.Establecer("atributoInteger", editor.EditorInteger);
            mapeo.Establecer("atributoLong", editor.EditorLong);
            mapeo.Establecer("atributoSByte", editor.EditorSByte);
            mapeo.Establecer("atributoShort", editor.EditorShort);
            mapeo.Establecer("atributoString", editor.EditorString);
            mapeo.Establecer("atributoUInteger", editor.EditorUInteger);
            mapeo.Establecer("atributoULong", editor.EditorULong);
            mapeo.Establecer("atributoUShort", editor.EditorUShort);
            mapeo.Establecer("ReferenciaObjetoDatos", mapeoReferencia);
            mapeo.Establecer("ReferenciaObjetoDatosItem", editorColeccion, mapeoColeccion);

            Assert.AreEqual("atributoBoolean", mapeo.Propiedades[0].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(mapeo.Propiedades[0].Editor.GetType()));
            Assert.AreEqual(editor.EditorBoolean, mapeo.Propiedades[0].Editor);

            Assert.AreEqual("atributoByte", mapeo.Propiedades[1].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(mapeo.Propiedades[1].Editor.GetType()));
            Assert.AreEqual(editor.EditorByte, mapeo.Propiedades[1].Editor);

            Assert.AreEqual("atributoChar", mapeo.Propiedades[2].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(mapeo.Propiedades[2].Editor.GetType()));
            Assert.AreEqual(editor.EditorChar, mapeo.Propiedades[2].Editor);

            Assert.AreEqual("atributoDateTime", mapeo.Propiedades[3].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(mapeo.Propiedades[3].Editor.GetType()));
            Assert.AreEqual(editor.EditorDateTime, mapeo.Propiedades[3].Editor);

            Assert.AreEqual("atributoDecimal", mapeo.Propiedades[4].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(mapeo.Propiedades[4].Editor.GetType()));
            Assert.AreEqual(editor.EditorDecimal, mapeo.Propiedades[4].Editor);

            Assert.AreEqual("atributoDouble", mapeo.Propiedades[5].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(mapeo.Propiedades[5].Editor.GetType()));
            Assert.AreEqual(editor.EditorDouble, mapeo.Propiedades[5].Editor);

            Assert.AreEqual("atributoFloat", mapeo.Propiedades[6].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(mapeo.Propiedades[6].Editor.GetType()));
            Assert.AreEqual(editor.EditorFloat, mapeo.Propiedades[6].Editor);

            Assert.AreEqual("atributoInteger", mapeo.Propiedades[7].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(mapeo.Propiedades[7].Editor.GetType()));
            Assert.AreEqual(editor.EditorInteger, mapeo.Propiedades[7].Editor);

            Assert.AreEqual("atributoLong", mapeo.Propiedades[8].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(mapeo.Propiedades[8].Editor.GetType()));
            Assert.AreEqual(editor.EditorLong, mapeo.Propiedades[8].Editor);

            Assert.AreEqual("atributoSByte", mapeo.Propiedades[9].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(mapeo.Propiedades[9].Editor.GetType()));
            Assert.AreEqual(editor.EditorSByte, mapeo.Propiedades[9].Editor);

            Assert.AreEqual("atributoShort", mapeo.Propiedades[10].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(mapeo.Propiedades[10].Editor.GetType()));
            Assert.AreEqual(editor.EditorShort, mapeo.Propiedades[10].Editor);

            Assert.AreEqual("atributoString", mapeo.Propiedades[11].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(mapeo.Propiedades[11].Editor.GetType()));
            Assert.AreEqual(editor.EditorString, mapeo.Propiedades[11].Editor);

            Assert.AreEqual("atributoUInteger", mapeo.Propiedades[12].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(mapeo.Propiedades[12].Editor.GetType()));
            Assert.AreEqual(editor.EditorUInteger, mapeo.Propiedades[12].Editor);

            Assert.AreEqual("atributoULong", mapeo.Propiedades[13].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(mapeo.Propiedades[13].Editor.GetType()));
            Assert.AreEqual(editor.EditorULong, mapeo.Propiedades[13].Editor);

            Assert.AreEqual("atributoUShort", mapeo.Propiedades[14].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(mapeo.Propiedades[14].Editor.GetType()));
            Assert.AreEqual(editor.EditorUShort, mapeo.Propiedades[14].Editor);

            Assert.AreEqual("ReferenciaObjetoDatos", mapeo.Propiedades[15].Propiedad.Nombre);
            Assert.AreEqual(typeof(MapeoReferencia), mapeo.Propiedades[15].GetType());
            Assert.IsNull(mapeo.Propiedades[15].Editor);
            Assert.AreEqual(mapeoReferencia, ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo);

            Assert.AreEqual("ReferenciaObjetoDatosItem", mapeo.Propiedades[16].Propiedad.Nombre);
            Assert.AreEqual(typeof(MapeoReferencia), mapeo.Propiedades[16].GetType());
            Assert.IsTrue(typeof(IEditorColeccion).IsAssignableFrom(mapeo.Propiedades[16].Editor.GetType()));
            Assert.AreEqual(editorColeccion, mapeo.Propiedades[16].Editor);
            Assert.AreEqual(mapeoColeccion, ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo);

            // editor referencia
            Assert.AreEqual("atributoBoolean", ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[0].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[0].Editor.GetType()));
            Assert.AreEqual(editorReferencia.EditorBoolean, ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[0].Editor);

            Assert.AreEqual("atributoByte", ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[1].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[1].Editor.GetType()));
            Assert.AreEqual(editorReferencia.EditorByte, ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[1].Editor);

            Assert.AreEqual("atributoChar", ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[2].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[2].Editor.GetType()));
            Assert.AreEqual(editorReferencia.EditorChar, ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[2].Editor);

            Assert.AreEqual("atributoDateTime", ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[3].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[3].Editor.GetType()));
            Assert.AreEqual(editorReferencia.EditorDateTime, ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[3].Editor);

            Assert.AreEqual("atributoDecimal", ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[4].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[4].Editor.GetType()));
            Assert.AreEqual(editorReferencia.EditorDecimal, ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[4].Editor);

            Assert.AreEqual("atributoDouble", ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[5].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[5].Editor.GetType()));
            Assert.AreEqual(editorReferencia.EditorDouble, ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[5].Editor);

            Assert.AreEqual("atributoFloat", ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[6].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[6].Editor.GetType()));
            Assert.AreEqual(editorReferencia.EditorFloat, ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[6].Editor);

            Assert.AreEqual("atributoInteger", ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[7].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[7].Editor.GetType()));
            Assert.AreEqual(editorReferencia.EditorInteger, ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[7].Editor);

            Assert.AreEqual("atributoLong", ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[8].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[8].Editor.GetType()));
            Assert.AreEqual(editorReferencia.EditorLong, ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[8].Editor);

            Assert.AreEqual("atributoSByte", ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[9].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[9].Editor.GetType()));
            Assert.AreEqual(editorReferencia.EditorSByte, ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[9].Editor);

            Assert.AreEqual("atributoShort", ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[10].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[10].Editor.GetType()));
            Assert.AreEqual(editorReferencia.EditorShort, ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[10].Editor);

            Assert.AreEqual("atributoString", ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[11].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[11].Editor.GetType()));
            Assert.AreEqual(editorReferencia.EditorString, ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[11].Editor);

            Assert.AreEqual("atributoUInteger", ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[12].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[12].Editor.GetType()));
            Assert.AreEqual(editorReferencia.EditorUInteger, ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[12].Editor);

            Assert.AreEqual("atributoULong", ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[13].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[13].Editor.GetType()));
            Assert.AreEqual(editorReferencia.EditorULong, ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[13].Editor);

            Assert.AreEqual("atributoUShort", ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[14].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[14].Editor.GetType()));
            Assert.AreEqual(editorReferencia.EditorUShort, ((MapeoReferencia)mapeo.Propiedades[15]).Mapeo.Propiedades[14].Editor);

            // editorColeccion
            Assert.AreEqual("atributoBoolean", ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[0].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorColumna).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[0].Editor.GetType()));
            Assert.AreEqual(editorColeccion.ColumnaBoolean, ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[0].Editor);

            Assert.AreEqual("atributoByte", ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[1].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorColumna).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[1].Editor.GetType()));
            Assert.AreEqual(editorColeccion.ColumnaByte, ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[1].Editor);

            Assert.AreEqual("atributoChar", ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[2].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorColumna).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[2].Editor.GetType()));
            Assert.AreEqual(editorColeccion.ColumnaChar, ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[2].Editor);

            Assert.AreEqual("atributoDateTime", ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[3].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorColumna).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[3].Editor.GetType()));
            Assert.AreEqual(editorColeccion.ColumnaDateTime, ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[3].Editor);

            Assert.AreEqual("atributoDecimal", ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[4].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorColumna).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[4].Editor.GetType()));
            Assert.AreEqual(editorColeccion.ColumnaDecimal, ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[4].Editor);

            Assert.AreEqual("atributoDouble", ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[5].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorColumna).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[5].Editor.GetType()));
            Assert.AreEqual(editorColeccion.ColumnaDouble, ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[5].Editor);

            Assert.AreEqual("atributoFloat", ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[6].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorColumna).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[6].Editor.GetType()));
            Assert.AreEqual(editorColeccion.ColumnaFloat, ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[6].Editor);

            Assert.AreEqual("atributoInteger", ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[7].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorColumna).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[7].Editor.GetType()));
            Assert.AreEqual(editorColeccion.ColumnaInteger, ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[7].Editor);

            Assert.AreEqual("atributoLong", ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[8].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorColumna).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[8].Editor.GetType()));
            Assert.AreEqual(editorColeccion.ColumnaLong, ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[8].Editor);

            Assert.AreEqual("atributoSByte", ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[9].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorColumna).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[9].Editor.GetType()));
            Assert.AreEqual(editorColeccion.ColumnaSByte, ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[9].Editor);

            Assert.AreEqual("atributoShort", ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[10].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorColumna).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[10].Editor.GetType()));
            Assert.AreEqual(editorColeccion.ColumnaShort, ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[10].Editor);

            Assert.AreEqual("atributoString", ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[11].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorColumna).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[11].Editor.GetType()));
            Assert.AreEqual(editorColeccion.ColumnaString, ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[11].Editor);

            Assert.AreEqual("atributoUInteger", ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[12].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorColumna).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[12].Editor.GetType()));
            Assert.AreEqual(editorColeccion.ColumnaUInteger, ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[12].Editor);

            Assert.AreEqual("atributoULong", ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[13].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorColumna).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[13].Editor.GetType()));
            Assert.AreEqual(editorColeccion.ColumnaULong, ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[13].Editor);

            Assert.AreEqual("atributoUShort", ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[14].Propiedad.Nombre);
            Assert.IsTrue(typeof(IEditorColumna).GetTypeInfo().IsAssignableFrom(((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[14].Editor.GetType()));
            Assert.AreEqual(editorColeccion.ColumnaUShort, ((MapeoReferencia)mapeo.Propiedades[16]).Mapeo.Propiedades[14].Editor);
        }

        [TestMethod, TestCategory("Evaluar Presentacion MVVM")]
        public void EstablecerVistaModelo1()
        {
            // modelo            
            IObjetoDatos od = TestHelper.Crear(HelperTipo.ObtenerTipo(), new FabricaDatos(FabricaNotificacion.Instancia));
            TestHelper.Construir(od);

            // vista
            EditorObjeto editor = new EditorObjeto() { Nombre = "EditorObjeto" };
            MapeoTipo mapeo = CrearMapeo(editor);

            Vista vista = new Vista(mapeo);
            VistaModelo vistaModelo = new VistaModelo(vista);
            vistaModelo.Establecer(od);

            // evaluar
            Evaluar(od, editor);
        }

        [TestMethod, TestCategory("Evaluar Presentacion MVVM")]
        public void EstablecerVistaModelo2()
        {
            // modelo            
            IObjetoDatos od = TestHelper.Crear(HelperTipo.ObtenerTipo(), new FabricaDatos(FabricaNotificacion.Instancia));
            TestHelper.Construir(od, 1);

            // vista
            EditorObjeto editor = new EditorObjeto() { Nombre = "EditorReferencia" };
            MapeoTipo mapeo = CrearMapeo(null, editor);

            Vista vista = new Vista(mapeo);
            VistaModelo vistaModelo = new VistaModelo(vista);
            vistaModelo.Establecer(od);

            // evaluar
            Evaluar(od.ObtenerObjetoDatos("ReferenciaObjetoDatos"), editor);
        }

        [TestMethod, TestCategory("Evaluar Presentacion MVVM")]
        public void EstablecerVistaModelo3()
        {
            // modelo            
            IObjetoDatos od = TestHelper.Crear(HelperTipo.ObtenerTipo2(), new FabricaDatos(FabricaNotificacion.Instancia));
            IObjetoDatos od2 = TestHelper.Crear(HelperTipo.ObtenerTipo());
            TestHelper.Construir(od, 1);
            TestHelper.Construir(od2, 1);

            // vista
            EditorObjeto editor = new EditorObjeto() { Nombre = "EditorReferencia" };
            MapeoTipo mapeoReferencia = CrearMapeo(editor);
            MapeoTipo mapeo = new MapeoTipo();
            mapeo.Establecer("ReferenciaObjetoDatos2", mapeoReferencia);

            Vista vista = new Vista(mapeo);
            VistaModelo vistaModelo = new VistaModelo(vista);
            vistaModelo.Establecer(od);

            // evaluar
            Evaluar(od.ObtenerObjetoDatos("ReferenciaObjetoDatos2"), editor, false);

            // asignar null
            od.EstablecerObjetoDatos("ReferenciaObjetoDatos2", null);

            // evaluar
            Evaluar(od.ObtenerObjetoDatos("ReferenciaObjetoDatos2"), editor, false);

            // establecer nuevo valor 
            od.EstablecerObjetoDatos("ReferenciaObjetoDatos2",  od2);

            // evaluar
            Evaluar(od.ObtenerObjetoDatos("ReferenciaObjetoDatos2"), editor, false);
        }

        [TestMethod, TestCategory("Evaluar Presentacion MVVM")]
        public void EstablecerVistaModelo4()
        {
            // modelo            
            IObjetoDatos od = TestHelper.Crear(HelperTipo.ObtenerTipo(), new FabricaDatos(FabricaNotificacion.Instancia));
            TestHelper.Construir(od, 1, 2);

            // vista
            EditorColeccion editor = new EditorColeccion() { Nombre = "EditorColeccion" };
            MapeoTipo mapeo = CrearMapeo(null, null, editor);

            Vista vista = new Vista(mapeo);
            VistaModelo vistaModelo = new VistaModelo(vista);
            vistaModelo.Establecer(od);

            // evaluar fila 1
            Evaluar(od.ObtenerColeccion("ReferenciaObjetoDatosItem")[0], editor.Items[0]);

            // evaluar fila 2
            Evaluar(od.ObtenerColeccion("ReferenciaObjetoDatosItem")[1], editor.Items[1]);

            // eliminar fila 2
            od.RemoverObjetoDatos("ReferenciaObjetoDatosItem", od.ObtenerColeccion("ReferenciaObjetoDatosItem")[1]);

            // evaluar 
            Assert.AreEqual(od.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud, editor.Items.Count);

            // eliminar fila 1
            od.RemoverObjetoDatos("ReferenciaObjetoDatosItem", od.ObtenerColeccion("ReferenciaObjetoDatosItem")[0]);

            // evaluar 
            Assert.AreEqual(od.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud, editor.Items.Count);

        }

        [TestMethod, TestCategory("Evaluar Presentacion MVVM")]
        public void EstablecerVistaModelo5()
        {
            // modelo            
            IObjetoDatos od = TestHelper.Crear(HelperTipo.ObtenerTipo(), new FabricaDatos(FabricaNotificacion.Instancia));
            TestHelper.Construir(od, 1, 2);

            // vista
            EditorColeccion editor = new EditorColeccion() { Nombre = "EditorColeccion" };
            MapeoTipo mapeo = CrearMapeo(null, null, editor);

            Vista vista = new Vista(mapeo);
            VistaModelo vistaModelo = new VistaModelo(vista);
            vistaModelo.Establecer(od);

            // crear referencia en item 1
            od.ObtenerColeccion("ReferenciaObjetoDatosItem")[0].CrearObjetoDatos("ReferenciaObjetoDatos");

            // establecer valores 
            TestHelper.Construir(od.ObtenerColeccion("ReferenciaObjetoDatosItem")[0].ObtenerObjetoDatos("ReferenciaObjetoDatos"));

            // evaluar
            Evaluar(od.ObtenerColeccion("ReferenciaObjetoDatosItem")[0].ObtenerObjetoDatos("ReferenciaObjetoDatos"), editor.Items[0], "EditorColeccionReferencia.");

            // establecer referencia en item 1 en null
            od.ObtenerColeccion("ReferenciaObjetoDatosItem")[0].EstablecerObjetoDatos("ReferenciaObjetoDatos", null);

            // evaluar
            Evaluar(od.ObtenerColeccion("ReferenciaObjetoDatosItem")[0].ObtenerObjetoDatos("ReferenciaObjetoDatos"), editor.Items[0], "EditorColeccionReferencia.");
        }

        [TestMethod, TestCategory("Evaluar Presentacion MVVM")]
        public void EstablecerVistaModelo6()
        {
            // modelo            
            IObjetoDatos od = TestHelper.Crear(HelperTipo.ObtenerTipo(), new FabricaDatos(FabricaNotificacion.Instancia));
            TestHelper.Construir(od, 1, 2);

            // vista
            EditorColeccion editor = new EditorColeccion() { Nombre = "EditorColeccion" };
            MapeoTipo mapeo = CrearMapeo(null, null, editor);

            IComando comandoAgregar = new ComandoCrearObjetoDatos("ReferenciaObjetoDatosItem");
            IComando comandoRemover = new ComandoRemoverObjetoDatos("ReferenciaObjetoDatosItem");
            EditorComando invocadorAgregar = new EditorComando("AgregarItem");
            EditorComando invocadorRemover = new EditorComando("RemoverItem");

            mapeo.EstablecerComando(invocadorAgregar, comandoAgregar);
            mapeo.EstablecerComando(invocadorRemover, comandoRemover);

            Vista vista = new Vista(mapeo);
            VistaModelo vistaModelo = new VistaModelo(vista);
            vistaModelo.Establecer(od);

            Assert.AreEqual(2, od.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud);

            // agregar item
            invocadorAgregar.Invocar();

            Assert.AreEqual(3, od.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud);

            // remover item
            invocadorRemover.Invocar();

            Assert.AreEqual(2, od.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud);

        }

        private void Evaluar(IObjetoDatos od, EditorObjetoBase editor)
        {
            Evaluar(od, editor, true);
        }

        private void Evaluar(IObjetoDatos od, EditorObjetoBase editor, bool esObservable)
        {
            Evaluar(od, editor, esObservable, "");
        }

        private void Evaluar(IObjetoDatos od, EditorObjetoBase editor, string prefijoEditor)
        {
            Evaluar(od, editor, true, prefijoEditor);
        }

        private void Evaluar(IObjetoDatos od, EditorObjetoBase editor, bool esObservable, string prefijoEditor)
        {
            // evaluar datos iniciales
            Assert.AreEqual(od?.ObtenerBoolean("atributoBoolean"), editor[string.Format("{0}EditorBoolean", prefijoEditor)].Valor);
            Assert.AreEqual(od?.ObtenerByte("atributoByte"), editor[string.Format("{0}EditorByte", prefijoEditor)].Valor);
            Assert.AreEqual(od?.ObtenerChar("atributoChar"), editor[string.Format("{0}EditorChar", prefijoEditor)].Valor);
            Assert.AreEqual(od?.ObtenerDateTime("atributoDateTime"), editor[string.Format("{0}EditorDateTime", prefijoEditor)].Valor);
            Assert.AreEqual(od?.ObtenerDecimal("atributoDecimal"), editor[string.Format("{0}EditorDecimal", prefijoEditor)].Valor);
            Assert.AreEqual(od?.ObtenerDouble("atributoDouble"), editor[string.Format("{0}EditorDouble", prefijoEditor)].Valor);
            Assert.AreEqual(od?.ObtenerFloat("atributoFloat"), editor[string.Format("{0}EditorFloat", prefijoEditor)].Valor);
            Assert.AreEqual(od?.ObtenerInteger("atributoInteger"), editor[string.Format("{0}EditorInteger", prefijoEditor)].Valor);
            Assert.AreEqual(od?.ObtenerLong("atributoLong"), editor[string.Format("{0}EditorLong", prefijoEditor)].Valor);
            Assert.AreEqual(od?.ObtenerSByte("atributoSByte"), editor[string.Format("{0}EditorSByte", prefijoEditor)].Valor);
            Assert.AreEqual(od?.ObtenerShort("atributoShort"), editor[string.Format("{0}EditorShort", prefijoEditor)].Valor);
            Assert.AreEqual(od?.ObtenerString("atributoString"), editor[string.Format("{0}EditorString", prefijoEditor)].Valor);
            Assert.AreEqual(od?.ObtenerUInteger("atributoUInteger"), editor[string.Format("{0}EditorUInteger", prefijoEditor)].Valor);
            Assert.AreEqual(od?.ObtenerULong("atributoULong"), editor[string.Format("{0}EditorULong", prefijoEditor)].Valor);
            Assert.AreEqual(od?.ObtenerUShort("atributoUShort"), editor[string.Format("{0}EditorUShort", prefijoEditor)].Valor);

            if (!esObservable || od == null) return;

            // editar valores vista
            editor[string.Format("{0}EditorBoolean", prefijoEditor)].Valor = true;
            editor[string.Format("{0}EditorByte", prefijoEditor)].Valor = (byte)15;
            editor[string.Format("{0}EditorChar", prefijoEditor)].Valor = 'F';
            editor[string.Format("{0}EditorDateTime", prefijoEditor)].Valor = new DateTime(2017, 1, 7);
            editor[string.Format("{0}EditorDecimal", prefijoEditor)].Valor = (decimal)1420.3102;
            editor[string.Format("{0}EditorDouble", prefijoEditor)].Valor = 78950.2561;
            editor[string.Format("{0}EditorFloat", prefijoEditor)].Valor = (float)52014.5201;
            editor[string.Format("{0}EditorInteger", prefijoEditor)].Valor = -31285;
            editor[string.Format("{0}EditorLong", prefijoEditor)].Valor = (long)458790;
            editor[string.Format("{0}EditorSByte", prefijoEditor)].Valor = (sbyte)125;
            editor[string.Format("{0}EditorShort", prefijoEditor)].Valor = (short)5896.56;
            editor[string.Format("{0}EditorString", prefijoEditor)].Valor = "valor string en vista";
            editor[string.Format("{0}EditorUInteger", prefijoEditor)].Valor = (uint)112520;
            editor[string.Format("{0}EditorULong", prefijoEditor)].Valor = (ulong)789954002;
            editor[string.Format("{0}EditorUShort", prefijoEditor)].Valor = (ushort)45520;
            
            // evaluar valores modificados en la vista
            Assert.AreEqual(editor[string.Format("{0}EditorBoolean", prefijoEditor)].Valor, od.ObtenerBoolean("atributoBoolean"));
            Assert.AreEqual(editor[string.Format("{0}EditorByte", prefijoEditor)].Valor, od.ObtenerByte("atributoByte"));
            Assert.AreEqual(editor[string.Format("{0}EditorChar", prefijoEditor)].Valor, od.ObtenerChar("atributoChar"));
            Assert.AreEqual(editor[string.Format("{0}EditorDateTime", prefijoEditor)].Valor, od.ObtenerDateTime("atributoDateTime"));
            Assert.AreEqual(editor[string.Format("{0}EditorDecimal", prefijoEditor)].Valor, od.ObtenerDecimal("atributoDecimal"));
            Assert.AreEqual(editor[string.Format("{0}EditorDouble", prefijoEditor)].Valor, od.ObtenerDouble("atributoDouble"));
            Assert.AreEqual(editor[string.Format("{0}EditorFloat", prefijoEditor)].Valor, od.ObtenerFloat("atributoFloat"));
            Assert.AreEqual(editor[string.Format("{0}EditorInteger", prefijoEditor)].Valor, od.ObtenerInteger("atributoInteger"));
            Assert.AreEqual(editor[string.Format("{0}EditorLong", prefijoEditor)].Valor, od.ObtenerLong("atributoLong"));
            Assert.AreEqual(editor[string.Format("{0}EditorSByte", prefijoEditor)].Valor, od.ObtenerSByte("atributoSByte"));
            Assert.AreEqual(editor[string.Format("{0}EditorShort", prefijoEditor)].Valor, od.ObtenerShort("atributoShort"));
            Assert.AreEqual(editor[string.Format("{0}EditorString", prefijoEditor)].Valor, od.ObtenerString("atributoString"));
            Assert.AreEqual(editor[string.Format("{0}EditorUInteger", prefijoEditor)].Valor, od.ObtenerUInteger("atributoUInteger"));
            Assert.AreEqual(editor[string.Format("{0}EditorULong", prefijoEditor)].Valor, od.ObtenerULong("atributoULong"));
            Assert.AreEqual(editor[string.Format("{0}EditorUShort", prefijoEditor)].Valor, od.ObtenerUShort("atributoUShort"));


            // establecer valores en el modelo
            od.EstablecerBoolean("atributoBoolean", false); 
            od.EstablecerByte("atributoByte", 120);
            od.EstablecerChar("atributoChar", 'G');
            od.EstablecerDateTime("atributoDateTime", new DateTime(2011,5,8));
            od.EstablecerDecimal("atributoDecimal", (decimal)458620.0123); 
            od.EstablecerDouble("atributoDouble", 63582.0215); 
            od.EstablecerFloat("atributoFloat", 8552170); 
            od.EstablecerInteger("atributoInteger", -10015); 
            od.EstablecerLong("atributoLong", 84201011); 
            od.EstablecerSByte("atributoSByte", sbyte.MaxValue); 
            od.EstablecerShort("atributoShort", 8511); 
            od.EstablecerString("atributoString", "valor string en modelo");
            od.EstablecerUInteger("atributoUInteger", 78554);
            od.EstablecerULong("atributoULong", 4587452); 
            od.EstablecerUShort("atributoUShort", 7896);

            // evaluar datos modificados en el modelo
            Assert.AreEqual(od.ObtenerBoolean("atributoBoolean"), editor[string.Format("{0}EditorBoolean", prefijoEditor)].Valor);
            Assert.AreEqual(od.ObtenerByte("atributoByte"), editor[string.Format("{0}EditorByte", prefijoEditor)].Valor);
            Assert.AreEqual(od.ObtenerChar("atributoChar"), editor[string.Format("{0}EditorChar", prefijoEditor)].Valor);
            Assert.AreEqual(od.ObtenerDateTime("atributoDateTime"), editor[string.Format("{0}EditorDateTime", prefijoEditor)].Valor);
            Assert.AreEqual(od.ObtenerDecimal("atributoDecimal"), editor[string.Format("{0}EditorDecimal", prefijoEditor)].Valor);
            Assert.AreEqual(od.ObtenerDouble("atributoDouble"), editor[string.Format("{0}EditorDouble", prefijoEditor)].Valor);
            Assert.AreEqual(od.ObtenerFloat("atributoFloat"), editor[string.Format("{0}EditorFloat", prefijoEditor)].Valor);
            Assert.AreEqual(od.ObtenerInteger("atributoInteger"), editor[string.Format("{0}EditorInteger", prefijoEditor)].Valor);
            Assert.AreEqual(od.ObtenerLong("atributoLong"), editor[string.Format("{0}EditorLong", prefijoEditor)].Valor);
            Assert.AreEqual(od.ObtenerSByte("atributoSByte"), editor[string.Format("{0}EditorSByte", prefijoEditor)].Valor);
            Assert.AreEqual(od.ObtenerShort("atributoShort"), editor[string.Format("{0}EditorShort", prefijoEditor)].Valor);
            Assert.AreEqual(od.ObtenerString("atributoString"), editor[string.Format("{0}EditorString", prefijoEditor)].Valor);
            Assert.AreEqual(od.ObtenerUInteger("atributoUInteger"), editor[string.Format("{0}EditorUInteger", prefijoEditor)].Valor);
            Assert.AreEqual(od.ObtenerULong("atributoULong"), editor[string.Format("{0}EditorULong", prefijoEditor)].Valor);
            Assert.AreEqual(od.ObtenerUShort("atributoUShort"), editor[string.Format("{0}EditorUShort", prefijoEditor)].Valor);

        }

        private MapeoTipo CrearMapeo(EditorObjeto editor)
        {
            return CrearMapeo(editor, null);
        }

        private MapeoTipo CrearMapeo(EditorObjeto editor, EditorObjeto editorReferencia)
        {
            return CrearMapeo(editor, editorReferencia, null);
        }

        private MapeoTipo CrearMapeo(EditorObjeto editor, EditorObjeto editorReferencia, EditorColeccion editorColeccion)
        {
            MapeoTipo mapeo = new MapeoTipo();
            
            if (editor != null)
            {
                mapeo.Establecer("atributoBoolean", editor.EditorBoolean);
                mapeo.Establecer("atributoByte", editor.EditorByte);
                mapeo.Establecer("atributoChar", editor.EditorChar);
                mapeo.Establecer("atributoDateTime", editor.EditorDateTime);
                mapeo.Establecer("atributoDecimal", editor.EditorDecimal);
                mapeo.Establecer("atributoDouble", editor.EditorDouble);
                mapeo.Establecer("atributoFloat", editor.EditorFloat);
                mapeo.Establecer("atributoInteger", editor.EditorInteger);
                mapeo.Establecer("atributoLong", editor.EditorLong);
                mapeo.Establecer("atributoSByte", editor.EditorSByte);
                mapeo.Establecer("atributoShort", editor.EditorShort);
                mapeo.Establecer("atributoString", editor.EditorString);
                mapeo.Establecer("atributoUInteger", editor.EditorUInteger);
                mapeo.Establecer("atributoULong", editor.EditorULong);
                mapeo.Establecer("atributoUShort", editor.EditorUShort);
            }

            if (editorReferencia != null)
            {
                MapeoTipo mapeoReferencia = new MapeoTipo();

                mapeoReferencia.Establecer("atributoBoolean", editorReferencia.EditorBoolean);
                mapeoReferencia.Establecer("atributoByte", editorReferencia.EditorByte);
                mapeoReferencia.Establecer("atributoChar", editorReferencia.EditorChar);
                mapeoReferencia.Establecer("atributoDateTime", editorReferencia.EditorDateTime);
                mapeoReferencia.Establecer("atributoDecimal", editorReferencia.EditorDecimal);
                mapeoReferencia.Establecer("atributoDouble", editorReferencia.EditorDouble);
                mapeoReferencia.Establecer("atributoFloat", editorReferencia.EditorFloat);
                mapeoReferencia.Establecer("atributoInteger", editorReferencia.EditorInteger);
                mapeoReferencia.Establecer("atributoLong", editorReferencia.EditorLong);
                mapeoReferencia.Establecer("atributoSByte", editorReferencia.EditorSByte);
                mapeoReferencia.Establecer("atributoShort", editorReferencia.EditorShort);
                mapeoReferencia.Establecer("atributoString", editorReferencia.EditorString);
                mapeoReferencia.Establecer("atributoUInteger", editorReferencia.EditorUInteger);
                mapeoReferencia.Establecer("atributoULong", editorReferencia.EditorULong);
                mapeoReferencia.Establecer("atributoUShort", editorReferencia.EditorUShort);

                mapeo.Establecer("ReferenciaObjetoDatos", mapeoReferencia);
            }
            
            if (editorColeccion != null)
            {
                MapeoTipo mapeoColeccion = new MapeoTipo();

                mapeoColeccion.Establecer("atributoBoolean", editorColeccion.ColumnaBoolean);
                mapeoColeccion.Establecer("atributoByte", editorColeccion.ColumnaByte);
                mapeoColeccion.Establecer("atributoChar", editorColeccion.ColumnaChar);
                mapeoColeccion.Establecer("atributoDateTime", editorColeccion.ColumnaDateTime);
                mapeoColeccion.Establecer("atributoDecimal", editorColeccion.ColumnaDecimal);
                mapeoColeccion.Establecer("atributoDouble", editorColeccion.ColumnaDouble);
                mapeoColeccion.Establecer("atributoFloat", editorColeccion.ColumnaFloat);
                mapeoColeccion.Establecer("atributoInteger", editorColeccion.ColumnaInteger);
                mapeoColeccion.Establecer("atributoLong", editorColeccion.ColumnaLong);
                mapeoColeccion.Establecer("atributoSByte", editorColeccion.ColumnaSByte);
                mapeoColeccion.Establecer("atributoShort", editorColeccion.ColumnaShort);
                mapeoColeccion.Establecer("atributoString", editorColeccion.ColumnaString);
                mapeoColeccion.Establecer("atributoUInteger", editorColeccion.ColumnaUInteger);
                mapeoColeccion.Establecer("atributoULong", editorColeccion.ColumnaULong);
                mapeoColeccion.Establecer("atributoUShort", editorColeccion.ColumnaUShort);

                if (editorColeccion.ColumnaReferencia != null)
                {
                    MapeoTipo mapeoColeccionReferencia = new MapeoTipo();

                    mapeoColeccionReferencia.Establecer("atributoBoolean", editorColeccion.ColumnaReferencia.ColumnaBoolean);
                    mapeoColeccionReferencia.Establecer("atributoByte", editorColeccion.ColumnaReferencia.ColumnaByte);
                    mapeoColeccionReferencia.Establecer("atributoChar", editorColeccion.ColumnaReferencia.ColumnaChar);
                    mapeoColeccionReferencia.Establecer("atributoDateTime", editorColeccion.ColumnaReferencia.ColumnaDateTime);
                    mapeoColeccionReferencia.Establecer("atributoDecimal", editorColeccion.ColumnaReferencia.ColumnaDecimal);
                    mapeoColeccionReferencia.Establecer("atributoDouble", editorColeccion.ColumnaReferencia.ColumnaDouble);
                    mapeoColeccionReferencia.Establecer("atributoFloat", editorColeccion.ColumnaReferencia.ColumnaFloat);
                    mapeoColeccionReferencia.Establecer("atributoInteger", editorColeccion.ColumnaReferencia.ColumnaInteger);
                    mapeoColeccionReferencia.Establecer("atributoLong", editorColeccion.ColumnaReferencia.ColumnaLong);
                    mapeoColeccionReferencia.Establecer("atributoSByte", editorColeccion.ColumnaReferencia.ColumnaSByte);
                    mapeoColeccionReferencia.Establecer("atributoShort", editorColeccion.ColumnaReferencia.ColumnaShort);
                    mapeoColeccionReferencia.Establecer("atributoString", editorColeccion.ColumnaReferencia.ColumnaString);
                    mapeoColeccionReferencia.Establecer("atributoUInteger", editorColeccion.ColumnaReferencia.ColumnaUInteger);
                    mapeoColeccionReferencia.Establecer("atributoULong", editorColeccion.ColumnaReferencia.ColumnaULong);
                    mapeoColeccionReferencia.Establecer("atributoUShort", editorColeccion.ColumnaReferencia.ColumnaUShort);

                    mapeoColeccion.Establecer("ReferenciaObjetoDatos", mapeoColeccionReferencia);
                }

                mapeo.Establecer("ReferenciaObjetoDatosItem", editorColeccion, mapeoColeccion); 
            }

            
            return mapeo;
        }
    }
}

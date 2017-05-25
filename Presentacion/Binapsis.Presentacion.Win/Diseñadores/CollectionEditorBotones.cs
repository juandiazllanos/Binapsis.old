using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binapsis.Presentacion.Win.Diseñadores
{
    public class CollectionEditorBotones : CollectionEditor
    {
        // Define a static event to expose the inner PropertyGrid's
        // PropertyValueChanged event args...
        public delegate void MyPropertyValueChangedEventHandler(object sender,
                                            PropertyValueChangedEventArgs e);

        public static event MyPropertyValueChangedEventHandler MyPropertyValueChanged;


        // Inherit the default constructor from the standard
        // Collection Editor...
        public CollectionEditorBotones(Type type) 
            : base(type)
        {
        }

        // Override this method in order to access the containing user controls
        // from the default Collection Editor form or to add new ones...
        protected override CollectionForm CreateCollectionForm()
        {
            // Getting the default layout of the Collection Editor...
            CollectionForm collectionForm = base.CreateCollectionForm();
            Form frmCollectionEditorForm = collectionForm as Form;
            TableLayoutPanel tlpLayout = frmCollectionEditorForm.Controls[0] as TableLayoutPanel;

            if (tlpLayout != null)
            {
                // Get a reference to the inner PropertyGrid and hook
                // an event handler to it.
                if (tlpLayout.Controls[5] is PropertyGrid)
                {
                    PropertyGrid propertyGrid = tlpLayout.Controls[5] as PropertyGrid;
                    propertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(propertyGrid_PropertyValueChanged);
                }
            }

            return collectionForm;
        }

        void propertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
        {
            // Fire our customized collection event...
            MyPropertyValueChanged?.Invoke(this, e);
        }

        protected override Type[] CreateNewItemTypes()
        {
            Type[] types = new Type[] {
                typeof(Boton)
            };

            return types;
        }
    }
}

using System.Collections;
using System.Windows.Forms.Design;

namespace Binapsis.Presentacion.Editores.Win.Diseñadores
{
    public class ControlDesignerEditor : ControlDesigner
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterAttributes(properties);

            string[] props = {
                    "AllowDrop",
                    "AccessibleDescription",
                    "AccessibleName",
                    "AccessibleRole",
                    "AutoScroll",
                    "AutoScrollMargin",
                    "AutoScrollMinSize",
                    "AutoScrollOffset",
                    "AutoSize",
                    "AutoSizeMode",
                    "AutoValidate",
                    "BackColor",
                    "BackgroundImage",
                    "BackgroundImageLayout",
                    "BindingContext",
                    "BorderStyle",
                    "CausesValidation",
                    "ContextMenu",
                    "ContextMenuStrip",
                    "Cursor",
                    "Font",
                    "ForeColor",
                    "GenerateMember",
                    "ImeMode",
                    "Margin",
                    "MaximumSize",
                    "MinimumSize",
                    "Padding",
                    "RightToLeft",
                    "Tag",
                    "Site",
                    "Visible",
                    "UseWaitCursor" };

            foreach (string property in props)
                properties.Remove(property);
        }
    }
}

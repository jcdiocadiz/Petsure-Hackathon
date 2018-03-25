using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet_Notes.Model;

namespace Pet_Notes.Configuration
{
     public static class PetNotesConfig
    {
        public static TextboxModel  textboxProperties { get; set; }
        public static PanelPropModel panelProperties { get; set; }
        public static ButtonPropModel buttonProperties { get; set; }
     
        
        public static TextboxModel SetDefaultTextboxProperties()
        {
           return new TextboxModel()
            {
                Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192))))),
                DefaultExpandedHeight = 120,
                DefaultCollapseHeight = 30,
                DefaultPrefixName = "txtNote_",
                X = 0,
                Y = 30
        };
        }

        public static PanelPropModel SetPanelProperties()
        {
            return new PanelPropModel() {
                DefaultPanelHeight = 30,
                DefaultTextboxProperties = textboxProperties
            };

        }
        public static ButtonPropModel SetButtonProperties()
        {
            return new ButtonPropModel() {
                ExpandCollapsePrefixName = "btnExpandCollapse_",
                Height = 30,
                Width = 30,
                X = 0,
                Y = 0
            };

        }


    }
}

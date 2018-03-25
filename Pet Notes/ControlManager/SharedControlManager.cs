using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet_Notes.Configuration;
using Pet_Notes.DataService;
using System.Windows.Forms;

namespace Pet_Notes.ControlManager
{
    public static   class SharedControlManager
    {
        public static int _formWidth;

        public static Control.ControlCollection panelControl;

        public static Control Panel;
        public static async Task LoadAllControls()
        {
        
            PetNotesConfig.textboxProperties.Y = 30;
            PetNotesConfig.buttonProperties.Y = 0;
            
            foreach (var a in PetNotesDataAdapter._dataModel)
            {
              
              TextboxManager.AddControl(a);
              ButtonManager.AddControl(a);
                Panel.Height = PetNotesConfig.textboxProperties.Y + PetNotesConfig.textboxProperties.DefaultExpandedHeight + (PetNotesConfig.panelProperties.DefaultPanelHeight *2); 
                if (a.IsActive)
                {

                    PetNotesConfig.textboxProperties.Y += PetNotesConfig.textboxProperties.DefaultExpandedHeight + PetNotesConfig.panelProperties.DefaultPanelHeight;

                    PetNotesConfig.buttonProperties.Y += PetNotesConfig.textboxProperties.DefaultExpandedHeight + PetNotesConfig.panelProperties.DefaultPanelHeight;
                }
                else
                {
                    PetNotesConfig.textboxProperties.Y += PetNotesConfig.textboxProperties.DefaultCollapseHeight + PetNotesConfig.panelProperties.DefaultPanelHeight;

                    PetNotesConfig.buttonProperties.Y += PetNotesConfig.textboxProperties.DefaultCollapseHeight + PetNotesConfig.panelProperties.DefaultPanelHeight;
                }
            }
        }

        public static async Task ClearAllControls()
        {

            SharedControlManager.panelControl.Clear();
        }

        public static async Task ResizePanel(int width)
        {
            Panel.Width = width - 36;
            panelControl.OfType<TextBox>().ToList().ForEach(c =>
            {
                c.Width = width - 36;


            });

        }
    }
}

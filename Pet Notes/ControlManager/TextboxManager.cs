using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing; 
using Pet_Notes.Configuration;
using Pet_Notes.Model;
using Pet_Notes.DataService;
using Pet_Notes.ControlManager;
namespace Pet_Notes.ControlManager
{
    public static class TextboxManager
    {
        //Variables    
        //Form data 
        //Data 
        
        public static void AddControl(PetNotesModel _data)
        {
            TextBox newTextbox = new TextBox()
            {
                Text = _data.Notes,
                BorderStyle = BorderStyle.None,
                Multiline = true,
                Name = _data.PetNotesID,
                BackColor = _data.Color,             
                Size =   GetSizeByNoteStatus(_data.IsActive),
                Location = new Point(PetNotesConfig.textboxProperties.X, PetNotesConfig.textboxProperties.Y)

            };
            newTextbox.TextChanged += new System.EventHandler(PetNotesTextbox_TextChanged);
            SharedControlManager.panelControl.Add(newTextbox);
            newTextbox.Focus();
        }

        public static async Task ResizeTextboxes(int newWidth)
        {
            SharedControlManager._formWidth = newWidth;
            SharedControlManager.LoadAllControls();
        }
        private static void PetNotesTextbox_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            UpdateModelFromTextbox(textbox.Name, textbox.Text);

        }

        private static async Task UpdateModelFromTextbox(string textboxName, string Notes)
        {
            PetNotesDataAdapter._dataModel.SingleOrDefault(c => c.PetNotesID == textboxName).Notes = Notes;

        }       

        //public static async Task LoadAllTextboxesControl()
        //{
        //    PetNotesConfig.textboxProperties.Y = 30;

        //    foreach (var a in PetNotesDataAdapter._dataModel)
        //    {
        //        await AddControl(a);
        //        if (a.IsActive)
        //            PetNotesConfig.textboxProperties.Y += PetNotesConfig.textboxProperties.DefaultExpandedHeight + PetNotesConfig.panelProperties.DefaultPanelHeight;
        //        else
        //            PetNotesConfig.textboxProperties.Y += PetNotesConfig.textboxProperties.DefaultCollapseHeight + PetNotesConfig.panelProperties.DefaultPanelHeight;
        //    }    
        //}

        public static async Task DeactivatePreviousNotes()
        {
            if (PetNotesDataAdapter._dataModel != null)
                PetNotesDataAdapter._dataModel.Where(c => c.IsActive == true).ToList().ForEach(d => {
                d.IsActive = false;
            });

        }
        public static async Task FocusOnLastActiveTextbox()
        {
            var getLastRecord = PetNotesDataAdapter._dataModel.LastOrDefault();
            TextBox textbox = SharedControlManager.panelControl.Find(getLastRecord.ControlGroupID.ToString(), true).OfType<TextBox>().SingleOrDefault();

        }
        public static async Task FocusOnSelectedTextbox(Guid groupControlId)
        {
            TextBox getTextbox = SharedControlManager.panelControl.OfType<TextBox>().Where(c => c.Name == PetNotesConfig.textboxProperties.DefaultPrefixName + groupControlId).SingleOrDefault();
            getTextbox.Focus();
            

        }
    
        public static Size GetSizeByNoteStatus(bool IsActive)
        {
            if (IsActive)
                return new Size(SharedControlManager._formWidth - 52, PetNotesConfig.textboxProperties.DefaultExpandedHeight);
            else
                return new Size(SharedControlManager._formWidth - 52, PetNotesConfig.textboxProperties.DefaultCollapseHeight);
        }
 
         
        
    }
}

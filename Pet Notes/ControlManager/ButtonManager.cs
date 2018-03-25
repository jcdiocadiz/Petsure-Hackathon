using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Pet_Notes.Model;
using Pet_Notes.Configuration;
using Pet_Notes.DataService;

namespace Pet_Notes.ControlManager
{
  public static class ButtonManager
    {
           

         

        //public static async Task AddHeaderCollapseExpandButtons()
        //{
        //  foreach(var c in PetNotesDataAdapter._dataModel) { 
        //        await AddControl(c);
        //        if (c.IsActive)
        //            PetNotesConfig.buttonProperties.Y += PetNotesConfig.textboxProperties.DefaultExpandedHeight + PetNotesConfig.panelProperties.DefaultPanelHeight;
        //        else
        //            PetNotesConfig.buttonProperties.Y += PetNotesConfig.textboxProperties.DefaultCollapseHeight + PetNotesConfig.panelProperties.DefaultPanelHeight;
        //    };
        //}


        public static void AddControl(PetNotesModel data)
        {
            Button newButton = new Button()
            {
                Name = PetNotesConfig.buttonProperties.ExpandCollapsePrefixName + data.ControlGroupID,
                BackColor = System.Drawing.Color.Transparent,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                ForeColor = System.Drawing.Color.Black,
                Location = new System.Drawing.Point(PetNotesConfig.buttonProperties.X, PetNotesConfig.buttonProperties.Y),
                Size = new System.Drawing.Size(PetNotesConfig.buttonProperties.Width, PetNotesConfig.buttonProperties.Height),
                TabIndex = 0,
                Text =   ChangeButtonTextBasedOnStatus(data.IsActive),
                UseVisualStyleBackColor = false
            };
            newButton.Click += new EventHandler( PetNotesExpandCollapse_Click);

            SharedControlManager.panelControl.Add(newButton);
        }

        private static async void PetNotesExpandCollapse_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var ButtonNameSplit = btn.Name.Split('_');
             UpdateNoteStatusToActive(ButtonNameSplit[1], btn.Text);
            await SharedControlManager.ClearAllControls();

            if (SharedControlManager.panelControl.Count == 0)
            {
                await SharedControlManager.LoadAllControls();
                await FocusOnSelectedButton(ButtonNameSplit[1]);
            }
        }

        private static async Task FocusOnSelectedTextbox(string GroupControlId)
        {
            SharedControlManager.panelControl.OfType<TextBox>().Where(c => c.Name == PetNotesConfig.textboxProperties.DefaultPrefixName + GroupControlId).SingleOrDefault().Focus();
        }

        private static async Task FocusOnSelectedButton(string GroupControlId)
        {
            SharedControlManager.panelControl.OfType<Button>().Where(c => c.Name == PetNotesConfig.buttonProperties.ExpandCollapsePrefixName + GroupControlId).SingleOrDefault().Focus();
        }
        private static void UpdateNoteStatusToActive(string groupId, string btnText)
        {
            bool Isactive = btnText == "+";
           
          var data =  PetNotesDataAdapter._dataModel.Where(c => c.ControlGroupID == new Guid(groupId)).SingleOrDefault();
            data.IsActive = Isactive;
        }


        private static string ChangeButtonTextBasedOnStatus(bool IsActive)
        {

            if (IsActive)
                return "-";
            else
                return "+";
        }














        //public async Task AddNewButton(Button btn, Control.ControlCollection control)
        //{
        //    control.Add(btn);

        //}

        //public async Task ChangeAllCollapseIconToExpandExcept(Control.ControlCollection control, string controlName )
        //{
        //    control.OfType<Button>().ToList().ForEach(c =>
        //    {
        //        if (!c.Name.Contains(controlName))
        //            c.Text = "+";
        //    });
        //}   

        //public async Task AdjustButtonLocationDown(Control.ControlCollection control, string controlName, int LocationY, int addedHeight)
        //{
        //    control.OfType<Button>().ToList().ForEach(c => {
        //        if (!c.Name.Contains(controlName) && c.Location.Y > LocationY)
        //            c.Location = new Point(c.Location.X, c.Location.Y + addedHeight);
        //    });

        //}

        //public async Task ResizeOtherControlsUponExpandExcept(Control.ControlCollection control,   int expandHeight)
        //{
        //    Button btnToBeBasis = new Button();
        //    TextBox txtBox = new TextBox(); 

        //    control.OfType<TextBox>().ToList().ForEach(c => {
        //        if (c.Height == expandHeight)
        //            txtBox = c;


        //    });

        //    var txtBoxID = txtBox.Name.Split('_');

        //    control.OfType<Button>().ToList().ForEach(c => {
        //        if (c.Name.Contains(txtBoxID[1]))
        //            btnToBeBasis = c;


        //    });
        //    //adjust location below 
        //    control.OfType<Button>().ToList().ForEach(c => {
        //        if (c.Location.Y > btnToBeBasis.Location.Y)
        //            c.Location = new Point(c.Location.X, c.Location.Y - expandHeight);
        //    });
        //    //collapse other container to minimum height





        //}

        //public async Task AdjustAllButtonsDownward(Control.ControlCollection control, string controlName, int expandHeight, int collapseSize)
        //{
        //    Button btn = new Button();

        //    //adjust location above 
        //    control.OfType<Button>().ToList().ForEach(c => {
        //        if (c.Name== controlName)
        //            btn = c;


        //    });

        //    //adjust location below 
        //    control.OfType<Button>().ToList().ForEach(c => {
        //        if (c.Location.Y > btn.Location.Y)
        //            c.Location = new Point(c.Location.X, c.Location.Y + expandHeight - collapseSize );
        //    });


        //}

    }
}

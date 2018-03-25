using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Pet_Notes.ControlManager;
using Pet_Notes.Model;
using Pet_Notes.DataService;
using Pet_Notes.Configuration;

namespace Pet_Notes
{
    public partial class Form1 : Form
    {
        //#region Form Variables
        //private const string _textboxDefaultPrefixName = "txtNote_";
        //private const string _buttonExpandNoteDefaultPrefixName = "btnExpandNote_";
        //private int _textboxLocationPointX = 0;
        //private int _textboxLocationPointY = 30; 
        //private int _textBoxHeight = 120;
        //private int _textBoxWidth = 0;
        //private int _textBoxTabIndex = 0; 
        //private int _panelHeight = 120;
        //private int _textboxCollapseHeight = 30;


        //private int _btnLocPointX = 0;
        //private int _btnLocPointY = 0;
        //#endregion 
         
        public Form1()
        {
            InitializeComponent();
            InitializeControlManager();
           // InitializeControlConfig();
        }

        private void InitializeControlManager()
        {

          PetNotesConfig.buttonProperties =  PetNotesConfig.SetButtonProperties();
            PetNotesConfig.textboxProperties = PetNotesConfig.SetDefaultTextboxProperties();
            PetNotesConfig.panelProperties = PetNotesConfig.SetPanelProperties();

            PetNotesDataAdapter._dataModel = new List<PetNotesModel>();

            SharedControlManager._formWidth = this.Width;
            SharedControlManager.panelControl = PanelNotes.Controls;
            SharedControlManager.Panel = PanelNotes;
        
        }
       
        //private void InitializeControlConfig()
        //{             
        //    _textBoxWidth = this.Width;
        //}

        private async void btnAddNote_Click_1(object sender, EventArgs e)
        {
            PetNotesDataAdapter._groupControlID = Guid.NewGuid();
            //Textbox
            SharedControlManager._formWidth = this.Width;
            await SharedControlManager.ClearAllControls();
            await TextboxManager.DeactivatePreviousNotes();
            await PetNotesDataAdapter.AddNewRecord();
            if (SharedControlManager.panelControl.Count == 0)
            {
                await SharedControlManager.LoadAllControls();
                await TextboxManager.FocusOnLastActiveTextbox();
            }
            
        }
         

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void Form1_SizeChanged(object sender, EventArgs e)
        {
          //  PanelNotes.Size = new Size(this.Size.Width - 60, this.Size.Height);
            SharedControlManager.ResizePanel(this.Size.Width);
            //_textManager.ResizeWidthOfAllControls(PanelNotes.Controls, _textboxDefaultPrefixName, this.Size.Width);


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PanelNotes.Controls.Clear();
        }


        //#region Methods
        //private async Task AddNoteTextbox(Guid controlID)
        //{
        //    //increment tabIndex
        //    TabIndex += 1;
        //    //add new textbox
        //    TextBox newTextbox = new TextBox()
        //    {
        //        Text = "",
        //        BorderStyle = BorderStyle.None,
        //        Multiline = true,
        //        Name = _textboxDefaultPrefixName + controlID,
        //        BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192))))),
        //        Size = new Size(this.Width, _textBoxHeight),
        //        Location = new Point(_textboxLocationPointX, _textboxLocationPointY),
        //        TabIndex = _textBoxTabIndex,
        //        Margin = new Padding(1, 1, 1, 1)
        //    };


        //    if (PanelNotes.Controls.OfType<TextBox>().Count() == 0)
        //    {
        //        _textboxLocationPointY += 60;
        //        _textManager.ResizeOtherControlsExcept(PanelNotes.Controls, newTextbox.Name, _textboxCollapseHeight);
        //    }
        //    else
        //    {
        //        _textManager.ResizeOtherControlsExcept(PanelNotes.Controls, newTextbox.Name, _textboxCollapseHeight);

        //        TextBox ctr = PanelNotes.Controls.OfType<TextBox>().LastOrDefault();

        //        _textboxLocationPointY = ctr.Location.Y + _textBoxHeight;


        //    }
        //    _textManager.AddTextBox(newTextbox, PanelNotes.Controls);






        //}

        //private async Task AddExpandButton(Guid controlId)
        //{


        //    if (PanelNotes.Controls.OfType<Button>().Count() != 0)
        //    {
        //        Button ctr = PanelNotes.Controls.OfType<Button>().LastOrDefault();

        //        _btnLocPointY += ctr.Location.Y  ; 

        //    }

        //    Button newButton = new Button()
        //    {
        //        Name = _buttonExpandNoteDefaultPrefixName + controlId,
        //        BackColor = System.Drawing.Color.Transparent,
        //        FlatStyle = System.Windows.Forms.FlatStyle.Flat,
        //        ForeColor = System.Drawing.Color.Black,
        //        Location = new System.Drawing.Point(_btnLocPointX, _btnLocPointY),
        //        Size = new System.Drawing.Size(30, 30),
        //        TabIndex = 0,
        //        Text = "-",
        //        UseVisualStyleBackColor = false

        //    };
        //    if (PanelNotes.Controls.OfType<Button>().Count() == 0)
        //    {
        //        _btnLocPointY += 60;

        //    } 
        //        newButton.Click += new EventHandler(btnExpandNote);
        //    _btnManager.AddNewButton(newButton, PanelNotes.Controls);
        //    _btnManager.ChangeAllCollapseIconToExpandExcept(PanelNotes.Controls, controlId.ToString());
        //}
        //#endregion

        //private async void btnExpandNote(object sender, EventArgs e)
        //{
        //    var button = (Button)sender;
        //    var buttonNameSplit = button.Name.Split('_'); 
        //    TextBox textbox = (TextBox)PanelNotes.Controls.Find(_textboxDefaultPrefixName + buttonNameSplit[1],true).SingleOrDefault();    



        //    if (button.Text == "+")
        //    {
        //        //Adjust all position
        //        await _textManager.ResizeOtherControlsUponExpandExcept(PanelNotes.Controls,  _textBoxHeight );

        //        await _btnManager.ResizeOtherControlsUponExpandExcept(PanelNotes.Controls,  _textBoxHeight );
        //        //Resize Textbox
        //        _textManager.CollapseTextbox(PanelNotes.Controls, _textboxCollapseHeight ,_textBoxHeight);

        //        //Adjust all notes down

        //        _textManager.AdjustAllNotesDownward(PanelNotes.Controls, _textboxDefaultPrefixName + buttonNameSplit[1], _textBoxHeight, _textboxCollapseHeight);

        //        //Adjust all buttons down
        //        await _btnManager.AdjustAllButtonsDownward(PanelNotes.Controls, _buttonExpandNoteDefaultPrefixName + buttonNameSplit[1], _textBoxHeight, _textboxCollapseHeight);
        //        //rename button        


        //        _btnManager.ChangeAllCollapseIconToExpandExcept(PanelNotes.Controls, buttonNameSplit[1].ToString());
        //          button.Text = "-";
        //    }
        //    else
        //    {



        //    }

        //}

    }
}

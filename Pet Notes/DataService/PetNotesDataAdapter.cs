using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet_Notes.Model;
using System.Drawing;
using Pet_Notes.Configuration;
namespace Pet_Notes.DataService
{
    public static class PetNotesDataAdapter
    {
         
        public static List<PetNotesModel> _dataModel { get; set; }

        public static Guid _groupControlID { get; set; }
         

 

        public static async Task<PetNotesModel> AddNewRecord()
        {
            PetNotesModel newRecord = new PetNotesModel()
            {
                PetNotesID = PetNotesConfig.textboxProperties.DefaultPrefixName + _groupControlID,
                ControlGroupID = _groupControlID,
                Color = PetNotesConfig.textboxProperties.Color, 
                Notes = string.Empty,
                IsActive = true,
                Created = DateTime.UtcNow,
                Modified = null
            };

            _dataModel.Add(newRecord);
            return newRecord;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pet_Notes.Model
{
     public  class PetNotesModel
    {
        public string PetNotesID { get; set; }
        public Guid ControlGroupID { get; set; } 
        public  Color Color { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

    }
}

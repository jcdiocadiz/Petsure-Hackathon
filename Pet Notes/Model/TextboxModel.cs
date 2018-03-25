using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Notes.Model
{
   public class TextboxModel
    { 
        public Color Color { get; set; }
        public int DefaultExpandedHeight { get; set; }
        public int DefaultCollapseHeight { get; set; } 
        public string DefaultPrefixName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}

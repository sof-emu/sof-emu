using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Template.World
{
    public class MapTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float X1 { get; set; }
        public float Z1 { get; set; }
        public float Y1 { get; set; }

        public float X2 { get; set; }
        public float Z2 { get; set; }
        public float Y2 { get; set; }
    }
}

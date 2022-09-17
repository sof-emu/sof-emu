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
        public int X { get; set; }
        public int Y { get; set; }

        public float UnkF1 { get; set; }
        public float UnkF2 { get; set; }
        public float UnkF3 { get; set; }

        public float UnkA1 { get; set; }
        public float UnkA2 { get; set; }
        public float UnkA3 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fontshop_dl_cs.Classes
{
    public class FontshopFont
    {
        private string name;
        private string weightName;
        private string id;
        private bool available;
        public FontshopFont(string name, string weightName, string id, bool available)
        {
            this.name = name;
            this.weightName = weightName;
            this.id = id;
            this.available = available;
        }

        public string Name { get => name; set => name = value; }
        public string WeightName { get => weightName; set => weightName = value; }
        public string Id { get => id; set => id = value; }
        public bool Available { get => available; set => available = value; }
    }
}

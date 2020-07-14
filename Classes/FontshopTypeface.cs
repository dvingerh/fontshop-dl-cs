using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fontshop_dl_cs.Classes
{
    public class FontshopTypeface
    {
        private string name;
        private List<FontshopFont> fonts;
        private int fontsAvailable;
        public FontshopTypeface(string name, List<FontshopFont> fonts)
        {
            this.name = name;
            this.fonts = fonts;
        }

        public string Name { get => name; set => name = value; }
        public List<FontshopFont> Fonts { get => fonts; set => fonts = value; }
        public int FontsAvailable { get => fontsAvailable; set => fontsAvailable = value; }
    }
}

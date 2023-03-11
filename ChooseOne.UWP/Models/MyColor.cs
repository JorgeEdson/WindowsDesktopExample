using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseOne.UWP.Models
{
    public class MyColor
    {
        public string Name{ get; set; }
        public string Hexa { get; set; }

        public MyColor(string name, string hexa)
        {
            Name = name;
            Hexa = hexa;
        }
    }
}

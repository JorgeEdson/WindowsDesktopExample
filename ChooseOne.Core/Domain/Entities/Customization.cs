using ChooseOne.Core.Domain.Base;
using ChooseOne.Core.Domain.Entities.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseOne.Core.Domain.Entities
{
    public class Customization : Entity
    {
        public ChooseComponent ChooseComponent { get;  set; }
        public string Name { get;  set; }
        public string Content { get; set; }
        public string BackGroundColor { get; set; }
        public string ForeGroundColor { get; set; }
        public string CornerRadius { get; set; }
        public string MaxValue { get; set; }
        public string MinValue { get; set; }
        public string FontSize { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string DialogButton1 { get; set; }
        public string DialogButton2 { get; set; }
        public string DialogButton3 { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace FingerTips
{
    public class Member
    {
        public string Name { get; set; }
        public string Code => Name.Length < 2 ? Name : Name.Substring(0, 2);
        public Brush Color { get; set; }
    }
}

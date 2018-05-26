using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace FingerTips
{
    public class Member : DataEntity
    {
        public string Name { get; set; }
        public string Code => Name.Length < 2 ? Name : Name.Substring(0, 2);

        [NotMapped]
        public Brush Color { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}

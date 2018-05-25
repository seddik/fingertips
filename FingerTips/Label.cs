using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace FingerTips
{
    public class Label : DataEntity
    {
        public string Name { get; set; }
        public string ColorString { get; set; }
        [NotMapped]
        public Brush Color { get; set; }

        public virtual ICollection<Card> Cards { get; set; } = new HashSet<Card>();
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FingerTips
{
    public class Card : DataEntity
    {
        public string Title { get; set; }
        


        public virtual ICollection<Label> Labels { get; set; } = new ObservableCollection<Label>();
        public virtual ICollection<Member> Members { get; set; } = new ObservableCollection<Member>();

        public virtual List List { get; set; }
    }
}

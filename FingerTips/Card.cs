using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FingerTips
{
    public class Card
    {
        public string Title { get; set; } 
        public int Order { get; set; }
        public List List { get; set; }

        public ObservableCollection<Label> Labels { get; set; } = new ObservableCollection<Label>();
        public ObservableCollection<Member> Members { get; set; } = new ObservableCollection<Member>();
        public ObservableCollection<string> Messages { get; set; } = new ObservableCollection<string>();
    }
}

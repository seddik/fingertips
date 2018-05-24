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
        public List List { get; set; }

        public int IdList { get; set; }

        public ObservableCollection<Label> Labels { get; set; } = new ObservableCollection<Label>();
        public ObservableCollection<Member> Members { get; set; } = new ObservableCollection<Member>();
        public ObservableCollection<string> Messages { get; set; } = new ObservableCollection<string>();

        public override void Deserialize(string data)
        {

            Id = data.ToSplit("€€€", 0).ToInt();
            Order = data.ToSplit("€€€", 1).ToInt();
            Title = data.ToSplit("€€€", 2);
            IdList = data.ToSplit("€€€", 3).ToInt();
        }

        public override string Serialize()
        {
            return Id + "€€€" + Order + "€€€" + Title.Replace("€", "$") + "€€€" + List.Id;
        }
    }
}

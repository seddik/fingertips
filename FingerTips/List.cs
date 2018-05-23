using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FingerTips
{
    public class List : DataEntity
    {
        public string Title { get; set; }

        public ObservableCollection<Card> Cards { get; set; } = new ObservableCollection<Card>();

        public List<Card> OrderedCards => Cards.OrderBy(X => X.Order).ThenBy(X => X.Title).ToList();

        public override void Deserialize(string data)
        {

            Id = data.ToSplit("€€€", 0).ToInt();
            Order = data.ToSplit("€€€", 1).ToInt();
            Title = data.ToSplit("€€€", 2);
        }

        public override string Serialize()
        {
            return Id + "€€€" + Order + "€€€" + Title.Replace("€", "$");
        }
    }
}

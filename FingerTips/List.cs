using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FingerTips
{
    public class List : DataEntity
    {
        public List()
        {
            Cards = new HashSet<Card>();
        }
        public string Title { get; set; }

        public virtual ICollection<Card> Cards { get; set; } = new HashSet<Card>();


        public List<Card> OrderedCards => Cards.OrderBy(X => X.Order).ThenBy(X => X.Title).ToList();
        
    
    }
}

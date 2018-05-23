﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace FingerTips
{
    public class MainModelView : INotifyPropertyChanged
    {
        public MainModelView()
        {

            /*  Labels = new ObservableCollection<Label>
              {
                  new Label{ Name="Bug",Color=Brushes.Red},
                  new Label{ Name="Feature",Color=Brushes.Green},
                  new Label{ Name="Client",Color=Brushes.Blue},
                  new Label{ Name="Potential",Color=Brushes.ForestGreen},
              };

              Members = new ObservableCollection<Member>            {
                  new Member{ Name="SEDDIK",Color=Brushes.Maroon},
                  new Member{ Name="OUSSAMA",Color=Brushes.Goldenrod},
                  new Member{ Name="LAZHAR",Color=Brushes.PowderBlue},
              };
              Lists.Add(new List
              {
                  Title = "Personnel",
                  Cards = new ObservableCollection<Card> { new Card { Title = "Haircut", Order = 2 }, new Card { Title = "Buy new clothes", Order = 1 } },
                  Order = 1
              });
              Lists.Add(new List
              {
                  Title = "Car",
                  Cards = new ObservableCollection<Card> { new Card { Title = "Change the oil", Order = 15 }, new Card { Title = "Buy new wheel", Order = 1 }
                  , new Card { Title = "Renew the trunk locker", Order = 1 }},
                  Order = 2
              });

              Lists[0].Cards[0].Labels.Add(Labels[1]);
              Lists[0].Cards[0].Labels.Add(Labels[3]);

              Lists[0].Cards[1].Labels.Add(Labels[0]);
              Lists[0].Cards[1].Labels.Add(Labels[1]);
              Lists[0].Cards[1].Labels.Add(Labels[2]);


              Lists[0].Cards[0].Members.Add(Members[2]);

              Lists[0].Cards[1].Members.Add(Members[0]);
              Lists[0].Cards[1].Members.Add(Members[1]);

              Lists[1].Cards[1].Members.Add(Members[2]);
              Lists[1].Cards[2].Labels.Add(Labels[0]);*/

            Lists = new ObservableCollection<List>(DataStore.Instance.GetDataEntitySet<List>("list") ?? new List<List>());

        }

        public bool AddItem(List t)
        {
            if (!DataStore.Instance.Add<List>("list", t))
            {
                MessageBox.Show("Data save error");
                return false;
            }
            Instance.Lists.Add(t);
            Instance.UpdateAll();
            return true;
        }

        public bool DeleteItem(int id)
        {
            var t = Find(id);
            if (t == null)
                return false;
            Instance.Lists.Remove(t);
            Instance.UpdateAll();
            return true;
        }

        public bool EditItem(int id, List t)
        {
            var old = Find(id);

            old.Title = t.Title;
            old.Order = t.Order;
            Instance.UpdateAll();
            return true;
        }

        public List Find(int id)
        {
            return Instance.Lists.FirstOrDefault(X => X.Id == id);
        }

        public ObservableCollection<List> Lists { get; set; } 
        public ObservableCollection<Label> Labels { get; set; } = new ObservableCollection<Label>();
        public ObservableCollection<Member> Members { get; set; } = new ObservableCollection<Member>();
        public List<List> OrderedLists => Lists.OrderBy(X => X.Order).ThenBy(X => X.Title).ToList();
        static MainModelView _instance;

        public event PropertyChangedEventHandler PropertyChanged;

        public static MainModelView Instance => _instance ?? (_instance = new MainModelView());


        public void UpdateAll()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void UpdateProperty(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}

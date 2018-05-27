using System;
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

            UpdateAll();
     
        }

        public ObservableCollection<List> Lists { get; set; }
        public ObservableCollection<Label> Labels { get; set; }
        public ObservableCollection<Member> Members { get; set; }
        static MainModelView _instance;

        public event PropertyChangedEventHandler PropertyChanged;

        public static MainModelView Instance => _instance ?? (_instance = new MainModelView());


        public void UpdateAll()
        {
            Lists = new ObservableCollection<List>(oAppContext.Instance.Lists.OrderBy(X => X.Order).ToList());
            Labels = new ObservableCollection<Label>(oAppContext.Instance.Labels.OrderBy(X => X.Order).ToList());
            Members = new ObservableCollection<Member>(oAppContext.Instance.Members.OrderBy(X => X.Order).ToList());

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void UpdateProperty(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}

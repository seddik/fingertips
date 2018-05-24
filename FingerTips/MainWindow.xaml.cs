using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FingerTips
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = MainModelView.Instance;
        }

        private void AddList_Click(object sender, RoutedEventArgs e)
        {
            var title = wList.Read();
            if (title == null)
                return;
            MainModelView.Instance.AddItem(new List { Title = title, Order = MainModelView.Instance.Lists.Select(X => X.Order).DefaultIfEmpty().Max() + 1 });
        }

        private void List_Options_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var tb = (TextBlock)sender;
            var list = tb.Tag as List;

            if (tb.ContextMenu == null)
            {
                tb.ContextMenu = new ContextMenu();
                var mi = new MenuItem { Header = "Add Card" };
                mi.Click += (s, o) =>
                {
                    var r = wCard.Read();
                    if (r == null)
                        return;

                    var card = new Card
                    {
                        Title = r,
                        Order = list.Cards == null || !list.Cards.Any() ? 1 : list.Cards.Max(X => X.Order) + 1,
                        List = list
                    };

                    
                    MainModelView.Instance.AddCard(card);
                };
                tb.ContextMenu.Items.Add(mi);

                tb.ContextMenu.Items.Add(new Separator());
                mi = new MenuItem { Header = "Edit" };
                mi.Click += (s, o) =>
                {
                    var r = wList.Read(list.Title);
                    if (r == null)
                        return;

                    list.Title = r;
                    MainModelView.Instance.EditItem(list.Id, list);
                };
                tb.ContextMenu.Items.Add(mi);

                mi = new MenuItem { Header = "Delete" };
                mi.Click += (s, o) =>
                {
                    MainModelView.Instance.DeleteItem(list.Id);
                };
                tb.ContextMenu.Items.Add(mi);


            }

            tb.ContextMenu.IsOpen = true;


        }
    }
}

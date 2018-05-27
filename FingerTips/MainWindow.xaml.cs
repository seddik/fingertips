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

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = MainModelView.Instance;
        }

        private void AddList_Click(object sender, RoutedEventArgs e)
        {
            var title = wList.Read();
            if (title == null)
                return;

            oAppContext.Instance.Lists.Add(new List { Title = title, Order = 9999 });
            oAppContext.Instance.SaveChangesAndUpdate();

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

                    list = oAppContext.Instance.Lists.Find(list.Id);
                    list.Cards.Add(card);
                    oAppContext.Instance.SaveChangesAndUpdate();
                };
                tb.ContextMenu.Items.Add(mi);

                tb.ContextMenu.Items.Add(new Separator());
                mi = new MenuItem { Header = "Edit" };
                mi.Click += (s, o) =>
                {
                    var r = wList.Read(list.Title);
                    if (r == null)
                        return;

                    list = oAppContext.Instance.Lists.Find(list.Id);
                    list.Title = r;
                    oAppContext.Instance.SaveChangesAndUpdate();
                };
                tb.ContextMenu.Items.Add(mi);

                mi = new MenuItem { Header = "Delete" };
                mi.Click += (s, o) =>
                {
                    list = oAppContext.Instance.Lists.Find(list.Id);
                    oAppContext.Instance.Lists.Remove(list);
                    oAppContext.Instance.SaveChangesAndUpdate();
                };
                tb.ContextMenu.Items.Add(mi);


            }

            tb.ContextMenu.IsOpen = true;


        }

        private void Card_Options_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var tb = (TextBlock)sender;
            var card = tb.Tag as Card;

            var AllLabels = MainModelView.Instance.Labels;
            var AllMembers = MainModelView.Instance.Members;

            if (tb.ContextMenu == null)
            {
                tb.ContextMenu = new ContextMenu();
                var mi = new MenuItem { Header = "Labels" };
                tb.ContextMenu.Items.Add(mi);

                foreach (var lb in AllLabels)
                {
                    var mmi = new MenuItem { Header = lb.Name, IsCheckable = true, IsChecked = lb.Cards.Any(X => X.Id == card.Id) };
                    mmi.Click += (s, o) =>
                    {
                        card = oAppContext.Instance.Cards.Find(card.Id);
                        if (mmi.IsChecked)
                            card.Labels.Add(lb);
                        else
                            card.Labels.Remove(lb);
                        oAppContext.Instance.SaveChangesAndUpdate();
                    };
                    mi.Items.Add(mmi);
                }


                mi = new MenuItem { Header = "Members" };
                tb.ContextMenu.Items.Add(mi);

                foreach (var mem in AllMembers)
                {
                    var mmi = new MenuItem { Header = mem.Name, IsCheckable = true, IsChecked = mem.Cards.Any(X => X.Id == card.Id) };
                    mmi.Click += (s, o) =>
                    {
                        card = oAppContext.Instance.Cards.Find(card.Id);
                        if (mmi.IsChecked)
                            card.Members.Add(mem);
                        else
                            card.Members.Remove(mem);
                        oAppContext.Instance.SaveChangesAndUpdate();
                    };
                    mi.Items.Add(mmi);
                }
                tb.ContextMenu.Items.Add(new Separator());

                mi = new MenuItem { Header = "Edit" };
                mi.Click += (s, o) =>
                {
                    var r = wCard.Read(card.Title);
                    if (r == null)
                        return;


                    card = oAppContext.Instance.Cards.Find(card.Id);
                    card.Title = r;

                    oAppContext.Instance.SaveChangesAndUpdate();

                };
                tb.ContextMenu.Items.Add(mi);

                mi = new MenuItem { Header = "Delete" };
                mi.Click += (s, o) =>
                {
                    card = oAppContext.Instance.Cards.Find(card.Id);

                    oAppContext.Instance.Cards.Remove(card);
                    oAppContext.Instance.SaveChangesAndUpdate();
                };
                tb.ContextMenu.Items.Add(mi);


            }

            tb.ContextMenu.IsOpen = true;
        }

        private void AddLabel_Click(object sender, RoutedEventArgs e)
        {
            var title = wLabel.Read();
            if (title == null)
                return;

            oAppContext.Instance.Labels.Add(new Label { Name = title, Order = 9999 });
            oAppContext.Instance.SaveChangesAndUpdate();
        }

        private void AddMember_Click(object sender, RoutedEventArgs e)
        {
            var title = wMember.Read();
            if (title == null)
                return;

            oAppContext.Instance.Members.Add(new Member { Name = title, Order = 9999 });
            oAppContext.Instance.SaveChangesAndUpdate();
        }
    }
}

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
using System.Windows.Shapes;

namespace FingerTips
{
    /// <summary>
    /// Interaction logic for wList.xaml
    /// </summary>
    public partial class wList : Window
    {
        public wList()
        {
            InitializeComponent();
            t_title.Focus();
            t_title.PreviewKeyUp += T_title_PreviewKeyUp;
        }

        private void T_title_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                DoOk();
        }

        private void Ok_Clicked(object sender, RoutedEventArgs e)
        {
            DoOk();
        }

        private void DoOk()
        {
            TheTitle = t_title.Text;
            Close();
        }

        public string TheTitle { get; set; }

        public static string Read(string old = "")
        {
            var w = new wList();
            w.t_title.Text = old;
            w.t_title.SelectAll();
            w.ShowDialog();
            return w.TheTitle;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Media;

namespace FingerTips
{
    public static class Tools
    {
        public static string LocalFile(string filename)
        {
            return System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filename);
        }

        public static string ToSplit(this string s, string sep, int idx)
        {
            var ss = s.Split(new string[] { sep }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                return ss[idx];
            }
            catch
            {

                return "";
            }
        }


        public static int ToInt(this string s)
        {
            try
            {
                return int.Parse(s);
            }
            catch
            {

                return 0;
            }
        }

        static BrushConverter bconv = new BrushConverter();
        public static SolidColorBrush ToBrush(this string brush)
        {
            try
            {
                return (SolidColorBrush)bconv.ConvertFromString(brush);
            }
            catch
            {
                return Brushes.Black;
            }
        }
    }
}

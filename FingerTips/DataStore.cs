using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace FingerTips
{
    public class DataStore
    {
        public DataStore()
        {

        }

        public void SaveItem()
        {

        }

        /*
        public List<T> GetDataEntitySet<T>(string key) where T : DataEntity
        {
            var file = Tools.LocalFile(key);
            if (!File.Exists(file))
                return null;

            var lines = File.ReadAllLines(file);

            List<T> list = new List<T>();
            foreach (var item in lines)
            {
                var t = Activator.CreateInstance<T>();
                t.Deserialize(item);
                list.Add(t);
            }
            return list.OrderBy(X => X.Order).ToList();
        }

        public static DataStore _instance;
        public static DataStore Instance => _instance ?? (_instance = new DataStore());

        public bool Add<T>(string key, T t) where T : DataEntity
        {
            try
            {
                var dataset = GetDataEntitySet<T>(key);
                int id = 1;
                if (dataset != null)
                    id = dataset.Select(X => X.Id).DefaultIfEmpty().Max() + 1;

                t.Id = id;
                File.AppendAllLines(Tools.LocalFile(key), new List<string> { t.Serialize() });
            }
            catch
            {
                return false;

            }
            return true;
        }

        internal bool Edit<T>(string key, int id, T t) where T : DataEntity
        {
            try
            {
                var all = File.ReadAllLines(Tools.LocalFile(key));

                List<string> l = new List<string>();
                foreach (var item in all)
                {
                    var tt = Activator.CreateInstance<T>();
                    tt.Deserialize(item);
                    if (tt.Id == id)
                        l.Add(t.Serialize());
                    else
                        l.Add(item);
                }
                File.WriteAllLines(Tools.LocalFile(key), l);
            }
            catch
            {
                return false;

            }
            return true;
        }

        internal bool Delete<T>(string key, int id) where T : DataEntity
        {
            try
            {
                var all = File.ReadAllLines(Tools.LocalFile(key));

                List<string> l = new List<string>();
                foreach (var item in all)
                {
                    var tt = Activator.CreateInstance<T>();
                    tt.Deserialize(item);
                    if (tt.Id == id)
                        continue;
                    l.Add(item);
                }

                File.WriteAllLines(Tools.LocalFile(key), l);
            }
            catch
            {
                return false;

            }
            return true;
        }*/
    }

    public abstract class DataEntity : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public int Order { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

  
        public void UpdateProp(string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

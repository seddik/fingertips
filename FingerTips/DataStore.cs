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
                File.AppendAllLines(Tools.LocalFile(key), new List<string> { t.Serialize() });
            }
            catch  
            {
                return false;
                
            }
            return true;
        }
    }

    public abstract class DataEntity
    {
        public int Id { get; set; }

        public int Order { get; set; }

        public abstract void Deserialize(string data);

        public abstract string Serialize();
    }
}

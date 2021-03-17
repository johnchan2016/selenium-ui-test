using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UI.Test.Framework.Helpers
{
    public class FileHelper
    {
        public static T LoadJson<T>(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                T obj = JsonConvert.DeserializeObject<T>(json);

                return obj;
            }
        }

        public static IEnumerable<T> LoadJsonToList<T>(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                IEnumerable<T> obj = JsonConvert.DeserializeObject<IEnumerable<T>>(json);

                return obj;
            }
        }
    }
}

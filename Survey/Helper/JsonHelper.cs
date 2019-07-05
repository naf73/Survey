using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Helper
{
    /// <summary>
    /// Статический класс для работы с JSON
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// Сериализация списка данных в файл Json
        /// </summary>
        /// <typeparam name="T">Тип данных</typeparam>
        /// <param name="name">Путь к файлу</param>
        /// <param name="objects">Список данных</param>
        public static void Serialization<T>(string name, T objects)
        {
            try
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
                using (var fs = new FileStream(name, FileMode.OpenOrCreate))
                {
                    jsonSerializer.WriteObject(fs, objects);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Десериализация файла Json в список данных
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T Deserialization<T>(string name)
        {
            try
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<T>));
                T result;
                using (var fs = new FileStream(name, FileMode.OpenOrCreate))
                {
                    result = (T)jsonSerializer.ReadObject(fs);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

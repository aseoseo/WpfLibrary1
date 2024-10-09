using System;
using System.Collections.Generic;
using System.Linq;

namespace DataFilterApp
{
    public class DataFilter
    {
        // Делегат для фильтрации данных
        public delegate IEnumerable<string> FilterDelegate(IEnumerable<string> data);

        // Метод для фильтрации по дате
        public IEnumerable<string> FilterByDate(IEnumerable<string> data)
        {
            return data.Where(d => d.Contains("2023"));
        }

        // Метод для фильтрации по ключевым словам
        public IEnumerable<string> FilterByKeyword(IEnumerable<string> data, string keyword)
        {
            return data.Where(d => d.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }
    }
}

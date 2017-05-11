using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyanyca
{
    static class LinkedListExtension
    {
        public static LinkedList<T> subList<T>(this LinkedList<T> list, int count)
        {
            List<T> tmp = new List<T>(list);
            return new LinkedList<T>(tmp.GetRange(0, count));
        }
    }
}

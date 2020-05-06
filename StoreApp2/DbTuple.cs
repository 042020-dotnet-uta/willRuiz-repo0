using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    public class DbTuple<T1, T2, TForeign>
    {
        public int Id { get; set; }
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
        public TForeign ForeignObject { get; set; } 
        public int ForeignId { get; set; }
    }
}

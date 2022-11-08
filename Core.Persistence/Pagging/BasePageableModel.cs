using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Pagging
{
    public class BasePageableModel
    {
        public int Index { get; set; }//sayfa sayısı
        public int Size { get; set; }//sayfadaki data sayısı
        public int Count { get; set; }//toplam data sayısı
        public int Pages { get; set; }//sayfalar
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
    }
}



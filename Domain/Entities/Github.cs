using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Github : Entity
    {
        public string Account { get; set; }

        public Github()
        {

        }
        public Github(int id, string account)
        {
            Id = id;
            Account = account;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Technology : Entity
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public virtual Language? Language { get; set; }

        public Technology()
        {
            Language language = new Language();
        }

        public Technology(int languageId, string name, string imageUrl,int id)
        {

            LanguageId = languageId;
            Name = name;
            ImageUrl = imageUrl;
            Id = id;

        }
    }
}

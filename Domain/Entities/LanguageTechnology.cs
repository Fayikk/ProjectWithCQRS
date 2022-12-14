using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LanguageTechnology : Entity
    {
        public int? LanguageId { get; set; }
        public string? Name { get; set; }
    
        public virtual Language? Language { get; set; }

        public LanguageTechnology()
        {
            Language language = new Language();

        }

        public LanguageTechnology(int languageId,int id, string name)
        {
            LanguageId = languageId;
            Name = name;

            Id = id;
        }
    }
}

using Application.Features.Languages.Dtos.ForLanguage;
using Core.Persistence.Pagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Models
{
    public class LanguageListModel:BasePageableModel
    {

        public IList<LanguageListDto> Items { get; set; }

    }
}

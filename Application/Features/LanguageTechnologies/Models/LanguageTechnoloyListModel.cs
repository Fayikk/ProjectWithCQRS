using Application.Features.LanguageTechnologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Models
{
    public class LanguageTechnoloyListModel
    {
        public IList<LanguageTechnologyListDto> Items { get; set; }
    }
}

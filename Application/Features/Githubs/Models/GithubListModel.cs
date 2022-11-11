using Application.Features.Githubs.Dtos.ForGithubs;
using Application.Features.Languages.Dtos.ForLanguage;
using Core.Persistence.Pagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Models
{
    public class GithubListModel : BasePageableModel
    {
        public IList<GithubListDto> Items { get; set; }

    }
}

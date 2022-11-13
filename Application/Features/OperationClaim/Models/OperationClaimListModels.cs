using Application.Features.OperationClaim.Dtos;
using Core.Persistence.Pagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaim.Models
{
    public class OperationClaimListModels
    {
        public class OperationClaimListModel : BasePageableModel
        {
            public List<GetListOperationClaimDto> Items { get; set; }
        }
    }
}

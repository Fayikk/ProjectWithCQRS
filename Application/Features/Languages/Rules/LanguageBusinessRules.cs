using Application.Services;
using Core.Persistence.Pagging;
using Core.CrossCuttingConcerns.Exceptions;

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
       private readonly ILanguageRepository _languageRepository;
        public LanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository= languageRepository;
        }
        //programşlama dişl isimer tekrar edemez
        //Progeamlama dil boş geçilmez

        public async Task LanguageNameCanNotBeRepeat(string name)
        {
            IPaginate<Language>? result = await _languageRepository.GetListAsync(a => a.Name == name);
            if (result.Items.Any()) throw new BusinessException("Language name exists.");


        }


    }
}

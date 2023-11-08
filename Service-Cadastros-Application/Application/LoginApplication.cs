using service_cadastros_application.Interfaces;
using service_cadastros_application.ViewModels;
using service_cadastros_persistence.Interfaces;
using service_cadastros_persistence.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper; 

namespace service_cadastros_application.Application
{
    public class LoginApplication : ILoginApplication
    {
        public readonly IMapper _mapper;
        public readonly ILoginRepository _loginRepository;

        public LoginApplication(IMapper mapper, ILoginRepository loginRepository)
        {
            _mapper = mapper; 
            _loginRepository = loginRepository;
        }

        public async Task<int> AtualizarLoginAsync(RequestLoginViewModel model)
        {
            var modelVO = _mapper.Map<LoginValueObject>(model);         
            return await _loginRepository.AtualizarLoginAsync(modelVO);            
        }

        public async Task<bool> DeletarLoginAsync(int id)
        {
            return await _loginRepository.DeletarLoginAsync(id);            
        }

        public async Task<int> InserirLoginAsync(RequestLoginViewModel model)
        {
            var modelVO = _mapper.Map<LoginValueObject>(model);
            return await _loginRepository.InserirLoginAsync(modelVO);
        }
        
        public async Task<ResponseLoginViewModel> ObterLogiPorIdAsync(int id)
        {            
            var modelVO = await _loginRepository.ObterLoginAsync(id);
            return _mapper.Map<ResponseLoginViewModel>(modelVO);                             
        }

        public async Task<List<ResponseLoginViewModel>> ObterLogiPorFiltrosAsync(RequestFiltrosConsultaViewModel filtros)
        {
            var filtrosVo = _mapper.Map<RequestFiltrosConsultaValueObject>(filtros);            
            var dados = await _loginRepository.ObterLoginPorFiltrosAsync(filtrosVo);
            if(dados != null)            
                return _mapper.Map<List<ResponseLoginViewModel>>(dados);                
            
            return null;                       
        }
    }
}

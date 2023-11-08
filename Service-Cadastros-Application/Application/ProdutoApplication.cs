using AutoMapper;
using service_cadastros_application.Interfaces;
using service_cadastros_application.ViewModels;
using service_cadastros_persistence.Interfaces;
using service_cadastros_persistence.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_cadastros_application.Application
{
    public class ProdutoApplication : IProdutoApplication
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;


        public ProdutoApplication(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<int> InserirProdutoAsync(ResquestProdutoViewModel model)
        {
            //validar se objeto esta ok
            model.DataRegistro = DateTime.Now;
            var id = await _produtoRepository.InserirProdutoAsync(_mapper.Map<ProdutoDTO>(model));
            return id;              
        }

        public async Task<int> AtualizarProdutoAsync(ResquestProdutoViewModel model)
        {
            model.DataAlteracao = DateTime.Now;
            var id = await _produtoRepository.AtualizarProdutoAsync(_mapper.Map<ProdutoDTO>(model));
            return id;
        }

        public async Task<bool> DeletarProdutoAsync(int id, string usuario)
        {
            //posso?:::????
            await _produtoRepository.DeletarProdutoAsync(id, usuario);
            return true;
        }

        public async Task<ResponseProdutoViewModel> ObterProdutoPorIdAsync(int id)
        {
            var dados = await _produtoRepository.ObterProdutoPorIdAsync(id);
            return _mapper.Map<ResponseProdutoViewModel>(dados);            
        }

        public async Task<List<ResponseProdutoViewModel>> ObterListaProdutosAsync(RequestProdutoFiltrosViewModel model)
        {
            var dados = await _produtoRepository.ObterListaProdutosAsync(_mapper.Map<FiltrosProdutoValueObjet>(model));            
            return _mapper.Map<List<ResponseProdutoViewModel>>(dados);
        }
    }
}

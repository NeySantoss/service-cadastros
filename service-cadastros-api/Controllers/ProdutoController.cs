using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using service_cadastros_application.Interfaces;
using service_cadastros_application.ViewModels;

namespace service_cadastros_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProdutoController : Controller
    {
        private readonly IProdutoApplication _produtoApplication;

        public ProdutoController(IProdutoApplication produtoApplication)
        {
            _produtoApplication = produtoApplication;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost()]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> InseriProdutoAsync([FromBody] ResquestProdutoViewModel model)
        {            
            int id = await _produtoApplication.InserirProdutoAsync(model);            
            return Ok(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut()]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> AtualizarProdutoAsync([FromBody] ResquestProdutoViewModel model)
        {
            int id = await _produtoApplication.AtualizarProdutoAsync(model);
            return Ok(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpDelete("{id}/{usuario}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletarProdutoAsync([FromRoute] int id, string usuario)
        {
            await _produtoApplication.DeletarProdutoAsync(id, usuario);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseProdutoViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterProdutoAsync([FromRoute] int id)
        {
            var dados = await _produtoApplication.ObterProdutoPorIdAsync(id);
            return Ok(dados);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("lista")]
        [ProducesResponseType(typeof(List<ResponseProdutoViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterListaProdutoAsync([FromQuery] RequestProdutoFiltrosViewModel model)
        {
            var dados = await _produtoApplication.ObterListaProdutosAsync(model);
            return Ok(dados);
        }




        /*
        private readonly ILoginApplication _loginApplication;

        public LoginController(ILoginApplication loginApplication)
        {
            _loginApplication = loginApplication;
        }

        /// <summary>
        /// Inserir um usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost()]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> InserirLogin([FromBody] RequestLoginViewModel model)
        {
            var id = await _loginApplication.InserirLoginAsync(model);
            return Ok(id);
        }

        /// <summary>
        /// Atualizar Usuário
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPut()]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> AtualizarLogin([FromBody] RequestLoginViewModel model)
        {
            var id = await _loginApplication.AtualizarLoginAsync(model);
            return Ok(id);
        }

        /// <summary>
        /// Deletar Usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletarLogin([FromRoute] int id)
        {
            await _loginApplication.DeletarLoginAsync(id);
            return Ok(true);
        }

        /// <summary>
        /// Obter Usuário por Id
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseLoginViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterLoginPorId([FromRoute] int id)
        {
            var retorno = await _loginApplication.ObterLogiPorIdAsync(id);
            return Ok(retorno);
        }

        /// <summary>
        /// Obter Usuário por Id
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("filtros")]
        [ProducesResponseType(typeof(List<ResponseLoginViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterLoginPorId([FromQuery] RequestFiltrosConsultaViewModel filtros)
        {
            var retorno = await _loginApplication.ObterLogiPorFiltrosAsync(filtros);
            return Ok(retorno);
        }

        */
    }  
}

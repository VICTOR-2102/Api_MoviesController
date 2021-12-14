using Api_MoviesController.Request;
using Api_MoviesController.Response;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_MoviesController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepositorio _filmeRepositorio;

        public FilmeController(IFilmeRepositorio filme)
        {
            _filmeRepositorio = filme;
        }

        // GET obter todos
        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                List<FilmeResponse> filme = new List<FilmeResponse>();
                var filmes = _filmeRepositorio.ObterTodos();

                foreach (var item in filmes)
                {
                    filme.Add(new FilmeResponse()
                    {
                        NomeFilme = item.Nome,
                        AnoLancamentoFilme = item.AnoLancamento,
                        GeneroFilme = item.Genero,
                        FaixaEtariaFilme = item.FaixaEtaria,
                        DuracaoFilme = item.Duracao,
                        SinopseFilme = item.Sinopse,
                    });
                }

                return Ok(filme);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // GET por ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {

                List<FilmeResponse> filme = new List<FilmeResponse>();
                var itemFilme = _filmeRepositorio.ObterPorId(id);

                if (itemFilme == null)
                    throw new Exception("Id deste Filme não existe");

                filme.Add(new FilmeResponse()
                {
                    NomeFilme = itemFilme.Nome,
                    AnoLancamentoFilme = itemFilme.AnoLancamento,
                    GeneroFilme = itemFilme.Genero,
                    FaixaEtariaFilme = itemFilme.FaixaEtaria,
                    DuracaoFilme = itemFilme.Duracao,
                    SinopseFilme = itemFilme.Sinopse
                });

                return Ok(filme);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public IActionResult Post([FromBody] FilmeRequest filme)
        {
            try
            {
                Filme film = new Filme();

                film.Nome = filme.Nome;
                film.AnoLancamento = filme.AnoLancamento;
                film.Genero = filme.Genero;
                film.FaixaEtaria = filme.FaixaEtaria;
                film.Duracao = filme.Duracao;
                film.Sinopse = filme.Sinopse;

                _filmeRepositorio.Adicionar(film);
                return Ok(film.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FilmeRequest filme)
        {
            try
            {
                var item = _filmeRepositorio.ObterPorId(id);

                if (item == null)
                    throw new Exception("O id é diferente do id filme");

                Filme film = item;

                film.Nome = filme.Nome;
                film.AnoLancamento = filme.AnoLancamento;
                film.Genero = filme.Genero;
                film.FaixaEtaria = filme.FaixaEtaria;
                film.Duracao = filme.Duracao;
                film.Sinopse = filme.Sinopse;

                _filmeRepositorio.Atualizar(film);
                return Ok("Alteração feita com sucesso!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id = 0)
        {
            try
            {
                var filme = _filmeRepositorio.ObterPorId(id);

                if (filme == null)
                    throw new Exception("ID filme não existe");

                _filmeRepositorio.Remover(filme);
                return Ok("Filme excluída!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
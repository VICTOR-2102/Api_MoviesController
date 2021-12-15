using Api_MoviesController.Request;
using Api_MoviesController.Response;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Repositorios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_MoviesController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayMovieController : ControllerBase
    {
        private readonly IPlayMovieRepositorio _playMovieRepositorio;
        private readonly IFilmeRepositorio _filmeRepositorio;
        private readonly IEspectadorRepositorio _espectadorRepositorio;

        public PlayMovieController(IPlayMovieRepositorio playmovie, IFilmeRepositorio filme, IEspectadorRepositorio espectador)
        {
            _playMovieRepositorio = playmovie;
            _filmeRepositorio = filme;
            _espectadorRepositorio = espectador;

        }

        // POST Para dar Play no filme Chamando Espectador e um Filme cadastrado/Marcar que um espectador viu um filme em especifico
        [HttpPost("{Espectador}")]
        public IActionResult Post([FromBody] PlayMovieRequest playmovie)
        {
            try
            {
                PlayMovie play = new PlayMovie();

                play.NomeDoEspectador = playmovie.NomeDoEspectador;
                play.FilmeId = playmovie.FilmeId;
                play.Filme = _filmeRepositorio.ObterPorId(playmovie.FilmeId);

                _playMovieRepositorio.Adicionar(play);
                return Ok(play.NomeDoEspectador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpGet("nome/{Espectadores}")]//  Para retornar quais filmes cada Espectador viu.
        public IActionResult Get(string NomeDoEspectador)
        {
            try
            {
                var espe = _playMovieRepositorio.ObterTodos().Where(
                        e => e.NomeDoEspectador.ToLower().Equals(NomeDoEspectador.ToLower())
                    );

                return Ok(espe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("{Filme}")] //Para depois fazer um Get Para retornar quantos espectadores um filme teve
        public IActionResult Post([FromBody] PlayMovieResponse playfilme)
        {
            try
            {
                PlayMovie play = new PlayMovie();


                play.NomeDoFilme = playfilme.NomeDoFilme;
                play.EspectadorId = playfilme.EspectadorId;
                play.Espectador = _espectadorRepositorio.ObterPorId(playfilme.EspectadorId);

                _playMovieRepositorio.Adicionar(play);
                return Ok(play.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        //GET por ID para retornar o nome do filme e o Espectador Cadastrado
        [HttpGet("Id/{Filme}")]
        public IActionResult Get(int id)
        {
            try
            {
                PlayMovieResponse fil = new PlayMovieResponse();
                var item = _playMovieRepositorio.ObterPorId(id);

                if (item == null)
                    throw new Exception("Id deste filme não existe");

                fil.NomeDoFilme = item.NomeDoFilme;
                fil.EspectadorId =item.EspectadorId;

                return Ok(fil);
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
                var playmovie = _playMovieRepositorio.ObterPorId(id);

                if (playmovie == null)
                    throw new Exception("ID não encontrado!");

                _playMovieRepositorio.Remover(playmovie);
                return Ok("Espectador excluido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
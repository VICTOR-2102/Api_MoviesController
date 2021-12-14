using Api_MoviesController.Request;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlayMovieRequest playmovie)
        {
            try
            {
                PlayMovie play = new PlayMovie();

                play.NomeDoFilme = playmovie.NomeDoFilme;
                play.FilmeId = playmovie.FilmeId;
                play.Filme = _filmeRepositorio.ObterPorId(playmovie.FilmeId);
                play.EspectadorId = playmovie.EspectadorId;
                play.Espectador = _espectadorRepositorio.ObterPorId(playmovie.EspectadorId);

                _playMovieRepositorio.Adicionar(play);
                return Ok(play.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpGet]


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id = 0)
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
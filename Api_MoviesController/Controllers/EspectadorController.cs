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
    public class EspectadorController : ControllerBase
    {
        private readonly IEspectadorRepositorio _espectadorRepositorio;

        public EspectadorController(IEspectadorRepositorio espectador)
        {
            _espectadorRepositorio = espectador;
        }

        // GET por nome
        [HttpGet("nome/{nome}")]
        public IActionResult Get(string nome)
        {
            try
            {
                var espec = _espectadorRepositorio.ObterTodos().Where(
                        e => e.Nome.ToLower().Equals(nome.ToLower())
                    );

                return Ok(espec);
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
                EspectadorResponse espectador = new EspectadorResponse();
                var item = _espectadorRepositorio.ObterPorId(id);

                if (item == null)
                    throw new Exception("Id Cliente não existe");

                espectador.NomeEspectador = item.Nome;
                espectador.TelefoneEspectador = item.Telefone;
                espectador.EmailEspectador = item.Email;
                espectador.CPFCNPJEspectador = item.CPFCNPJ;
                espectador.EnderecoEspectador = item.Endereco;
                espectador.DataDeNascimentoEspectador = item.DataDeNascimento;
                espectador.SexoEspectador = item.Sexo;

                return Ok(espectador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // GET obter todos
        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                List<EspectadorResponse> espectador = new List<EspectadorResponse>();
                var espectadores = _espectadorRepositorio.ObterTodos();

                foreach (var item in espectadores)
                {
                    espectador.Add(new EspectadorResponse()
                    {
                        NomeEspectador = item.Nome,
                        TelefoneEspectador = item.Telefone,
                        EmailEspectador = item.Email,
                        CPFCNPJEspectador = item.CPFCNPJ,
                        EnderecoEspectador = item.Endereco,
                        DataDeNascimentoEspectador = item.DataDeNascimento,
                        SexoEspectador = item.Sexo,
                    });
                }

                return Ok(espectador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult Post([FromBody] EspectadorRequest espectador)
        {
            try
            {
                Espectador espec = new Espectador();

                espec.Nome = espectador.Nome;
                espec.Telefone = espectador.Telefone;
                espec.Email = espectador.Email;
                espec.CPFCNPJ = espectador.CPFCNPJ;
                espec.Endereco = espectador.Endereco;
                espec.DataDeNascimento = espectador.DataDeNascimento;
                espec.Sexo = espectador.Sexo;

                _espectadorRepositorio.Adicionar(espec);
                return Ok(espec.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EspectadorRequest espectador)
        {
            try
            {
                var item = _espectadorRepositorio.ObterPorId(id);

                if (item == null)
                    throw new Exception("O ID é diferente do ID do Espectador");

                Espectador esp = item;

                esp.Nome = espectador.Nome;
                esp.Telefone = espectador.Telefone;
                esp.Email = espectador.Email;
                esp.CPFCNPJ = espectador.CPFCNPJ;
                esp.Endereco = espectador.Endereco;
                esp.DataDeNascimento = espectador.DataDeNascimento;
                esp.Sexo = espectador.Sexo;

                _espectadorRepositorio.Atualizar(esp);
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
                var espectador = _espectadorRepositorio.ObterPorId(id);

                if (espectador == null)
                    throw new Exception("ID não encontrado!");

                _espectadorRepositorio.Remover(espectador);
                return Ok("Espectador excluido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}

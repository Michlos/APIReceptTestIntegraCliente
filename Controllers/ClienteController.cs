using AutoMapper;
using IntegraCliente.Data;
using IntegraCliente.Dto;
using IntegraCliente.Interfaces;
using IntegraCliente.Model;

using Microsoft.AspNetCore.Mvc;


namespace IntegraCliente.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ClienteController : Controller
        {
            private readonly IClienteRepository _clienteRepository;
            private readonly IMapper _mapper;

            public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
            {
                _clienteRepository = clienteRepository;
                _mapper = mapper;
            }

            [HttpGet]
            [ProducesResponseType(200, Type = typeof(IEnumerable<Cliente>))]
            public IActionResult GetClientes()
            {
                var clientes = _mapper.Map<List<ClienteDto>>(_clienteRepository.GetClientes());

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(clientes);
            }

            [HttpGet("{clienteId}")]
            [ProducesResponseType(200, Type = typeof(Cliente))]
            [ProducesResponseType(400)]
            public IActionResult GetCliente(long clienteId)
            {
                if (!_clienteRepository.ClienteExists(clienteId))
                    return NotFound();

                var cliente = _mapper.Map<ClienteDto>(_clienteRepository.GetCliente(clienteId));

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(cliente);
            }


            [HttpPost]
            [ProducesResponseType(204)]
            [ProducesResponseType(400)]
            public IActionResult CreateCliente([FromBody] Cliente clienteCreate)
            {
                var cliEntry = new Cliente();
                cliEntry = clienteCreate;

                if (cliEntry == null)
                    return BadRequest(ModelState);

                var clientes = _clienteRepository.GetClientes()
                    .Where(c => c.Cgc == cliEntry.Cgc)
                    .FirstOrDefault();

                if (clientes != null)
                {
                    ModelState.AddModelError("", "Cliente já cadastrado");
                    return StatusCode(422, ModelState);
                }

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!_clienteRepository.CreateCliente(cliEntry))
                {
                    ModelState.AddModelError("", "Algo deu errado ao tentar salvar os dados do Cliente");
                    return StatusCode(500, ModelState);
                }

                return Ok("Cliente Cadastrado com Sucesso");

            }

    }
}

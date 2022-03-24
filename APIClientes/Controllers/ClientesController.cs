#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIClientes.Data;
using APIClientes.Modelo;
using APIClientes.Repositorio;
using APIClientes.Modelo.DTo;
using Microsoft.AspNetCore.Authorization;

namespace APIClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Para que alguien pueda acceder a cualquier de los metetodos debe estar autorizado
    [Authorize]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        protected ResponseDTo _response;

        public ClientesController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            _response = new ResponseDTo();
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            try
            {
                var lista = await _clienteRepositorio.GetClientes();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Clientes";

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMesagge = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _clienteRepositorio.GetClienteById(id);
            if (cliente==null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "El cliente no existe";
                return NotFound(_response);
            }
            _response.Result = cliente;
            _response.DisplayMessage = "Informacion del cliente";
            return Ok(_response);

        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteDTo clienteDTo)
        {
            try
            {
                ClienteDTo model = await _clienteRepositorio.CreateUpdate(clienteDTo);
                _response.Result =model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess=false;
                _response.DisplayMessage = "Error al actualizar el registro";
                _response.ErrorMesagge = new List<string> {ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(ClienteDTo clienteDTo)
        {
            try
            {
                ClienteDTo model = await _clienteRepositorio.CreateUpdate(clienteDTo);
                _response.Result = model;
                return CreatedAtAction("GetCliente", new { id = model.Id }, _response);

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al grabar el registro";
                _response.ErrorMesagge = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }

        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                bool estaEliminado = await _clienteRepositorio.DeleteCliente(id);
                if (estaEliminado)
                {
                    _response.Result = estaEliminado;
                    _response.DisplayMessage = "Cliente eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess=false;
                    _response.DisplayMessage = "Error al eliminar cliente";
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMesagge = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

    }
}

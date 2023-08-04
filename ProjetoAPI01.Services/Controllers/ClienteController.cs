using Microsoft.AspNetCore.Mvc;
using ProjetoAPI01.Repository.Entities;
using ProjetoAPI01.Repository.Interfaces;
using ProjetoAPI01.Services.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ProjetoAPI01.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienterepository;

        public ClienteController(IClienteRepository clienterepository)
        {
            _clienterepository = clienterepository;
        }
        [HttpPost]
        public IActionResult Post(ClienteCadastroModel model)
        {
            try
            {

                if (_clienterepository.GetByEmail(model.Email) != null)
                            
                    return BadRequest(new
                    {Mensagem = $"O email'${model.Email}',já está cadastrado,tente outro." });
                    

                var cliente = new Cliente();
                cliente.Nome = model.Nome;
                cliente.Email = model.Email;
                _clienterepository.Create(cliente);
                
                return Ok(new
                {
                    Mensagem = $"Cliente {cliente.Nome},cadastrado com sucesso."
                });

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);

            }
        }


        [HttpPut] //método para atualizar um cliente na API
        public IActionResult Put(ClienteEdicaoModel model)
        {
            try
            {
                var cliente = _clienterepository.GetById(model.IdCliente);
                
                if (cliente != null)
                {
                    var registro = _clienterepository.GetByEmail(model.Email);
                    if (registro != null && registro.IdCliente

                    != cliente.IdCliente)

                        return BadRequest(new
                        {
                            Mensagem = $"O email '{model.Email}' já está cadastrado para outro cliente." });
                        
                    cliente.Nome = model.Nome;
                    cliente.Email = model.Email;
                    _clienterepository.Update(cliente);
                    

                    return Ok(new
                    {
                        Mensagem = $"Cliente {cliente.Nome},atualizado com sucesso." });

                    }
                else
                {
                    return BadRequest(new
                    {
                        Mensagem = $"Cliente não encontrado.ID '{model.IdCliente}' inválido." });

                    }
                }
                catch (Exception e)
            {
                
                return StatusCode(500, e.Message);
            }
        }


        [HttpDelete("{id}")] 
        public IActionResult Delete(Guid id)
        {
            try
            {
                var cliente = _clienterepository.GetById(id);
               
                if (cliente != null)
                {
                    _clienterepository.Delete(cliente);
                   

                    return Ok(new
                    {Mensagem = $"Cliente {cliente.Nome}, excluído com sucesso." });

                }
                    else
                    {
                        return BadRequest(new
                        { Mensagem = $"Cliente não encontrado. ID '{id}' inválido." });

                    }
                 }
                    catch (Exception e)
                    {
                
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet] 
        public IActionResult GetAll()
        {
            try
            {
                
                return Ok(_clienterepository.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("{id}")] 
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_clienterepository.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}


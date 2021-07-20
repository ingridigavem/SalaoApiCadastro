using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SalaoApi.Models;
using System;
using System.Linq;

namespace SalaoApi.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : ControllerBase {


        private IMongoCollection<Cadastro> _cadastroCollection;

        public CadastroController(IMongoClient client) {

            var database = client.GetDatabase("salaoDatabase");
            _cadastroCollection = database.GetCollection<Cadastro>("cadastros");
        }

        [HttpGet]
        public IActionResult GetCadastros() {
            return Ok(_cadastroCollection.Find(c => true).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCadastroById(string id) {
            try {
                var cadastro = _cadastroCollection.Find(c => c.Id == id).FirstOrDefault();
                if (cadastro != null) {
                    return Ok(cadastro);
                }
                return NotFound();
            } catch (Exception e) {
                return BadRequest(e.Message);              
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cadastro cadastro) {
            _cadastroCollection.InsertOne(cadastro);
            return CreatedAtAction(nameof(GetCadastroById), new { Id = cadastro.Id }, cadastro);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCadastro(string id, [FromBody] Cadastro updatedCadastro) {
            try {
                var cadastro = _cadastroCollection.ReplaceOne(c => c.Id == id, updatedCadastro);
                if (cadastro == null) {
                    return NotFound();
                }
                return NoContent();

            } catch (Exception e) {
                return BadRequest(e.Message); 
            }    
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCadastroById(string id) {
            try {
                var cadastro = _cadastroCollection.DeleteOne(c => c.Id == id);
                return NoContent();

            } catch (Exception e) {
                return BadRequest(e.Message);
            }           
        }

    }
}

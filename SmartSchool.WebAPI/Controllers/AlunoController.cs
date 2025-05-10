using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public AlunoController()
        {
            
        }


        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno(){
                Id = 1, Nome = "Marcos", SobreNome = "Queróz", Telefone = "119636488905",
            },
            new Aluno(){
                Id = 2, Nome = "Luciana", SobreNome = "Santos", Telefone = "11977488909"
            },
            new Aluno(){
                Id = 3, Nome = "Maria", SobreNome = "Silva", Telefone = "11977488909"
            }
        };
            
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var alunos = Alunos.FirstOrDefault(a => a.Id == id);
            if(alunos == null) return BadRequest("O aluno não foi encontrado!");
        
            return Ok(alunos);
        }
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var alunos = Alunos.FirstOrDefault(a => a.Nome.ToUpper().Contains(nome.ToUpper().ToUpper().Trim()));
            if(alunos == null) return BadRequest("O aluno não foi encontrado!");
        
            return Ok(alunos);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }
        
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Put(int id)
        {
            return Ok();
        }

    }
}
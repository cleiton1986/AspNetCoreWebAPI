using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly SmartSchoolContext _dbContext;
        public AlunoController(SmartSchoolContext dbContext)
        {
            _dbContext = dbContext;
        }
  
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Alunos);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var alunos = _dbContext.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(alunos == null) return BadRequest("O aluno não foi encontrado!");
        
            return Ok(alunos);
        }
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var alunos = _dbContext.Alunos.AsNoTracking().FirstOrDefault(a => a.Nome.ToUpper().Contains(nome.ToUpper().ToUpper().Trim()));
            if(alunos == null) return BadRequest("O aluno não foi encontrado!");
        
            return Ok(alunos);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _dbContext.Alunos.Add(aluno);
            _dbContext.SaveChanges();
           // return Created($"/api/aluno/{aluno.Id}", aluno);
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alunoBanco = _dbContext.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(alunoBanco == null) return BadRequest("O aluno não foi encontrado!");

            alunoBanco.Nome = aluno.Nome;
            alunoBanco.SobreNome = aluno.SobreNome;
            alunoBanco.Telefone = aluno.Telefone;

            _dbContext.Alunos.Update(alunoBanco);
            _dbContext.SaveChanges();
            return Ok(alunoBanco);
        }
        
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alunoBanco = _dbContext.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(alunoBanco == null) return BadRequest("O aluno não foi encontrado!");

            alunoBanco.Nome = aluno.Nome;
            alunoBanco.SobreNome = aluno.SobreNome;
            alunoBanco.Telefone = aluno.Telefone;
            _dbContext.Alunos.Update(alunoBanco);
            return Ok(alunoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alunoBanco = _dbContext.Alunos.FirstOrDefault(a => a.Id == id);
            if(alunoBanco == null) return BadRequest("O aluno não foi encontrado!");

            _dbContext.Alunos.Remove(alunoBanco);
            _dbContext.SaveChanges();
            return Ok();
        }

    }
}
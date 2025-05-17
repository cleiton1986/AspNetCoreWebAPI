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
    public class ProfessorController : ControllerBase
    {
        private readonly SmartSchoolContext _dbContext;
        public ProfessorController(SmartSchoolContext dbContext)
        {
            _dbContext = dbContext;
        }
           [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Professores);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professores = _dbContext.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(professores == null) return BadRequest("O professor não foi encontrado!");
        
            return Ok(professores);
        }
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var professores = _dbContext.Professores.AsNoTracking().FirstOrDefault(a => a.Nome.ToUpper().Contains(nome.ToUpper().ToUpper().Trim()));
            if(professores == null) return BadRequest("O professor não foi encontrado!");
        
            return Ok(professores);
        }

        [HttpPost]
        public IActionResult Post(Professor professores)
        {
            _dbContext.Professores.Add(professores);
            _dbContext.SaveChanges();
           // return Created($"/api/aluno/{aluno.Id}", aluno);
            return Ok(professores);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var professoresBanco = _dbContext.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(professoresBanco == null) return BadRequest("O professor não foi encontrado!");

            professoresBanco.Nome = professor.Nome;

            _dbContext.Professores.Update(professoresBanco);
            _dbContext.SaveChanges();
            return Ok(professoresBanco);
        }
        
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var professoresBanco = _dbContext.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(professoresBanco == null) return BadRequest("O professor não foi encontrado!");

            professoresBanco.Nome = professor.Nome;
            _dbContext.Professores.Update(professoresBanco);
            return Ok(professoresBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professoresBanco = _dbContext.Professores.FirstOrDefault(a => a.Id == id);
            if(professoresBanco == null) return BadRequest("O professor não foi encontrado!");

            _dbContext.Professores.Remove(professoresBanco);
            _dbContext.SaveChanges();
            return Ok();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.models
{
    public class Aluno
    {
        public Aluno(){}
        public Aluno(int id,string nome, string sobreNome, string telefone) 
        {
            this.Id = id;
            this.Nome = nome;
            this.SobreNome = sobreNome;
            this.Telefone = telefone;
        }
         public int Id { get; set; }
         public string Nome { get; set; }
         public string SobreNome { get; set; }
         public string Telefone { get; set; }
         public Disciplina Disciplinas { get; set; }
         public IEnumerable<AlunoDisciplina> AlunoDisciplinas { get; set; }
    }
}
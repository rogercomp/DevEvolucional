using System;
using System.Collections.Generic;
using System.Text;

namespace DevEvolucional.Model.Dtos
{
    public class Aluno_DisciplinaDto
    {
        public Aluno_DisciplinaDto(int idAluno, int idDisciplina, decimal nota, string nomeAluno, string nomeDisciplina)
        {
            IdAluno = idAluno;
            IdDisciplina = idDisciplina;
            Nota = nota;
            NomeAluno = nomeAluno;
            NomeDisciplina = nomeDisciplina;
        }

        public int IdAluno { get; private set; }
        public int IdDisciplina { get; private set; }
        public decimal Nota { get; private set; }
        public string NomeAluno { get; private set; }
        public string NomeDisciplina { get; private set; }
    }
}

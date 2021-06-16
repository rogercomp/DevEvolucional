using System;
using System.Collections.Generic;
using System.Text;

namespace DevEvolucional.Model.Dtos
{
    public class DisciplinaDto
    {
        public DisciplinaDto(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
    }
}

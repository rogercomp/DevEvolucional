using System;
using DevEvolucional.Model.Entities;
using DevEvolucional.Model.Interfaces;

namespace DevEvolucional.Data.Repositories
{
    public class AlunoRepository : GenericRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}

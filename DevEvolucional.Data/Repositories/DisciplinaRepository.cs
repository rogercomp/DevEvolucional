using System;
using DevEvolucional.Model.Entities;
using DevEvolucional.Model.Interfaces;

namespace DevEvolucional.Data.Repositories
{
    public class DisciplinaRepository : GenericRepository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}

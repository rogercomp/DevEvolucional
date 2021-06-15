using System;
using DevEvolucional.Data.Repositories;
using DevEvolucional.Model.Interfaces;

namespace DevEvolucional.Data
{
	public class UnitOfWork : IUnitOfWork
    {
		public ApplicationContext Context { get; internal set; }

		private IUsuarioRepository usuarioRepository;
		private AlunoRepository alunoRepository;
		private DisciplinaRepository disciplinaRepository;

        public UnitOfWork(ApplicationContext context)
        {
			this.Context = context;
        }

		public IUsuarioRepository UsuarioRepository
		{
			get
			{
				if (this.usuarioRepository == null)
					this.usuarioRepository = new UsuarioRepository(this.Context);
				return this.usuarioRepository;
			}
		}

		public IAlunoRepository AlunoRepository
        {
			get
			{
				if (this.alunoRepository == null)
					this.alunoRepository = new AlunoRepository(this.Context);
				return this.alunoRepository;
			}
        }

		public IDisciplinaRepository DisciplinaRepository
		{
			get
			{
				if (this.disciplinaRepository == null)
					this.disciplinaRepository = new DisciplinaRepository(this.Context);
				return this.disciplinaRepository;
			}
		}

		public bool SaveChanges()
		{
			return this.Context.SaveChanges() > 0;
		}
    }
}

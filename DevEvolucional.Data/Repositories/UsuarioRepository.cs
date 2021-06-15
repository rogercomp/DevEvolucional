using System;
using DevEvolucional.Model.Entities;
using DevEvolucional.Model.Interfaces;

namespace DevEvolucional.Data.Repositories
{
	public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
		public UsuarioRepository(ApplicationContext context) 
			: base (context)
        {
        }
    }
}

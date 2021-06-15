using System;
namespace DevEvolucional.Model.Interfaces
{
    public interface IUnitOfWork
    {
		IUsuarioRepository UsuarioRepository { get; }

		bool SaveChanges();
    }
}

using System;
namespace DevEvolucional.Model.Entities
{
	public class Usuario
	{
		public virtual int IdUsuario { get; set; }
		public virtual string Login { get; set; }
		public virtual string Hash { get; set; }
		public virtual string Salt { get; set; }
	}
}

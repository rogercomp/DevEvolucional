using DevEvolucional.Model.Dtos;
using DevEvolucional.Model.Entities;
using DevEvolucional.Model.Interfaces;
using DevEvolucional.Utils;
using System.Collections.Generic;
using System.Linq;

namespace DevEvolucional.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioBusiness(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public virtual UsuarioDto Autenticar(LoginDto loginDto)
        {
            var usuario = this._unitOfWork
                .UsuarioRepository
                .Get(q => q.Login.ToLower().Equals(loginDto.Usuario))
                .FirstOrDefault();

            if (!SecurityManager.Validate(loginDto.Senha, usuario.Salt, usuario.Hash))
                return null;

            return new UsuarioDto
            {
                IdUsuario = usuario.IdUsuario,
                Login = usuario.Login
            };
        }

        public IEnumerable<UsuarioDto> Filtrar()
        {
            var query = this._unitOfWork
                .UsuarioRepository
                .Get(null, o => o.OrderBy(u => u.Login))
                .Select(s => new UsuarioDto
                {
                    IdUsuario = s.IdUsuario,
                    Login = s.Login
                });
            return query.ToList();
        }

        public UsuarioDto Selecionar(int id)
        {
            var usuario = this._unitOfWork
                .UsuarioRepository
                .GetById(id);

            return new UsuarioDto
            {
                IdUsuario = usuario.IdUsuario,
                Login = usuario.Login
            };
        }

        public ResultadoDto Excluir(int id)
        {
            this._unitOfWork.UsuarioRepository.Delete(id);
            var sucesso = this._unitOfWork.SaveChanges();
            return new ResultadoDto
            {
                Sucesso = sucesso
            };
        }

        public ResultadoDto Salvar(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario();

            if (usuarioDto.IdUsuario > 0)
            {
                usuario = this._unitOfWork.UsuarioRepository.GetById(usuarioDto.IdUsuario);

                this._unitOfWork.UsuarioRepository.Update(usuario);
            }
            else
            {                
                var salt = SecurityManager.CreateSalt();
                var hash = SecurityManager.CreateHash(usuarioDto.Senha, salt);

                usuario = new Usuario();
                usuario.Login = usuarioDto.Login;
                usuario.Hash = hash;
                usuario.Salt = salt;
                this._unitOfWork.UsuarioRepository.Add(usuario);
            }

            var sucesso = this._unitOfWork.SaveChanges();
            var resultado = new ResultadoDto
            {
                Sucesso = sucesso,
                Id = usuario.IdUsuario
            };
            
            return resultado;
        }
    }
}

using Dapper;
using DevEvolucional.Model.Dtos;
using DevEvolucional.Model.Entities;
using DevEvolucional.Model.Interfaces;
using DevEvolucional.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;


namespace DevEvolucional.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public UsuarioBusiness(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this._unitOfWork = unitOfWork;
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
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
           

       
    }
}

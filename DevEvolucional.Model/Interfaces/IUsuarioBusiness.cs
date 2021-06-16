using System;
using System.Collections.Generic;
using DevEvolucional.Model.Dtos;
using DevEvolucional.Model.Entities;

namespace DevEvolucional.Model.Interfaces
{
    public interface IUsuarioBusiness
    {
        UsuarioDto Autenticar(LoginDto loginDto);
        IEnumerable<UsuarioDto> Filtrar();
        UsuarioDto Selecionar(int id);
        ResultadoDto Excluir(int id);
        ResultadoDto GerarBaseAluno();
        ResultadoDto GerarPlanilha();
        ResultadoDto Salvar(UsuarioDto usuario);
    }
}

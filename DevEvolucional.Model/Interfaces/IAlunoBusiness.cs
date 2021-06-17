using System;
using System.Collections.Generic;
using System.Data;
using DevEvolucional.Model.Dtos;
using DevEvolucional.Model.Entities;

namespace DevEvolucional.Model.Interfaces
{
    public interface IAlunoBusiness
    {
        ResultadoDto GerarBaseAluno();
        DataTable GerarPlanilha();
    }
}

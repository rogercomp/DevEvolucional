using ClosedXML.Excel;
using Dapper;
using DevEvolucional.Model.Dtos;
using DevEvolucional.Model.Entities;
using DevEvolucional.Model.Interfaces;
using DevEvolucional.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace DevEvolucional.Business
{
    public class AlunoBusiness : IAlunoBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public AlunoBusiness(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this._unitOfWork = unitOfWork;
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public ResultadoDto GerarBaseAluno()
        {
            var dir = _configuration["SaveDirFile:Path"];
            var file = _configuration["SaveDirFile:File"];
            int counter = 0;
            string line;

            System.IO.StreamReader arquivo = new System.IO.StreamReader(dir + file);

            //Criando os aluno e disciplinas            
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                using (var sqlCommand = new SqlCommand())
                {
                    if (sqlConnection.State == System.Data.ConnectionState.Closed)
                        sqlConnection.Open();

                    var script = "";
                    while ((line = arquivo.ReadLine()) != null)
                    {
                        script = line;
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandText = line;
                        sqlCommand.ExecuteNonQuery();
                        counter++;
                    }
                    arquivo.Close();

                    // Inserir 1 nota para cada aluno e para cada disciplina
                    if (sqlConnection.State == System.Data.ConnectionState.Closed)
                        sqlConnection.Open();

                    script = "SELECT Id, Nome FROM Aluno ";

                    List<AlunoDto> alunos = sqlConnection.Query<AlunoDto>(script).ToList();

                    script = "SELECT Id, Nome FROM Disciplina ";

                    List<DisciplinaDto> disciplinas = sqlConnection.Query<DisciplinaDto>(script).ToList();

                    script = "INSERT INTO Aluno_Disciplina(IdAluno, IdDisciplina, Nota) VALUES(@IdAluno, @IdDisciplina, @Nota) ";

                    // Define as informações do parâmetro criado
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@IdAluno";
                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@IdDisciplina";
                    SqlParameter param3 = new SqlParameter();
                    param3.ParameterName = "@Nota";

                    // Inserindo o parâmetro no comando
                    sqlCommand.Parameters.Add(param1);
                    sqlCommand.Parameters.Add(param2);
                    sqlCommand.Parameters.Add(param3);

                    Random rnd = new Random();

                    foreach (AlunoDto aluno in alunos)
                    {
                        foreach (DisciplinaDto disciplina in disciplinas)
                        {
                            sqlCommand.Connection = sqlConnection;
                            sqlCommand.CommandText = script;

                            param1.Value = aluno.Id;
                            param2.Value = disciplina.Id;
                            param3.Value = rnd.Next(0, 10);

                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }
            }


            return new ResultadoDto
            {
                Sucesso = true
            };
        }

        public DataTable GerarPlanilha()
        {
            var script = "";

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                using (var sqlCommand = new SqlCommand())
                {
                    if (sqlConnection.State == System.Data.ConnectionState.Closed)
                        sqlConnection.Open();                 

                    script = "SELECT a.IdAluno, a.IdDisciplina, a.Nota, b.Nome as NomeAluno, c.Nome as NomeDisciplina " +
                             "FROM Aluno_Disciplina a " +
                             "INNER JOIN Aluno b ON(b.Id = a.Idaluno) " +
                             "INNER JOIN Disciplina c ON(c.Id = a.IdDisciplina) ";

                    List<Aluno_DisciplinaDto> alunoDisciplina = sqlConnection.Query<Aluno_DisciplinaDto>(script).ToList();


                    DataTable pivotTable = alunoDisciplina.ToPivotTable(                             
                             item => item.NomeDisciplina,
                             item => item.NomeAluno,
                             items => items.Any() ? items.Average(x => x.Nota) : 0);

                    pivotTable.TableName = "AlunoDisciplina";

                    return pivotTable;

                }

            }

            //return new ResultadoDto
            //{
            //    Sucesso = true
            //};
        }

        private void ExporttoExcel(DataTable table)
        {
            
        }
    }
}

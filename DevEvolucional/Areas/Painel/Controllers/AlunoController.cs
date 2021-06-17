using ClosedXML.Excel;
using DevEvolucional.Model.Dtos;
using DevEvolucional.Model.Interfaces;
using DevEvolucional.WebApp.Areas.Painel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace DevEvolucional.WebApp.Areas.Painel.Controllers
{
    [Area("Painel")]
    [Authorize]
    public class AlunoController : Controller
    {
        private readonly IAlunoBusiness _alunoBusiness;
        public AlunoController(IAlunoBusiness alunoBusiness)
        {
            this._alunoBusiness = alunoBusiness;
        }

        public IActionResult Action1()
        {
            var resultado = _alunoBusiness.GerarBaseAluno();

            return Json(new ResultadoViewModel
            {
                Sucesso = resultado.Sucesso
            });

            //return RedirectToAction("Action1", "Aluno");
        }
        public IActionResult Action2()
        {
            var resultado = _alunoBusiness.GerarPlanilha();

            string fileName = "Sample.xlsx";
            using (XLWorkbook wb = new XLWorkbook())
            {
                //Add DataTable in worksheet  
                wb.Worksheets.Add(resultado);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    //Return xlsx Excel File  
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }


            /*  return Json(new ResultadoViewModel
            {
                Sucesso = resultado.Sucesso
            });*/
        }
    }
}

using DevEvolucional.Model.Dtos;
using DevEvolucional.Model.Interfaces;
using DevEvolucional.WebApp.Areas.Painel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevEvolucional.WebApp.Areas.Painel.Controllers
{
    [Area("Painel")]
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public UsuarioController(IUsuarioBusiness usuarioBusiness)
        {
            this._usuarioBusiness = usuarioBusiness;
        }

        public IActionResult Action1()
        {
            var resultado = _usuarioBusiness.GerarBaseAluno();

            return Json(new ResultadoViewModel
            {
                Sucesso = resultado.Sucesso              
            });
        }
        public IActionResult Action2()
        {
            var resultado = _usuarioBusiness.GerarPlanilha();

            return Json(new ResultadoViewModel
            {
                Sucesso = resultado.Sucesso
            });
        }
    }
}
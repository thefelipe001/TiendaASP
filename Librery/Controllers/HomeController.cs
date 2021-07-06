using Librery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Librery.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
           var lista= editorialDao.Mostrar();
            return View(lista);
        }



        [HttpGet]
        public ActionResult BuscarEditorial()
        {
            List<editoriales> data = editorialDao.Mostrar();
            SelectList lista = new SelectList(data, "codigo", "nombre");
            ViewBag.ListaCategorias = lista;

            List<editoriales> listas = editorialDao.Mostrar();
            return View(listas);
        }
        [HttpPost]
        public ActionResult BuscarEditorial(string txtnombre)
        {

            if (txtnombre == "" )
            {
                txtnombre = "-1";
              
            }
           

            List<editoriales> data = editorialDao.Mostrar();
            SelectList lista = new SelectList(data, "nombre", "codigo");
            ViewBag.ListaCategorias = lista;

            editoriales editorial = new editoriales();
            editorial.nombre = txtnombre;

            List<editoriales> obj = editorialDao.TodolasCategoria(editorial);
            mensajeErrorServidor(editorial);
            return View(obj);
        }



        public void mensajeErrorServidor(editoriales objProducto)
        {
            switch (objProducto.nombre)
            {
                case "h":
                    ViewBag.MensajeError = "ERROR DE SERVIDOR DE SQL SERVER";
                    break;
            }
        }





        public ActionResult Registro()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Registro( string nombre)
        {
            var lista = new editoriales()
            {
            
                nombre = nombre

            };
          
                editorialDao.Agregar(lista);



            return RedirectToAction(nameof(Index));
        }



        public ActionResult Eliminar(byte id)
        {

            try
            {
                editorialDao.Eliminar(id);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            //  return RedirectToAction("Index");
        }

       
        public ActionResult Obtener(byte codigo)
        {
            var customer = editorialDao.Obtener(codigo);
            return View(customer);
        }



    }
}
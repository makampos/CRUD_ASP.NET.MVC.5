using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projeto01.Contexts;
using Projeto01.Models;

namespace Projeto01.Controllers
{   /// <summary>
    /// 
    /// </summary>
    public class FabricantesController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Fabricantes
        /// <summary>
        ///  Action capta uma requisição HTTP GET
        /// </summary>
        /// <returns>Retorna a view Index com o nome dos fabricantes ordenamos em ordem alfabética</returns>
        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(c => c.Nome));
        }

        // GET: Create
        /// <summary>
        /// Action capta uma requisção HTTP GET
        /// </summary>
        /// <returns>Retorna a view Create</returns>
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create
        /// <summary>
        ///  Action capta uma requisição HTTP POST. 
        ///  Insere o objeto recebido no Dbset Fabricantes e em seguida realiza atualização no banco de dados
        /// </summary>
        /// <param name="fabricante">Objeto do tipo fabricante</param>
        /// <returns>Retorna para a view Index</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Fabricante fabricante)
        {
            context.Fabricantes.Add(fabricante);
            context.SaveChanges();            
            return RedirectToAction("Index");
        }

        // GET: Fabricantes/Edit/5
        /// <summary>
        /// Action capta uma requisição HTTP GET e faz uma validação.
        /// </summary>
        /// <param name="id"> Id do objeto</param>
        /// <returns>Retorna a view fabricante</returns>
        public ActionResult Edit (long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.Find(id);
            if ( fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        // POST: Fabricantes
        /// <summary>
        ///  Action capta uma requisição HTTP POST faz uma validação e salva os dados no banco de dados
        /// </summary>
        /// <param name="fabricante">Objeto do tipo fabricante</param>
        /// <returns>retorna para view Index caso validação OK se não retorna view fabricante</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                context.Entry(fabricante).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fabricante);
        }

        //GET: Details
        /// <summary>
        ///  Action capta uma requisição HTTP GET e faz validação.
        /// </summary>
        /// <param name="id">Id do objeto</param>
        /// <returns>Retorna view fabricante</returns>
        public ActionResult Details (long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View (fabricante);
        }

        //GET: Fabricantes/Delete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult  Delete (long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.Find(id);
            if(fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        //POST: Fabricantes/Delete
        /// <summary>
        ///  Action captura uma requisição HTTP POST e realiza o DELETE do objeto requisitado.
        ///  TempData cria a chave MESSAGE e nela armazena um valor que  será recuperada na View DELETE
        /// </summary>  
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (long id)
        {
            Fabricante fabricante = context.Fabricantes.Find(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            TempData["Message"] = "Fabricante" + fabricante.Nome.ToUpper() + "foi removido";
            return RedirectToAction("Index");
        }
    }
}
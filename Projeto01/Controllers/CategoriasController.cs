using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto01.Models;

namespace Projeto01.Controllers
{
    /// <summary>
    /// Classe que representa uma lista de categorias de produtos
    /// </summary>
    public class CategoriasController : Controller
    {   
        private static IList<Categoria> categorias = new List<Categoria>()
        {   
            new Categoria()
            {
                CategoriaId = 1, Nome = "Notebooks"
            },

            new Categoria()
            {   
                CategoriaId = 2, Nome = "Monitores"
            },
            new Categoria()
            {
                CategoriaId = 3, Nome = "Impressoras"
            },
            new Categoria()
            {
                CategoriaId = 4, Nome = "Mouses"
            },
            new Categoria()
            {
                CategoriaId = 5, Nome = "Desktops"
            },
        };

        // GET: Categorias
        /// <summary>
        /// Action Captura uma requisião HTTP GET
        /// </summary>
        /// <returns>Retorna a view "Index" com os objetos ordenados em ordem alfabética</returns>
        public ActionResult Index()
        {   
            return View(categorias.OrderBy(c => c.Nome));
        }

        // GET: Create
        /// <summary>
        /// Action captura uma requisição HTTP GET
        /// </summary>
        /// <returns>Retorna a view Create</returns>
        public ActionResult Create ()
        {
            return View();
        }

        
        // POST: Categorias
        /// <summary>
        ///  Action captura uma requisição HTTP POST para criar objeto
        /// </summary>
        /// <param name="categoria">Objeto do tipo categoria</param>
        /// <returns>Retorna a view "Index"</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Categoria categoria)
        {
            categorias.Add(categoria);
            categoria.CategoriaId = categorias.Select(m => m.CategoriaId).Max() + 1;
            return RedirectToAction("Index");
        }
        
        // GET: Edit
        /// <summary>
        /// Action captura uma requisição HTTP GET
        /// </summary>
        /// <param name="id">Id do objeto</param>
        /// <returns>Retorna a view Edit do objeto requisitado</returns>
        public ActionResult Edit (long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        // POST: Edit
        /// <summary>
        ///  Action aptura uma requisição HTTP POST para editar um objeto
        /// </summary>
        /// <param name="categoria">Objeto do tipo categoria</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Categoria categoria)
        {
            //categorias.Remove(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            //categorias.Add(categoria);

            // ou
            /*
                Uma maneira	alternativa	para	alterar	um	item	da lista, sem	 ter
                de remover	 e inseri-lo novamente, é fazer uso	 da implementação
	            categorias[categorias.IndexOf(categorias.Where(c	 => c.CategoriaId	== categoria.CategoriaId).First())]	 =
                categoria;. Aqui o List	 é	manipulado como um array e,	por meio	do	método	IndexOf(),sua posição	é recuperada,	com	base
                na instrução  LINQ	 Where(c	 =>	 c.CategoriaId == categoria.CategoriaId).First())	
             */
            categorias[categorias.IndexOf(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First())] = categoria;
            return RedirectToAction("Index");
        }

        // GET: Details
        /// <summary>
        /// Action captura uma requisião HTTP GET
        /// </summary>
        /// <param name="id">Id da categoria do objeto</param>
        /// <returns>Retorna a view Details do objeto requisitado</returns>
        public ActionResult Details (long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        // GET: Delete
        /// <summary>
        /// Action captura uma requisição HTTP GET
        /// </summary>
        /// <param name="id"> Id da categoria do objeto</param>
        /// <returns>Retorna a view Delete do objeto requisitado</returns>
        public ActionResult Delete (long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        // POST: Delete
        /// <summary>
        /// Action captura uma requisição HTTP POST 
        /// </summary>
        /// <param name="categoria">Objeto do tipo categoria</param>
        /// <returns>Deleta o objeto requisitado e retorna para a página "Index"</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            return RedirectToAction("Index");
        }
    }
}
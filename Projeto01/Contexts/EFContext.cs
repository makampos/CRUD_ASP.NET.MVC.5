using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Projeto01.Models;

namespace Projeto01.Contexts
{   /// <summary>
    /// Classe que representa a conexão com o banco de dados
    /// </summary>
    public class EFContext : DbContext
    {      /// <summary>
           /// Construtor base da classe EFContext que recebe a Connection String 
           /// </summary>
        public EFContext() : base("Asp_Net_MVC_CS") {
        
        }
        /// <summary>
        /// Classe persistida no banco de dados
        /// </summary>
        public DbSet<Categoria> Categorias { get; set; }

        /// <summary>
        /// Classe persistida no banco de dados
        /// </summary>
        public DbSet<Fabricante> Fabricantes { get; set; }
    }
}
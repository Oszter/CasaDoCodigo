using CasaDoCodigo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext context;

        public DataService(ApplicationContext context)
        {
            this.context = context;
        }

        public void InicializaDB()
        {
            context.Database.EnsureCreated();
            var json = File.ReadAllText(@"C:\Users\Rodrigo\Desktop\ASPNETCore20-5fc8ba0d3a47d8344c2bac9a32edfbe177b35a9d\_Recursos\dados\livros.json");
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);

            foreach (var livro in livros)
            {
                context.Set<Produto>().Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
            }
            context.SaveChanges();
        }
    }
}

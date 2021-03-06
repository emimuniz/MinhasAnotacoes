using AluraTunes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AluraTunes
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraTunesEntities())
            {
                var query = from g in contexto.Generoes
                            select g;



                foreach(var genero in query)
                {
                    Console.WriteLine("{0}\t{1}", genero.GeneroId, genero.Nome);
                }


                Console.WriteLine("");

                var faixaEGenero = from g in contexto.Generoes
                                   join f in contexto.Faixas
                                        on g.GeneroId equals f.GeneroId
                                        select new { f, g };

                faixaEGenero = faixaEGenero.Take(10);

                contexto.Database.Log = Console.WriteLine;

                foreach (var item in faixaEGenero)
                {
                    Console.WriteLine("{0}\t{1}", item.f.Nome, item.g.Nome);
                }



            }

            Console.ReadKey();
        }
    }
}

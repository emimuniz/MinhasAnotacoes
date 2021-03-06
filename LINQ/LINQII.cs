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

                var textoBusca = "Led";

                var query = from a in contexto.Artistas
                            where a.Nome.Contains(textoBusca)
                            select a;



                foreach(var artista in query)
                {
                    Console.WriteLine("{0}\t{1}",artista.ArtistaId, artista.Nome);
                }



                var query2 = contexto.Artistas.Where(a => a.Nome.Contains(textoBusca));

                Console.WriteLine();

                foreach (var artista in query2)
                {
                    Console.WriteLine("{0}\t{1}", artista.ArtistaId, artista.Nome);
                }

            }

            Console.ReadKey();
        }
    }
}

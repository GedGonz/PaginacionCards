using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaginacionCards.Controllers
{
    public class HomeController : Controller
    {
        List<Articulos> Lista = null;
        int _TotalRegistros = 0;
        int _RegistrosPorPagina = 4;
        PaginadorGenerico<Articulos> _PaginadorArticulos;
        public HomeController()
        {
            Lista = new List<Articulos>()
            {
                new Articulos()
                {
                    Id = 1,
                    Titulo = "Pompeya",
                    Descripcion ="Novela de Romana",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 2,
                    Titulo = "Ruby",
                    Descripcion ="Lenguaje de Programacion",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 3,
                    Titulo = "Blanca Navidad",
                    Descripcion ="Hitorias de Navidad",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 4,
                    Titulo = "C#",
                    Descripcion ="El Lenguaje para las Epresas",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 5,
                    Titulo = "Domino",
                    Descripcion ="Un juego de Mesa",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 6,
                    Titulo = "Avatar",
                    Descripcion ="La pelicula del Año",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 7,
                    Titulo = "Playas",
                    Descripcion ="Donde ir este verano",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 8,
                    Titulo = "El Alchol",
                    Descripcion ="No tomar si maneja",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 9,
                    Titulo = "Aple",
                    Descripcion ="Una Ejemplo para todos",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 10,
                    Titulo = "Stve Jobs",
                    Descripcion ="La Distorcion de la Realidad",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 11,
                    Titulo = "WOOZZ",
                    Descripcion ="El genio tras de Aple",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 12,
                    Titulo = "Libros",
                    Descripcion ="El Silencion de la Ciudad Blanca",
                    Fecha = DateTime.Now

                },
                new Articulos()
                {
                    Id = 13,
                    Titulo = "Carima",
                    Descripcion ="Es necesario para los negocios",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 14,
                    Titulo = "Otra mas",
                    Descripcion ="Una cansada hitoria de amor",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 1,
                    Titulo = "Pompeya",
                    Descripcion ="Novela de Romana",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 1,
                    Titulo = "Pompeya",
                    Descripcion ="Novela de Romana",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 1,
                    Titulo = "Pompeya",
                    Descripcion ="Novela de Romana",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 1,
                    Titulo = "Pompeya",
                    Descripcion ="Novela de Romana",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 1,
                    Titulo = "Pompeya",
                    Descripcion ="Novela de Romana",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 1,
                    Titulo = "Pompeya",
                    Descripcion ="Novela de Romana",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 1,
                    Titulo = "Pompeya",
                    Descripcion ="Novela de Romana",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 1,
                    Titulo = "Pompeya",
                    Descripcion ="Novela de Romana",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 1,
                    Titulo = "Pompeya",
                    Descripcion ="Novela de Romana",
                    Fecha = DateTime.Now

                },
                new Articulos()
                {
                    Id = 1,
                    Titulo = "Pompeya",
                    Descripcion ="Novela de Romana",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 1,
                    Titulo = "Pompeya",
                    Descripcion ="Novela de Romana",
                    Fecha = DateTime.Now
                },
                new Articulos()
                {
                    Id = 1,
                    Titulo = "Pompeya",
                    Descripcion ="Novela de Romana",
                    Fecha = DateTime.Now
                }

            };
        }
        public ActionResult Index()
        {

            _TotalRegistros =26;

            _PaginadorArticulos = PaginacionCards(1, _TotalRegistros, Lista);
            ViewBag.ListAriticulos = _PaginadorArticulos;

            return View();
        }

        public ActionResult _Card(int pagina = 1)
        {
            
            _TotalRegistros = Lista.Count;

            _PaginadorArticulos = PaginacionCards(pagina, _TotalRegistros, Lista);
            return PartialView(_PaginadorArticulos);
        }

        private PaginadorGenerico<Articulos> PaginacionCards(int pagina,int _TotalRegistros, List<Articulos> Listado)
        {
            var ListFiltrada = Listado.OrderBy(x => x.Fecha)
                 .Skip((pagina - 1) * _RegistrosPorPagina)
                 .Take(_RegistrosPorPagina)
                 .ToList();

            var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);

            _PaginadorArticulos = new PaginadorGenerico<Articulos>()
            {
                RegistrosPorPagina = _RegistrosPorPagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = pagina,
                Resultado = ListFiltrada
            };

            return _PaginadorArticulos;
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class Articulos
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class PaginadorGenerico<T> where T : class
    {
        public int PaginaActual { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public IEnumerable<T> Resultado { get; set; }
    }
}
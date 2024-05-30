using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Collections.Generic;

namespace TP04_Paquetes_Turisticos.Models
{
    public class HelloWorldController : Controller
    {
        private List<string> ListaDestinos;
        private List<string> ListaHoteles;
        private List<string> ListaAereos;
        private List<string> ListaExcursiones;
        private Dictionary<string, Paquete> Paquetes;

        public IActionResult Index()
        {
            Dictionary<int, string> Diccionario = new Dictionary<int, string>();
            ViewBag.Diccionario = Diccionario;
            return View();
        }

        public IActionResult SelectPaquete()
        {
            ListaDestinos = ORTWorld.ListaDestinos;
            ListaHoteles = ORTWorld.ListaHoteles;
            ListaAereos = ORTWorld.ListaAereos; 
            ListaExcursiones = ORTWorld.ListaExcursiones;
            
            ViewBag.ListaDestinos = ListaDestinos;
            ViewBag.ListaHoteles = ListaHoteles;
            ViewBag.ListaAereos = ListaAereos;
            ViewBag.ListaExcursiones = ListaExcursiones;
            return View();
        }

        public IActionResult GuardarPaquete(int Destino, int Hotel, int Aereo, int Excursion)
        {
            if (Destino != -1 && Hotel != -1 && Aereo != -1 && Excursion != -1)
            {
                Paquete paquete = new Paquete(ORTWorld.ListaDestinos[Destino], ORTWorld.ListaHoteles[Hotel], ORTWorld.ListaAereos[Aereo], ORTWorld.ListaExcursiones[Excursion]);
                ORTWorld.IngresarPaquete(ORTWorld.ListaDestinos[Destino], paquete);
                
                ListaDestinos = ORTWorld.ListaDestinos;
                ListaHoteles = ORTWorld.ListaHoteles;
                ListaAereos = ORTWorld.ListaAereos; 
                ListaExcursiones = ORTWorld.ListaExcursiones;
                
                ViewBag.ListaDestinos = ListaDestinos;
                ViewBag.ListaHoteles = ListaHoteles;
                ViewBag.ListaAereos = ListaAereos;
                ViewBag.ListaExcursiones = ListaExcursiones;

                return View();

            }
            else
            {
                ViewBag.ErrorMessage = "Todos los campos son obligatorios. Por favor, seleccione una opción para cada categoría.";
                return View();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    public class HomeController : Controller
    {
        internal class Orario
        {
            public DateTime Quando { get; set; }
            public string Stato { get; set; }
        }

        public IActionResult Index()
        {
            return Content("✅ Dummy .NET Core app is running.");
        }

        [HttpGet]
        [ActionName("time")]
        public IActionResult Time()
        {
            string nextStatus = "alla fine";
            DateTime mo = DateTime.Now;
            TimeSpan quantoManca = TimeSpan.Zero; // Initialize to avoid compiler error

            if (mo.Hour >= 18 || mo.Hour < 9)
            {
                DateTime leNove = DateTime.Today.AddDays(mo.Hour >= 18 ? 1 : 0).AddHours(9);
                quantoManca = leNove - mo;
                nextStatus = "all'inizio";
            }
            else if (mo.Hour >= 9 && mo.Hour < 11)
            {
                quantoManca = DateTime.Today.AddHours(11) - mo;
                nextStatus = "alla pausa del mattino";
            }
            else if (mo.Hour >= 11 && mo.Hour < 13)
            {
                quantoManca = DateTime.Today.AddHours(13) - mo;
                nextStatus = "alla pausa pranzo";
            }
            else if (mo.Hour >= 13 && mo.Hour < 14)
            {
                quantoManca = DateTime.Today.AddHours(14) - mo;
                nextStatus = "alla fine della pausa pranzo";
            }
            else if (mo.Hour >= 14 && mo.Hour < 16)
            {
                quantoManca = DateTime.Today.AddHours(16) - mo;
                nextStatus = "alla pausa pomeridiana";
            }
            else if (mo.Hour >= 16 && mo.Hour < 18)
            {
                quantoManca = DateTime.Today.AddHours(18) - mo;
                nextStatus = "alla fine della giornata";
            }

            string risultato = $"Mancano {quantoManca.Hours} {(quantoManca.Hours == 1 ? "ora" : "ore")}, " +
                               $"{quantoManca.Minutes} {(quantoManca.Minutes == 1 ? "minuto" : "minuti")}, " +
                               $"{quantoManca.Seconds} {(quantoManca.Seconds == 1 ? "secondo" : "secondi")} {nextStatus}!";

            return Json(new { result = risultato });
        }

        [HttpGet]
        [ActionName("times")]
        public IActionResult Times()
        {
            DateTime mo = DateTime.Now;
            var orari = new List<Orario>
            {
                new Orario { Quando = DateTime.Today.AddHours(9), Stato = "all'inizio della giornata" },
                new Orario { Quando = DateTime.Today.AddHours(11), Stato = "alla pausa del mattino" },
                new Orario { Quando = DateTime.Today.AddHours(13), Stato = "alla pausa pranzo" },
                new Orario { Quando = DateTime.Today.AddHours(14), Stato = "alla fine della pausa pranzo" },
                new Orario { Quando = DateTime.Today.AddHours(16), Stato = "alla pausa pomeridiana" },
                new Orario { Quando = DateTime.Today.AddHours(18), Stato = "alla fine della giornata" }
            };

            var risultati = new List<string>();
            foreach (var orario in orari)
            {
                TimeSpan diff = orario.Quando > mo ? orario.Quando - mo : TimeSpan.Zero;

                string result = $"Mancano {diff.Hours} {(diff.Hours == 1 ? "ora" : "ore")}, " +
                                $"{diff.Minutes} {(diff.Minutes == 1 ? "minuto" : "minuti")}, " +
                                $"{diff.Seconds} {(diff.Seconds == 1 ? "secondo" : "secondi")} {orario.Stato}!";

                risultati.Add(result);
            }

            return Json(new { results = risultati });
        }

        [HttpGet]
        [ActionName("content")]
        public IActionResult GetFileContent()
        {
            string filePath = "README.md";
            string content = System.IO.File.Exists(filePath)
                             ? System.IO.File.ReadAllText(filePath)
                             : "❌ File not found.";
            return Json(new { content = content });
        }

        public IActionResult About()
        {
            return Content("📘 About: This is a sample .NET Core app.");
        }

        public IActionResult Contact()
        {
            return Content("📞 Contact: support@example.com");
        }

        public IActionResult Error()
        {
            return Content("❌ An error occurred.");
        }
    }
}


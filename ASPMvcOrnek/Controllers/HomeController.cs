using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPMvcOrnek.Models;

namespace ASPMvcOrnek.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListeKaydet(string Islemci, string Anakart, string Ram, string SolidDrive, string HardDrive, string PowerSupply)
        {
            if(HttpRuntime.Cache["Bilesenler"] == null)
            {
                List<Liste> BilesenListesi = new List<Liste>();
                Liste listeler = new Liste();
                listeler.Islemci = Islemci;
                listeler.Anakart = Anakart;
                listeler.Ram = Ram;
                listeler.SolidDrive = SolidDrive;
                listeler.HardDrive = HardDrive;
                listeler.PowerSupply = PowerSupply;

                BilesenListesi.Add(listeler);
                HttpRuntime.Cache["Bilesenler"] = BilesenListesi;
            }
            else
            {
                List<Liste> BilesenListesi = (List<Liste>)HttpRuntime.Cache["Bilesenler"];
                Liste listeler = new Liste();
                listeler.Islemci = Islemci;
                listeler.Anakart = Anakart;
                listeler.Ram = Ram;
                listeler.SolidDrive = SolidDrive;
                listeler.HardDrive = HardDrive;
                listeler.PowerSupply = PowerSupply;

                BilesenListesi.Add(listeler);
                HttpRuntime.Cache["Bilesenler"] = BilesenListesi;
            }
            return RedirectToAction("BilesenListesi");
        }

        public ActionResult BilesenListesi()
        {
            var model = (List<Liste>)HttpRuntime.Cache["Bilesenler"];
            return View(model);
        }
    }
}
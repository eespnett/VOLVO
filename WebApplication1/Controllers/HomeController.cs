using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.Migrations;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
 

        public IActionResult TruckCreate()
        {
            var options = new DbContextOptionsBuilder<AppDBContext>().UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Eder\\OneDrive\\Documentos\\VOLVO.mdf;Integrated Security=True;Connect Timeout=30").Options;
            EntityTruck retornoTruck = new EntityTruck();
            List<EntityModel> retornoEntityModels = new List<EntityModel>();


            using (var ctx = new AppDBContext(options))
            {
                var retorno = ctx.truck.ToList().Last();

                if (retorno != null)
                {
                    retornoTruck.Id = retorno.Id + 1;

                    retornoTruck.Model = new EntityModel() { Id = 0, model = "Select" };
                }
                var retornoModels = ctx.model.ToList();

                retornoEntityModels.Add(new EntityModel() { Id = 0, model = "Select" });
                foreach (var item in retornoModels)
                {
                    EntityModel myModel = new EntityModel();

                    myModel.Id = item.Id;
                    myModel.model = item.model;

                    retornoEntityModels.Add(myModel);

                }

                retornoTruck.oListModels = retornoEntityModels;
            }


            return View(retornoTruck);
        }
        
        [HttpPost]
        public IActionResult TruckCreate(EntityTruck myModel)
        {
            var options = new DbContextOptionsBuilder<AppDBContext>().UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Eder\\OneDrive\\Documentos\\VOLVO.mdf;Integrated Security=True;Connect Timeout=30").Options;
            EntityTruck retornoTruck = new EntityTruck();
            bool isValid = true;

            if (myModel.FactoryYear != DateTime.Now.Year)
            {
                isValid = false;
            }

            if (!(myModel.Model.Id == 1 || myModel.Model.Id == 2))
            {
                isValid = false;
            }

            if (myModel.ModelYear < DateTime.Now.Year)
            {
                isValid = false;
            }


            if (isValid)
            {
                using (var ctx = new AppDBContext(options))
                {
                    Truck retorno = new Truck();

                    retorno.FactoryYear = myModel.FactoryYear;
                    retorno.ModelYear = myModel.ModelYear;
                    retorno.IdModel = myModel.Model.Id;
                    ctx.Add(retorno);


                    ctx.SaveChanges();


                }

            }
            else
            {

            }



            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult TruckChange(EntityTruck myModel)
        {
            var options = new DbContextOptionsBuilder<AppDBContext>().UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Eder\\OneDrive\\Documentos\\VOLVO.mdf;Integrated Security=True;Connect Timeout=30").Options;
            EntityTruck retornoTruck = new EntityTruck();
            bool isValid = true;

            if (myModel.FactoryYear != DateTime.Now.Year)
            {
                isValid = false;
            }

            if (myModel.ModelYear < DateTime.Now.Year)
            {
                isValid = false;
            }


            if (isValid)
            {
                using (var ctx = new AppDBContext(options))
                {
                    var retorno = ctx.truck.Where(x => x.Id == myModel.Id).SingleOrDefault();

                    if (retorno != null)
                    {
                        retorno.FactoryYear = myModel.FactoryYear;
                        retorno.ModelYear = myModel.ModelYear;
                        retorno.IdModel = myModel.Model.Id;

                        ctx.SaveChanges();
                    }

                }

            }
            else
            {

            }



            return RedirectToAction("Index", "Home");
        }


        public IActionResult TruckChange(int idTruck)
        {
            var options = new DbContextOptionsBuilder<AppDBContext>().UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Eder\\OneDrive\\Documentos\\VOLVO.mdf;Integrated Security=True;Connect Timeout=30").Options;
            EntityTruck retornoTruck = new EntityTruck();
            List<EntityModel> retornoEntityModels = new List<EntityModel>();


            using (var ctx = new AppDBContext(options))
            {
                var retorno = ctx.truck.Where(x => x.Id == idTruck).SingleOrDefault();

                if (retorno != null)
                {
                    retornoTruck.Id = retorno.Id;
                    retornoTruck.FactoryYear = retorno.FactoryYear;
                    retornoTruck.ModelYear = retorno.ModelYear;

                    if (retorno.IdModel > 0)
                    {
                        var retornoModel = ctx.model.Where(x => x.Id == retorno.IdModel).FirstOrDefault();
                        retornoTruck.Model = new EntityModel();

                        retornoTruck.Model.Id = retornoModel.Id;
                        retornoTruck.Model.model = retornoModel.model;
                    }
                }
                var retornoModels = ctx.model.ToList();


                foreach (var item in retornoModels)
                {
                    EntityModel myModel = new EntityModel();

                    myModel.Id = item.Id;
                    myModel.model = item.model;

                    retornoEntityModels.Add(myModel);

                }
                retornoTruck.oListModels = retornoEntityModels;
            }


            return View(retornoTruck);
        }

        public IActionResult TruckDelete(int idTruck)
        {
            var options = new DbContextOptionsBuilder<AppDBContext>().UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Eder\\OneDrive\\Documentos\\VOLVO.mdf;Integrated Security=True;Connect Timeout=30").Options;

            using (var ctx = new AppDBContext(options))
            {
                var retorno = ctx.truck.Where(x => x.Id == idTruck).SingleOrDefault();

                if (retorno != null)
                {
                    ctx.truck.Remove(retorno);


                    ctx.SaveChanges();
                }

            }


            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {

            var options = new DbContextOptionsBuilder<AppDBContext>().UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Eder\\OneDrive\\Documentos\\VOLVO.mdf;Integrated Security=True;Connect Timeout=30").Options;
            List<EntityTruck> retornoTrucks = new List<EntityTruck>();

            using (var ctx = new AppDBContext(options))
            {
                var retorno = ctx.truck.ToList();

                foreach (var item in retorno)
                {
                    EntityTruck myTruck = new EntityTruck();

                    myTruck.FactoryYear = item.FactoryYear;
                    myTruck.Id = item.Id;
                    myTruck.ModelYear = item.ModelYear;

                    if (item.IdModel > 0)
                    {
                        var retornoModel = ctx.model.Where(x => x.Id == item.IdModel).FirstOrDefault();

                        if (retornoModel != null)
                        {
                            myTruck.Model = new EntityModel();

                            myTruck.Model.Id = retornoModel.Id;
                            myTruck.Model.model = retornoModel.model;
                        }
                    }

                    retornoTrucks.Add(myTruck);
                }
                ViewData["retornoTrucks"] = retornoTrucks;

            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SytnerTest.Models;
using SytnerTest.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SytnerTest.Controllers
{
    public class CarsController : Controller
    {

        private readonly DBContext _context;

        public CarsController(DBContext context)
        {
            _context = context;
        }


        // Get Whole cars list
        public ActionResult Index()
        {
            //The returned context currently not being used here
            return View(_context.cars);
        }


        // Edit record
        public ActionResult edit(int id)
        {

            var toEdit = new car { ID = id };
            var car = _context.Entry(toEdit).GetDatabaseValues().ToObject();

            ViewBag.car = car;

            return View();
        }

        // Confirm after edits made
        public ActionResult confirmEdit(string txtMake, string txtModel, int txtYear, int id)
        {
            _context.Database.EnsureCreated();

            var editing = _context.cars.Find(id);

            if (editing != null)
            {
                editing.Make = txtMake;
                editing.Model = txtModel;
                editing.Year = txtYear;
                _context.SaveChanges();
            }
           
            return RedirectToAction("index");
        }



        // Add new record
        [HttpPost]
        public ActionResult addNew(string txtMake, string txtModel, int txtYear)
        {
            _context.Database.EnsureCreated();

            var addNew = new car { Make = txtMake, Model = txtModel, Year = txtYear };
            _context.cars.Add(addNew);
            _context.SaveChanges();

            return RedirectToAction("index");
        }




        // Delete Record
        public ActionResult Delete(int id)
        {
            _context.Database.EnsureCreated();

            var toDelete = new car { ID = id };
            _context.Entry(toDelete).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }

}

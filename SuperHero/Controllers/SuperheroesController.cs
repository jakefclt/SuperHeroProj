using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SuperHero.Data;
using SuperHero.Models;

namespace SuperHero.Controllers
{
    public class SuperheroesController : Controller
    {
        public ApplicationDbContext _context;

        public SuperheroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Superheroes
        public ActionResult Index()
        {
            //template view is called List but you need to name the view Index
            //localhost44307/Superheroes/Index
            var superheroes = _context.Superheroes.ToList();  
            return View(superheroes);
        }

        // GET: Superheroes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Superheroes/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Superheroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hero superHero)
        {
            try
            {
                // TODO: Add insert logic here

                _context.Superheroes.Add(superHero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheroes/Edit/5
        public ActionResult Edit(int id)
        {
            
            var hero = _context.Superheroes.Where(s => s.Id == id).Single();
            return View(hero);
        }

        // POST: Superheroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Hero superhero)
        {
            try
            {
                // TODO: Add update logic here

                _context.Superheroes.Update(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheroes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Superheroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Hero superhero)
        {
            try
            {
                // TODO: Add delete logic here
                _context.Superheroes.Remove(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
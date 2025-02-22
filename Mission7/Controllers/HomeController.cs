using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission7.Models;

namespace Mission7.Controllers;

public class HomeController : Controller
{
    
    private AddMovieContext _context;

    public HomeController(AddMovieContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Joel()
    {
        return View("Joel");
    }
    
    public IActionResult AddMovie()
    {
        ViewBag.Categories = _context.Categories.ToList();
        
        return View("AddMovie", new Movie());
    }

    [HttpPost]
    public IActionResult AddMovie(Movie response)
    {
        if (ModelState.IsValid)
        {
              _context.Add(response);
              _context.SaveChanges();
      
              return View("Index", response);  
        }
        else
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(response);
        }

    }

    public IActionResult Dictionary()
    {
        var movies = _context.Movies
            .Include(m => m.Category)  // 🚀 This ensures the Category data is loaded
            .OrderBy(x => x.Title)
            .ToList();
    
        return View(movies);
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {

        var recordToEdit = _context.Movies
            .Single(m => m.MovieId == id);
        
        ViewBag.Categories = _context.Categories.ToList();
        return View("AddMovie", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Movie response)
    {
        _context.Update(response);
        _context.SaveChanges();
        
        return RedirectToAction("Dictionary");
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies.Single(m => m.MovieId == id);
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movie response)
    {
        _context.Movies.Remove(response);
        _context.SaveChanges();
        return RedirectToAction("Dictionary");
    }

    
}
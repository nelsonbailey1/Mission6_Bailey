using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6.Models;

namespace Mission6.Controllers;

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
        return View("AddMovie");
    }

    [HttpPost]
    public IActionResult AddMovie(Application response)
    {
        _context.Add(response);
        _context.SaveChanges();

        return View("Index", response);
    }
}
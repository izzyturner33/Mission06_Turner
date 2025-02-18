using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6.Models;

namespace Mission6.Controllers;

public class HomeController : Controller
{
    private MovieCollectionContext _context;
    
    public HomeController(MovieCollectionContext temp) //controller
    {
        _context = temp;
    }
   

    public IActionResult Index() 
    {
        return View();
    }

    public IActionResult GetToKnowJoel() 
    {
        return View();
    }

    [HttpGet]
    public IActionResult MovieCollection() //the get for the form
    {
        return View();
    }
    
    
    [HttpPost]
    public IActionResult MovieCollection(Form response) //the post for the form
    {
        _context.Movies.Add(response); //add record to the database
        _context.SaveChanges(); //submit changes to the database
        
        return View("Confirmation", response); //posting the confirmation page once the movie is submitted
    }


    public IActionResult AllMovies()
    {
        var movies =_context.Movies
            .Include(x => x.MovieCategory)
            .OrderBy(x => x.MovieTitle).ToList();

        return View();
    }
    
}
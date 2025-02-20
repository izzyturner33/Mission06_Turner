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
        ViewBag.Categories = _context.Categories.ToList();
        return View("MovieCollection", new Movies());
    }
    
    
    [HttpPost]
    public IActionResult MovieCollection(Movies response) //the post for the form
    {
        if (ModelState.IsValid)
        {
                    _context.Movies.Add(response); //add record to the database
                    _context.SaveChanges(); //submit changes to the database
                    
                    return View("Confirmation", response); //posting the confirmation page once the movie is submitted
        }
        else
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(response);
        }

    }


    public IActionResult AllMovies()
    {
        var movies = _context.Movies
            .Include(x => x.Categories) // Ensures the Categories entity is included
            .OrderBy(x => x.MovieTitle)
            .ToList();

        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movieToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        return View("MovieCollection", movieToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Movies updatedMovie)
    {
        if (ModelState.IsValid)
        {
             _context.Update(updatedMovie);
             _context.SaveChanges();
                    
             return RedirectToAction("AllMovies");
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View(updatedMovie);
        }
       
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movies movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        
        return RedirectToAction("AllMovies");
    }
    
}
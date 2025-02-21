using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6.Models;

namespace Mission6.Controllers;

public class HomeController : Controller
{
    private MovieCollectionContext _context; // Database context for accessing movie data

    // Constructor to initialize the database context
    public HomeController(MovieCollectionContext temp) 
    {
        _context = temp;
    }
   
    // Displays the home page
    public IActionResult Index() 
    {
        return View();
    }

    // Displays the "Get to Know Joel" page
    public IActionResult GetToKnowJoel() 
    {
        return View();
    }

    // GET: Displays the movie collection form with category selection
    [HttpGet]
    public IActionResult MovieCollection() 
    {
        ViewBag.Categories = _context.Categories.ToList(); // Loads categories for dropdown
        return View("MovieCollection", new Movie()); // Returns the form view
    }
    
    // POST: Handles form submission for adding a new movie
    [HttpPost]
    public IActionResult MovieCollection(Movie response) 
    {
        if (ModelState.IsValid) // Ensures valid data before saving
        {
            _context.Movies.Add(response); // Adds new movie to the database
            _context.SaveChanges(); // Saves changes to the database
            
            return View("Confirmation", response); // Redirects to confirmation page
        }
        else
        {
            ViewBag.Categories = _context.Categories.ToList(); // Reloads categories if form validation fails
            return View(response);
        }
    }

    // Displays all movies, including category information
    public IActionResult AllMovies()
    {
        var movies = _context.Movies
            .Include(x => x.Categories) // Ensures the Category entity is included
            .OrderBy(x => x.Title) // Orders movies alphabetically by title
            .ToList();

        return View(movies);
    }

    // GET: Loads movie data for editing
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movieToEdit = _context.Movies
            .Single(x => x.MovieId == id); // Finds the movie by ID
        
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList(); // Loads categories for dropdown
        
        return View("MovieCollection", movieToEdit); // Reuses MovieCollection form for editing
    }

    // POST: Handles editing a movie
    [HttpPost]
    public IActionResult Edit(Movie updatedMovie)
    {
        if (ModelState.IsValid) // Ensures data is valid before saving
        {
            _context.Update(updatedMovie); // Updates movie in the database
            _context.SaveChanges(); // Saves changes
            
            return RedirectToAction("AllMovies"); // Redirects to the list of movies
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList(); // Reloads categories if validation fails
            return View("MovieCollection", updatedMovie); // Reloads form with validation errors
        }
    }

    // GET: Displays a confirmation page before deleting a movie
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id); // Finds movie by ID
        
        return View(recordToDelete);
    }

    // POST: Handles deleting a movie
    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie); // Removes movie from the database
        _context.SaveChanges(); // Saves changes
        
        return RedirectToAction("AllMovies"); // Redirects back to movie list
    }
}

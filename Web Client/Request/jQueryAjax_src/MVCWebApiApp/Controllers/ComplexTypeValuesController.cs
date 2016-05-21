using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCWebApiApp.Controllers
{
    public class ComplexTypeValuesController : ApiController
    {

        static readonly MoviesRepository repository = new MoviesRepository();

        // GET api/values
        public IEnumerable<Movie> Get()
        {
            return repository.Movies;
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            Movie repMovie = repository.Movies.Where(m => m.ID == id).SingleOrDefault();
            if (repMovie == null)
                return NotFound();
            else
                return Ok(repMovie);
        }

        /*
        Post this JSON object will cause cross-field validation error from IValidatableObject:

        {
        "Title": "Fifty Shades of Grey",
        "ReleaseDate": "2015-02-13T00:00:00",
        "Genre": "Family",
        "Price": 15.99,
        "Rating": "R",
        "Stars": 5
        }
 
 
         */
        // POST api/values
        public IHttpActionResult Post(Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int? maxId = (from m in repository.Movies
                          orderby m.ID descending
                          select m.ID).FirstOrDefault();

            Movie newMovie = new Movie
            {
                ID = (maxId != null) ? (int)maxId + 1 : 1,
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                Genre = movie.Genre,
                Rating = movie.Rating,
                Price = movie.Price
            };

            repository.Movies.Add(newMovie);
            return Ok(newMovie);
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var repMovie = (from m in repository.Movies
                            where m.ID == id
                            select m).SingleOrDefault();

            if (repMovie == null)
                return NotFound();
            else
            {

                repMovie.Title = movie.Title;
                repMovie.ReleaseDate = movie.ReleaseDate;
                repMovie.Genre = movie.Genre;
                repMovie.Rating = movie.Rating;
                repMovie.Price = movie.Price;
                return Ok(repMovie);
            }

        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            var repMovie = (from m in repository.Movies
                            where m.ID == id
                            select m).SingleOrDefault();

            if (repMovie == null)
                return NotFound();
            else
            {
                repository.Movies.Remove(repMovie);
                return Ok();
            }
        }
    }

    public class MoviesRepository
    {
        public List<Movie> Movies;

        public MoviesRepository()
        {
            Seed();
        }

        private void Seed()
        {
            Movies = new List<Movie> {  
                            new Movie { 
                                    ID = 41,
                                    Title = "When Harry Met Sally",   
                                    ReleaseDate=DateTime.Parse("1989-1-11"),   
                                    Genre="Romantic Comedy",  
                                    Rating="R",  
                                    Stars=4,
                                    Price=7.99M},  

                            new Movie { 
                                    ID = 42,
                                    Title = "Ghostbusters ",   
                                    ReleaseDate=DateTime.Parse("1984-3-13"),   
                                    Genre="Comedy",  
                                    Rating="R",
                                    Stars=5,
                                    Price=8.99M},   
  
                            new Movie { 
                                    ID = 43,
                                    Title = "Ghostbusters 2",   
                                    ReleaseDate=DateTime.Parse("1986-2-23"),   
                                    Genre="Comedy",  
                                    Rating="R",
                                    Stars=4,
                                    Price=9.99M},   

                            new Movie { 
                                    ID = 44,
                                    Title = "Rio Bravo",   
                                    ReleaseDate=DateTime.Parse("1959-4-15"),   
                                    Genre="Western",  
                                    Rating="R",
                                    Stars= 3,
                                    Price=3.99M},   
                            new Movie { 
                                    ID = 45,
                                    Title = "Big Hero 6",   
                                    ReleaseDate=DateTime.Parse("2014-11-7"),   
                                    Genre="Family",  
                                    Rating="PG",
                                    Stars= 3,
                                    Price=15.99M},   
                            new Movie { 
                                    ID = 46,
                                    Title = "Underworld",   
                                    ReleaseDate=DateTime.Parse("2003-9-19"),   
                                    Genre="Action",  
                                    Rating="R",
                                    Stars= 5,
                                    Price=4.99M},   
                            };
        }

    }

    public class Movie : IValidatableObject
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Genre must be specified")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Price Required")]
        [Range(1, 100, ErrorMessage = "Price must be between 100")]
        public decimal Price { get; set; }

        [StringLength(5)]
        public string Rating { get; set; }

        [Range(0, 5)]
        public int Stars { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Genre == "Family" && Rating != "G" && Rating != "PG" && Rating != "PG-13")
                yield return new ValidationResult("Error: This is not a family movie");
        }
    }
                
}
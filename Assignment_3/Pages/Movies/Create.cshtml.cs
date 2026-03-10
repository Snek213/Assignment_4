using Assignment_3.Data;
using Assignment_3.Models;
using Assignment_4.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly Assignment_3.Data.Assignment_4Context _context;
        private readonly IWebHostEnvironment _env;

        public CreateModel(Assignment_3.Data.Assignment_4Context context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (HttpContext.Request.Form.Files.Count > 0)
            {
                Movie.PictureUri = PictureHelper.UploadNewImage(_env,
                    HttpContext.Request.Form.Files[0]);
            }

            // update the database
            _context.Movie.Add(Movie);
            _context.SaveChanges();

            // redirect to the index page where the table of all items is
            return RedirectToPage("./Index");
        }

    }

}

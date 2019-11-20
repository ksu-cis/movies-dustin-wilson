using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string search { get; set; }

        [BindProperty]
        public List<string> rating { get; set; } = new List<string>();

        [BindProperty]
        public float minIMBD { get; set; }

        [BindProperty]
        public float maxIMBD { get; set; } = 10;

        public List<Movie> Movies;

        public void OnGet()
        {
            Movies = MovieDatabase.All;
        }

        public void OnPost()
        {
            Movies = MovieDatabase.FilterIMBD(minIMBD, maxIMBD);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        

            if (rating.Count != 0)
                Movies = MovieDatabase.Filter(rating, Movies);
            if (search != null)                                                                                                                                                                                                                
                Movies = MovieDatabase.Search(search, Movies);
        }
    }
}

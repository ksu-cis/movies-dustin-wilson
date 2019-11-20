using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Movies
{
    /// <summary>
    /// A class representing a database of movies
    /// </summary>
    public static class MovieDatabase
    {
        private static List<Movie> movies;

        public static List<Movie> All
        {
            get
            {
                if(movies == null)
                {
                    using (StreamReader file = System.IO.File.OpenText("movies.json"))
                    {
                        string json = file.ReadToEnd();
                        movies = JsonConvert.DeserializeObject<List<Movie>>(json);
                    }
                }

                return movies;
            }
        }

        public static List<Movie> Search(string searchString, List<Movie> movies)
        {
            List<Movie> result = new List<Movie>();

            foreach (Movie movie in movies)
            {
                if (movie.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    result.Add(movie);
            }

            return result;
        }

        public static List<Movie> Filter(List<string> ratings, List<Movie> movies)
        {
            List<Movie> result = new List<Movie>();

            foreach (Movie movie in movies)
            {
                if (ratings.Contains(movie.MPAA_Rating))
                    result.Add(movie);
            }

            return result;
        }

        public static List<Movie> FilterIMBD(float minIMBD, float maxIMBD)
        {
            List<Movie> result = new List<Movie>();

            foreach (Movie movie in movies)
            {
                if(movie.IMDB_Rating > minIMBD && movie.IMDB_Rating < maxIMBD)
                {
                    result.Add(movie);
                }
            }

            return result;
        }
    }
}

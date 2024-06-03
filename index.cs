using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Security.Cryptography;


namespace Assignment1
{
    public class MovieDetails
    {
        public string DirectorName { get; set; }
        public List<string> ActorsNames { get; set; }
        public string VideoLink { get; set; }
    }

    public class Movie
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public MovieDetails Details { get; set; }
    }

    public class MovieData
    {
        public List<string> Directors { get; set; }
        public List<Movie> Movies { get; set; }
        public List<string> Actors { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string movies = @"..\..\..\movies.json";
            string info = @"..\..\..\info.json";
            string jsonString1 = File.ReadAllText(movies);
            string jsonString2 = File.ReadAllText(info);

            List<Movie> moviesList = System.Text.Json.JsonSerializer.Deserialize<List<Movie>>(jsonString1);
            List<MovieData> listOfMovie = System.Text.Json.JsonSerializer.Deserialize<List<MovieData>>(jsonString2);

            // List all the director/Movies to the user.
            Console.WriteLine("All the Movies");
            foreach (var item in listOfMovie)
            {
                for (int i = 0; i < item.Movies.Count; i++)
                {
                    Console.WriteLine(item.Movies[i].MovieName);
                }

            }
            Console.WriteLine();
            Console.WriteLine("All the Directors");
            foreach (var item in listOfMovie)
            {
                for (int i = 0; i < item.Directors.Count; i++)
                {
                    Console.WriteLine(item.Directors[i]);
                }
         
            }

            // Part-2
            //1
            Console.Write("Enter Director Name: ");
            string dir = Console.ReadLine();
            string DirectorName = dir.ToLower();
            foreach (var item in moviesList)
            {
                if (DirectorName == item.Details.DirectorName.ToLower())
                {
                    Console.WriteLine(item.MovieName);
                }
            }
            //2
            Console.Write("Enter Movie Name: ");
            string dir1 = Console.ReadLine();
            string MovieName = dir1.ToLower();
            foreach (var item in moviesList)
            {
                if (MovieName == item.MovieName.ToLower())
                {
                    for(int i = 0; i < item.Details.ActorsNames.Count; i++)
                    {
                        Console.WriteLine(item.Details.ActorsNames[i]);
                    }
                }
            }
            //3
            foreach (var item in moviesList)
            {   
                    for (int i = 0; i < item.Details.ActorsNames.Count; i++)
                    {           
                    if (item.Details.DirectorName == item.Details.ActorsNames[i])
                    {
                        Console.WriteLine(item.MovieName);
                    }
                }   
            }
        }
    }
}

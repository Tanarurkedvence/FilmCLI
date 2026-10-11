namespace FilmCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>();
            using (StreamReader o = new StreamReader("../../../forras/filmek.txt"))
            {
                o.ReadLine();
                while (!o.EndOfStream)
                {
                    string line = o.ReadLine();
                    movies.Add(new Movie(line));
                }

            }
            Console.WriteLine("5. feladat");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(movies[i].ToString());
            }

            
            var f6 = movies.Where(x => x.Genre.GenreName == "Akció" && x.Language == "Angol" && x.AgeLimit >= 16
            && x.RevenueM > 0 && x.BudgetM > 0);
            Console.WriteLine($"6. feladat (a leszűrt filmek száma: {f6.Count()})");

            var max = f6.Max(x => x.Roi());

            
            if (f6.Any())
            {
                foreach (var movie in f6)
                {
                    Console.WriteLine(movie.ToString());
                    
                }
               
                foreach (var movie in f6)
                {
                    if(movie.Roi() == max)
                    {
                        Console.WriteLine($"A legnagyobb megtérülésű film: {movie.Title} ({max})");
                    }
                }
            }

            Console.WriteLine("7. feladat fájlba íratás");

            var f7 = movies.Where(x => x.Year >= 2000 && x.Year <= 2010
            && x.Rating >= 7.0 && x.Language == "Magyar").OrderByDescending(x => x.Rating).ThenBy(x => x.Title);

            using(StreamWriter i = new StreamWriter("../../../forras/jo_filmek.txt"))
            {
                foreach(var movie in f7)
                {
                    i.WriteLine($"{movie.Rating} {movie.Year} {movie.Title}");
                }
            }
        }
    }
}
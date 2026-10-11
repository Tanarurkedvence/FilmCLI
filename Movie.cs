using System;
using System.Collections.Generic;
using System.Text;

namespace FilmCLI
{
    internal class Movie
    {
        static int szamlalo = 1;
        public Movie(string l)
        {
            var r = l.Split(";");
            Title = r[0];
            Year = int.Parse(r[1]);
            LengthMin = int.Parse(r[2]);
            BudgetM = r[3] == "NA" ? 0 : int.Parse(r[3]);
            RevenueM = r[4] == "NA" ? 0 : double.Parse(r[4].Replace(".", ","));
            Rating = r[5] == "NA" ? 0 : double.Parse(r[5].Replace(".", ","));
            Genre = new Genre()
            {
                GenreID = int.Parse(r[6]),
                GenreName = r[7]
            };
            Director = new Director()
            {
                DirectorID = int.Parse(r[8]),
                DirectorName = r[9]
            };
            Language = r[10];
            AgeLimit = int.Parse(r[11]);
            MovieId = szamlalo++;
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public int LengthMin { get; set; }
        public int BudgetM { get; set; }
        public double RevenueM { get; set; }
        public double Rating { get; set; }
        public Genre Genre { get; set; }
        public Director Director { get; set; }
        public string Language { get; set; }
        public int AgeLimit { get; set; }
        public int MovieId { get; set; }

        public double Roi()
        {
            if(RevenueM > 0 && BudgetM > 0)
            {
              return Math.Round(((double)RevenueM/ BudgetM), 2);
            }

            return double.NaN;
        }
        public override string ToString()
        {
            return $"        Movie ID: {MovieId}\n" +
                $"        Title: {Title}\n" +
                $"        Year: {Year}\n" +
                $"        Length: {LengthMin}\n" +
                $"        Budget (M USD): {BudgetM}\n" +
                $"        Revenue (M USD): {RevenueM}\n" +
                $"        Rating: {Rating}\n" +
                $"        Genre: {Genre.GenreName}\n" +
                $"        Director: {Director.DirectorName}\n" +
                $"        Language: {Language}\n" +
                $"        Age Limit: {AgeLimit}\n" +
                $"        ROI: {Roi()}\n";
        }
    }
}

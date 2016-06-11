using System;

namespace Decorator.Data
{
    public class Video : LibraryItem<Video>
    {
        private string Director;
        private int Playtime;

        public Video(string director, int playtime, int copes)
        {
            Director = director;
            Playtime = playtime;
            NumCopes = copes;
        }

        public override void Display()
        {
            Console.WriteLine("Video:");
            Console.WriteLine("Director - {0}, Playtime - {1}, Numcopies - {2}", Director, Playtime, NumCopes);
        }
    }
}

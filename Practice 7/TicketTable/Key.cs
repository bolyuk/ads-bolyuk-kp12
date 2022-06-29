using System;
namespace adsbolyuklab7.TicketTable
{
    public class Key
    {
        public string cinemaHall;
        public string movieTitle;

        public Key()
        {

        }

        public Key(string cinemaHall, string movieTitle)
        {
            this.cinemaHall = cinemaHall;
            this.movieTitle = movieTitle;
        }

        public string toStringForHash()
        {
            return cinemaHall + movieTitle;
        }
    }
}

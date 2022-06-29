namespace adsbolyuklab7.MainTable
{
    public class Value
    {
        public string movieTitle;
        public string cinemaHall;
        public Date date;
        public int seat;

        public Value()
        {

        }

        public Value(string movieTitle, string cinemaHall, Date date, int seat)
        {
            this.movieTitle = movieTitle;
            this.cinemaHall = cinemaHall;
            this.date = date;
            this.seat = seat;
        }

        public string String()
        {
            return $"MovieName: {movieTitle}; cinameHall: {cinemaHall}; date: {date}; seat: {seat}";
        }
    }
}

using System;
namespace adsbolyuklab7.TicketTable
{
    public class Value
    {
        public Date date;
        public int seat;

        public Value()
        {

        }

        public Value(Date date, int seat)
        {
            this.date = date;
            this.seat = seat;
        }
    }
}

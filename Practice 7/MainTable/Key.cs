using System;
namespace adsbolyuklab7.MainTable
{
    public class Key
    {
        public int id;

        public Key()
        {

        }
        public Key(int id)
        {
            this.id = id;
        }

        public String String()
        {
            return "ID: " + id;
        }
    }
}

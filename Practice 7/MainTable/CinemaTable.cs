using System;
namespace adsbolyuklab7.MainTable
{
    public class CinemaTable
    {
        private Key[] _keys;
        private Value[] _table;
        private int _size=0;

        public CinemaTable()
        {
            Array.Resize(ref _keys, 0);
            Array.Resize(ref _table, 0);
        }

        public int getLoadness()
        {
            return _size / _table.Length;
            }

        private int hashCode(Key Key, int i, int length) {
            return (Key.id + i * i) % length;
        }

        private int getHash(Key key, Value[] table)
        {
            int i = 0;
            int hash = hashCode(key, i, table.Length);
            while (table[hash] != null)
            {
                i++;
                hash = hashCode(key, i, table.Length);
            }

            return hash;
        }
        private void rehashing(ref Value[] oTable, ref Key[] oKey)
        {
            Value[] nTable = new Value[oTable.Length * 2];
            Key[] nKey = new Key[oKey.Length * 2];

            for (int i = 0; i < oKey.Length; i++)
            {
                if (oKey[i] != null)
                {
                    int NewHash = getHash(oKey[i], nTable);
                    nTable[NewHash] = oTable[i];
                    nKey[NewHash] = oKey[i];
                }
            }

            oTable = nTable;
            oKey = nKey;
        }
        private int findEntry(Key key)
        {
            if (_keys.Length == 0)
                return -1;

            int i = 0;
            int hash = hashCode(key, i, _keys.Length);

            while (i < _keys.Length)
            {
                try
                {
                    if (_keys[hash].id == key.id)
                        return hash;
                }
                catch (Exception) { }
                finally
                {
                    i++;
                    hash = hashCode(key, i, _keys.Length);
                }
            }

            hash = -1;
            return hash;
        }
        public void insertEntry(Key key, Value value)
        {
            if (_table.Length == 0)
            {
                Array.Resize(ref _keys, 2);
                Array.Resize(ref _table, 2);
            }

            if ((double)_size / _table.Length >= 0.5)
                rehashing(ref _table, ref _keys);

            int hash = getHash(key, _table);

            _table[hash] = value;
            _keys[hash] = key;
            _size++;

        }

        public void removeEntry(Key key)
        {
            int hash = findEntry(key);
            if (hash == -1)
                new Exception("can`t find entry");
            else
            {
                dynamic dV = _table[hash];
                dynamic dK = _keys[hash];

                _table[hash] = new Value();
                _keys[hash] = new Key();
                _size--;

            }
        }

        public Value getInfo(Key key)
        {
            int hash = findEntry(key);
            if (hash != -1)
                return _table[hash];
            return new Value();
        }
        public void showEntry(Key key)
        {
            int hash = findEntry(key);
            if (hash == -1)
                new Exception("can`t find entry");
            else
                Console.WriteLine($"{_keys[hash].String()} : {_table[hash].String()}");
        }
        public void showData()
        {
            foreach (Key key in _keys)
                if (key != null)
                    showEntry(key);
        }
    }
}

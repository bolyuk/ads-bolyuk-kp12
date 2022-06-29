using System;
using System.Collections.Generic;

namespace adsbolyuklab7.TicketTable
{
    public class SecondTable
    {
            private Key[] _keys = new Key[0];
            private List<Value>[] _table = new List<Value>[0];
            private int _size = 0;

        public SecondTable()
        {
            Array.Resize(ref _keys, 0);
            Array.Resize(ref _table, 0);
        }

        private int hashCode(Key Key, int i, int ArrayLength)
            {
                string hs = Key.toStringForHash().ToLower();
                ulong s = 0;
                for (int j = 0; j < hs.Length; j++)
                    s +=(ulong)(hs[j] * Math.Pow(27, hs.Length - j - 1));                 
                return (int)((s + Convert.ToUInt64(i * i)) % Convert.ToUInt64(ArrayLength));
            }

            private int getHash(Key key, List<Value>[] table)
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
            private int findEntry(Key key)
            {
                string kh = key.toStringForHash();
                if (_keys.Length == 0)
                    return -1;

                int i = 0;
                int hash = hashCode(key, i, _keys.Length);

                while (i < _keys.Length)
                    try
                    {
                        if (_keys[hash].toStringForHash() == kh)
                            return hash;

                }
                catch (Exception) { }
                finally
                    {
                        i++;
                        hash = hashCode(key, i, _keys.Length);
                    }

                hash = -1;
                return hash;
            }

        private void rehashing(ref List<Value>[] oTable, ref Key[] oKey)
        {
            List<Value>[] nTable = new List<Value>[oTable.Length * 2];
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

        public void insertEntry(Key key, Value value)
            {
                if (_table.Length == 0)
                {
                Array.Resize(ref _keys, 2);
                Array.Resize(ref _table, 2);
            }
                if ((double)_size / _table.Length >= 0.5)
                    rehashing(ref _table, ref _keys);

                int hash = findEntry(key);
                if (hash == -1)
                {
                    int newHash = getHash(key, _table);

                    _table[newHash] = new List<Value> { value };
                    _keys[newHash] = key;
                    _size++;
                }
                else
                {
                    _table[hash].Add(value);
                }
            }

            public void UpdateEntry(Key key, Value value)
            {
                _table[findEntry(key)].Add(value);
            }

            public void removeEntry(Key key, Value value)
            {
                int hash = findEntry(key);

                if (hash != -1)
                {
                    if (_table[hash].Count == 1)
                    {
                        _table[hash] = new List<Value>();
                        _keys[hash] = new Key();
                        _size--;
                    }
                    else
                        for (int i = 0; i < _table[hash].Count; i++)
                            if (value.Equals(_table[hash][i]))
                            {
                                _table[hash].RemoveAt(i);
                                break;
                    }
                }
            }

            public List<Value> getAllTicketsForDate(Key key, Date date)
            {
                int hash = findEntry(key);
                if (hash == -1) return null;

                List<Value> result = new List<Value>();

                foreach (Value v in _table[hash])
                {
                    if (date.Equals(v.date)) result.Add(v);
                }

                return result;
            }
        }
}

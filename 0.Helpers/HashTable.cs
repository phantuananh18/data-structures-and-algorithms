using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTable
{   
    public class NotFoundKeyException : Exception
    {
        public NotFoundKeyException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }

    public static class HashGenerator<T>
    {
        private const int PRIME = (int)1e6 + 3;
        //hash code = key % prime_number   
        
        public static int hash(T k)
        {
            return typeof(T) == typeof(Int32)
                ? Convert.ToInt32(k) % PRIME
                : Convert.ToString(k).Select(x => (int)x).Sum();
        }
    }

    public class Bucket<K, V>
    {
        public K key;
        public V value;

        public Bucket(K k,V v)
        {
            this.key = k;
            this.value = v;
        }

        public Bucket()
        {

        }
    }

    public class MyHashTable<K, V>
    {
        public List<List<Bucket<K, V>>> table;
        
        public MyHashTable(int size)
        {
            table = new List<List<Bucket<K, V>>>();
            for(int i = 0; i < size; i++)
            {
                List<Bucket<K,V >> _v=new List<Bucket<K, V>>();
                table.Add(_v);
            }
        }

        public void Set(K k,V v)
        {
            Bucket<K, V> bucket = new Bucket<K, V>(k, v);
            if (typeof(K) == typeof(Int32))
            {
                int parsed = Convert.ToInt32(k);
                int hashed = HashGenerator<int>.hash(parsed);
                for(int i = 0; i < table[hashed].Count; i++)
                {
                    if (Convert.ToInt32(table[hashed][i].key) == parsed)
                    {
                        table[hashed][i] = bucket;
                        return;
                    }
                }
                table[hashed].Add(bucket);
            }
            else
            {
                string parsed = Convert.ToString(k);
                int hashed = HashGenerator<string>.hash(parsed);
                for (int i = 0; i < table[hashed].Count; i++)
                {
                    if (Convert.ToString(table[hashed][i].key) == parsed)
                    {
                        table[hashed][i] = bucket;
                        return;
                    }
                }
                table[hashed].Add(bucket);
            }
        }

        public V Get(K k)
        {
            if (typeof(K) == typeof(Int32))
            {
                int parsed = Convert.ToInt32(k);
                int hashed = HashGenerator<int>.hash(parsed);
                for (int i = 0; i < table[hashed].Count; i++)
                {
                    if (Convert.ToInt32(table[hashed][i].key) == parsed)
                    {
                        return table[hashed][i].value;
                    }
                }

            }
            else
            {
                string parsedString = Convert.ToString(k);
                int hashedString = HashGenerator<string>.hash(parsedString);
                for (int i = 0; i < table[hashedString].Count; i++)
                {
                    if (Convert.ToString(table[hashedString][i].key) == parsedString)
                    {
                        return table[hashedString][i].value;
                    }
                }
            }
            throw new NotFoundKeyException("Not found key");
        }

        public bool Exist(K k)
        {
            if (typeof(K) == typeof(Int32))
            {
                int parsed = Convert.ToInt32(k);
                int hashed = HashGenerator<int>.hash(parsed);
                for (int i = 0; i < table[hashed].Count; i++)
                {
                    if (Convert.ToInt32(table[hashed][i].key) == parsed)
                    {
                        return true;
                    }
                }

            }
            else
            {
                string parsedString = Convert.ToString(k);
                int hashedString = HashGenerator<string>.hash(parsedString);
                for (int i = 0; i < table[hashedString].Count; i++)
                {
                    if (Convert.ToString(table[hashedString][i].key) == parsedString)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Remove(K k)
        {
            if (typeof(K) == typeof(Int32))
            {
                int parsed = Convert.ToInt32(k);
                int hashed = HashGenerator<int>.hash(parsed);
                for (int i = 0; i < table[hashed].Count; i++)
                {
                    if (Convert.ToInt32(table[hashed][i].key) == parsed)
                    {
                        table.Remove(table[hashed]);
                    }
                }

            }
            else
            {
                string parsedString = Convert.ToString(k);
                int hashedString = HashGenerator<string>.hash(parsedString);
                for (int i = 0; i < table[hashedString].Count; i++)
                {
                    if (Convert.ToString(table[hashedString][i].key) == parsedString)
                    {
                        table.Remove(table[hashedString]);
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyHashTable<int, int> hashTable = new MyHashTable<int, int>(99999);
            hashTable.Set(1, 32);

            MyHashTable<string, string> hashTableString = new MyHashTable<string, string>(999);
            hashTableString.Set("coding", "vudang");
            Console.WriteLine(hashTable.Get(1));
            hashTable.Remove(1);
            Console.WriteLine(hashTableString.Get("coding"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyFunBlob
{
    public class OpenAddressedHashtable : Dictionary 
    {
        int count;
        string[] keys;
        object[] values;
        
        public OpenAddressedHashtable(int size)
        {
            count = 0;
            keys = new string[size];
            values = new object[size];
        }

        int hashFunction(string s, int i)
        {
            int sum = 0;
            foreach (char c in s)
                sum += (int)c;
            sum = ((int)(((sum* (Math.Sqrt(5) - 1)/2)%1.0)*keys.Length) + i)%keys.Length;
            return sum;
        }

        public override void Store(string name, object value)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                int j = hashFunction(name, i);
                if (keys[j] == name)
                {
                    values[j] = value;
                    return;
                }
                else if (keys[j] == null)
                {
                    keys[j] = name;
                    values[j] = value;
                    count++;
                    return;
                }
            }
            throw new HashtableFullException();
        }

        public override object Lookup(string name)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                int j = hashFunction(name, i);
                if (keys[j] == name)
                    return values[j];
            }
            throw new DictionaryKeyNotFoundException(name);
        }

        public override int Count
        {
            get
            {
                return count;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyFunBlob
{
    public class ChainedHashtable : Dictionary
    {
        object[] arraythingy;
        int count;
        class Cell
        {
            public string key;
            public object value;
            public Cell next;
            public Cell(string key, object value)
            {
                this.key = key;
                this.value = value;
            }
        }

        public ChainedHashtable(int size)
        {
            count = 0;
            arraythingy = new object[size];
        }
        
        int hashFunction(string s)
        {
            int sum = 0;
            foreach (char c in s)
                sum += (int)c;
            sum = (int)(((sum * (Math.Sqrt(5) - 1) / 2) % 1.0) * arraythingy.Length);
            return sum;
        }

        public override void Store(string name, object value)
        {
            int i = hashFunction(name);
            if (arraythingy[i] == null)
            {
                arraythingy[i] = new Cell(name, value);
                count++;
            }
            else
            {
                Cell thisthing = (Cell)arraythingy[i];
                while (thisthing != null)
                {
                    if (thisthing.key == name)
                    {
                        thisthing.value = value;
                        return;
                    }
                    thisthing = thisthing.next;
                }
                Cell thing = new Cell(name, value);
                thing.next = (Cell)arraythingy[i];
                arraythingy[i] = thing;
                count++;
            }
        }

        public override object Lookup(string name)
        {
            int i = hashFunction(name);
            
            if (arraythingy[i] != null)
            {
                Cell thing = (Cell)arraythingy[i];
                while (thing != null)
                {
                    if (thing.key == name)
                        return thing.value;
                    thing = thing.next;
                }
            }
            throw new DictionaryKeyNotFoundException(name);
        }

        public override int Count
        {
            get { return count; }
        }
    }
}
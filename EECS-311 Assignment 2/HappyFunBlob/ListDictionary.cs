using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyFunBlob
{
    public class ListDictionary : Dictionary
    {
        Cell head;
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
        public ListDictionary()
        {
            //throw new NotImplementedException();
        }

        public override void Store(string key, object value)
        {
            Cell thing = head;
            while (thing != null)
            {
                if ((thing.key==key))
                {
                    thing.value = value;
                    return;
                }
                thing = thing.next;
            }
            Cell nextCell = new Cell(key, value);
            nextCell.next = head;
            head = nextCell;
            count++;
        }

        public override object Lookup(string key)
        {
            Cell thing = head;
            while (thing != null)
            {
                if (thing.key==key)
                    return thing.value;
                thing = thing.next;
            }
            throw new DictionaryKeyNotFoundException(key);
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

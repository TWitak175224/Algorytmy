using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgIST
{
    internal class List
    {
        public NodeL head, tail;
        public uint count;

        public void AddFirst(int liczba)
        {
            var nowy=new NodeL(liczba);
            nowy.next= this.head;
            this.head.prev= nowy;
            this.head = nowy;
            ;
            count++;
        }
        public void AddLast(int liczba) 
        {
            var nowy = new NodeL(liczba);
            nowy.prev = this.tail;
            this.tail.next = nowy;
            this.tail = nowy;
            
            count++;
        }
    }
}

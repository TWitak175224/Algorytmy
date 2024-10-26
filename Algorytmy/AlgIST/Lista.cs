using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgIST
{
    internal class Lista
    {
        public NodeL head;
        public NodeL tail;
        public uint count;

        
        public void AddFirst(int liczba)
        {
            var nowy=new NodeL(liczba);
            nowy.next= this.head;
            if (this.count > 0)
            {
                this.head.prev = nowy;
            }
            else { 
                this.tail = nowy; 
            }
            this.head = nowy;
            
            count++;
        }
        public void AddLast(int liczba) 
        {
            var nowy = new NodeL(liczba);
            nowy.prev = this.tail;
            if (this.count > 0)
            {
                this.tail.next = nowy;
            }
            else {
                this.head=nowy; 
            }
            this.tail = nowy;
            
            count++;
        }
        public void RemoveFirst() 
        { 
            count--;
            if (count == 0)
            {
                this.tail = null;
            }
            else
            {
                this.head = this.head.next;
                this.head.prev.next = null;
                this.head.prev = null;
            }
            
        }
        public void RemoveLast()
        {
            count--;
            if (count == 0)
            {
                this.head = null;
            }
            else
            {

                this.tail = this.tail.prev;
                this.tail.next.prev = null;
                this.tail.next = null;
            }
            
        }
        public string ToStringi()
        {
            string stringowana="";
            NodeL node = this.head;
            for (int i = 0; i < this.count; i++) {
                stringowana += node.data+" ";
                node = node.next;
            }
            return stringowana;
        }
    }
}

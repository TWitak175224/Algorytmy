using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgIST
{
    internal class NodeL
    {
        public NodeL next, prev;
        public int data;
        public NodeL(int liczba)
        {
            this.data = liczba;
        }
    }
}

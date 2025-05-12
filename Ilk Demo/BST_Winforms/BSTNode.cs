using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_Winforms
{
    public class BSTNode
    {
        public int Key;
        public BSTNode Left;
        public BSTNode Right;

        public BSTNode(int key)
        {
            this.Key = key;
            this.Left = null;
            this.Right = null;
        }
    }
}

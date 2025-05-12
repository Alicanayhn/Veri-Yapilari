using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_Winforms
{
    public class BinarySearchTree
    {
        public BSTNode Root;

        public void Insert(int key)
        {
            Root = Insert(Root, key);
        }

        private BSTNode Insert(BSTNode node, int key)
        {
            if (node == null) return new BSTNode(key);
            if (key < node.Key)
                node.Left = Insert(node.Left, key);
            else
                node.Right = Insert(node.Right, key);
            return node;
        }

        
        public void Delete(int key) => Root = Delete(Root, key);

        private BSTNode Delete(BSTNode node, int key)
        {
            if (node == null) return null;
            if (key < node.Key)
                node.Left = Delete(node.Left, key);
            else if (key > node.Key)
                node.Right = Delete(node.Right, key);
            else
            {
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;
                // iki çocuklu durum
                BSTNode succ = node.Right;
                while (succ.Left != null) succ = succ.Left;
                node.Key = succ.Key;
                node.Right = Delete(node.Right, succ.Key);
            }
            return node;
        }
        public List<int> InOrder()
        {
            var result = new List<int>();
            void Traverse(BSTNode node)
            {
                if (node == null) return;
                Traverse(node.Left);
                result.Add(node.Key);
                Traverse(node.Right);
            }
            Traverse(Root);
            return result;
        }

        public List<int> PreOrder()
        {
            var result = new List<int>();
            void Traverse(BSTNode node)
            {
                if (node == null) return;
                result.Add(node.Key);
                Traverse(node.Left);
                Traverse(node.Right);
            }
            Traverse(Root);
            return result;
        }

        public List<int> PostOrder()
        {
            var result = new List<int>();
            void Traverse(BSTNode node)
            {
                if (node == null) return;
                Traverse(node.Left);
                Traverse(node.Right);
                result.Add(node.Key);
            }
            Traverse(Root);
            return result;
        }
        public List<int> InOrderIterative()
        {
            var result = new List<int>();
            var stack = new Stack<BSTNode>();
            var current = Root;

            while (current != null || stack.Count > 0)
            {
                // Solu tümüyle yığına al
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                // En üstten çıkar, listeye ekle, sağa geç
                current = stack.Pop();
                result.Add(current.Key);
                current = current.Right;
            }

            return result;
        }
        public List<int> PreOrderIterative()
        {
            var result = new List<int>();
            if (Root == null) return result;

            var stack = new Stack<BSTNode>();
            stack.Push(Root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                result.Add(node.Key);

                // Sağ altı önce yığına ekliyoruz ki sol önce işleme gelsin
                if (node.Right != null)
                    stack.Push(node.Right);
                if (node.Left != null)
                    stack.Push(node.Left);
            }

            return result;
        }

        /// <summary>
        /// Iterative Post-Order Traversal (Left → Right → Root) using two Stacks.
        /// </summary>
        public List<int> PostOrderIterative()
        {
            var result = new List<int>();
            if (Root == null) return result;

            var s1 = new Stack<BSTNode>();
            var s2 = new Stack<BSTNode>();
            s1.Push(Root);

            // İlk yığınla kök→sağ→sol sırasıyla s2'ye geçiyoruz
            while (s1.Count > 0)
            {
                var node = s1.Pop();
                s2.Push(node);
                if (node.Left != null)
                    s1.Push(node.Left);
                if (node.Right != null)
                    s1.Push(node.Right);
            }

            // s2’den pop ettikçe Left→Right→Root sıralaması ortaya çıkar
            while (s2.Count > 0)
                result.Add(s2.Pop().Key);

            return result;
        }
        public List<int> LevelOrder()
        {
            var result = new List<int>();
            if (Root == null) return result;

            var queue = new Queue<BSTNode>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                result.Add(node.Key);

                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }

            return result;
        }
        public BSTNode FindSuccessor(int key)
        {
            BSTNode node = Root;

            // Önce silinecek düğüm bulunur
            while (node != null && node.Key != key)
            {
                if (key < node.Key)
                    node = node.Left;
                else
                    node = node.Right;
            }

            if (node == null || node.Right == null)
                return null;

            // Sağ alt ağacın en solundaki düğüm successor'dır
            var succ = node.Right;
            while (succ.Left != null)
                succ = succ.Left;

            return succ;
        }


    }

}

using BST_WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BST_Winforms
{
    public partial class Form1 : Form
    {
        private BinarySearchTree bst = new BinarySearchTree();
        private CustomLinkedList<int> eklenenler = new CustomLinkedList<int>();
        private string highlightedKey = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtInput.Text, out int value))
            {
                if (!eklenenler.Contains(value)) // aynı sayı 2 kere eklenmesin
                {
                    bst.Insert(value); // BST'ye ekle
                    eklenenler.AddLast(value); // Bağlı listeye ekle
                    panelCanvas.Invalidate(); // Ağacı yeniden çiz
                    GuncelleEklemeListesi(); // Listeyi UI'da göster
                }
                else
                {
                    MessageBox.Show("Bu sayı zaten eklendi!");
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtInput.Text, out int value))
            {
                MessageBox.Show("Lütfen geçerli bir sayı girin.");
                return;
            }

            bst.Delete(value);
            bool removed = eklenenler.Remove(value);
            if (!removed)
            {
                MessageBox.Show("Sayı silinemedi: Listede bulunamadı.");
            }
            panelCanvas.Invalidate();
            GuncelleEklemeListesi();
        }
        private void btnDeleteLast_Click(object sender, EventArgs e)
        {
            // LinkedList<T>.RemoveLast çıktısını alalım
            if (eklenenler.RemoveLast(out int lastValue))
            {
                bst.Delete(lastValue);
                panelCanvas.Invalidate();
                GuncelleEklemeListesi();
            }
            else
            {
                MessageBox.Show("Silinecek eleman yok.");
            }
        }
        private async void btnInOrder_Click(object sender, EventArgs e)
        {
            listBoxTraversal.Items.Clear();
            await AnimateInOrderTraversal(bst.Root);

            var seq = bst.InOrder();
            var line = string.Join(" → ", seq);
            listBoxTraversal.Items.Add(line);
        }
        private async Task AnimateInOrderTraversal(BSTNode node)
        {
            if (node == null) return;

            await AnimateInOrderTraversal(node.Left);

            highlightedKey = node.Key.ToString();
            panelCanvas.Invalidate();
            await Task.Delay(1);             // hemen çizim başlaması için tetik
            await Task.Yield();              // UI thread'e geçiş için
            await Task.Delay(600);           // animasyonu görünür kılar
            highlightedKey = null;
            panelCanvas.Invalidate();
            await Task.Delay(100);           // geçiş efekti için

            await AnimateInOrderTraversal(node.Right);
        }


        private async void btnPreOrder_Click(object sender, EventArgs e)
        {
            listBoxTraversal.Items.Clear();
            await AnimatePreOrderTraversal(bst.Root);

            var seq = bst.PreOrder();
            var line = string.Join(" → ", seq);
            listBoxTraversal.Items.Clear();
            listBoxTraversal.Items.Add(line);
        }
        private async Task AnimatePreOrderTraversal(BSTNode node)
        {
            if (node == null) return;

            highlightedKey = node.Key.ToString();
            panelCanvas.Refresh();
            await Task.Delay(600);
            highlightedKey = null;
            panelCanvas.Refresh();
            await Task.Delay(200);

            await AnimatePreOrderTraversal(node.Left);
            await AnimatePreOrderTraversal(node.Right);
        }

        private async void btnPostOrder_Click(object sender, EventArgs e)
        {
            listBoxTraversal.Items.Clear();
            await AnimatePostOrderTraversal(bst.Root);

            var seq = bst.PostOrder();
            var line = string.Join(" → ", seq);
            listBoxTraversal.Items.Clear();
            listBoxTraversal.Items.Add(line);
        }
        private async Task AnimatePostOrderTraversal(BSTNode node)
        {
            if (node == null) return;

            await AnimatePostOrderTraversal(node.Left);
            await AnimatePostOrderTraversal(node.Right);

            highlightedKey = node.Key.ToString();
            panelCanvas.Refresh();
            await Task.Delay(600);
            highlightedKey = null;
            panelCanvas.Refresh();
            await Task.Delay(200);
        }
        private async void btnInOrderIter_Click(object sender, EventArgs e)
        {
            listBoxTraversal.Items.Clear();
            await AnimateInOrderIterative();

            var seq = bst.InOrderIterative();
            listBoxTraversal.Items.Clear();
            listBoxTraversal.Items.Add(string.Join(" → ", seq));
        }
        private async Task AnimateInOrderIterative()
        {
            var stack = new Stack<BSTNode>();
            var current = bst.Root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();

                highlightedKey = current.Key.ToString();
                panelCanvas.Refresh();
                await Task.Delay(600);
                highlightedKey = null;
                panelCanvas.Refresh();
                await Task.Delay(200);

                current = current.Right;
            }
        }
        private async void btnPreOrderIter_Click(object sender, EventArgs e)
        {
            listBoxTraversal.Items.Clear();
            await AnimatePreOrderIterative();

            var seq = bst.PreOrderIterative();
            listBoxTraversal.Items.Clear();
            listBoxTraversal.Items.Add(string.Join(" → ", seq));
        }
        private async Task AnimatePreOrderIterative()
        {
            if (bst.Root == null) return;

            var stack = new Stack<BSTNode>();
            stack.Push(bst.Root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                highlightedKey = node.Key.ToString();
                panelCanvas.Refresh();
                await Task.Delay(600);
                highlightedKey = null;
                panelCanvas.Refresh();
                await Task.Delay(200);

                if (node.Right != null) stack.Push(node.Right);
                if (node.Left != null) stack.Push(node.Left);
            }
        }

        private async void btnPostOrderIter_Click(object sender, EventArgs e)
        {
            listBoxTraversal.Items.Clear();
            await AnimatePostOrderIterative();

            var seq = bst.PostOrderIterative();
            listBoxTraversal.Items.Clear();
            listBoxTraversal.Items.Add(string.Join(" → ", seq));
        }
        private async Task AnimatePostOrderIterative()
        {
            if (bst.Root == null) return;

            var s1 = new Stack<BSTNode>();
            var s2 = new Stack<BSTNode>();
            s1.Push(bst.Root);

            while (s1.Count > 0)
            {
                var node = s1.Pop();
                s2.Push(node);

                if (node.Left != null) s1.Push(node.Left);
                if (node.Right != null) s1.Push(node.Right);
            }

            while (s2.Count > 0)
            {
                var node = s2.Pop();

                highlightedKey = node.Key.ToString();
                panelCanvas.Refresh();
                await Task.Delay(600);
                highlightedKey = null;
                panelCanvas.Refresh();
                await Task.Delay(200);
            }
        }


        private async void btnLevelOrder_Click(object sender, EventArgs e)
        {
            listBoxTraversal.Items.Clear();
            await AnimateLevelOrderTraversal();

            var seq = bst.LevelOrder();
            listBoxTraversal.Items.Clear();
            listBoxTraversal.Items.Add(string.Join(" → ", seq));
        }
        private async Task AnimateLevelOrderTraversal()
        {
            if (bst.Root == null) return;

            var queue = new Queue<BSTNode>();
            queue.Enqueue(bst.Root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                highlightedKey = node.Key.ToString();
                panelCanvas.Refresh();
                await Task.Delay(600);
                highlightedKey = null;
                panelCanvas.Refresh();
                await Task.Delay(200);

                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }
        }


        private void GuncelleEklemeListesi()
        {
            listBoxEklenenler.Items.Clear();
            foreach (int sayi in eklenenler)
            {
                listBoxEklenenler.Items.Add(sayi);
            }
        }


        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (bst.Root != null)
            {
                DrawNode(e.Graphics, bst.Root, panelCanvas.Width / 2, 20, panelCanvas.Width / 4);
                DrawLinkedList(e.Graphics);
            }
        }

        private void DrawNode(Graphics g, BSTNode node, int x, int y, int offset)
        {
            if (node == null) return;

            // Highlight kontrolü
            Brush fillBrush = (highlightedKey != null && node.Key.ToString() == highlightedKey)
                ? Brushes.Yellow
                : Brushes.LightBlue;

            // Daire çizimi
            g.FillEllipse(fillBrush, x - 15, y - 15, 30, 30);
            g.DrawEllipse(Pens.Black, x - 15, y - 15, 30, 30);
            g.DrawString(node.Key.ToString(), new Font("Arial", 10), Brushes.Black, x - 10, y - 8);

            // Sol çocuk
            if (node.Left != null)
            {
                g.DrawLine(Pens.Black, x, y, x - offset, y + 50);
                DrawNode(g, node.Left, x - offset, y + 50, offset / 2);
            }

            // Sağ çocuk
            if (node.Right != null)
            {
                g.DrawLine(Pens.Black, x, y, x + offset, y + 50);
                DrawNode(g, node.Right, x + offset, y + 50, offset / 2);
            }
        }

        private void DrawLinkedList(Graphics g)
        {
            int startX = 20;
            int y = panelCanvas.Height - 40; // panelin en altı
            int nodeWidth = 40;
            int nodeHeight = 30;
            int spacing = 20;

            // Yanlış: var node = eklenenler.First;
            // Doğru:
            var current = eklenenler.Head;


            while (current != null)
            {
                // Düğüm kutusu
                g.FillRectangle(Brushes.LightGreen, startX, y, nodeWidth, nodeHeight);
                g.DrawRectangle(Pens.Black, startX, y, nodeWidth, nodeHeight);
                g.DrawString(current.Value.ToString(), new Font("Arial", 10), Brushes.Black, startX + 10, y + 7);

                // Bağlantı çizgisi (ok gibi)
                int nextX = startX + nodeWidth + spacing;
                if (current.Next != null) // Eğer bir sonraki varsa ok çizelim
                {
                    g.DrawLine(Pens.Black, startX + nodeWidth, y + nodeHeight / 2, nextX - spacing / 2, y + nodeHeight / 2);
                    g.DrawLine(Pens.Black, nextX - spacing / 2, y + nodeHeight / 2, nextX - spacing / 2 - 5, y + nodeHeight / 2 - 5);
                    g.DrawLine(Pens.Black, nextX - spacing / 2, y + nodeHeight / 2, nextX - spacing / 2 - 5, y + nodeHeight / 2 + 5);
                }
                else
                {
                    // Son düğümde "Son" yazısını ekleyelim
                    g.DrawString("Son", new Font("Arial", 10), Brushes.Red, nextX + 10, y + nodeHeight / 4);  // "Son" yazısı
                }

                startX = nextX;
                current = current.Next;
            }
        }
    }
}

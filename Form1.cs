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
        private void btnInOrder_Click(object sender, EventArgs e)
        {
            var seq = bst.InOrder();
            var line = string.Join(" → ", seq);    // araya ok da koyduk istersen sadece boşluk bırak
            listBoxTraversal.Items.Clear();
            listBoxTraversal.Items.Add(line);
        }

        private void btnPreOrder_Click(object sender, EventArgs e)
        {
            var seq = bst.PreOrder();
            var line = string.Join(" → ", seq);
            listBoxTraversal.Items.Clear();
            listBoxTraversal.Items.Add(line);
        }

        private void btnPostOrder_Click(object sender, EventArgs e)
        {
            var seq = bst.PostOrder();
            var line = string.Join(" → ", seq);
            listBoxTraversal.Items.Clear();
            listBoxTraversal.Items.Add(line);
        }
        private void btnInOrderIter_Click(object sender, EventArgs e)
        {
            var seq = bst.InOrderIterative();
            listBoxTraversal.Items.Clear();
            listBoxTraversal.Items.Add(string.Join(" → ", seq));
        }
        private void btnPreOrderIter_Click(object sender, EventArgs e)
        {
            var seq = bst.PreOrderIterative();
            listBoxTraversal.Items.Clear();
            listBoxTraversal.Items.Add(string.Join(" → ", seq));
        }

        private void btnPostOrderIter_Click(object sender, EventArgs e)
        {
            var seq = bst.PostOrderIterative();
            listBoxTraversal.Items.Clear();
            listBoxTraversal.Items.Add(string.Join(" → ", seq));
        }

        private void btnLevelOrder_Click(object sender, EventArgs e)
        {
            var seq = bst.LevelOrder();
            listBoxTraversal.Items.Clear();
            listBoxTraversal.Items.Add(string.Join(" → ", seq));
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

            // Düğümün dairesi
            g.FillEllipse(Brushes.LightBlue, x - 15, y - 15, 30, 30);
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

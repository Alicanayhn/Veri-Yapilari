namespace BST_Winforms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.ListBox listBoxEklenenler;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDeleteLast;
        private System.Windows.Forms.Button btnInOrder;
        private System.Windows.Forms.Button btnPreOrder;
        private System.Windows.Forms.Button btnPostOrder;
        private System.Windows.Forms.Button btnInOrderIter;
        private System.Windows.Forms.Button btnPreOrderIter;
        private System.Windows.Forms.Button btnPostOrderIter;
        private System.Windows.Forms.Button btnLevelOrder;
        private System.Windows.Forms.ListBox listBoxTraversal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.listBoxEklenenler = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(100, 20);
            this.txtInput.TabIndex = 0;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(118, 10);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 1;
            this.btnInsert.Text = "Ekle";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            //
            // btnDelete
            //
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDelete.Location = new System.Drawing.Point(200, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnDeleteLast (yeni Son Sil butonu)
            //
            this.btnDeleteLast = new System.Windows.Forms.Button();
            this.btnDeleteLast.Location = new System.Drawing.Point(290, 10);
            this.btnDeleteLast.Name = "btnDeleteLast";
            this.btnDeleteLast.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteLast.TabIndex = 4;
            this.btnDeleteLast.Text = "Son Sil";
            this.btnDeleteLast.UseVisualStyleBackColor = true;
            this.btnDeleteLast.Click += new System.EventHandler(this.btnDeleteLast_Click);
            //
            // btnInOrder
            //
            this.btnInOrder = new System.Windows.Forms.Button();
            this.btnInOrder.Location = new System.Drawing.Point(12, 560);
            this.btnInOrder.Name = "btnInOrder";
            this.btnInOrder.Size = new System.Drawing.Size(75, 23);
            this.btnInOrder.Text = "In-Order";
            this.btnInOrder.UseVisualStyleBackColor = true;
            this.btnInOrder.Click += new System.EventHandler(this.btnInOrder_Click);
            //
            // btnPreOrder
            //
            this.btnPreOrder = new System.Windows.Forms.Button();
            this.btnPreOrder.Location = new System.Drawing.Point(100, 560);
            this.btnPreOrder.Name = "btnPreOrder";
            this.btnPreOrder.Size = new System.Drawing.Size(75, 23);
            this.btnPreOrder.Text = "Pre-Order";
            this.btnPreOrder.UseVisualStyleBackColor = true;
            this.btnPreOrder.Click += new System.EventHandler(this.btnPreOrder_Click);
            //
            // btnPostOrder
            //
            this.btnPostOrder = new System.Windows.Forms.Button();
            this.btnPostOrder.Location = new System.Drawing.Point(188, 560);
            this.btnPostOrder.Name = "btnPostOrder";
            this.btnPostOrder.Size = new System.Drawing.Size(75, 23);
            this.btnPostOrder.Text = "Post-Order";
            this.btnPostOrder.UseVisualStyleBackColor = true;
            this.btnPostOrder.Click += new System.EventHandler(this.btnPostOrder_Click);
            // 
            // btnInOrderIter
            // 
            this.btnInOrderIter = new System.Windows.Forms.Button();
            this.btnInOrderIter.Location = new System.Drawing.Point(276, 560);
            this.btnInOrderIter.Name = "btnInOrderIter";
            this.btnInOrderIter.Size = new System.Drawing.Size(100, 23);
            this.btnInOrderIter.TabIndex = 5;
            this.btnInOrderIter.Text = "InOrder Iter";
            this.btnInOrderIter.UseVisualStyleBackColor = true;
            this.btnInOrderIter.Click += new System.EventHandler(this.btnInOrderIter_Click);
            // 
            // btnPreOrderIter
            // 
            this.btnPreOrderIter = new System.Windows.Forms.Button();
            this.btnPreOrderIter.Location = new System.Drawing.Point(382, 560);
            this.btnPreOrderIter.Name = "btnPreOrderIter";
            this.btnPreOrderIter.Size = new System.Drawing.Size(100, 23);
            this.btnPreOrderIter.TabIndex = 6;
            this.btnPreOrderIter.Text = "PreOrder Iter";
            this.btnPreOrderIter.UseVisualStyleBackColor = true;
            this.btnPreOrderIter.Click += new System.EventHandler(this.btnPreOrderIter_Click);            
            // 
            // btnPostOrderIter
            // 
            this.btnPostOrderIter = new System.Windows.Forms.Button();
            this.btnPostOrderIter.Location = new System.Drawing.Point(488, 560);
            this.btnPostOrderIter.Name = "btnPostOrderIter";
            this.btnPostOrderIter.Size = new System.Drawing.Size(100, 23);
            this.btnPostOrderIter.TabIndex = 7;
            this.btnPostOrderIter.Text = "PostOrder Iter";
            this.btnPostOrderIter.UseVisualStyleBackColor = true;
            this.btnPostOrderIter.Click += new System.EventHandler(this.btnPostOrderIter_Click);            
            // 
            // btnLevelOrder
            // 
            this.btnLevelOrder = new System.Windows.Forms.Button();
            this.btnLevelOrder.Location = new System.Drawing.Point(594, 560);
            this.btnLevelOrder.Name = "btnLevelOrder";
            this.btnLevelOrder.Size = new System.Drawing.Size(100, 23);
            this.btnLevelOrder.TabIndex = 8;
            this.btnLevelOrder.Text = "Level-Order";
            this.btnLevelOrder.UseVisualStyleBackColor = true;
            this.btnLevelOrder.Click += new System.EventHandler(this.btnLevelOrder_Click);
            //
            // listBoxTraversal
            //
            this.listBoxTraversal = new System.Windows.Forms.ListBox();
            this.listBoxTraversal.FormattingEnabled = true;
            this.listBoxTraversal.Location = new System.Drawing.Point(12, 590);
            this.listBoxTraversal.Name = "listBoxTraversal";
            this.listBoxTraversal.Size = new System.Drawing.Size(760, 95);
            // 
            // panelCanvas
            // 
            this.panelCanvas.BackColor = System.Drawing.Color.White;
            this.panelCanvas.Location = new System.Drawing.Point(12, 50);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(760, 500);
            this.panelCanvas.TabIndex = 2;
            this.panelCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCanvas_Paint);
            // 
            // listBoxEklenenler
            // 
            this.listBoxEklenenler.FormattingEnabled = true;
            this.listBoxEklenenler.Location = new System.Drawing.Point(790, 50);
            this.listBoxEklenenler.Name = "listBoxEklenenler";
            this.listBoxEklenenler.Size = new System.Drawing.Size(150, 500);
            this.listBoxEklenenler.TabIndex = 3;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(960, 720);
            this.Controls.Add(this.listBoxEklenenler);
            this.Controls.Add(this.panelCanvas);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDeleteLast);
            this.Controls.Add(this.btnInOrder);
            this.Controls.Add(this.btnPreOrder);
            this.Controls.Add(this.btnPostOrder);
            this.Controls.Add(this.btnInOrderIter);
            this.Controls.Add(this.btnPreOrderIter);
            this.Controls.Add(this.btnPostOrderIter);
            this.Controls.Add(this.btnLevelOrder);
            this.Controls.Add(this.listBoxTraversal);
            this.Controls.Add(this.txtInput);
            this.Name = "Form1";
            this.Text = "İkili Arama Ağacı (BST)";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}


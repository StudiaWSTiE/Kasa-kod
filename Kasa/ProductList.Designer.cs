namespace Kasa
{
    partial class ProductList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridProducts = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNazwa = new System.Windows.Forms.TextBox();
            this.txtRFID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCena = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJednostka = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rb5 = new System.Windows.Forms.RadioButton();
            this.rb8 = new System.Windows.Forms.RadioButton();
            this.rb23 = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridProducts);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.ForeColor = System.Drawing.Color.Tomato;
            this.groupBox1.Location = new System.Drawing.Point(8, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(618, 255);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Produkty:";
            // 
            // dataGridProducts
            // 
            this.dataGridProducts.AllowUserToAddRows = false;
            this.dataGridProducts.AllowUserToDeleteRows = false;
            this.dataGridProducts.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dataGridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridProducts.EnableHeadersVisualStyles = false;
            this.dataGridProducts.GridColor = System.Drawing.Color.DimGray;
            this.dataGridProducts.Location = new System.Drawing.Point(3, 16);
            this.dataGridProducts.Name = "dataGridProducts";
            this.dataGridProducts.ReadOnly = true;
            this.dataGridProducts.Size = new System.Drawing.Size(612, 236);
            this.dataGridProducts.TabIndex = 0;
            this.dataGridProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProducts_CellClick);
            this.dataGridProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProducts_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nazwa:";
            // 
            // txtNazwa
            // 
            this.txtNazwa.Location = new System.Drawing.Point(31, 46);
            this.txtNazwa.Name = "txtNazwa";
            this.txtNazwa.Size = new System.Drawing.Size(128, 20);
            this.txtNazwa.TabIndex = 2;
            // 
            // txtRFID
            // 
            this.txtRFID.Location = new System.Drawing.Point(31, 96);
            this.txtRFID.Name = "txtRFID";
            this.txtRFID.Size = new System.Drawing.Size(128, 20);
            this.txtRFID.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.Tomato;
            this.label2.Location = new System.Drawing.Point(28, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "RFID:";
            // 
            // txtCena
            // 
            this.txtCena.Location = new System.Drawing.Point(226, 96);
            this.txtCena.Name = "txtCena";
            this.txtCena.Size = new System.Drawing.Size(128, 20);
            this.txtCena.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.Tomato;
            this.label3.Location = new System.Drawing.Point(223, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cena:";
            // 
            // txtJednostka
            // 
            this.txtJednostka.Location = new System.Drawing.Point(226, 46);
            this.txtJednostka.Name = "txtJednostka";
            this.txtJednostka.Size = new System.Drawing.Size(128, 20);
            this.txtJednostka.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.Tomato;
            this.label4.Location = new System.Drawing.Point(223, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Jednostka:";
            // 
            // rb5
            // 
            this.rb5.AutoSize = true;
            this.rb5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rb5.ForeColor = System.Drawing.Color.Tomato;
            this.rb5.Location = new System.Drawing.Point(380, 39);
            this.rb5.Name = "rb5";
            this.rb5.Size = new System.Drawing.Size(69, 17);
            this.rb5.TabIndex = 11;
            this.rb5.TabStop = true;
            this.rb5.Text = "VAT 5%";
            this.rb5.UseVisualStyleBackColor = true;
            // 
            // rb8
            // 
            this.rb8.AutoSize = true;
            this.rb8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rb8.ForeColor = System.Drawing.Color.Tomato;
            this.rb8.Location = new System.Drawing.Point(380, 69);
            this.rb8.Name = "rb8";
            this.rb8.Size = new System.Drawing.Size(69, 17);
            this.rb8.TabIndex = 12;
            this.rb8.TabStop = true;
            this.rb8.Text = "VAT 8%";
            this.rb8.UseVisualStyleBackColor = true;
            // 
            // rb23
            // 
            this.rb23.AutoSize = true;
            this.rb23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rb23.ForeColor = System.Drawing.Color.Tomato;
            this.rb23.Location = new System.Drawing.Point(380, 99);
            this.rb23.Name = "rb23";
            this.rb23.Size = new System.Drawing.Size(76, 17);
            this.rb23.TabIndex = 13;
            this.rb23.TabStop = true;
            this.rb23.Text = "VAT 23%";
            this.rb23.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAdd.ForeColor = System.Drawing.Color.Tomato;
            this.btnAdd.Location = new System.Drawing.Point(521, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 33);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Dodaj";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRemove.ForeColor = System.Drawing.Color.Tomato;
            this.btnRemove.Location = new System.Drawing.Point(521, 70);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(91, 33);
            this.btnRemove.TabIndex = 15;
            this.btnRemove.Text = "Usuń";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEdit.ForeColor = System.Drawing.Color.Tomato;
            this.btnEdit.Location = new System.Drawing.Point(521, 109);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(91, 33);
            this.btnEdit.TabIndex = 16;
            this.btnEdit.Text = "Edytuj";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nazwa";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "RFID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Cena";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Jednostka";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "VAT";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // ProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(634, 435);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rb23);
            this.Controls.Add(this.rb8);
            this.Controls.Add(this.rb5);
            this.Controls.Add(this.txtJednostka);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCena);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRFID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNazwa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ProductList";
            this.Text = "ProductList";
            this.Load += new System.EventHandler(this.ProductList_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNazwa;
        private System.Windows.Forms.TextBox txtRFID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCena;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJednostka;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rb5;
        private System.Windows.Forms.RadioButton rb8;
        private System.Windows.Forms.RadioButton rb23;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}
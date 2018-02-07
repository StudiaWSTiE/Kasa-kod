namespace Kasa
{
    partial class MainPanel
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPanel));
            this.kasaUHF = new System.Windows.Forms.Label();
            this.CustomerPanel = new System.Windows.Forms.Button();
            this.AdminPanel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // kasaUHF
            // 
            this.kasaUHF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kasaUHF.AutoSize = true;
            this.kasaUHF.Font = new System.Drawing.Font("Perpetua Titling MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kasaUHF.ForeColor = System.Drawing.Color.Tomato;
            this.kasaUHF.Location = new System.Drawing.Point(71, 70);
            this.kasaUHF.Name = "kasaUHF";
            this.kasaUHF.Size = new System.Drawing.Size(202, 38);
            this.kasaUHF.TabIndex = 0;
            this.kasaUHF.Text = "Kasa RFID";
            // 
            // CustomerPanel
            // 
            this.CustomerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CustomerPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.CustomerPanel.ForeColor = System.Drawing.Color.Tomato;
            this.CustomerPanel.Image = ((System.Drawing.Image)(resources.GetObject("CustomerPanel.Image")));
            this.CustomerPanel.Location = new System.Drawing.Point(22, 251);
            this.CustomerPanel.Name = "CustomerPanel";
            this.CustomerPanel.Size = new System.Drawing.Size(130, 70);
            this.CustomerPanel.TabIndex = 1;
            this.CustomerPanel.Text = "Panel klienta";
            this.CustomerPanel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CustomerPanel.UseVisualStyleBackColor = true;
            this.CustomerPanel.Click += new System.EventHandler(this.CustomerPanel_Click);
            // 
            // AdminPanel
            // 
            this.AdminPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.AdminPanel.ForeColor = System.Drawing.Color.Tomato;
            this.AdminPanel.Image = ((System.Drawing.Image)(resources.GetObject("AdminPanel.Image")));
            this.AdminPanel.Location = new System.Drawing.Point(189, 251);
            this.AdminPanel.Name = "AdminPanel";
            this.AdminPanel.Size = new System.Drawing.Size(130, 70);
            this.AdminPanel.TabIndex = 2;
            this.AdminPanel.Text = "Panel administratora";
            this.AdminPanel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AdminPanel.UseVisualStyleBackColor = true;
            this.AdminPanel.Click += new System.EventHandler(this.AdminPanel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(92, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Proszę wybrać panel:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Tomato;
            this.label2.Location = new System.Drawing.Point(71, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Jakub Sobański , Rafał Mosór";
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(344, 378);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AdminPanel);
            this.Controls.Add(this.CustomerPanel);
            this.Controls.Add(this.kasaUHF);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "MainPanel";
            this.Text = "Panel startowy";
            this.Load += new System.EventHandler(this.MainPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label kasaUHF;
        private System.Windows.Forms.Button CustomerPanel;
        private System.Windows.Forms.Button AdminPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


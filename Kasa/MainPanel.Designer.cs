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
            this.kasaUHF = new System.Windows.Forms.Label();
            this.CustomerPanel = new System.Windows.Forms.Button();
            this.AdminPanel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kasaUHF
            // 
            this.kasaUHF.AutoSize = true;
            this.kasaUHF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.kasaUHF.ForeColor = System.Drawing.Color.Tomato;
            this.kasaUHF.Location = new System.Drawing.Point(106, 43);
            this.kasaUHF.Name = "kasaUHF";
            this.kasaUHF.Size = new System.Drawing.Size(83, 20);
            this.kasaUHF.TabIndex = 0;
            this.kasaUHF.Text = "Kasa UHF";
            // 
            // CustomerPanel
            // 
            this.CustomerPanel.Location = new System.Drawing.Point(12, 154);
            this.CustomerPanel.Name = "CustomerPanel";
            this.CustomerPanel.Size = new System.Drawing.Size(97, 45);
            this.CustomerPanel.TabIndex = 1;
            this.CustomerPanel.Text = "Panel klienta";
            this.CustomerPanel.UseVisualStyleBackColor = true;
            this.CustomerPanel.Click += new System.EventHandler(this.CustomerPanel_Click);
            // 
            // AdminPanel
            // 
            this.AdminPanel.Location = new System.Drawing.Point(175, 154);
            this.AdminPanel.Name = "AdminPanel";
            this.AdminPanel.Size = new System.Drawing.Size(97, 45);
            this.AdminPanel.TabIndex = 2;
            this.AdminPanel.Text = "Panel administratora";
            this.AdminPanel.UseVisualStyleBackColor = true;
            this.AdminPanel.Click += new System.EventHandler(this.AdminPanel_Click);
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 261);
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
    }
}


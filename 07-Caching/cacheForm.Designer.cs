namespace CSharpWinFormsPOCs._07_Caching
{
    partial class cacheForm
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.btnClearCache = new System.Windows.Forms.Button();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.lblCacheStats = new System.Windows.Forms.Label();
            this.btnForceRefresh = new System.Windows.Forms.Button();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.lstActivity = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(205, 25);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(82, 35);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(20, 31);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(179, 22);
            this.txtCustomerId.TabIndex = 1;
            // 
            // btnClearCache
            // 
            this.btnClearCache.Location = new System.Drawing.Point(482, 25);
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(102, 35);
            this.btnClearCache.TabIndex = 2;
            this.btnClearCache.Text = "ClearCache";
            this.btnClearCache.UseVisualStyleBackColor = true;
            this.btnClearCache.Click += new System.EventHandler(this.btnClearCache_Click);
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(631, 25);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(64, 16);
            this.lblSource.TabIndex = 3;
            this.lblSource.Text = "lblSource";
            // 
            // lblElapsed
            // 
            this.lblElapsed.AutoSize = true;
            this.lblElapsed.Location = new System.Drawing.Point(631, 53);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(72, 16);
            this.lblElapsed.TabIndex = 4;
            this.lblElapsed.Text = "lblElapsed";
            // 
            // lblCacheStats
            // 
            this.lblCacheStats.AutoSize = true;
            this.lblCacheStats.Location = new System.Drawing.Point(631, 86);
            this.lblCacheStats.Name = "lblCacheStats";
            this.lblCacheStats.Size = new System.Drawing.Size(90, 16);
            this.lblCacheStats.TabIndex = 5;
            this.lblCacheStats.Text = "lblCacheStats";
            // 
            // btnForceRefresh
            // 
            this.btnForceRefresh.Location = new System.Drawing.Point(482, 74);
            this.btnForceRefresh.Name = "btnForceRefresh";
            this.btnForceRefresh.Size = new System.Drawing.Size(122, 35);
            this.btnForceRefresh.TabIndex = 6;
            this.btnForceRefresh.Text = "ForceRefresh";
            this.btnForceRefresh.UseVisualStyleBackColor = true;
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Location = new System.Drawing.Point(20, 221);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.RowTemplate.Height = 24;
            this.dgvCustomer.Size = new System.Drawing.Size(685, 217);
            this.dgvCustomer.TabIndex = 7;
            // 
            // lstActivity
            // 
            this.lstActivity.FormattingEnabled = true;
            this.lstActivity.ItemHeight = 16;
            this.lstActivity.Location = new System.Drawing.Point(20, 74);
            this.lstActivity.Name = "lstActivity";
            this.lstActivity.Size = new System.Drawing.Size(443, 132);
            this.lstActivity.TabIndex = 8;
            // 
            // cacheForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstActivity);
            this.Controls.Add(this.dgvCustomer);
            this.Controls.Add(this.btnForceRefresh);
            this.Controls.Add(this.lblCacheStats);
            this.Controls.Add(this.lblElapsed);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.btnClearCache);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.btnLoad);
            this.Name = "cacheForm";
            this.Text = "cacheForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Button btnClearCache;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblElapsed;
        private System.Windows.Forms.Label lblCacheStats;
        private System.Windows.Forms.Button btnForceRefresh;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.ListBox lstActivity;
    }
}
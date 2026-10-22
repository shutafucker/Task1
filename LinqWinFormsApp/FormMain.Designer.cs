namespace LinqWinFormsApp;

partial class FormMain
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel pnlTop;
    private System.Windows.Forms.Label lblOperation;
    private System.Windows.Forms.ComboBox cmbOperation;
    private System.Windows.Forms.Panel pnlFilterParams;
    private System.Windows.Forms.Label lblThreshold;
    private System.Windows.Forms.NumericUpDown numThreshold;
    private System.Windows.Forms.Label lblSkipCount;
    private System.Windows.Forms.NumericUpDown numSkipCount;
    private System.Windows.Forms.Button btnApplyFilter;

    private System.Windows.Forms.Panel pnlPaging;
    private System.Windows.Forms.Button btnPrev;
    private System.Windows.Forms.Button btnNext;
    private System.Windows.Forms.Label lblPageSizeTitle;
    private System.Windows.Forms.NumericUpDown numPageSize;
    private System.Windows.Forms.Label lblPageInfo;

    private System.Windows.Forms.DataGridView dgvResults;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel lblSummary;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dgvRowStyle = new System.Windows.Forms.DataGridViewCellStyle();

        this.pnlTop = new System.Windows.Forms.Panel();
        this.lblOperation = new System.Windows.Forms.Label();
        this.cmbOperation = new System.Windows.Forms.ComboBox();
        this.pnlFilterParams = new System.Windows.Forms.Panel();
        this.lblThreshold = new System.Windows.Forms.Label();
        this.numThreshold = new System.Windows.Forms.NumericUpDown();
        this.lblSkipCount = new System.Windows.Forms.Label();
        this.numSkipCount = new System.Windows.Forms.NumericUpDown();
        this.btnApplyFilter = new System.Windows.Forms.Button();

        this.pnlPaging = new System.Windows.Forms.Panel();
        this.btnPrev = new System.Windows.Forms.Button();
        this.btnNext = new System.Windows.Forms.Button();
        this.lblPageSizeTitle = new System.Windows.Forms.Label();
        this.numPageSize = new System.Windows.Forms.NumericUpDown();
        this.lblPageInfo = new System.Windows.Forms.Label();

        this.dgvResults = new System.Windows.Forms.DataGridView();
        this.statusStrip = new System.Windows.Forms.StatusStrip();
        this.lblSummary = new System.Windows.Forms.ToolStripStatusLabel();

        this.pnlTop.SuspendLayout();
        this.pnlFilterParams.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numSkipCount)).BeginInit();
        this.pnlPaging.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
        this.statusStrip.SuspendLayout();
        this.SuspendLayout();

        // 
        // pnlTop
        // 
        this.pnlTop.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
        this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlTop.Controls.Add(this.pnlFilterParams);
        this.pnlTop.Controls.Add(this.cmbOperation);
        this.pnlTop.Controls.Add(this.lblOperation);
        this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlTop.Location = new System.Drawing.Point(0, 0);
        this.pnlTop.Name = "pnlTop";
        this.pnlTop.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
        this.pnlTop.Size = new System.Drawing.Size(1080, 72);
        this.pnlTop.TabIndex = 0;

        // 
        // lblOperation
        // 
        this.lblOperation.AutoSize = true;
        this.lblOperation.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblOperation.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
        this.lblOperation.Location = new System.Drawing.Point(12, 12);
        this.lblOperation.Name = "lblOperation";
        this.lblOperation.Size = new System.Drawing.Size(155, 17);
        this.lblOperation.TabIndex = 0;
        this.lblOperation.Text = "Режим работы (LINQ):";

        // 
        // cmbOperation
        // 
        this.cmbOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbOperation.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cmbOperation.FormattingEnabled = true;
        this.cmbOperation.Location = new System.Drawing.Point(15, 33);
        this.cmbOperation.Name = "cmbOperation";
        this.cmbOperation.Size = new System.Drawing.Size(360, 25);
        this.cmbOperation.TabIndex = 1;
        this.cmbOperation.SelectedIndexChanged += new System.EventHandler(this.CmbOperation_SelectedIndexChanged);

        // 
        // pnlFilterParams
        // 
        this.pnlFilterParams.Controls.Add(this.btnApplyFilter);
        this.pnlFilterParams.Controls.Add(this.numSkipCount);
        this.pnlFilterParams.Controls.Add(this.lblSkipCount);
        this.pnlFilterParams.Controls.Add(this.numThreshold);
        this.pnlFilterParams.Controls.Add(this.lblThreshold);
        this.pnlFilterParams.Location = new System.Drawing.Point(385, 10);
        this.pnlFilterParams.Name = "pnlFilterParams";
        this.pnlFilterParams.Size = new System.Drawing.Size(460, 50);
        this.pnlFilterParams.TabIndex = 2;

        // 
        // lblThreshold
        // 
        this.lblThreshold.AutoSize = true;
        this.lblThreshold.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblThreshold.Location = new System.Drawing.Point(5, 5);
        this.lblThreshold.Name = "lblThreshold";
        this.lblThreshold.Size = new System.Drawing.Size(117, 15);
        this.lblThreshold.TabIndex = 0;
        this.lblThreshold.Text = "Порог выручки (₽):";

        // 
        // numThreshold
        // 
        this.numThreshold.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.numThreshold.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
        this.numThreshold.Location = new System.Drawing.Point(8, 23);
        this.numThreshold.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
        this.numThreshold.Name = "numThreshold";
        this.numThreshold.Size = new System.Drawing.Size(130, 24);
        this.numThreshold.TabIndex = 1;
        this.numThreshold.Value = new decimal(new int[] { 50000, 0, 0, 0 });
        this.numThreshold.ValueChanged += new System.EventHandler(this.FilterParams_Changed);

        // 
        // lblSkipCount
        // 
        this.lblSkipCount.AutoSize = true;
        this.lblSkipCount.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblSkipCount.Location = new System.Drawing.Point(155, 5);
        this.lblSkipCount.Name = "lblSkipCount";
        this.lblSkipCount.Size = new System.Drawing.Size(126, 15);
        this.lblSkipCount.TabIndex = 2;
        this.lblSkipCount.Text = "Пропустить первых N:";

        // 
        // numSkipCount
        // 
        this.numSkipCount.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.numSkipCount.Location = new System.Drawing.Point(158, 23);
        this.numSkipCount.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
        this.numSkipCount.Name = "numSkipCount";
        this.numSkipCount.Size = new System.Drawing.Size(120, 24);
        this.numSkipCount.TabIndex = 3;
        this.numSkipCount.Value = new decimal(new int[] { 5, 0, 0, 0 });
        this.numSkipCount.ValueChanged += new System.EventHandler(this.FilterParams_Changed);

        // 
        // btnApplyFilter
        // 
        this.btnApplyFilter.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
        this.btnApplyFilter.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnApplyFilter.FlatAppearance.BorderSize = 0;
        this.btnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnApplyFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnApplyFilter.ForeColor = System.Drawing.Color.White;
        this.btnApplyFilter.Location = new System.Drawing.Point(295, 21);
        this.btnApplyFilter.Name = "btnApplyFilter";
        this.btnApplyFilter.Size = new System.Drawing.Size(100, 26);
        this.btnApplyFilter.TabIndex = 4;
        this.btnApplyFilter.Text = "Применить";
        this.btnApplyFilter.UseVisualStyleBackColor = false;
        this.btnApplyFilter.Click += new System.EventHandler(this.BtnApplyFilter_Click);

        // 
        // pnlPaging
        // 
        this.pnlPaging.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
        this.pnlPaging.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlPaging.Controls.Add(this.lblPageInfo);
        this.pnlPaging.Controls.Add(this.btnNext);
        this.pnlPaging.Controls.Add(this.btnPrev);
        this.pnlPaging.Controls.Add(this.numPageSize);
        this.pnlPaging.Controls.Add(this.lblPageSizeTitle);
        this.pnlPaging.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlPaging.Location = new System.Drawing.Point(0, 72);
        this.pnlPaging.Name = "pnlPaging";
        this.pnlPaging.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
        this.pnlPaging.Size = new System.Drawing.Size(1080, 48);
        this.pnlPaging.TabIndex = 1;

        // 
        // btnPrev
        // 
        this.btnPrev.BackColor = System.Drawing.Color.FromArgb(230, 235, 240);
        this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnPrev.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(189, 195, 199);
        this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnPrev.Location = new System.Drawing.Point(15, 8);
        this.btnPrev.Name = "btnPrev";
        this.btnPrev.Size = new System.Drawing.Size(100, 30);
        this.btnPrev.TabIndex = 0;
        this.btnPrev.Text = "< Назад";
        this.btnPrev.UseVisualStyleBackColor = false;
        this.btnPrev.Click += new System.EventHandler(this.BtnPrev_Click);

        // 
        // btnNext
        // 
        this.btnNext.BackColor = System.Drawing.Color.FromArgb(230, 235, 240);
        this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(189, 195, 199);
        this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnNext.Location = new System.Drawing.Point(125, 8);
        this.btnNext.Name = "btnNext";
        this.btnNext.Size = new System.Drawing.Size(100, 30);
        this.btnNext.TabIndex = 1;
        this.btnNext.Text = "Вперед >";
        this.btnNext.UseVisualStyleBackColor = false;
        this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);

        // 
        // lblPageSizeTitle
        // 
        this.lblPageSizeTitle.AutoSize = true;
        this.lblPageSizeTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblPageSizeTitle.Location = new System.Drawing.Point(250, 15);
        this.lblPageSizeTitle.Name = "lblPageSizeTitle";
        this.lblPageSizeTitle.Size = new System.Drawing.Size(110, 15);
        this.lblPageSizeTitle.TabIndex = 2;
        this.lblPageSizeTitle.Text = "Размер страницы:";

        // 
        // numPageSize
        // 
        this.numPageSize.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.numPageSize.Location = new System.Drawing.Point(368, 11);
        this.numPageSize.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
        this.numPageSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        this.numPageSize.Name = "numPageSize";
        this.numPageSize.Size = new System.Drawing.Size(65, 24);
        this.numPageSize.TabIndex = 3;
        this.numPageSize.Value = new decimal(new int[] { 5, 0, 0, 0 });
        this.numPageSize.ValueChanged += new System.EventHandler(this.NumPageSize_ValueChanged);

        // 
        // lblPageInfo
        // 
        this.lblPageInfo.AutoSize = true;
        this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblPageInfo.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
        this.lblPageInfo.Location = new System.Drawing.Point(460, 14);
        this.lblPageInfo.Name = "lblPageInfo";
        this.lblPageInfo.Size = new System.Drawing.Size(124, 17);
        this.lblPageInfo.TabIndex = 4;
        this.lblPageInfo.Text = "Страница 1 из 1";

        // 
        // dgvResults
        // 
        this.dgvResults.AllowUserToAddRows = false;
        this.dgvResults.AllowUserToDeleteRows = false;
        this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvResults.BackgroundColor = System.Drawing.Color.White;
        this.dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvResults.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.dgvResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
        dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        dgvHeaderStyle.ForeColor = System.Drawing.Color.White;
        dgvHeaderStyle.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
        dgvHeaderStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.dgvResults.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
        this.dgvResults.ColumnHeadersHeight = 36;
        this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgvRowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dgvRowStyle.BackColor = System.Drawing.Color.White;
        dgvRowStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        dgvRowStyle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
        dgvRowStyle.Padding = new System.Windows.Forms.Padding(4);
        dgvRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(214, 234, 248);
        dgvRowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
        this.dgvResults.DefaultCellStyle = dgvRowStyle;
        this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvResults.EnableHeadersVisualStyles = false;
        this.dgvResults.GridColor = System.Drawing.Color.FromArgb(236, 240, 241);
        this.dgvResults.Location = new System.Drawing.Point(0, 120);
        this.dgvResults.MultiSelect = false;
        this.dgvResults.Name = "dgvResults";
        this.dgvResults.ReadOnly = true;
        this.dgvResults.RowHeadersVisible = false;
        this.dgvResults.RowHeadersWidth = 40;
        this.dgvResults.RowTemplate.Height = 32;
        this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvResults.Size = new System.Drawing.Size(1080, 480);
        this.dgvResults.TabIndex = 2;

        // 
        // statusStrip
        // 
        this.statusStrip.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
        this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.lblSummary});
        this.statusStrip.Location = new System.Drawing.Point(0, 600);
        this.statusStrip.Name = "statusStrip";
        this.statusStrip.Size = new System.Drawing.Size(1080, 26);
        this.statusStrip.TabIndex = 3;
        this.statusStrip.Text = "statusStrip";

        // 
        // lblSummary
        // 
        this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
        this.lblSummary.Name = "lblSummary";
        this.lblSummary.Size = new System.Drawing.Size(262, 21);
        this.lblSummary.Text = "Вывод количества элементов и сумм...";

        // 
        // FormMain
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(1080, 626);
        this.Controls.Add(this.dgvResults);
        this.Controls.Add(this.pnlPaging);
        this.Controls.Add(this.pnlTop);
        this.Controls.Add(this.statusStrip);
        this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.MinimumSize = new System.Drawing.Size(950, 550);
        this.Name = "FormMain";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "LINQ-запросы в Windows Forms: Группировка, Соединение и Постраничная выборка";
        this.Load += new System.EventHandler(this.FormMain_Load);
        this.pnlTop.ResumeLayout(false);
        this.pnlTop.PerformLayout();
        this.pnlFilterParams.ResumeLayout(false);
        this.pnlFilterParams.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numSkipCount)).EndInit();
        this.pnlPaging.ResumeLayout(false);
        this.pnlPaging.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
        this.statusStrip.ResumeLayout(false);
        this.statusStrip.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}

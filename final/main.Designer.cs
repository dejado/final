namespace final
{
    partial class main
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.lot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.bad_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Calendar_cal = new Calendar.NET.Calendar();
            this.label4 = new System.Windows.Forms.Label();
            this.product_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bad_chart)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.product_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1295, 680);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridView);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 377);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 300);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(706, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "비전 현황";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridView
            // 
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lot,
            this.type,
            this.num,
            this.date});
            this.gridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridView.Location = new System.Drawing.Point(0, 20);
            this.gridView.Name = "gridView";
            this.gridView.RowHeadersWidth = 51;
            this.gridView.RowTemplate.Height = 27;
            this.gridView.Size = new System.Drawing.Size(706, 280);
            this.gridView.TabIndex = 10;
            // 
            // lot
            // 
            this.lot.HeaderText = "Lot넘버";
            this.lot.MinimumWidth = 6;
            this.lot.Name = "lot";
            this.lot.Width = 125;
            // 
            // type
            // 
            this.type.HeaderText = "유형";
            this.type.MinimumWidth = 6;
            this.type.Name = "type";
            this.type.Width = 125;
            // 
            // num
            // 
            this.num.HeaderText = "개수";
            this.num.MinimumWidth = 6;
            this.num.Name = "num";
            this.num.Width = 125;
            // 
            // date
            // 
            this.date.HeaderText = "생산일자";
            this.date.MinimumWidth = 6;
            this.date.Name = "date";
            this.date.Width = 125;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(577, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "생산 현황";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.product_chart);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(715, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 368);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bad_chart);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(715, 377);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(577, 300);
            this.panel3.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(577, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "불량 현황";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bad_chart
            // 
            chartArea3.Name = "개수";
            this.bad_chart.ChartAreas.Add(chartArea3);
            this.bad_chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.bad_chart.Legends.Add(legend3);
            this.bad_chart.Location = new System.Drawing.Point(0, 20);
            this.bad_chart.Name = "bad_chart";
            series4.ChartArea = "개수";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series4.Legend = "Legend1";
            series4.Name = "bad";
            this.bad_chart.Series.Add(series4);
            this.bad_chart.Size = new System.Drawing.Size(577, 280);
            this.bad_chart.TabIndex = 10;
            this.bad_chart.Text = "불량현황";
            title3.Name = "불량 현황";
            this.bad_chart.Titles.Add(title3);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Calendar_cal);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(706, 368);
            this.panel4.TabIndex = 13;
            // 
            // Calendar_cal
            // 
            this.Calendar_cal.AllowEditingEvents = true;
            this.Calendar_cal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Calendar_cal.CalendarDate = new System.DateTime(2024, 2, 14, 23, 10, 54, 584);
            this.Calendar_cal.CalendarView = Calendar.NET.CalendarViews.Month;
            this.Calendar_cal.CausesValidation = false;
            this.Calendar_cal.DateHeaderFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Calendar_cal.DayOfWeekFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Calendar_cal.DaysFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Calendar_cal.DayViewTimeFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Calendar_cal.DimDisabledEvents = true;
            this.Calendar_cal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Calendar_cal.HighlightCurrentDay = true;
            this.Calendar_cal.LoadPresetHolidays = true;
            this.Calendar_cal.Location = new System.Drawing.Point(0, 20);
            this.Calendar_cal.Margin = new System.Windows.Forms.Padding(3, 3, 23, 3);
            this.Calendar_cal.Name = "Calendar_cal";
            this.Calendar_cal.ShowArrowControls = true;
            this.Calendar_cal.ShowDashedBorderOnDisabledEvents = true;
            this.Calendar_cal.ShowDateInHeader = true;
            this.Calendar_cal.ShowDisabledEvents = false;
            this.Calendar_cal.ShowEventTooltips = true;
            this.Calendar_cal.ShowTodayButton = true;
            this.Calendar_cal.Size = new System.Drawing.Size(706, 348);
            this.Calendar_cal.TabIndex = 8;
            this.Calendar_cal.TodayFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(706, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "일정";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // product_chart
            // 
            chartArea4.Name = "개수";
            this.product_chart.ChartAreas.Add(chartArea4);
            this.product_chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.product_chart.Legends.Add(legend4);
            this.product_chart.Location = new System.Drawing.Point(0, 20);
            this.product_chart.Name = "product_chart";
            series5.ChartArea = "개수";
            series5.Legend = "Legend1";
            series5.Name = "good";
            series6.ChartArea = "개수";
            series6.Legend = "Legend1";
            series6.Name = "bad";
            this.product_chart.Series.Add(series5);
            this.product_chart.Series.Add(series6);
            this.product_chart.Size = new System.Drawing.Size(577, 348);
            this.product_chart.TabIndex = 11;
            this.product_chart.Text = "생산현황";
            title4.Name = "불량 현황";
            this.product_chart.Titles.Add(title4);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "main";
            this.Size = new System.Drawing.Size(1295, 680);
            this.Load += new System.EventHandler(this.main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bad_chart)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.product_chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart bad_chart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private Calendar.NET.Calendar Calendar_cal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart product_chart;
    }
}

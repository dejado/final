namespace final
{
    partial class Navigation
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.slidePanel = new System.Windows.Forms.Panel();
            this.manaBt = new System.Windows.Forms.Button();
            this.productBt = new System.Windows.Forms.Button();
            this.mainBt = new System.Windows.Forms.Button();
            this.productCk = new System.Windows.Forms.CheckBox();
            this.wareBt = new System.Windows.Forms.Button();
            this.slideCk = new System.Windows.Forms.CheckBox();
            this.panelTimer = new System.Windows.Forms.Timer(this.components);
            this.manageBt = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.slidePanel.SuspendLayout();
            this.manageBt.SuspendLayout();
            this.SuspendLayout();
            // 
            // slidePanel
            // 
            this.slidePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.slidePanel.Controls.Add(this.manaBt);
            this.slidePanel.Controls.Add(this.productBt);
            this.slidePanel.Controls.Add(this.mainBt);
            this.slidePanel.Controls.Add(this.productCk);
            this.slidePanel.Controls.Add(this.wareBt);
            this.slidePanel.Controls.Add(this.slideCk);
            this.slidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.slidePanel.Location = new System.Drawing.Point(0, 0);
            this.slidePanel.Name = "slidePanel";
            this.slidePanel.Size = new System.Drawing.Size(200, 1033);
            this.slidePanel.TabIndex = 0;
            // 
            // manaBt
            // 
            this.manaBt.Dock = System.Windows.Forms.DockStyle.Top;
            this.manaBt.Location = new System.Drawing.Point(0, 250);
            this.manaBt.Name = "manaBt";
            this.manaBt.Size = new System.Drawing.Size(200, 50);
            this.manaBt.TabIndex = 24;
            this.manaBt.Text = "관리";
            this.manaBt.UseVisualStyleBackColor = true;
            this.manaBt.Click += new System.EventHandler(this.manaBt_Click);
            // 
            // productBt
            // 
            this.productBt.Dock = System.Windows.Forms.DockStyle.Top;
            this.productBt.Location = new System.Drawing.Point(0, 200);
            this.productBt.Name = "productBt";
            this.productBt.Size = new System.Drawing.Size(200, 50);
            this.productBt.TabIndex = 21;
            this.productBt.Text = "설비 현황";
            this.productBt.UseVisualStyleBackColor = true;
            this.productBt.Click += new System.EventHandler(this.productBt_Click);
            // 
            // mainBt
            // 
            this.mainBt.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainBt.Location = new System.Drawing.Point(0, 150);
            this.mainBt.Name = "mainBt";
            this.mainBt.Size = new System.Drawing.Size(200, 50);
            this.mainBt.TabIndex = 20;
            this.mainBt.Text = "생산 메인";
            this.mainBt.UseVisualStyleBackColor = true;
            this.mainBt.Click += new System.EventHandler(this.mainBt_Click);
            // 
            // productCk
            // 
            this.productCk.Appearance = System.Windows.Forms.Appearance.Button;
            this.productCk.Dock = System.Windows.Forms.DockStyle.Top;
            this.productCk.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.productCk.Location = new System.Drawing.Point(0, 100);
            this.productCk.Name = "productCk";
            this.productCk.Size = new System.Drawing.Size(200, 50);
            this.productCk.TabIndex = 18;
            this.productCk.Text = "생산";
            this.productCk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.productCk.UseVisualStyleBackColor = true;
            this.productCk.CheckedChanged += new System.EventHandler(this.productCk_CheckedChanged);
            // 
            // wareBt
            // 
            this.wareBt.Dock = System.Windows.Forms.DockStyle.Top;
            this.wareBt.Location = new System.Drawing.Point(0, 50);
            this.wareBt.Name = "wareBt";
            this.wareBt.Size = new System.Drawing.Size(200, 50);
            this.wareBt.TabIndex = 16;
            this.wareBt.Text = "창고";
            this.wareBt.UseVisualStyleBackColor = true;
            this.wareBt.Click += new System.EventHandler(this.wareBt_Click);
            // 
            // slideCk
            // 
            this.slideCk.Appearance = System.Windows.Forms.Appearance.Button;
            this.slideCk.Dock = System.Windows.Forms.DockStyle.Top;
            this.slideCk.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.slideCk.Location = new System.Drawing.Point(0, 0);
            this.slideCk.Name = "slideCk";
            this.slideCk.Size = new System.Drawing.Size(200, 50);
            this.slideCk.TabIndex = 6;
            this.slideCk.Text = ">";
            this.slideCk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.slideCk.UseVisualStyleBackColor = true;
            this.slideCk.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panelTimer
            // 
            this.panelTimer.Tick += new System.EventHandler(this.panelTimer_Tick);
            // 
            // manageBt
            // 
            this.manageBt.Controls.Add(this.panel1);
            this.manageBt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manageBt.Location = new System.Drawing.Point(200, 0);
            this.manageBt.Name = "manageBt";
            this.manageBt.Size = new System.Drawing.Size(1702, 1033);
            this.manageBt.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1702, 1033);
            this.panel1.TabIndex = 0;
            // 
            // Navigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.manageBt);
            this.Controls.Add(this.slidePanel);
            this.Name = "Navigation";
            this.Text = "반도체 생산";
            this.Load += new System.EventHandler(this.Navigation_Load);
            this.slidePanel.ResumeLayout(false);
            this.manageBt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel slidePanel;
        private System.Windows.Forms.Timer panelTimer;
        private System.Windows.Forms.CheckBox productCk;
        private System.Windows.Forms.CheckBox slideCk;
        private System.Windows.Forms.Panel manageBt;
        private System.Windows.Forms.Button wareBt;
        private System.Windows.Forms.Button productBt;
        private System.Windows.Forms.Button mainBt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button manaBt;
    }
}


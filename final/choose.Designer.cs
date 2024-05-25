namespace final
{
    partial class choose
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chiptxt = new System.Windows.Forms.TextBox();
            this.moldtxt = new System.Windows.Forms.TextBox();
            this.pcbtxt = new System.Windows.Forms.TextBox();
            this.chipBt = new System.Windows.Forms.Button();
            this.moldBt = new System.Windows.Forms.Button();
            this.pcbBt = new System.Windows.Forms.Button();
            this.okBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(194, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "chip, mold, pcb 를 입력하십시오.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(105, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "chip";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(101, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "mold";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(107, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "pcb";
            // 
            // chiptxt
            // 
            this.chiptxt.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chiptxt.Location = new System.Drawing.Point(217, 113);
            this.chiptxt.Name = "chiptxt";
            this.chiptxt.Size = new System.Drawing.Size(277, 34);
            this.chiptxt.TabIndex = 4;
            // 
            // moldtxt
            // 
            this.moldtxt.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.moldtxt.Location = new System.Drawing.Point(217, 191);
            this.moldtxt.Name = "moldtxt";
            this.moldtxt.Size = new System.Drawing.Size(277, 34);
            this.moldtxt.TabIndex = 5;
            // 
            // pcbtxt
            // 
            this.pcbtxt.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pcbtxt.Location = new System.Drawing.Point(217, 277);
            this.pcbtxt.Name = "pcbtxt";
            this.pcbtxt.Size = new System.Drawing.Size(277, 34);
            this.pcbtxt.TabIndex = 6;
            // 
            // chipBt
            // 
            this.chipBt.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chipBt.Location = new System.Drawing.Point(533, 113);
            this.chipBt.Name = "chipBt";
            this.chipBt.Size = new System.Drawing.Size(83, 34);
            this.chipBt.TabIndex = 7;
            this.chipBt.Text = "검색";
            this.chipBt.UseVisualStyleBackColor = true;
            this.chipBt.Click += new System.EventHandler(this.chipBt_Click);
            // 
            // moldBt
            // 
            this.moldBt.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.moldBt.Location = new System.Drawing.Point(533, 196);
            this.moldBt.Name = "moldBt";
            this.moldBt.Size = new System.Drawing.Size(83, 34);
            this.moldBt.TabIndex = 8;
            this.moldBt.Text = "검색";
            this.moldBt.UseVisualStyleBackColor = true;
            this.moldBt.Click += new System.EventHandler(this.moldBt_Click);
            // 
            // pcbBt
            // 
            this.pcbBt.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pcbBt.Location = new System.Drawing.Point(533, 274);
            this.pcbBt.Name = "pcbBt";
            this.pcbBt.Size = new System.Drawing.Size(83, 34);
            this.pcbBt.TabIndex = 9;
            this.pcbBt.Text = "검색";
            this.pcbBt.UseVisualStyleBackColor = true;
            this.pcbBt.Click += new System.EventHandler(this.pcbBt_Click);
            // 
            // okBt
            // 
            this.okBt.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.okBt.Location = new System.Drawing.Point(217, 359);
            this.okBt.Name = "okBt";
            this.okBt.Size = new System.Drawing.Size(277, 34);
            this.okBt.TabIndex = 10;
            this.okBt.Text = "확인";
            this.okBt.UseVisualStyleBackColor = true;
            this.okBt.Click += new System.EventHandler(this.okBt_Click);
            // 
            // choose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 450);
            this.Controls.Add(this.okBt);
            this.Controls.Add(this.pcbBt);
            this.Controls.Add(this.moldBt);
            this.Controls.Add(this.chipBt);
            this.Controls.Add(this.pcbtxt);
            this.Controls.Add(this.moldtxt);
            this.Controls.Add(this.chiptxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "choose";
            this.Text = "choose";
            this.Load += new System.EventHandler(this.choose_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox chiptxt;
        private System.Windows.Forms.TextBox moldtxt;
        private System.Windows.Forms.TextBox pcbtxt;
        private System.Windows.Forms.Button chipBt;
        private System.Windows.Forms.Button moldBt;
        private System.Windows.Forms.Button pcbBt;
        private System.Windows.Forms.Button okBt;
    }
}
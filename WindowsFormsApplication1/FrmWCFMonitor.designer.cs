namespace WindowsFormsApplication1
{
    partial class FrmWCFMonitor
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWcfServiceUri = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRetryTime = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtExeFilePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.btnSelectExeFile = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "检测间隔(分钟)";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(126, 34);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(182, 21);
            this.txtInterval.TabIndex = 1;
            this.txtInterval.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "服务地址";
            // 
            // txtWcfServiceUri
            // 
            this.txtWcfServiceUri.Location = new System.Drawing.Point(90, 40);
            this.txtWcfServiceUri.Name = "txtWcfServiceUri";
            this.txtWcfServiceUri.Size = new System.Drawing.Size(499, 21);
            this.txtWcfServiceUri.TabIndex = 1;
            this.txtWcfServiceUri.Text = "http://manage.chatop.com/t_bas_addressbaseService";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "检测时重试次数";
            // 
            // txtRetryTime
            // 
            this.txtRetryTime.Location = new System.Drawing.Point(527, 31);
            this.txtRetryTime.Name = "txtRetryTime";
            this.txtRetryTime.Size = new System.Drawing.Size(182, 21);
            this.txtRetryTime.TabIndex = 1;
            this.txtRetryTime.Text = "3";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("宋体", 11F);
            this.btnStart.Location = new System.Drawing.Point(353, 499);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(216, 48);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "启动监控";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 17);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(833, 180);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "服务地址";
            this.columnHeader1.Width = 410;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "程序路径";
            this.columnHeader2.Width = 416;
            // 
            // txtExeFilePath
            // 
            this.txtExeFilePath.Location = new System.Drawing.Point(90, 67);
            this.txtExeFilePath.Name = "txtExeFilePath";
            this.txtExeFilePath.Size = new System.Drawing.Size(404, 21);
            this.txtExeFilePath.TabIndex = 1;
            this.txtExeFilePath.Text = "D:\\Project\\ChaTu.Manage\\WcfHosting\\CustomDomainMgr.exe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "程序路径";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(48, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(839, 200);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "监控WCF服务列表";
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(653, 40);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(155, 48);
            this.btnAddToList.TabIndex = 3;
            this.btnAddToList.Text = "加入监控列表";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // btnSelectExeFile
            // 
            this.btnSelectExeFile.Location = new System.Drawing.Point(500, 67);
            this.btnSelectExeFile.Name = "btnSelectExeFile";
            this.btnSelectExeFile.Size = new System.Drawing.Size(89, 23);
            this.btnSelectExeFile.TabIndex = 6;
            this.btnSelectExeFile.Text = "选择文件...";
            this.btnSelectExeFile.UseVisualStyleBackColor = true;
            this.btnSelectExeFile.Click += new System.EventHandler(this.btnSelectExeFile_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnSelectExeFile);
            this.groupBox2.Controls.Add(this.txtWcfServiceUri);
            this.groupBox2.Controls.Add(this.txtExeFilePath);
            this.groupBox2.Controls.Add(this.btnAddToList);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(48, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(836, 123);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "监控内容";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtInterval);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtRetryTime);
            this.groupBox3.Location = new System.Drawing.Point(48, 378);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(839, 79);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "监控设置";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 582);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "WCF监控程序";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWcfServiceUri;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRetryTime;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox txtExeFilePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnSelectExeFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}


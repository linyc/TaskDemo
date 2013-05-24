namespace WindowsFormsApplication1
{
    partial class Form4
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cobox = new System.Windows.Forms.ComboBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(34, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 80;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.Size = new System.Drawing.Size(348, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // Column1
            // 
            dataGridViewCellStyle1.NullValue = "发起";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(436, 36);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(295, 214);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            // 
            // cobox
            // 
            this.cobox.FormattingEnabled = true;
            this.cobox.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e"});
            this.cobox.Location = new System.Drawing.Point(68, 258);
            this.cobox.Name = "cobox";
            this.cobox.Size = new System.Drawing.Size(121, 20);
            this.cobox.TabIndex = 3;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(211, 256);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(821, 213);
            this.webBrowser1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(78, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7});
            this.dataGridView2.Location = new System.Drawing.Point(764, 46);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(240, 150);
            this.dataGridView2.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "nikename";
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Key";
            this.dataGridViewTextBoxColumn2.HeaderText = "Column4";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn3.HeaderText = "Column5";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "key";
            this.dataGridViewTextBoxColumn4.HeaderText = "编号";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "value";
            this.dataGridViewTextBoxColumn5.HeaderText = "xxx";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "nikename";
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Key";
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Value";
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "key";
            this.Column6.HeaderText = "编号";
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "value";
            this.Column7.HeaderText = "xxx";
            this.Column7.Name = "Column7";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 494);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.cobox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form4";
            this.Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox cobox;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewLinkColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}
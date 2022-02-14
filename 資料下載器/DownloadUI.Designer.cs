
namespace 資料下載器
{
    partial class DownloadUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadUI));
            this.DownloadToSqlBtn = new System.Windows.Forms.Button();
            this.comboBoxDownLoadList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DownloadToSqlBtn
            // 
            this.DownloadToSqlBtn.BackColor = System.Drawing.Color.Black;
            this.DownloadToSqlBtn.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DownloadToSqlBtn.ForeColor = System.Drawing.Color.White;
            this.DownloadToSqlBtn.Location = new System.Drawing.Point(156, 198);
            this.DownloadToSqlBtn.Name = "DownloadToSqlBtn";
            this.DownloadToSqlBtn.Size = new System.Drawing.Size(173, 63);
            this.DownloadToSqlBtn.TabIndex = 1;
            this.DownloadToSqlBtn.Text = "開始下載";
            this.DownloadToSqlBtn.UseVisualStyleBackColor = false;
            this.DownloadToSqlBtn.Click += new System.EventHandler(this.DownloadToSqlBtn_Click);
            // 
            // comboBoxDownLoadList
            // 
            this.comboBoxDownLoadList.DisplayMember = "請選擇";
            this.comboBoxDownLoadList.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBoxDownLoadList.FormattingEnabled = true;
            this.comboBoxDownLoadList.IntegralHeight = false;
            this.comboBoxDownLoadList.Items.AddRange(new object[] {
            "請選擇",
            "NBA球員歷史資料"});
            this.comboBoxDownLoadList.Location = new System.Drawing.Point(156, 25);
            this.comboBoxDownLoadList.Name = "comboBoxDownLoadList";
            this.comboBoxDownLoadList.Size = new System.Drawing.Size(332, 33);
            this.comboBoxDownLoadList.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 33);
            this.label1.TabIndex = 24;
            this.label1.Text = "下載清單";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Navy;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(365, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 37);
            this.button1.TabIndex = 25;
            this.button1.Text = "創建";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 33);
            this.label2.TabIndex = 26;
            this.label2.Text = "一鍵產生 Table Schemas";
            // 
            // DownloadUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(509, 297);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDownLoadList);
            this.Controls.Add(this.DownloadToSqlBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "DownloadUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "資料下載器(下載)";
            this.Load += new System.EventHandler(this.DownloadUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DownloadToSqlBtn;
        private System.Windows.Forms.ComboBox comboBoxDownLoadList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}
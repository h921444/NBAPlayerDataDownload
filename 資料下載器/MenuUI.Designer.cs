
namespace 資料下載器
{
    partial class MenuIU
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuIU));
            this.GoToDownLoadBtn = new System.Windows.Forms.Button();
            this.GoToQueryBtn = new System.Windows.Forms.Button();
            this.textBoxDatabase = new System.Windows.Forms.TextBox();
            this.textBoxDataTable = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GoToDownLoadBtn
            // 
            this.GoToDownLoadBtn.BackColor = System.Drawing.Color.Black;
            this.GoToDownLoadBtn.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GoToDownLoadBtn.ForeColor = System.Drawing.Color.Red;
            this.GoToDownLoadBtn.Location = new System.Drawing.Point(362, 249);
            this.GoToDownLoadBtn.Name = "GoToDownLoadBtn";
            this.GoToDownLoadBtn.Size = new System.Drawing.Size(151, 43);
            this.GoToDownLoadBtn.TabIndex = 2;
            this.GoToDownLoadBtn.Text = "下載管理";
            this.GoToDownLoadBtn.UseVisualStyleBackColor = false;
            this.GoToDownLoadBtn.Click += new System.EventHandler(this.GoToDownLoadBtn_Click);
            // 
            // GoToQueryBtn
            // 
            this.GoToQueryBtn.BackColor = System.Drawing.Color.Black;
            this.GoToQueryBtn.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GoToQueryBtn.ForeColor = System.Drawing.Color.Red;
            this.GoToQueryBtn.Location = new System.Drawing.Point(159, 249);
            this.GoToQueryBtn.Name = "GoToQueryBtn";
            this.GoToQueryBtn.Size = new System.Drawing.Size(151, 43);
            this.GoToQueryBtn.TabIndex = 3;
            this.GoToQueryBtn.Text = "查詢管理";
            this.GoToQueryBtn.UseVisualStyleBackColor = false;
            // 
            // textBoxDatabase
            // 
            this.textBoxDatabase.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxDatabase.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxDatabase.Location = new System.Drawing.Point(286, 128);
            this.textBoxDatabase.Name = "textBoxDatabase";
            this.textBoxDatabase.Size = new System.Drawing.Size(207, 34);
            this.textBoxDatabase.TabIndex = 21;
            // 
            // textBoxDataTable
            // 
            this.textBoxDataTable.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxDataTable.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxDataTable.Location = new System.Drawing.Point(286, 168);
            this.textBoxDataTable.Name = "textBoxDataTable";
            this.textBoxDataTable.Size = new System.Drawing.Size(207, 34);
            this.textBoxDataTable.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(153, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 31);
            this.label5.TabIndex = 23;
            this.label5.Text = "DataBase :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(153, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 31);
            this.label6.TabIndex = 24;
            this.label6.Text = "DataTable :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(104, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 36);
            this.label1.TabIndex = 25;
            this.label1.Text = "位置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(104, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 36);
            this.label2.TabIndex = 26;
            this.label2.Text = "功能";
            // 
            // MenuIU
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(675, 403);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxDataTable);
            this.Controls.Add(this.textBoxDatabase);
            this.Controls.Add(this.GoToQueryBtn);
            this.Controls.Add(this.GoToDownLoadBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MenuIU";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "資料整合器(選單)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GoToDownLoadBtn;
        private System.Windows.Forms.Button GoToQueryBtn;
        private System.Windows.Forms.TextBox textBoxDatabase;
        private System.Windows.Forms.TextBox textBoxDataTable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
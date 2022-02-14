using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 資料下載器
{
    public partial class MenuIU : Form
    {
        public MenuIU()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 進入下載器按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToDownLoadBtn_Click(object sender, EventArgs e)
        {
            if (textBoxDatabase.Text != "" && textBoxDataTable.Text != "")
            {
                //將儲存路徑資訊(db、table)加上下載資訊輸出成"路徑參數檔"，給下載程式讀取              
                string parameterContent = $"{textBoxDatabase.Text},{textBoxDataTable.Text}";
                File.WriteAllText(@".\pathParameter.txt", parameterContent);

                //顯示DownloadUI
                DownloadUI form3 = new DownloadUI();
                form3.Visible = true;
            }
            else
            {
                MessageBox.Show("請填寫資料庫及資料表名稱。", "警告訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

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
using System.Diagnostics;
using 資料下載器;

namespace 資料下載器
{
    public partial class DownloadUI : Form
    {
        /// <summary>
        /// 傳入主控台下載程式的引數: "Weixen" (此引數是為了防止有人從外部執行該下載程式)
        /// </summary>
        public string MagicWord = "Weixen";

        public DownloadUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 按下下載鈕時，啟動主控台背景下載程式並將參數傳入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadToSqlBtn_Click(object sender, EventArgs e)
        {
            //判斷資料夾有沒有"載入檔"，有的話代表正在下載，因此不允許重複按下載鍵
            if (!File.Exists(@".\loading.txt"))
            {
                //判斷資料夾有無"連線參數檔"和"路徑參數檔"，沒有的話代表已斷開連線
                if (File.Exists(@".\loginParameter.txt") && File.Exists(@".\pathParameter.txt"))
                {
                    if (comboBoxDownLoadList.Text == "NBA球員歷史資料")
                    {
                        //執行nba球員資料下載程式
                        DwonloadExcutingProgram(@"..\..\..\背景下載nba資料\bin\Debug.\背景下載nba資料.exe");

                        //產生"載入檔"，表示下載程式正在下載
                        File.WriteAllText(@".\loading.txt", "downloading");

                        MessageBox.Show("已在背景執行下載，待完成後跳出通知，可放心關閉程式!", "執行通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        MessageBox.Show("資料填寫不完全，請填寫完整。", "警告訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("已斷開連線，請重新連線", "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("請勿重複執行下載", "警告訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 設定combobox初始值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadUI_Load(object sender, EventArgs e)
        {
            comboBoxDownLoadList.Text = comboBoxDownLoadList.Items[0].ToString();
        }

        /// <summary>
        /// 啟動下載程式
        /// </summary>
        /// <param name="filePath">下載程式路徑(相對路徑)</param>
        private void DwonloadExcutingProgram(string filePath)
        {
            //啟動下載程式
            Process pro = new Process();
            pro.StartInfo.FileName = string.Format(@"{0}", filePath);
            pro.StartInfo.Arguments = $"{MagicWord}";
            pro.Start();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using MySqlCreateByWeixen;
using 資料下載器;

namespace 下載nba資料
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 測試是否成功連線資料庫
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectCheckBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DoMySQL.ConnectToMySql(textBoxSvr.Text, textBoxUser.Text, textBoxPw.Text);
                MessageBox.Show("連線成功!", "連線測試", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MenuIU form2 = new MenuIU();
                //DownloadUI form3 = new DownloadUI();
                //form3.Owner = form2;

                //畫面跳轉至MenuIU並把ConnectUI隱藏
                form2.Visible = true;
                Visible = false;

                //若關閉MenuIU則須重新連線登陸
                form2.FormClosing += new FormClosingEventHandler(Form2_FormClosing);

                //將連線資訊輸出成"連線參數檔"，給下載程式讀取
                string parameterContent = $"{textBoxSvr.Text},{textBoxUser.Text},{textBoxPw.Text}";
                File.WriteAllText(@".\loginParameter.txt", parameterContent);
            }
            catch (Exception)
            {
                MessageBox.Show("連線失敗，請確認server ip、user、password有無錯誤!", "連線測試", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 顯示ConnectUI，跳回連線畫面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("若關閉視窗將斷開連線，是否繼續？\np.s.若正在下載資料，斷開連線不會造成任何影響。", "確認訊息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //刪除連線參數檔和路徑參數檔
                File.Delete(@".\loginParameter.txt");
                File.Delete(@".\pathParameter.txt");
                
                this.Visible = true;
                textBoxUser.Text = "";
                textBoxPw.Text = "";

                //關閉視窗
                e.Cancel = false; 
            }
            else
            {
                e.Cancel = true;    //取消關閉
            }          
        }
    }
}

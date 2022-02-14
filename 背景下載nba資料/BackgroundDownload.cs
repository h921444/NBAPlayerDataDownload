using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using MySqlCreateByWeixen;
using System.Diagnostics;

namespace 背景下載nba資料
{
    class BackgroundDownload
    {
        /// <summary>
        /// 主程式進入點
        /// </summary>
        /// <param name="args">接收六個引數:server、user、password、database、datatable、"Weixen"</param>
        static void Main(string[] args)
        {
            Stopwatch runTime = new Stopwatch();
            runTime.Start();

            //讀取連線參數和路徑參數
            string[] loginParameter = File.ReadAllText(@"..\..\..\資料下載器\bin\Debug\loginParameter.txt").Split(',');
            string[] pathParameter = File.ReadAllText(@"..\..\..\資料下載器\bin\Debug\pathParameter.txt").Split(',');

            try
            {
                if (args[0] == "Weixen")
                {
                    //呼叫下載資料的class
                    DownloadData dt = new DownloadData();

                    //StringBuilder query = new StringBuilder();
                    string nonQuery;
                    nonQuery = $"INSERT INTO {pathParameter[0]}.{pathParameter[1]}"
        + "(`ID`,`Player`,`From`,`To`,`Pos`,`Ht`,`Wt`,`Birth Date`,`Colleges`,`Games`,`PTS`,`TRB`,`AST`,`FG%`,`FG3%`,`FT%`,`eFG%`,`PER`,`WS`)"
        + "VALUES";
                    //串出insert的sql語法
                    foreach (var rowData in dt.DownloadAllData())
                    {
                        nonQuery += "(";
                        foreach (var value in rowData.Value.Split(','))
                        {
                            nonQuery += "'" + value + "'" + ",";
                        }
                        nonQuery = nonQuery.Substring(0, nonQuery.Length - 1);
                        nonQuery += "),";
                    }
                    nonQuery = nonQuery.Substring(0, nonQuery.Length - 1);

                    //啟動通知執行結果的主控台程式
                    Process pro = new Process();
                    pro.StartInfo.FileName = @"..\..\..\資料下載器\SendMessage\bin\Debug\SendMessage.exe";

                    //新增入資料庫(MySql)
                    DoMySQL.ConnectToMySql(loginParameter[0], loginParameter[1], loginParameter[2]);
                    DoMySQL.CommandNonQuery(nonQuery.ToString());

                    //刪除載入檔，表示結束下載
                    File.Delete(@"..\..\..\資料下載器\bin\Debug\loading.txt");

                    //計算下載花費時間
                    runTime.Stop();
                    string totalRunTime = $"{runTime.Elapsed.Hours}:{runTime.Elapsed.Minutes}:{runTime.Elapsed.Seconds}";

                    //將引數傳入Sendmessage主控台程式
                    pro.StartInfo.Arguments = $"Success {loginParameter[0]} {pathParameter[0]} {pathParameter[1]} {totalRunTime}";
                    pro.Start();
                }
            }
            catch (Exception)
            {
                //刪除載入檔，表示結束下載
                File.Delete(@"..\..\..\資料下載器\bin\Debug\loading.txt");

                //計算下載花費時間
                runTime.Stop();
                string totalRunTime = $"{runTime.Elapsed.Hours}:{runTime.Elapsed.Minutes}:{runTime.Elapsed.Seconds}";

                //啟動通知執行結果的主控台程式
                Process pro = new Process();
                pro.StartInfo.FileName = @"..\..\..\資料下載器\SendMessage\bin\Debug\SendMessage.exe";

                //將引數傳入Sendmessage主控台程式
                pro.StartInfo.Arguments = $"Fail {loginParameter[0]} {pathParameter[0]} {pathParameter[1]}  {totalRunTime}";
                pro.Start();
            }
        }
    }
}

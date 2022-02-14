using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMessage
{
    /// <summary>
    /// 通知下載結果程式
    /// </summary>
    class SendMessage
    {
        /// <summary>
        /// 主程式進入點
        /// </summary>
        /// <param name="args">接收五個引數:"Success"or"Fail"、server、database、datatable、程式執行時間</param>
        static void Main(string[] args)
        {
            if (args[0] == "Success")
            {
                Console.WriteLine($"下載儲存位置：\nServer:\"{args[1]}\"\nDataBase:\"{args[2]}\"\nDataTable:\"{args[3]}\"" +
                    $"\n\n下載結果：\n成功，請至指定資料庫查看!\n\n花費時間：{args[4]}(hours:minutes:seconds)");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("按下Enter關閉視窗");
                Console.ReadKey();
            } else if(args[0] == "Fail")
            {
                Console.WriteLine($"下載儲存位置：\nServer:\"{args[1]}\"\nDataBase:\"{args[2]}\"\nDataTable\"{args[3]}\"" +
                    $"\n\n下載結果：\n失敗，請重新至下載器下載!\n\n花費時間：{args[4]}(hours:minutes:seconds)");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("按下Enter關閉視窗");
                Console.ReadKey();
            }
            //else if (args[0] == "wrong")
            //{
            //    Console.WriteLine("錯誤地方" + args[1] + args[2]);
            //    Console.ReadKey();
            //}
        }
    }
}

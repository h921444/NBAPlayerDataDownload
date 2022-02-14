using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 下載nba資料
{
    /// <summary>
    /// 存放webrequest參數
    /// </summary>
    class DownLoadParameter
    {
        /// <summary>
        /// 網址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 請求方法
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// 檔案類型
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// post參數
        /// </summary>
        public string PostData { get; set; }

        /// <summary>
        /// UserAgent參數
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// X-Requested-With參數
        /// </summary>
        public string XRequestedWith { get; set; }

        /// <summary>
        /// 輸出編碼
        /// </summary>
        public string OutputEncoding { get; set; }
    }
}

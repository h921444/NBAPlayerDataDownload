using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using MySqlCreateByWeixen;
using System.Diagnostics;

namespace 背景下載nba資料
{
    class DownloadData
    {
        /// <summary>
        /// 下載a~z所有球員的資料
        /// </summary>
        public Dictionary<string, string> DownloadAllData()
        {
            //string wrongletter = "";
            //string playerinformation ="";
            //try
            //{
                // 儲存所有nba球員下載回來的詳細資料
                Dictionary<string, string> AllPlayersData = new Dictionary<string, string>();

                DownLoadParameter dp = new DownLoadParameter
                {
                    Method = "GET",
                    OutputEncoding = "utf-8",
                };

            //將網址裡的參數(26個小寫英文字母)存入串列中
            List<string> urlParam = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            //List<string> urlParam = new List<string> { "m" };

                //每位球員給予流水編號
                int ID = 0;

                foreach (var letter in urlParam)
                {
                    //wrongletter = letter;

                    dp.Url = "https://www.basketball-reference.com/players/" + letter;
                    string content = WebDownLoadStreamReader(dp);

                    //解析該字母裡的player數字
                    string pattern = @"table class.*\n....<caption>(?<playerNum>.*)Players";

                    //存放該字母有多少球員
                    int playerQuantity = 0;
                    foreach (Match m in Regex.Matches(content, pattern))
                    {
                        playerQuantity = Convert.ToInt16(m.Groups["playerNum"].Value);
                    }

                    //如果球員人數不為0才開始解析每個球員的資料，否則就不解析直接跳下一個字母
                    if (playerQuantity != 0)
                    {
                        //eachPlayerPattern:用來正規出此頁面每一位球員資料(即來源頁面球員資料)
                        string eachPlayerPattern = @"(<tr ><th scope=""row"").*";

                        //playerInformationPattern:用來正規出此頁面每一位球員的詳細資料(姓名、身高、出生等等...)
                        string playerInformationPattern = @"(?<=(<a href="")|(.html"">)|(data-stat=""year_min"" >)|(data-stat=""year_max"" >)|(data-stat=""pos"" >)|(\.0"" >)|data-stat=""weight"" >|colleges.fcgi\?college=).*?(?=(.html"")>|(<\/a>)|(<\/td><td class))";

                        //用來存放球員頁面url的參數
                        string clickPlayerUrl = "";

                        //存放每一位球員的基本資料(姓名、身高、出生等等...)
                        string eachPlayerAllInformation;

                        //用來將birthDate資訊後的資訊(即出生日期和就讀的大學)做字串處裡
                        int numb = 0;

                        foreach (Match eachPlayer in Regex.Matches(content, eachPlayerPattern))
                        {
                            //流水號
                            ID++;

                            //清空字串，重新存放新球員的資訊
                            eachPlayerAllInformation = $"{ID},";
                            //if (ID == 279)
                            //{ }

                            //用來註記程式目前抓到該球員的第幾個資料，若mark最後=9則表示所有資料皆無空值
                            int mark = 0;

                            foreach (Match playerInformation in Regex.Matches(eachPlayer.Value, playerInformationPattern))
                            {
                                mark++;
                                string playerData = playerInformation.Value;
                                //if (playerData.Contains("Michigan"))
                                //{ }
                                if (playerData.Length > 9 && playerData.Substring(0, 9) == "/players/")
                                {
                                    clickPlayerUrl = $@"https://www.basketball-reference.com/{playerData}.html";
                                    numb = 0;
                                }
                                else if (playerData.Length > 11 && playerData.Substring(6, 5) == "birth")
                                {
                                    string birthDate = playerData.Split('>')[1].Replace(',', '/');
                                    eachPlayerAllInformation += birthDate + ",";
                                    numb++;
                                }
                                else if (numb == 1 || mark == 8)
                                {
                                    string colleges = playerData.Split('>')[1];
                                    if (mark == 8)
                                    {
                                        //mark=8代表抓不到該球員的生日資料，因此要手動加入空值
                                        eachPlayerAllInformation += "," + colleges + ",";

                                        mark++;
                                    }
                                    else if (mark >= 10)
                                    {
                                        //mark>=10代表該球員就讀的學校有兩間(或以上)且正規表達式抓資料是分至少兩次(或以上)讀進來(ex:球員 Tariq Abdul-Wahad)
                                        eachPlayerAllInformation = eachPlayerAllInformation
                                                                   .Substring(0, eachPlayerAllInformation.Length - 1);
                                        eachPlayerAllInformation += "、" + colleges.Replace("'", "，").Replace(",", "、") + ",";
                                    }
                                    else
                                    {
                                        eachPlayerAllInformation += colleges.Replace("'", "，").Replace(",", "、") + ",";
                                    }
                                }
                                else
                                {
                                    eachPlayerAllInformation += playerData.Replace("'", "，") + ",";
                                }
                            }

                            //若出來迴圈後mark依然=8，則代表抓不到該球員大學資料，因此要手動加入空值
                            if (mark == 8)
                            {
                                eachPlayerAllInformation += ",";
                            }

                            //將該球員的SUMMARY Career 資料存放在該球員的基本資料下方
                            eachPlayerAllInformation += DownloadPlayerCareer(clickPlayerUrl);

                            //刪除最後一個逗號
                            eachPlayerAllInformation = eachPlayerAllInformation.Substring(0, eachPlayerAllInformation.Length - 1);

                            //取出該球員的姓名作為字典的key值，而該球員的所有資料則作為value
                            string playerID = eachPlayerAllInformation.Split(',')[0];
                            //playerinformation = eachPlayerAllInformation;
                            AllPlayersData.Add(playerID, eachPlayerAllInformation.ToString());
                        }
                    }
                }
                return AllPlayersData;
            //}
            //catch (Exception)
            //{
            //    Dictionary<string, string> a = new Dictionary<string, string>();
            //    a.Add("0",wrongletter);
            //    a.Add("1", playerinformation);
            //    Process pro = new Process();
            //    pro.StartInfo.FileName = @"..\..\..\資料下載器\SendMessage\bin\Debug\SendMessage.exe";

            //    //將引數傳入Sendmessage主控台程式
            //    pro.StartInfo.Arguments = $"wrong {wrongletter} {playerinformation}";
            //    pro.Start();
            //    return a;
            //}
        }

        /// <summary>
        /// 下載該球員的Career數據
        /// </summary>
        /// <param name="url">球員網址</param>
        /// <returns></returns>
        private string DownloadPlayerCareer(string url)
        {
            DownLoadParameter dp = new DownLoadParameter
            {
                Url = url,
                Method = "GET",
                OutputEncoding = "utf-8"
            };
            //該位球員的個人資料頁面
            string content = WebDownLoadStreamReader(dp);

            //抓取該位球員summary的資料(因為不一定所有summary都有)
            string summaryPattern = @"(?<=(<h4 class=""poptip"" data-tip=""Games"">)|(<h4 class=""poptip"" data-tip=""Points"">)|(<h4 class=""poptip"" data-tip=""Total Rebounds"">)|(<h4 class=""poptip"" data-tip=""Assists"">)|(<h4 class=""poptip"" data-tip=""Field Goal Percentage"">)|(<h4 class=""poptip"" data-tip=""3-Point Field Goal Percentage"">)|(<h4 class=""poptip"" data-tip=""Free Throw Percentage"">)|(<h4 class=""poptip"" data-tip=""<strong>Effective Field Goal Percentage<\/strong><br>This statistic adjusts for the fact that a 3-point field goal is worth one more point than a 2-point field goal."">)|(<h4 class=""poptip"" data-tip=""<b>Player Efficiency Rating<\/b><br>A measure of per-minute production standardized such that the league average is 15."">)|(<h4 class=""poptip"" data-tip=""<b>Win Shares<\/b><br>An estimate of the number of wins contributed by a player."">)).*?(?=<\/h4><p>)";

            //抓取該位球員career的資料
            string careerPattern = @"(?<=(<p>)).*?(?=<\/p><\/div>)";

            //存取該名球員的summary和career資料並且排版
            StringBuilder eachPlayerCareerData = new StringBuilder();

            //球員最多會有的summary
            List<string> allSummaryList = new List<string>() { "G", "PTS", "TRB", "AST", "FG%", "FG3%", "FT%", "eFG%", "PER", "WS" };

            //實際上該球員有的summary(tempSummary為暫時存放的sumary)
            List<string> eachPlayerSummaryList = new List<string>();
            List<string> tempSummary = new List<string>();
            foreach (Match summary in Regex.Matches(content, summaryPattern))
            {
                tempSummary.Add(summary.Value);
            }

            //該球員沒有的summary直接填上空值(xe: G,,PTS,TRB,,FG%...)
            int count = 0;
            for (int i = 0; i < allSummaryList.Count(); i++)
            {
                if (tempSummary[count] == allSummaryList[i])
                {
                    eachPlayerSummaryList.Add(tempSummary[count]);
                    count++;
                }
                else
                {
                    eachPlayerSummaryList.Add("");
                }
            }

            //該球員的career資料
            List<string> tempCareer = new List<string>();
            foreach (Match career in Regex.Matches(content, careerPattern))
            {
                tempCareer.Add(career.Value);
            }

            //該球員沒有的summary其對應到的career資料要填上空值(xe: 256,,3.3,0.3...)
            int count2 = 0;
            for (int i = 0; i < eachPlayerSummaryList.Count(); i++)
            {
                if (eachPlayerSummaryList[i] != "")
                {
                    eachPlayerCareerData.Append(tempCareer[count2] + ",");
                    count2++;
                }
                else
                {
                    eachPlayerCareerData.Append(",");
                }
            }

            return eachPlayerCareerData.ToString();
        }

        /// <summary>
        /// 傳入下載網頁需要的參數並將指定的下載網址的資料傳至指定的資料夾中
        /// </summary>
        /// <param name="dp">DownLoadParameter參數</param>
        /// <returns></returns>
        private string WebDownLoadStreamReader(DownLoadParameter dp)
        {
            if (dp.Url != "")
            {
                HttpWebRequest request = HttpWebRequest.Create(dp.Url) as HttpWebRequest;
                request.Method = dp.Method;
                if (dp.UserAgent != null)
                {
                    request.UserAgent = dp.UserAgent;
                }

                if (dp.PostData != null)
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(dp.PostData);
                    request.ContentLength = byteArray.Length;
                    request.ContentType = "application/x-www-form-urlencoded";

                    //如果存在X-Requested-With參數則填入
                    if (dp.XRequestedWith != null)
                    {
                        request.Headers.Add("X-Requested-With", dp.XRequestedWith);
                    }

                    using (Stream reqStream = request.GetRequestStream())
                    {
                        reqStream.Write(byteArray, 0, byteArray.Length);
                    }
                }
                using (WebResponse httpResponse = (HttpWebResponse)request.GetResponse())
                {
                    //讀取檔案並編碼
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream(), Encoding.GetEncoding(dp.OutputEncoding)))
                    {
                        //將結果讀出
                        string result = streamReader.ReadToEnd();

                        return result;
                    }
                }
            }
            return string.Empty;
        }
    }
}

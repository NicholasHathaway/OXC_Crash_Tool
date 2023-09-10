using I_Support_KKK;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Vulkan.Win32;
using static System.Net.WebRequestMethods;

namespace OXC_Image_Crash
{
    public class API
    {
        public static void FriendRequest(string Token, string userid)
        {
            try
            {
                if (!userid.Contains("usr_")) return;
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create($"https://api.vrchat.cloud/api/1/user/{userid}/friendRequest?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26");
                webRequest.ContentType = "application/json";
                webRequest.Method = "POST";
                webRequest.UserAgent = "Mozilla/5.0";
                webRequest.Host = "api.vrchat.cloud";
                webRequest.Headers["Cookie"] = $"auth={Token}; apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26; twoFactorAuth=";
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                StreamReader webSource = new StreamReader(webResponse.GetResponseStream());
                if(webResponse.StatusCode == HttpStatusCode.OK)
                {
                    if(GUI_Renderer.logsuccess)
                    {
                        
                    }
                }
                else
                {
                    ConsoleHandler.LogError($"Failed to Crash Try Again Later!");
                }
                webSource.ReadToEnd();
                webResponse.Close();
            }
            catch
            {

            }
        }
        public static void Unfriend(string Token, string userid)
        {
            try
            {
                if (!userid.Contains("usr_")) return;
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create($"https://vrchat.com/api/1/auth/user/friends/{userid}?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26");
                webRequest.ContentType = "application/json";
                webRequest.Method = "DELETE";
                webRequest.UserAgent = "Mozilla/5.0";
                webRequest.Host = "api.vrchat.cloud";
                webRequest.Headers["Cookie"] = $"auth={Token}; apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26; twoFactorAuth=";
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                StreamReader webSource = new StreamReader(webResponse.GetResponseStream());
                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    if (GUI_Renderer.logsuccess)
                    {
                        
                    }
                }
                else
                {
                }
                webSource.ReadToEnd();
                webResponse.Close();
            }
            catch
            {

            }
        }
        public static void CancelFriendRequest(string Token, string userid)
        {
            try
            {
                if (!userid.Contains("usr_")) return;
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create($"https://vrchat.com/api/1/user/{userid}/friendRequest?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26");
                webRequest.ContentType = "application/json";
                webRequest.Method = "DELETE";
                webRequest.UserAgent = "Mozilla/5.0";
                webRequest.Host = "api.vrchat.cloud";
                webRequest.Headers["Cookie"] = $"auth={Token}; apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26; twoFactorAuth=";
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                StreamReader webSource = new StreamReader(webResponse.GetResponseStream());
                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    if (GUI_Renderer.logsuccess)
                    {

                    }
                }
                else
                {
                }
                webSource.ReadToEnd();
                webResponse.Close();
            }
            catch
            {

            }
        }
        public static string ValidateAuthcookie(string auth)
        {
            string URL = $"https://api.vrchat.cloud/api/1/auth?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26";
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URL);

            Uri target = new Uri("https://www.vrchat.com");

            Request.Headers.Clear();
            Request.Method = "GET";
            Request.Headers.Add("Cookie", $"apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26; auth={auth}");
            Request.Headers.Add("Host", "api.vrchat.cloud");
            Request.UserAgent = "Mozilla/5.0";
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    HttpWebResponse webResponse = (HttpWebResponse)Request.GetResponse();
                    if (webResponse.StatusCode == HttpStatusCode.OK || webResponse.StatusCode == HttpStatusCode.Accepted || webResponse.StatusCode == HttpStatusCode.Created || webResponse.StatusCode == HttpStatusCode.NotModified)
                    {
                        StreamReader webSource = new StreamReader(webResponse.GetResponseStream()); ;
                        string source = webSource.ReadToEnd();
                        webResponse.Close();
                        
                        return source;
                    }
                }
                catch { }
                Thread.Sleep(2500);
            }
            return null;
        }
        public static string GetUsers()
        {
            string URL = $"https://api.vrchat.cloud/api/1/visits";
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URL);
            Request.Method = "GET";
            Request.Headers["User-Agent"] = $"Mozilla/5.0";
            Request.UserAgent = "Mozilla/5.0";
            try
            {
                HttpWebResponse webResponse = (HttpWebResponse)Request.GetResponse();
                if (webResponse.StatusCode == HttpStatusCode.OK || webResponse.StatusCode == HttpStatusCode.Accepted || webResponse.StatusCode == HttpStatusCode.Created || webResponse.StatusCode == HttpStatusCode.NotModified)
                {
                    StreamReader webSource = new StreamReader(webResponse.GetResponseStream()); ;
                    string source = webSource.ReadToEnd();
                    webResponse.Close();
                    return source;
                }
            }
            catch { }
            return "";
        }
        public static void SetAvatar(BotClient botClient, string ID)
        {
            if (!ID.Contains("avtr_")) return;
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create($"https://api.vrchat.cloud/api/1/avatars/{ID}/select?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26&organization=vrchat");
            Request.Host = "api.vrchat.cloud";
            Request.Headers["Cookie"] = $"auth={botClient._token}; apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26; twoFactorAuth=";
            Request.Method = "PUT";
            Request.UserAgent = "Mozilla/5.0";
            HttpWebResponse webResponse = (HttpWebResponse)Request.GetResponse();
            StreamReader webSource = new StreamReader(webResponse.GetResponseStream());
            webSource.ReadToEnd();
            webResponse.Close();
        }
        public static void SetStatus(BotClient botClient, string Status)
        {
            string apiUrl = $"https://api.vrchat.cloud/api/1/users/{botClient._userid}";

            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(apiUrl);
            Request.Host = "api.vrchat.cloud";
            Request.Headers["Cookie"] = $"auth={botClient._token}; apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26; twoFactorAuth=";
            Request.Method = "PUT";
            Request.UserAgent = "Mozilla/5.0";

            string jsonPayload = $"{{\"statusDescription\":\"{Status}\"}}";
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonPayload);
            Request.ContentLength = byteArray.Length;

            using (Stream dataStream = Request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            HttpWebResponse webResponse = (HttpWebResponse)Request.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseContent = reader.ReadToEnd();
            webResponse.Close();
        }
        public static void SetBio(BotClient botClient, string Bio)
        {
            string apiUrl = $"https://api.vrchat.cloud/api/1/users/{botClient._userid}";

            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(apiUrl);
            Request.UserAgent = "Mozilla/5.0";
            Request.Host = "api.vrchat.cloud";
            Request.Headers["Cookie"] = $"auth={botClient._token}; apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26; twoFactorAuth=";
            Request.Method = "PUT";

            string jsonPayload = $"{{\"bio\":\"{Bio}\"}}";
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonPayload);
            Request.ContentLength = byteArray.Length;

            using (Stream dataStream = Request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            HttpWebResponse webResponse = (HttpWebResponse)Request.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseContent = reader.ReadToEnd();
            webResponse.Close();
        }

        public static string GetUserInfo(string token)
        {
            string URL = $"https://vrchat.com/api/1/auth/user";
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URL);
            Request.UserAgent = "Mozilla/5.0";
            Request.Host = "api.vrchat.cloud";
            Request.Headers["Cookie"] = $"auth={token}; apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26; twoFactorAuth=";
            Request.Method = "GET";
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    HttpWebResponse webResponse = (HttpWebResponse)Request.GetResponse();
                    if (webResponse.StatusCode == HttpStatusCode.OK || webResponse.StatusCode == HttpStatusCode.Accepted || webResponse.StatusCode == HttpStatusCode.Created || webResponse.StatusCode == HttpStatusCode.NotModified)
                    {
                        StreamReader webSource = new StreamReader(webResponse.GetResponseStream()); ;
                        string source = webSource.ReadToEnd();
                        webResponse.Close();
                        return source;
                    }
                }
                catch { }
                Thread.Sleep(2500);
            }
            return null;
        }

        public static string GetUserId(string token)
        {
            string userid;
            string userinfo = GetUserInfo(token);
            if (userinfo != null)
            {
                userid = JsonConvert.DeserializeObject<UserInfo>(userinfo).id;
                return userid;
            }
            else
            {
                return "N/A";
            }
        }
        public static string GetUserName(string token)
        {
            string displayName;
            string userinfo = GetUserInfo(token);
            if (userinfo != null)
            {
                displayName = JsonConvert.DeserializeObject<UserInfo>(userinfo).displayName;
                return displayName;
            }
            else
            {
                return "N/A";
            }
        }
    }
    public class UserInfo
    {
        public string id { get; set; }
        public string displayName { get; set; }
    }
}

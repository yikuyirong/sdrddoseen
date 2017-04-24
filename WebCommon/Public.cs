using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI.WebControls;
using WebDAL;
using WebModels;
using Yahoo.Yui.Compressor;

namespace WebCommon
{
    public class Public
    {
        public static string Get_BlankFilePath = "/inc/blank.dwg";

        public static string Get_BlankFileMapPath = HttpContext.Current.Server.MapPath(Public.Get_BlankFilePath);

        private static string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        private static Random objRndStatic = new Random();

        public static int DataTableAdd(string Table, string[] Data)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string text = "insert into {0} ({1}) values ({2})";
            string text2 = "";
            for (int i = 0; i < Data.Length; i++)
            {
                text2 = text2 + Data[i] + ",";
            }
            if (text2 != "")
            {
                text2 = text2.Substring(0, text2.Length - 1);
            }
            string text3 = "";
            for (int i = 0; i < Data.Length; i++)
            {
                text3 = text3 + "'" + HttpContext.Current.Request.Form[Data[i]].ToString() + "',";
            }
            if (text3 != "")
            {
                text3 = text3.Substring(0, text3.Length - 1);
            }
            text = string.Format(text, Table, text2, text3);
            int result = 0;
            if (DBHelper.ExecuteNonQuery(connectionString, CommandType.Text, text, new SqlParameter[0]) > 0)
            {
                result = (int)DBHelper.ExecuteScalar(connectionString, CommandType.Text, "select max(id) from " + Table, new SqlParameter[0]);
            }
            return result;
        }

        public static string DataTableEdit(string Table, string[] Data, string Where)
        {
            string result;
            if (Where == "")
            {
                result = "false";
            }
            else
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                string text = "update {0} set {1} where {2}";
                string text2 = "";
                for (int i = 0; i < Data.Length; i++)
                {
                    string text3 = text2;
                    text2 = string.Concat(new string[]
                    {
                        text3,
                        Data[i],
                        "='",
                        HttpContext.Current.Request.Form[Data[i]].ToString(),
                        "',"
                    });
                }
                if (text2 != "")
                {
                    text2 = text2.Substring(0, text2.Length - 1);
                }
                text = string.Format(text, Table, text2, Where);
                if (DBHelper.ExecuteNonQuery(connectionString, CommandType.Text, text, new SqlParameter[0]) > 0)
                {
                    result = "true";
                }
                else
                {
                    result = "false";
                }
            }
            return result;
        }

        public static bool DataTableUpdate(string Table, string SetValues, string Where)
        {
            bool result;
            if (Where == "")
            {
                result = false;
            }
            else
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                string text = "update {0} set {1} where {2}";
                text = string.Format(text, Table, SetValues, Where);
                result = (DBHelper.ExecuteNonQuery(connectionString, CommandType.Text, text, new SqlParameter[0]) > 0);
            }
            return result;
        }

        public static int DataTableDel(string Table, string Where)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string text = "update " + Table + " set [DealFlag]=1 where " + Where;
            return DBHelper.ExecuteNonQuery(connectionString, CommandType.Text, text, new SqlParameter[0]);
        }

        public static int DataTableDel(string Table, string Where, bool delete)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string text = "delete from " + Table + " where " + Where;
            return DBHelper.ExecuteNonQuery(connectionString, CommandType.Text, text, new SqlParameter[0]);
        }

        public static DataTable DataTableGet(string Table, int PageSize, int PageIndex, string Where, string Order)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string text = "select count(*) from " + Table + " where DealFlag=0 and [DealFlag]=0";
            if (Where != "")
            {
                text = text + " and (" + Where + ")";
            }
            text = string.Concat(new string[]
            {
                "select *,",
                ((int)DBHelper.ExecuteScalar(connectionString, CommandType.Text, text, new SqlParameter[0])).ToString(),
                " as RecordNum from ",
                Table,
                " where DealFlag=0 and [DealFlag]=0"
            });
            if (Where != "")
            {
                text = text + " and (" + Where + ")";
            }
            if (Order != "")
            {
                text = text + " order by " + Order;
            }
            int num = PageSize * (PageIndex - 1);
            return DBHelper.ExecuteDataTablePage(connectionString, CommandType.Text, text, num, PageSize, new SqlParameter[0]);
        }

        public static DataTable DataTableGetBySql(string Sql, int PageSize, int PageIndex)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Sql = Sql.Trim().ToLower();
            string text = "select count(*) " + Sql.Substring(Sql.LastIndexOf("from"));
            text = text.Substring(0, text.LastIndexOf("order"));
            int num = (int)DBHelper.ExecuteScalar(connectionString, CommandType.Text, text, new SqlParameter[0]);
            int num2 = PageSize * (PageIndex - 1);
            return DBHelper.ExecuteDataTablePage(connectionString, CommandType.Text, Sql, num2, PageSize, new SqlParameter[0]);
        }

        public static string DataTableFieldGet(string Table, string Field, string Where)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string text = string.Concat(new string[]
            {
                "select ",
                Field,
                " from ",
                Table,
                " where DealFlag=0 and [DealFlag]=0"
            });
            if (Where != "")
            {
                text = text + " and " + Where;
            }
            return Public.ToString(DBHelper.ExecuteScalar(connectionString, CommandType.Text, text, new SqlParameter[0]));
        }

        public static DataTable GetDataTableByPage(int PageSize, int PageIndex, string Sql, string Order)
        {
            Sql = "select * from (" + Sql + ") as tbl";
            if (Order != "")
            {
                Sql = Sql + " order by " + Order;
            }
            int num = PageSize * (PageIndex - 1);
            return DBHelper.ExecuteDataTablePage(Public.connection, CommandType.Text, Sql, num, PageSize, new SqlParameter[0]);
        }

        public static DataTable GetDataTableByPage2(int PageSize, int PageIndex, string Sql, string Order)
        {
            if (Order != "")
            {
                Sql = Sql + " order by " + Order;
            }
            int num = PageSize * (PageIndex - 1);
            return DBHelper.ExecuteDataTablePage(Public.connection, CommandType.Text, Sql, num, PageSize, new SqlParameter[0]);
        }

        public static int GetDataTableByCount(string sql)
        {
            sql = "select count(*) from (" + sql + ") as tbl";
            return (int)DBHelper.ExecuteScalar(Public.connection, CommandType.Text, sql, new SqlParameter[0]);
        }

        public static string GetUserName()
        {
            string result;
            try
            {
                result = Public.ToString(HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies["UserName"].Value));
            }
            catch
            {
                result = "";
            }
            return result;
        }

        public static string GetUserLimit()
        {
            string result;
            try
            {
                if (HttpContext.Current.Request.Cookies["UserLimit"] != null && HttpContext.Current.Request.Cookies["UserLimitUser"] != null)
                {
                    string a = Public.ToString(HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies["UserLimitUser"].Value));
                    string text = Public.ToString(HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies["UserLimit"].Value));
                    if (text != "" && a == Public.GetUserName())
                    {
                        result = text;
                        return result;
                    }
                }
                string text2 = Public.DataTableGet("tbl_limit", 1, 1, "limitname=(select top 1 limitid from tbl_user where username='" + Public.GetUserName() + "')", "").Rows[0]["limitinfo"].ToString();
                HttpCookie httpCookie = new HttpCookie("UserLimit", HttpUtility.UrlEncode(text2));
                httpCookie.Expires = DateTime.Now.AddDays(15.0);
                HttpContext.Current.Response.Cookies.Remove("UserLimit");
                HttpContext.Current.Response.Cookies.Add(httpCookie);
                HttpCookie httpCookie2 = new HttpCookie("UserLimitUser", HttpUtility.UrlEncode(Public.GetUserName()));
                httpCookie2.Expires = DateTime.Now.AddDays(15.0);
                HttpContext.Current.Response.Cookies.Remove("UserLimitUser");
                HttpContext.Current.Response.Cookies.Add(httpCookie2);
                result = text2;
            }
            catch
            {
                result = "";
            }
            return result;
        }

        public static string ListBoxValuesGet(ListBox listbox)
        {
            string text = "";
            foreach (ListItem listItem in listbox.Items)
            {
                if (listItem.Selected)
                {
                    text = text + "," + listItem.Value;
                }
            }
            if (text.StartsWith(","))
            {
                text = text.Remove(0, 1);
            }
            return text;
        }

        public static void ListBoxValuesSet(ListBox listbox, string values)
        {
            foreach (ListItem listItem in listbox.Items)
            {
                if (("," + values).Contains("," + listItem.Value))
                {
                    values = values.Replace(listItem.Value, "");
                    listItem.Selected = true;
                }
            }
        }

        public static string UploadFile(HttpPostedFile FileUpload, string SaveFolder, string SaveName, int FileMaxSize, int CutWidth, int CutHeight, bool havePath)
        {
            string fileName = FileUpload.FileName;
            string folderName = "/upload/" + SaveFolder;
            string result;
            if (fileName == "")
            {
                result = "";
            }
            else
            {
                string text2 = HttpContext.Current.Server.MapPath("~" + folderName);
                int num = FileUpload.ContentLength / 1024;
                string text3 = fileName.Substring(fileName.LastIndexOf("."));
                string text4 = ".jpg|.jpeg|.gif|.bmp|.png|.doc|.docx|.xls|.xlsx|.pdf|.rar|.dxf|.dwg|.txt|.rar";
                string text5 = "";
                bool flag = true;
                try
                {
                    string[] array = text4.ToLower().Split(new char[]
                    {
                        '|'
                    });
                    bool flag2 = false;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] == text3)
                        {
                            flag2 = true;
                        }
                    }
                    if (!flag2)
                    {
                        flag = false;
                        Script.AlertAndGoBack("文件格式上传不被许可");
                    }
                    if (num > FileMaxSize)
                    {
                        int num2 = num - FileMaxSize;
                        flag = false;
                        Script.AlertAndGoBack("文件大小超出了" + num2.ToString() + "KB");
                    }
                    if (flag)
                    {
                        if (text2.Contains(text3))
                        {
                            string path = text2.Substring(0, text2.LastIndexOf("\\"));
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            FileUpload.SaveAs(text2);
                            result = SaveFolder;
                            return result;
                        }
                        if (!Directory.Exists(text2))
                        {
                            Directory.CreateDirectory(text2);
                        }
                        text5 = DateTime.Now.Ticks.ToString() + text3;
                        FileUpload.SaveAs(text2 + "/" + text5);
                        if (CutWidth > 0 && CutHeight > 0)
                        {
                            string str = DateTime.Now.Ticks.ToString() + text3;
                            string text6 = Public.CutPic(folderName + "/" + text5, folderName + "/" + str, CutWidth, CutHeight, 90);
                            File.Delete(HttpContext.Current.Server.MapPath(folderName + "/" + text5));
                            result = text6;
                            return result;
                        }
                    }
                    if (havePath)
                    {
                        result = folderName + "/" + text5;
                    }
                    else
                    {
                        result = text5;
                    }
                }
                catch (Exception e)
                {
                    Script.AlertAndGoBack("上传文件发生错误");
                    result = "";
                }
            }
            return result;
        }

        public static string UploadFile(HttpPostedFile FileUpload, string SaveFolder, string SaveName, int FileMaxSize, bool havePath)
        {
            return Public.UploadFile(FileUpload, SaveFolder, SaveName, FileMaxSize, 0, 0, havePath);
        }

        public static string UploadFile(FileUpload FileUploadCtrl, string SaveFolder, int FileSize)
        {
            return Public.UploadFile(FileUploadCtrl.PostedFile, SaveFolder, "", FileSize, true);
        }

        public static string UploadFile(FileUpload FileUploadCtrl, string SaveFolder)
        {
            return Public.UploadFile(FileUploadCtrl.PostedFile, SaveFolder, "", 100000000, true);
        }

        public static string UploadFile(FileUpload FileUploadCtrl, string SaveFolder, string SaveName)
        {
            return Public.UploadFile(FileUploadCtrl.PostedFile, SaveFolder, SaveName, 100000000, true);
        }

        public static string UploadFile(FileUpload FileUploadCtrl, string SaveFolder, int CutWidth, int CutHeight)
        {
            return Public.UploadFile(FileUploadCtrl.PostedFile, SaveFolder, "", 100000000, CutWidth, CutHeight, true);
        }

        public static string CutPic(string fromFile, string toFile, int maxWidth, int maxHeight, int quality)
        {
            string result = toFile;
            fromFile = HttpContext.Current.Server.MapPath(fromFile);
            toFile = HttpContext.Current.Server.MapPath(toFile);
            System.Drawing.Image image = System.Drawing.Image.FromFile(fromFile);
            if (image.Width <= maxWidth && image.Height <= maxHeight)
            {
                image.Save(toFile, ImageFormat.Jpeg);
            }
            else
            {
                double num = (double)maxWidth / (double)maxHeight;
                double num2 = (double)image.Width / (double)image.Height;
                if (num == num2)
                {
                    System.Drawing.Image image2 = new Bitmap(maxWidth, maxHeight);
                    Graphics graphics = Graphics.FromImage(image2);
                    graphics.DrawImage(image, new Rectangle(0, 0, maxWidth, maxHeight), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
                    image2.Save(toFile, ImageFormat.Jpeg);
                }
                else
                {
                    Rectangle srcRect = new Rectangle(0, 0, 0, 0);
                    Rectangle destRect = new Rectangle(0, 0, 0, 0);
                    System.Drawing.Image image3;
                    Graphics graphics2;
                    if (num > num2)
                    {
                        image3 = new Bitmap(image.Width, (int)Math.Floor((double)image.Width / num));
                        graphics2 = Graphics.FromImage(image3);
                        srcRect.X = 0;
                        srcRect.Y = (int)Math.Floor(((double)image.Height - (double)image.Width / num) / 2.0);
                        srcRect.Width = image.Width;
                        srcRect.Height = (int)Math.Floor((double)image.Width / num);
                        destRect.X = 0;
                        destRect.Y = 0;
                        destRect.Width = image.Width;
                        destRect.Height = (int)Math.Floor((double)image.Width / num);
                    }
                    else
                    {
                        image3 = new Bitmap((int)Math.Floor((double)image.Height * num), image.Height);
                        graphics2 = Graphics.FromImage(image3);
                        srcRect.X = (int)Math.Floor(((double)image.Width - (double)image.Height * num) / 2.0);
                        srcRect.Y = 0;
                        srcRect.Width = (int)Math.Floor((double)image.Height * num);
                        srcRect.Height = image.Height;
                        destRect.X = 0;
                        destRect.Y = 0;
                        destRect.Width = (int)Math.Floor((double)image.Height * num);
                        destRect.Height = image.Height;
                    }
                    graphics2.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics2.SmoothingMode = SmoothingMode.HighQuality;
                    graphics2.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
                    System.Drawing.Image image2 = new Bitmap(maxWidth, maxHeight);
                    Graphics graphics = Graphics.FromImage(image2);
                    graphics.DrawImage(image3, new Rectangle(0, 0, maxWidth, maxHeight), new Rectangle(0, 0, image3.Width, image3.Height), GraphicsUnit.Pixel);
                    ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
                    ImageCodecInfo encoder = null;
                    ImageCodecInfo[] array = imageEncoders;
                    for (int i = 0; i < array.Length; i++)
                    {
                        ImageCodecInfo imageCodecInfo = array[i];
                        if (imageCodecInfo.MimeType == "image/jpeg")
                        {
                            encoder = imageCodecInfo;
                            break;
                        }
                    }
                    EncoderParameters encoderParameters = new EncoderParameters(1);
                    encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);
                    image2.Save(toFile, encoder, encoderParameters);
                    graphics.Dispose();
                    image2.Dispose();
                    graphics2.Dispose();
                    image3.Dispose();
                }
            }
            image.Dispose();
            return result;
        }

        public static string CutStr(string strSrc, int intLen)
        {
            return Public.CutStr(strSrc, intLen, "...");
        }

        public static string CutStr(string strSrc, int intLen, string strEnd)
        {
            string text = string.Copy(strSrc);
            text = Public.RemoveHTML(text, true);
            text = HttpContext.Current.Server.HtmlDecode(text);
            text = text.Replace(" ", "");
            int num = intLen * 2;
            string result;
            if (Encoding.Default.GetBytes(text).Length <= num)
            {
                result = text;
            }
            else
            {
                num -= Encoding.Default.GetBytes(strEnd).Length;
                int i = 0;
                int length = text.Length;
                while (i < length)
                {
                    if (Encoding.Default.GetBytes(text.Substring(0, i + 1)).Length > num)
                    {
                        text = text.Substring(0, i) + strEnd;
                        break;
                    }
                    i++;
                }
                text = HttpContext.Current.Server.HtmlEncode(text);
                result = text;
            }
            return result;
        }

        public static string CutStr(string str, string str1, string str2)
        {
            int num = str.IndexOf(str1);
            string text = str.Substring(num + str1.Length, str.Length - num - str1.Length);
            if (text.IndexOf(str2) > 0)
            {
                text = text.Remove(text.IndexOf(str2));
            }
            return text;
        }

        public static string RemoveHTML(string strSrc)
        {
            return Public.RemoveHTML(strSrc, false);
        }

        public static string RemoveHTML(string strSrc, bool clearBR)
        {
            string input = string.Copy(strSrc);
            string text = "<[^>]*>";
            text += (clearBR ? "|[\r\n]" : "");
            return Regex.Replace(input, text, "", RegexOptions.IgnoreCase);
        }

        public static string GetMD5(string str)
        {
            string result;
            if (str == "")
            {
                result = "";
            }
            else
            {
                string text = "";
                try
                {
                    text = FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
                }
                catch
                {
                    text = "";
                }
                result = text;
            }
            return result;
        }

        public static string GetFromUrl()
        {
            string text = Public.ToString(HttpContext.Current.Request.UrlReferrer);
            string text2 = Public.ToString(HttpContext.Current.Request["ref"]);
            return (text.Length < 3) ? ((text2.Length < 3) ? "/" : text2) : text;
        }

        public static int GetRnd(int minValue, int maxValue)
        {
            return Public.objRndStatic.Next(minValue, maxValue + 1);
        }

        public static int GetRnd()
        {
            return Public.GetRnd(0, 9);
        }

        public static string GetRndStr(string strs, int strLen)
        {
            string newValue = "0123456789";
            string newValue2 = "abcdefghijklmnopqrstuvwxyz";
            string newValue3 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string text = string.Copy(strs);
            text = text.Replace("$0", newValue).Replace("$a", newValue2).Replace("$A", newValue3);
            StringBuilder stringBuilder = new StringBuilder();
            int i = 0;
            int length = text.Length;
            while (i < strLen)
            {
                stringBuilder.Append(text.Substring(Public.GetRnd(1, length) - 1, 1));
                i++;
            }
            return stringBuilder.ToString();
        }

        public static string GetRndStr()
        {
            return Public.GetRndStr("$a$A", 1);
        }

        public static string GetOrderStr()
        {
            return DateTime.Now.ToString("yyyyMMddhhmmss") + Public.GetRndStr("$a$A$0", 5);
        }

        public static string GetHtml(string urlstr)
        {
            string result = "";
            try
            {
                WebRequest webRequest = WebRequest.Create(urlstr);
                webRequest.Timeout = 15000;
                WebResponse response = webRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GB2312"));
                result = streamReader.ReadToEnd();
            }
            catch
            {
                result = "";
            }
            return result;
        }

        public static string UrlEncode(string str)
        {
            StringBuilder stringBuilder = new StringBuilder();
            byte[] bytes = Encoding.Default.GetBytes(str);
            for (int i = 0; i < bytes.Length; i++)
            {
                stringBuilder.Append("%" + Convert.ToString(bytes[i], 16));
            }
            return stringBuilder.ToString();
        }

        public static bool SendMail(string MailTo, string strTitle, string strBody, bool isHTML)
        {
            string applicationPath = HttpContext.Current.Request.ApplicationPath;
            Configuration configuration = WebConfigurationManager.OpenWebConfiguration(applicationPath);
            SmtpSection smtpSection = (SmtpSection)configuration.GetSection("system.net/mailSettings/smtp");
            string text = smtpSection.Network.Host + ":" + smtpSection.Network.Port;
            bool result;
            if (text == null)
            {
                result = false;
            }
            else
            {
                string userName = smtpSection.Network.UserName;
                if (userName == null)
                {
                    result = false;
                }
                else
                {
                    string password = smtpSection.Network.Password;
                    if (password == null)
                    {
                        result = false;
                    }
                    else
                    {
                        string text2 = "";
                        if (text2 == null)
                        {
                            result = false;
                        }
                        else
                        {
                            string from = smtpSection.From;
                            result = (from != null && Public.SendMail(text, userName, password, text2, from, MailTo, strTitle, strBody, isHTML));
                        }
                    }
                }
            }
            return result;
        }

        public static bool SendMail(string smtpHost, string UserName, string UserPass, string MailName, string MailFrom, string MailTo, string strTitle, string strBody, bool isHTML)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(MailFrom, MailName);
            mailMessage.To.Add(MailTo);
            mailMessage.Subject = strTitle;
            mailMessage.IsBodyHtml = isHTML;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.Body = strBody;
            string[] array = smtpHost.Split(new char[]
            {
                ':'
            });
            string host = string.Copy(smtpHost);
            int port = 25;
            if (array.Length >= 2)
            {
                host = Public.ToString(array[0].ToString());
                port = Public.ToInt(array[1].ToString());
            }
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = host;
            smtpClient.Port = port;
            smtpClient.Credentials = new NetworkCredential(UserName, UserPass);
            bool result;
            try
            {
                smtpClient.Send(mailMessage);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static string ToString(object v)
        {
            string text = "";
            try
            {
                text = Convert.ToString(v);
                if (text == null)
                {
                    text = "";
                }
            }
            catch
            {
                text = "";
            }
            return text;
        }

        public static string ToString(int v)
        {
            return Public.ToString(v);
        }

        public static int ToInt(object v)
        {
            int result = 0;
            try
            {
                result = Convert.ToInt32(v);
            }
            catch
            {
                result = 0;
            }
            return result;
        }

        public static int ToInt(string v)
        {
            return Public.ToInt(v);
        }

        public static string DataTableToJson(DataTable dt)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            ArrayList arrayList = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                foreach (DataColumn dataColumn in dt.Columns)
                {
                    dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName].ToString());
                }
                arrayList.Add(dictionary);
            }
            return javaScriptSerializer.Serialize(arrayList);
        }

        public static DataTable JsonToDataTable(string json)
        {
            DataTable dataTable = new DataTable();
            DataTable result;
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
                if (arrayList.Count > 0)
                {
                    foreach (Dictionary<string, object> dictionary in arrayList)
                    {
                        if (dictionary.Keys.Count == 0)
                        {
                            result = dataTable;
                            return result;
                        }
                        if (dataTable.Columns.Count == 0)
                        {
                            foreach (string current in dictionary.Keys)
                            {
                                dataTable.Columns.Add(current, dictionary[current].GetType());
                            }
                        }
                        DataRow dataRow = dataTable.NewRow();
                        foreach (string current in dictionary.Keys)
                        {
                            dataRow[current] = dictionary[current];
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
            }
            catch
            {
                result = dataTable;
                return result;
            }
            result = dataTable;
            return result;
        }

        public static string EnCode(string Text)
        {
            return Public.EnCode(Text, "DoSeenSoft");
        }

        public static string EnCode(string Text, string sKey)
        {
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(Text);
            dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            StringBuilder stringBuilder = new StringBuilder();
            byte[] array = memoryStream.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                byte b = array[i];
                stringBuilder.AppendFormat("{0:X2}", b);
            }
            return stringBuilder.ToString();
        }

        public static string DeCode(string Text)
        {
            return Public.DeCode(Text, "DoSeenSoft");
        }

        public static string DeCode(string Text, string sKey)
        {
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            int num = Text.Length / 2;
            byte[] array = new byte[num];
            for (int i = 0; i < num; i++)
            {
                int num2 = Convert.ToInt32(Text.Substring(i * 2, 2), 16);
                array[i] = (byte)num2;
            }
            dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(array, 0, array.Length);
            cryptoStream.FlushFinalBlock();
            return Encoding.Default.GetString(memoryStream.ToArray());
        }

        public static void Compressor(string ReadPath, string SavePath, string Filter)
        {
            string[] files = Directory.GetFiles(HttpContext.Current.Server.MapPath(ReadPath), Filter);
            string[] array = files;
            for (int i = 0; i < array.Length; i++)
            {
                string text = array[i];
                FileInfo fileInfo = new FileInfo(text);
                string text2 = File.ReadAllText(text, Encoding.UTF8);
                if (!text.Contains(".min."))
                {
                    File.SetAttributes(text, FileAttributes.Normal);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(SavePath)))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(SavePath));
                    }
                    if (fileInfo.Extension.ToLower() == ".js")
                    {
                        JavaScriptCompressor javaScriptCompressor = new JavaScriptCompressor();
                        javaScriptCompressor.CompressionType = 0;
                        javaScriptCompressor.Encoding = Encoding.UTF8;
                        javaScriptCompressor.IgnoreEval = false;
                        javaScriptCompressor.ThreadCulture = CultureInfo.CurrentCulture;
                        text2 = javaScriptCompressor.Compress(text2);
                        File.WriteAllText(HttpContext.Current.Server.MapPath(SavePath) + "/" + fileInfo.Name, text2, Encoding.UTF8);
                    }
                    else if (fileInfo.Extension.ToLower() == ".css")
                    {
                        CssCompressor cssCompressor = new CssCompressor();
                        text2 = cssCompressor.Compress(text2);
                        File.WriteAllText(HttpContext.Current.Server.MapPath(SavePath) + "/" + fileInfo.Name, text2, Encoding.UTF8);
                    }
                }
            }
        }

        public static void WriteLog(string str)
        {
            try
            {
                Tbl_Log tbl_Log = new Tbl_Log();
                tbl_Log.LogInfo = str;
                tbl_Log.DealUser = Public.GetUserName();
                new Tbl_LogService().AddTbl_Log(tbl_Log);
            }
            catch
            {
            }
        }

        public static void WriteErrLog(Exception ex)
        {
            try
            {
                string text = HttpContext.Current.Server.MapPath("Log");
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                string path = text + "\\" + DateTime.Now.Date.ToString("yyyy-MM-dd") + ".txt";
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("时间:" + DateTime.Now.ToString() + "\r\n");
                stringBuilder.Append("错误消息:" + ex.Message + "\r\n");
                stringBuilder.Append("详细内容:" + ex.StackTrace + "\r\n");
                stringBuilder.Append("---------------------------------------------------------------------------------------------\r\n");
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    streamWriter.Write(stringBuilder);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            catch
            {
            }
        }

        public static void WriteAlert(string user, string title, string info, string url)
        {
            Tbl_Alert tbl_Alert = new Tbl_Alert();
            tbl_Alert.UserName = user;
            tbl_Alert.AlertMode = "0";
            tbl_Alert.AlertType = "消息";
            tbl_Alert.AlertTitle = title;
            tbl_Alert.AlertInfo = info;
            tbl_Alert.AlertUrl = url;
            tbl_Alert.Status = "未读";
            new Tbl_AlertService().AddTbl_Alert(tbl_Alert);
        }

        public static string ExcuteSql(string Sql)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return Public.ToString(DBHelper.ExecuteScalar(connectionString, CommandType.Text, Sql, new SqlParameter[0]));
        }

        public static string ToExcel(DataTable table, string file, string filter)
        {
            string text = "";
            filter = filter.ToLower();
            string text2 = "/upload/" + file;
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(text2.Remove(text2.LastIndexOf('/')))))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(text2.Remove(text2.LastIndexOf('/'))));
            }
            string path = HttpContext.Current.Server.MapPath("~" + text2);
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(new BufferedStream(fileStream), Encoding.Default);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                string text3 = table.Columns[i].ColumnName.ToLower();
                if (filter.Contains(text3))
                {
                    text = text + text3 + "\t";
                    text = text.Replace(text3, Public.CutStr(filter, text3 + ":", ","));
                }
            }
            text = text.Substring(0, text.Length - 1) + "\n";
            streamWriter.Write(text);
            foreach (DataRow dataRow in table.Rows)
            {
                string text4 = "";
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    if (filter.ToLower().Contains(table.Columns[i].ColumnName.ToLower()))
                    {
                        text4 = text4 + dataRow[i].ToString().Trim() + "\t";
                    }
                }
                text4 = text4.Substring(0, text4.Length - 1) + "\n";
                streamWriter.Write(text4);
            }
            streamWriter.Close();
            fileStream.Close();
            return text2;
        }
    }
}

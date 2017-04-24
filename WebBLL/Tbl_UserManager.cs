using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
using System.Data;
using System.Web.UI.WebControls;

namespace WebBLL
{

    
    public class Tbl_UserManager
    {
        public static int AddTbl_User(Tbl_User tbl_user)
        {
            WebCommon.Public.WriteLog("��ӻ�Ա��" + tbl_user.UserName);
            return new Tbl_UserService().AddTbl_User(tbl_user);
        }

        public static int UpdateTbl_User(Tbl_User tbl_user)
        {
            WebCommon.Public.WriteLog("�޸Ļ�Ա��" + tbl_user.UserName);
            tbl_user.DealUser = WebCommon.Public.GetUserName();
            tbl_user.DealTime = DateTime.Now;
            return new Tbl_UserService().UpdateTbl_UserById(tbl_user);
        }

        public static int DeleteTbl_User(int ID)
        {
            WebCommon.Public.WriteLog("ɾ����Ա��" + ID.ToString());
            return new Tbl_UserService().DeleteTbl_UserById(ID);
        }

        public static Tbl_User GetTbl_UserById(int ID)
        {
            return new Tbl_UserService().GetTbl_UserById(ID);
        }
        public static IList<Tbl_User> GetTbl_UserByDepartID(string DepartID)
        {
            return new Tbl_UserService().GetTbl_UserByDepartID(DepartID);
        }
        public static IList<Tbl_User> GetTbl_UserByJob(string Job)
        {
            return new Tbl_UserService().GetTbl_UserByJob(Job);
        }
        public static Tbl_User GetTbl_UserByUserName(string UserName)
        {
            return new Tbl_UserService().GetTbl_UserByUserName(UserName);
        }

        public static IList<Tbl_User> GetTbl_UserBySpecialty(string specialty)
        {
            return new Tbl_UserService().GetTbl_UserBySpecialty(specialty);
        }

        public static IList<Tbl_User> GetTbl_UserAll()
        {
            return new Tbl_UserService().GetTbl_UserAll();
        }

        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_UserService().GetDataTableByCount(Where);
        }

        public static DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_UserService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }

        //��ȡ�û��Ĳ�������
        public static Tbl_User GetTbl_UserDepartLeader(string UserName)
        {
            string UserDepart = WebBLL.Tbl_UserManager.GetTbl_UserByUserName(UserName).U_DepartID; 
            string Leaders = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set9;
            string[] Leaderstr = Leaders.Split(',');
            string per = "";
            string perDepart = "";
            Tbl_User perUser=null;
            for (int i = 0; i < Leaderstr.Length; i++)
            {
                per = Leaderstr[i];
                perUser=WebBLL.Tbl_UserManager.GetTbl_UserByUserName(per);
                perDepart = perUser.U_DepartID;
                if (UserDepart == perDepart) break;
            }
            return perUser;
        }

        //��ȡ�û��Ĳ��ž���
        public static Tbl_User GetTbl_UserDepartManager(string UserName)
        {
            string UserDepart = WebBLL.Tbl_UserManager.GetTbl_UserByUserName(UserName).U_DepartID;
            string Leaders = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set10;
            string[] Leaderstr = Leaders.Split(',');
            string per = "";
            string perDepart = "";
            Tbl_User perUser = null;
            for (int i = 0; i < Leaderstr.Length; i++)
            {
                per = Leaderstr[i];
                perUser = WebBLL.Tbl_UserManager.GetTbl_UserByUserName(per);
                perDepart = perUser.U_DepartID;
                if (UserDepart == perDepart) break;
            }
            return perUser;
        }

        //��������Ա�б�������ѡListBox�ؼ���
        public static void GetUsersByListBox(ListBox listbox)
        {
            DataTable dt = WebBLL.Tbl_UserManager.GetDataTableByPage(200, 1, "", "U_DepartID desc");
            string CacheUsers = "";
            string CacheDepart = "";
            string CacheDepartUsers = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["U_DepartID"].ToString() != CacheDepart)
                {
                    CacheDepart = dr["U_DepartID"].ToString();
                    foreach (WebModels.Tbl_User tbl_user in WebBLL.Tbl_UserManager.GetTbl_UserByDepartID(CacheDepart))
                    {
                        CacheDepartUsers += "," + tbl_user.UserName;
                    }
                    if (CacheDepartUsers.StartsWith(",")) CacheDepartUsers = CacheDepartUsers.Remove(0, 1);
                    listbox.Items.Add(new ListItem(CacheDepart + "��Ա", CacheDepartUsers));
                    CacheDepartUsers = "";
                }
                string itemText = "����" + dr["UserName"].ToString();
                listbox.Items.Add(new ListItem(itemText, dr["UserName"].ToString()));
                CacheUsers += "," + dr["UserName"].ToString();
            }
            if (CacheUsers.StartsWith(",")) CacheUsers = CacheUsers.Remove(0, 1);
            listbox.Items.Insert(0, new ListItem("ȫԺ������Ա", CacheUsers));
            //listbox.SelectedIndex = 0;
        }

        //��ȡĳ�����ŵ���Ա(���ŷָ�)
        public static string GetUsersByDepartName(string DepartName)
        {
            string users = "";
            foreach (WebModels.Tbl_User tbl_user in WebBLL.Tbl_UserManager.GetTbl_UserByDepartID(DepartName))
            {
                users += tbl_user.UserName + ",";
            }
            return users;
        }

        //��������Ա�б�����DropDownList�ؼ���
        public static void GetUsersByDropDownList(DropDownList dropdownlist)
        {
            DataTable dt = WebBLL.Tbl_UserManager.GetDataTableByPage(200, 1, "", "U_DepartID desc");
            string CacheUsers = "";
            string CacheDepart = "";
            string CacheDepartUsers = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["U_DepartID"].ToString() != CacheDepart)
                {
                    CacheDepart = dr["U_DepartID"].ToString();
                    foreach (WebModels.Tbl_User tbl_user in WebBLL.Tbl_UserManager.GetTbl_UserByDepartID(CacheDepart))
                    {
                        CacheDepartUsers += "," + tbl_user.UserName;
                    }
                    dropdownlist.Items.Add(new ListItem(CacheDepart + "��Ա", CacheDepartUsers));
                }
                string itemText = "����" + dr["UserName"].ToString();
                dropdownlist.Items.Add(new ListItem(itemText, dr["UserName"].ToString()));
                CacheUsers += "," + dr["UserName"].ToString();
            }
            dropdownlist.Items.Insert(0, new ListItem("ȫԺ������Ա", CacheUsers));
            //dropdownlist.SelectedIndex = 0;
        }

        public static bool UserLogin(string username, string userpwd)
        {
            var num = GetDataTableByCount("status='��ְ' and username='" + username + "' and userpwd='" + WebCommon.Public.GetMD5(userpwd) + "'");
            if (num > 0)
            {
                return true;
            }
            return false;
        }

        public static bool UserLogout()
        {
            return true;
        }
    }
}

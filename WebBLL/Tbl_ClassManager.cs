using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
using System.Data;
using System.Web.UI.WebControls;

namespace WebBLL
{


    public static  class Tbl_ClassManager
    {
        public static int AddTbl_Class(Tbl_Class tbl_class)
        {
            WebCommon.Public.WriteLog("��ӷ��ࣺ" + tbl_class.ClassName);
            return new Tbl_ClassService().AddTbl_Class(tbl_class);
        }

        public static int UpdateTbl_Class(Tbl_Class tbl_class)
        {
            WebCommon.Public.WriteLog("�޸ķ��ࣺ" + tbl_class.ClassName);
            tbl_class.DealUser = WebCommon.Public.GetUserName();
            tbl_class.DealTime = DateTime.Now;
            return new Tbl_ClassService().UpdateTbl_ClassById(tbl_class);
        }

        public static int DeleteTbl_Class(int ID)
        {
            if (GetDataTableByCount("parentid=" + ID.ToString()) > 0)
            {
                WebCommon.Script.AlertAndGoBack("�÷��������಻����ɾ��");
                return 0;
            }
            else
            {
                WebCommon.Public.WriteLog("ɾ�����ࣺ" + ID.ToString());
                return new Tbl_ClassService().DeleteTbl_ClassById(ID);
            }
        }

        public static Tbl_Class GetTbl_ClassById(int ID)
        {
            return new Tbl_ClassService().GetTbl_ClassById(ID);
        }

        public static IList<Tbl_Class> GetTbl_ClassAll()
        {
            return new Tbl_ClassService().GetTbl_ClassAll();
        }
        public static Tbl_Class GetTbl_ClassRemark(string Remark)
        {
            return new Tbl_ClassService().GetTbl_ClassRemark(Remark);
        }
        
        public static IList<Tbl_Class> GetTbl_ClassByParentID(int ParentID)
        {
            return new Tbl_ClassService().GetTbl_ClassByParentID(ParentID);
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ClassService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ClassService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }

        /// <summary>
        /// ���ݸ�IDֵ�ݹ�������ϲ��Ż�DataTable
        /// </summary>
        /// <param name="parentid">ָ����IDֵ</param>
        public static int ClassDeep = 0;
        public static DataTable TableData;
        public static DataTable TableTemp;
        public static DataTable GetTbl_ClassByAllParentID(int parentid)
        {
            TableData = GetDataTableByPage(1000, 1, "", "ordernum asc,id asc");//��ȡ������������
            TableTemp = GetDataTableByPage(1, 1, "1=2", "");//����һ��ͬ�ṹ�Ŀ�Table
            BindClassByPID(parentid);//��������±�
            return TableTemp;
        }
        private static void BindClassByPID(int parentid)
        {
            try
            {
                string NameStr = "";
                if (parentid > 0)
                {
                    NameStr = "��";
                    for (int x = 0; x < ClassDeep; x++)
                    {
                        NameStr = "��" + NameStr;
                    }
                }
                foreach (DataRow dr in TableData.Rows)
                {
                    if (dr["parentid"].ToString() == parentid.ToString())
                    {
                        dr["ClassName"] = NameStr + dr["classname"].ToString();
                        TableTemp.Rows.Add(dr.ItemArray);
                        ClassDeep++;
                        BindClassByPID(Convert.ToInt32(dr["id"]));
                    }
                }
                ClassDeep--;
                if (ClassDeep < 0) ClassDeep = 0;
            }
            catch (Exception ex)
            {
                WebCommon.Script.Alert(ex.StackTrace);
            }
        }
    }
}

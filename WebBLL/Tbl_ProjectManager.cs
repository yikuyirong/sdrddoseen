using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{
    public class Tbl_ProjectManager
    {
        public static int AddTbl_Project(Tbl_Project tbl_project)
        {
            WebCommon.Public.WriteLog("�����Ŀ��" + tbl_project.ProjectName);
            return new Tbl_ProjectService().AddTbl_Project(tbl_project);
        }

        public static int UpdateTbl_Project(Tbl_Project tbl_project)
        {
            WebCommon.Public.WriteLog("�޸���Ŀ��" + tbl_project.ProjectName);
            tbl_project.DealUser = WebCommon.Public.GetUserName();
            tbl_project.DealTime = DateTime.Now;
            WebModels.Tbl_Project pro = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(tbl_project.ID); //��ѯ�ɽڵ���Ϣ
            if (tbl_project.Status == "������" && tbl_project.NodeNo != pro.NodeNo)
            {
                //���������״̬�޸���ô������Ϣ���ڵ���Ա
                foreach (var obj in tbl_project.NodeUser.Split(','))
                {
                    WebCommon.Public.WriteAlert(obj, "��Ŀ����֪ͨ", "����һ���µ���Ŀ���̴�����" + tbl_project.ProjectName + " " + tbl_project.NodeNo, "views/alert.aspx");
                }
            }
            int count= new Tbl_ProjectService().UpdateTbl_ProjectById(tbl_project);
            return count;
        }

        public static int DeleteTbl_Project(int ID)
        {
            WebCommon.Public.WriteLog("ɾ����Ŀ��" + ID.ToString());
            return new Tbl_ProjectService().DeleteTbl_ProjectById(ID);
        }

        public static string GetProjectNo(string ProjectTypes)
        {
            WebModels.Tbl_Class tbl_class = WebBLL.Tbl_ClassManager.GetTbl_ClassRemark(ProjectTypes);
            string Remark = tbl_class.Remark;
            int ProjectCount = WebBLL.Tbl_ProjectManager.GetDataTableByCount("ProjectTypes='" + ProjectTypes + "'");
            int num = Convert.ToInt32(ProjectCount) + 1;
            return (Remark + "-" + num.ToString());
        }

        public static Tbl_Project GetTbl_ProjectById(int ID)
        {
            return new Tbl_ProjectService().GetTbl_ProjectById(ID);
        }

        public static IList<Tbl_Project> GetTbl_ProjectByProjectTypes(string ProjectTypes)
        {
            return new Tbl_ProjectService().GetTbl_ProjectByProjectTypes(ProjectTypes);
        }
        public static IList<Tbl_Project> GetTbl_ProjectAll()
        {
            return new Tbl_ProjectService().GetTbl_ProjectAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_ProjectService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
        public static System.Data.DataTable GetDataTableByPage2(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_ProjectService().GetDataTableByPage2(PageSize, PageIndex, Where, Order);
        }

        public static System.Data.DataTable GetDataTableByWork(string Where, string Order)
        {
            return new Tbl_ProjectService().GetDataTableByWork(Where, Order);
        }
    }
}

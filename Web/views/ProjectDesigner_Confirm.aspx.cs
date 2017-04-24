using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectDesigner_Confirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (WebCommon.Public.ToString(Request.QueryString["type"]) == "read")
                {
                    Table1.Visible = false;
                }
                Bind();
            }
        }
        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["ProjectID"]);
            WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ID);
            this.ProjectName.Value = project.ProjectName;
            this.ProjectNo.Value = project.ProjectNo;
            TaskList.DataSource = WebBLL.Tbl_ProjectDesignerManager.GetDataTableByPage(0,5,"ProjectID="+ID,"");
            TaskList.DataBind();

        }

        //判断这个项目的某个专业还没录入卷册任务
        public bool CheckMainDesigner(string classname)
        {
            int projectid=Convert.ToInt32(Request.QueryString["ProjectID"]);
            int MyNum = WebBLL.Tbl_DesignTaskManager.GetDataTableByCount("projectid=" + projectid.ToString() + " and status<>'任务录入' and classname1='" + classname + "'");
            if (MyNum > 0) return false;
            return true;
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            //int ID = Convert.ToInt32(Request.QueryString["id"]);
            //WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ID);
            //project.ProjectName = this.ProjectName.Value;
            //project.ProjectCustom = this.ProjectCustom.Value;
            //project.ProjectManager = this.ProjectManager.SelectedValue;
            //project.ProjectStartTime = Convert.ToDateTime(this.ProjectStartTime.Value);
            //project.ProjectEndTime = Convert.ToDateTime(this.ProjectEndTime.Value);
            //project.ProjectTypes = this.ProjectTypes.SelectedValue;
            //project.ProjectCity = this.ProjectCity.Value;
            //project.ProjectLevel = this.ProjectLevel.SelectedValue;
            //project.ProjectInfo = this.ProjectInfo.Value;
            //project.ProjectCustomContact = this.ProjectCustomContact.Value;
            //project.ProjectCustomPhone = this.ProjectCustomPhone.Value;
            //project.DealUser =WebCommon.Public.GetUserName();
            //int count = WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
            //if (count > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改成功!');window.external.reload();window.external.close();", true);
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('修改失败!');", true);
            //}
        }

        protected void Depart_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ProjectManager.DataSource = WebBLL.Tbl_UserManager.GetTbl_UserByDepartID(this.Depart.SelectedValue);
            //ProjectManager.DataTextField = "UserName";
            //ProjectManager.DataValueField = "UserName";
            //ProjectManager.DataBind();
        }


        //同意
        protected void btn_submit1_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["ProjectID"]);
            //更新项目的节点信息
            WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ID);
            //如果是最后一位室主任同意转技术副院长
            if (WebCommon.Public.GetUserName() != WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set7)
            {
                //如果不是最后一个室主任同意不流转
                if (project.NodeUser.Contains(","))
                {
                    string localUser = project.NodeUser + ",";
                    localUser = localUser.Replace(WebCommon.Public.GetUserName() + ",", "");
                    project.NodeUser = localUser.Remove(localUser.LastIndexOf(','));
                }
                else//直到最后一个室主任同意提交完才进入下一流程技术副院长
                {
                    project.NodeNo = "主设人员审批";
                    project.NodeUser = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set7;
                }
            }
            else
            {
                //如果是技术副院长直接下一流程
                project.NodeNo = "卷册任务执行";
                //读取各专业主设为节点人员
                string NodeUsers = "";
                int i = 0;
                foreach (WebModels.Tbl_ProjectDesigner pd in WebBLL.Tbl_ProjectDesignerManager.GetTbl_ProjectDesignerByProjectId(ID))
                {
                    if (i == 0) NodeUsers = pd.UserName;
                    if (i > 0) NodeUsers += "," + pd.UserName;
                    i++;
                    //添加室主任为节点人员
                    string zhuanyeleader = WebBLL.Tbl_ClassManager.GetDataTableByPage(1, 1, "parentid=15 and classname='" + pd.ClassName + "'", "").Rows[0]["status"].ToString();
                    if (!NodeUsers.Contains(zhuanyeleader)) NodeUsers += "," + zhuanyeleader;
                }
                //添加设总为节点人员
                if (!NodeUsers.Contains(project.ProjectMainDesigner)) NodeUsers += "," + project.ProjectMainDesigner;
                //添加设计管理部经理为节点人员
                string DepartManager = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set7;
                if (!NodeUsers.Contains(DepartManager)) NodeUsers += "," + DepartManager;
                project.NodeUser = NodeUsers;
            }
            WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('操作成功,等待" + project.NodeUser + "进行下一步!');window.external.reload();window.external.close();", true);
        }

        //不同意
        protected void btn_submit2_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["ProjectID"]);
            //更新项目的节点信息
            WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ID);
            project.NodeNo = "确认主设";
            project.NodeUser = project.ProjectMainDesigner;
            WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('操作成功!');window.external.reload();window.external.close();", true);
        }
    }
}
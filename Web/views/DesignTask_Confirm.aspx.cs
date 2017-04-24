using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class DesignTask_Confirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //项目ID
                ProjectID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectID.DataTextField = "ClassName";
                ProjectID.DataValueField = "ClassName";
                ProjectID.DataBind();
                ProjectID.Items.Insert(0, new ListItem("选择项目类别", ""));

                //专业
                ClassName.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(15);
                ClassName.DataTextField = "ClassName";
                ClassName.DataValueField = "ClassName";
                ClassName.DataBind();
                ClassName.Items.Insert(0, new ListItem("选择专业", ""));

                //遍历绑定人员列表
                //WebBLL.Tbl_UserManager.GetUsersByDropDownList(DesignManager);
                //DesignManager.Items.Insert(0, new ListItem("选择设总", ""));
                ////遍历绑定人员列表
                //WebBLL.Tbl_UserManager.GetUsersByDropDownList(DesignMain);
                //DesignMain.Items.Insert(0, new ListItem("选择主设", ""));
                //WebBLL.Tbl_UserManager.GetUsersByDropDownList(DT_SheJiRen);
                //DT_SheJiRen.Items.Insert(0, new ListItem("选择审计人", ""));
                //WebBLL.Tbl_UserManager.GetUsersByDropDownList(DT_JiaoDuiRen);
                //DT_JiaoDuiRen.Items.Insert(0, new ListItem("选择校对人", ""));
                //WebBLL.Tbl_UserManager.GetUsersByDropDownList(DT_ShenHeRen);
                //DT_ShenHeRen.Items.Insert(0, new ListItem("选择审核人", ""));
                //WebBLL.Tbl_UserManager.GetUsersByDropDownList(DT_ShenDingRen);
                //DT_ShenDingRen.Items.Insert(0, new ListItem("选择审定人", ""));
                //WebBLL.Tbl_UserManager.GetUsersByDropDownList(DT_HeZhunRen);
                //DT_HeZhunRen.Items.Insert(0, new ListItem("选择核准人", ""));
                ////卷册
                //ClassName3.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(60);
                //ClassName3.DataTextField = "ClassName";
                //ClassName3.DataValueField = "ClassName";
                //ClassName3.DataBind();
                //ClassName3.Items.Insert(0, new ListItem("选择卷册", ""));

                //删除
                if (Request.QueryString["limit"] == "del")
                {
                    int ids = Convert.ToInt32(Request.QueryString["id"].ToString());
                    int count = WebCommon.Public.DataTableDel("Tbl_DesignTask", "id in(" + ids + ")");
                    if (count > 0)
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('删除成功!');", true);
                    }
                    else
                    {
                        WebCommon.Script.AlertAndGoBack("删除失败！");
                    }
                }
                //如果是通过任务明细连接过来
                int projectid = WebCommon.Public.ToInt(Request.QueryString["ProjectID"]);
                if (projectid > 0)
                {
                    ProjectName.SelectedValue = projectid.ToString();
                    WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(Convert.ToInt32(Request.QueryString["ProjectID"]));
                    ProjectName.Items.Insert(0, new ListItem(project.ProjectName, Request.QueryString["ProjectID"]));
                    ProjectID.SelectedValue = project.ProjectTypes;
                    ProjectNo.Value = project.ProjectNo;
                    ProjectName.Enabled = false;
                    ProjectID.Enabled = false;
                    ProjectNo.Attributes.Add("readonly", "readonly");

                    //设总默认
                    DesignManager.Items.Insert(0, new ListItem(project.ProjectMainDesigner, project.ProjectMainDesigner));
                    DesignManager.Enabled = false;

                    //主设默认
                    //DesignMain.Items.Insert(0, new ListItem(WebCommon.Public.GetUserName(), WebCommon.Public.GetUserName()));
                    //DesignMain.Enabled = false;
                    DesignMain.DataSource = WebBLL.Tbl_ProjectDesignerManager.GetDataTableByPage(50, 1, "projectid=" + ProjectName.SelectedValue+" and username in (select distinct(designmain) from tbl_designtask where status='任务审批' and projectid="+project.ID.ToString()+")", "");
                    DesignMain.DataTextField = "UserName";
                    DesignMain.DataValueField = "ClassName";
                    DesignMain.DataBind();
                    DesignMain.Items.Insert(0, new ListItem("选择主设", ""));

                    //专业默认
                    //string classname = WebBLL.Tbl_UserManager.GetTbl_UserByUserName(WebCommon.Public.GetUserName()).U_Specialty;
                    //if (WebCommon.Public.ToString(Request.QueryString["ClassName"]) != "") classname = Request.QueryString["ClassName"];
                    //ClassName.Items.Insert(0, new ListItem(classname, classname));
                    ClassName.Enabled = false;

                    //卷默认
                    //ClassName1.DataSource = WebBLL.Tbl_ClassManager.GetDataTableByPage(10, 1, "parentid=(select top 1 id from tbl_class where classname='" + classname + "')", "id desc");
                    //ClassName1.DataTextField = "ClassName";
                    //ClassName1.DataValueField = "ID";
                    //ClassName1.DataBind();
                    ClassName1.Items.Insert(0, new ListItem("选择卷", ""));
                    ClassName1.Enabled = false;

                    //绑定当前任务
                    BindList();
                }
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            //WebModels.Tbl_DesignTask designTask = new WebModels.Tbl_DesignTask();
            //designTask.ClassName = this.ClassName.SelectedValue;
            //designTask.ProjectID = Convert.ToInt32(this.ProjectName.SelectedValue);
            //designTask.ProjectName = this.ProjectName.SelectedItem.Text;
            //designTask.ProjectNo = this.ProjectNo.Value;
            //designTask.DesignManager = this.DesignManager.Text;
            //designTask.DesignMain = this.DesignMain.Text;
            //designTask.DT_XuHao = this.DT_XuHao.Text;
            //designTask.DT_TuHao = this.DT_TuHao.Text;
            //designTask.ClassName3 = this.ClassName3.SelectedValue;
            //designTask.DT_GuGong = Convert.ToInt32(this.DT_GuGong.Text);
            //designTask.DT_SheJiRen = this.DT_SheJiRen.SelectedValue;
            //designTask.DT_SheJiTime = Convert.ToDateTime(this.DT_SheJiTime.Text);
            //designTask.DT_JiaoDuiRen = this.DT_JiaoDuiRen.SelectedValue;
            //designTask.DT_JiaoDuiTime = Convert.ToDateTime(this.DT_JiaoDuiTime.Text);
            //designTask.DT_ShenHeRen = this.DT_ShenHeRen.SelectedValue;
            //designTask.DT_ShenHeTime = Convert.ToDateTime(this.DT_ShenHeTime.Text);
            //designTask.DT_ShenDingRen = this.DT_ShenHeRen.Text;
            //designTask.DT_ShenDingTime = Convert.ToDateTime(this.DT_ShenHeTime.Text);
            //designTask.DT_HeZhunRen = this.DT_HeZhunRen.SelectedValue;
            //designTask.DT_HeZhunTime = Convert.ToDateTime(this.DT_HeZhunTime.Text);
            //designTask.DT_PublishTime = Convert.ToDateTime(this.DT_PublishTime.Text);
            //designTask.Remark = this.Remark.Text;
            //designTask.DealUser = WebCommon.Public.GetUserName();
            //int count = WebBLL.Tbl_DesignTaskManager.AddTbl_DesignTask(designTask);
            //if (count > 0)
            //{
            //    BindList();
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');", true);
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            //}
        }
        protected void ProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //绑定项目
            ProjectName.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectByProjectTypes(this.ProjectID.SelectedValue);
            ProjectName.DataTextField = "ProjectName";
            ProjectName.DataValueField = "ID";
            ProjectName.DataBind();
            ProjectName.Items.Insert(0, new ListItem("选择项目", ""));
        }

        protected void ProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            WebModels.Tbl_Project tbl_project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(Convert.ToInt32(this.ProjectName.SelectedValue));
            ProjectNo.Value = tbl_project.ProjectNo;
            this.ProjectNo.Attributes["readonly"] = "readonly";
            if (ClassName.SelectedValue != "") BindList();
        }

        protected void ClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选择卷
            ClassName1.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(Convert.ToInt32(this.ClassName.SelectedValue));
            ClassName1.DataTextField = "ClassName";
            ClassName1.DataValueField = "ID";
            ClassName1.DataBind();
            ClassName1.Items.Insert(0, new ListItem("选择卷", ""));
            if (ProjectName.SelectedValue != "") BindList();
        }

        protected void BindList()
        {
            string WhereStr = "Status='任务审批' and nodeuser='"+WebCommon.Public.GetUserName()+"' and ProjectID=" + ProjectName.SelectedValue + " and className1='" + this.ClassName.SelectedValue + "'";
            int count = WebBLL.Tbl_DesignTaskManager.GetDataTableByCount(WhereStr);
            if (count > 0)
            {
                TaskList.DataSource = WebBLL.Tbl_DesignTaskManager.GetDataTableByPage(200, 1, WhereStr, "");
                TaskList.DataBind();
            }
            else
            {
                TaskList.DataSource = "";
                TaskList.DataBind();
            }
        }

                //不同意全部
        protected void Button3_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["ProjectID"]);
            //更新项目的节点信息
            WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ID);
            project.NodeNo = "卷册任务书录入";
            //读取各专业主设
            string NodeUsers = "";
            int i = 0;
            foreach (WebModels.Tbl_ProjectDesigner pd in WebBLL.Tbl_ProjectDesignerManager.GetTbl_ProjectDesignerByProjectId(ID))
            {
                if (i == 0) NodeUsers = pd.UserName;
                if (i > 0) NodeUsers += "," + pd.UserName;
                i++;
            }
            project.NodeUser = NodeUsers;
            WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('操作成功!');window.external.reload();window.external.close();", true);
        }

        protected void DesignMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassName.SelectedValue = DesignMain.SelectedValue;
            BindList();
        }

        //同意该主设任务
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (DesignMain.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('请选择主设!');", true);
                return;
            }
            string zhuanyeleader = WebBLL.Tbl_ClassManager.GetDataTableByPage(1, 1, "parentid=15 and classname='" + ClassName.SelectedValue + "'", "").Rows[0]["status"].ToString();

            if (zhuanyeleader == WebCommon.Public.GetUserName())//如果是室主任
            {
                //string DepartManager = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set7;
                //string Data = "NodeUser='" + DepartManager + "'";
                string Data = "Status='等待设计',NodeUser=DT_SheJiRen";
                WebCommon.Public.DataTableUpdate("tbl_designtask", Data, "ProjectID=" + ProjectName.SelectedValue + " and className1='" + this.ClassName.SelectedValue + "'");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交成功,请等待设计管理部经理" + DepartManager + "审核!');window.external.reload();window.external.close();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交成功,设计师可以开展设计工作了!');window.external.reload();window.external.close();", true);
            }
            else//如果是设计管理部经理
            {
                string Data = "Status='等待设计',NodeUser=DT_SheJiRen";
                WebCommon.Public.DataTableUpdate("tbl_designtask", Data, "ProjectID=" + ProjectName.SelectedValue + " and className1='" + this.ClassName.SelectedValue + "'");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交成功,设计师可以开展设计工作了!');window.external.reload();window.external.close();", true);
            }
            //int ID = Convert.ToInt32(Request.QueryString["ProjectID"]);
            ////更新项目的节点信息
            //WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ID);
            ////如果是技术管理部批准人直接进入设计工作处理阶段、否则提交技术管理部批准人
            //if (WebCommon.Public.GetUserName() == WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set7)
            //{
            //    project.NodeNo = "设计工作处理";
            //    //读取项目的各个专业设计师
            //    string NodeUsers = "";
            //    int i = 0;
            //    foreach (WebModels.Tbl_DesignTask dt in WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTaskByProjectID(ID))
            //    {
            //        if (i == 0) NodeUsers = dt.DT_SheJiRen;
            //        if (i > 0) NodeUsers += "," + dt.DT_SheJiRen;
            //        i++;
            //    }
            //    project.NodeUser = NodeUsers;
            //}
            //else
            //{
            //    project.NodeUser = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set7;
            //}
            //WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('操作成功!');window.external.reload();window.external.close();", true);
        }

        //不同意该主设
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (DesignMain.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('请选择主设!');", true);
                return;
            }
            string zhuanyeleader = WebBLL.Tbl_ClassManager.GetDataTableByPage(1, 1, "parentid=15 and classname='" + ClassName.SelectedValue + "'", "").Rows[0]["status"].ToString();
            string Data = "Status='任务录入',NodeUser='" + DesignMain.SelectedItem.Text + "'";
            WebCommon.Public.DataTableUpdate("tbl_designtask", Data, "ProjectID=" + ProjectName.SelectedValue + " and className1='" + this.ClassName.SelectedValue + "'");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交成功,等待主设" + DesignMain.SelectedItem.Text + "修改任务!');window.external.reload();window.external.close();", true);
        
            //int ID = Convert.ToInt32(Request.QueryString["ProjectID"]);
            ////更新项目的节点信息
            //WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ID);
            //if (project.NodeNo == "卷册任务书审批")
            //{
            //    project.NodeNo = "卷册任务书录入";
            //    project.NodeUser = DesignMain.SelectedItem.Text;
            //}
            //else
            //{
            //    project.NodeUser = project.NodeUser+","+DesignMain.SelectedItem.Text;
            //}
            //WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('操作成功!');", true);
        }

    }
}
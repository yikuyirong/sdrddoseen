using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class DesignTask_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //删除
                if (Request.QueryString["limit"] == "del")
                {
                    int ids = Convert.ToInt32(Request.QueryString["id"].ToString());
                    int count = WebCommon.Public.DataTableDel("Tbl_DesignTask", "id in(" + ids + ")");
                    if (count > 0)
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('删除成功!');window.external.close()", true);
                        WebCommon.Script.AlertAndGoBack("删除成功！");
                    }
                    else
                    {
                        WebCommon.Script.AlertAndGoBack("删除失败！");
                    }
                }

                //项目ID
                ProjectID.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectID.DataTextField = "ClassName";
                ProjectID.DataValueField = "ClassName";
                ProjectID.DataBind();
                ProjectID.Items.Insert(0, new ListItem("选择项目类别", ""));
                ProjectName.Items.Insert(0, new ListItem("选择项目", ""));
                //专业
                ClassName1.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(15);
                ClassName1.DataTextField = "ClassName";
                ClassName1.DataValueField = "ID";
                ClassName1.DataBind();
                ClassName1.Items.Insert(0, new ListItem("选择专业", ""));

                //遍历绑定人员列表
                WebBLL.Tbl_UserManager.GetUsersByDropDownList(DesignManager);
                DesignManager.Items.Insert(0, new ListItem("选择设总", ""));
                //遍历绑定人员列表
                WebBLL.Tbl_UserManager.GetUsersByDropDownList(DesignMain);
                DesignMain.Items.Insert(0, new ListItem("选择主设", ""));

                DT_SheJiRen.DataSource = WebBLL.Tbl_UserManager.GetDataTableByPage(100, 1, "status='在职' and u_designlimit like '%设计人%'", "username asc");
                DT_SheJiRen.DataTextField = "UserName";
                DT_SheJiRen.DataValueField = "UserName";
                DT_SheJiRen.DataBind();
                DT_SheJiRen.Items.Insert(0, new ListItem("选设计人", ""));

                DT_JiaoDuiRen.DataSource = WebBLL.Tbl_UserManager.GetDataTableByPage(100, 1, "status='在职' and u_designlimit like '%校对人%'", "username asc");
                DT_JiaoDuiRen.DataTextField = "UserName";
                DT_JiaoDuiRen.DataValueField = "UserName";
                DT_JiaoDuiRen.DataBind();
                DT_JiaoDuiRen.Items.Insert(0, new ListItem("选校对人", ""));

                DT_ShenHeRen.DataSource = WebBLL.Tbl_UserManager.GetDataTableByPage(50, 1, "status='在职' and u_designlimit like '%审核人%'", "username asc");
                DT_ShenHeRen.DataTextField = "UserName";
                DT_ShenHeRen.DataValueField = "UserName";
                DT_ShenHeRen.DataBind();
                DT_ShenHeRen.Items.Insert(0, new ListItem("选审核人", ""));

                DT_ShenDingRen.DataSource = WebBLL.Tbl_UserManager.GetDataTableByPage(50, 1, "status='在职' and u_designlimit like '%审定人%'", "username asc");
                DT_ShenDingRen.DataTextField = "UserName";
                DT_ShenDingRen.DataValueField = "UserName";
                DT_ShenDingRen.DataBind();
                DT_ShenDingRen.Items.Insert(0, new ListItem("选审定人", ""));

                //卷册
                ClassName1.Items.Insert(0, new ListItem("选择专业", ""));
                ClassName2.Items.Insert(0, new ListItem("选择卷", ""));
                ClassName3.Items.Insert(0, new ListItem("选择册", ""));

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
                    DesignMain.Items.Insert(0, new ListItem(WebCommon.Public.GetUserName(), WebCommon.Public.GetUserName()));
                    DesignMain.Enabled = false;

                    //专业默认
                    //string classname = WebBLL.Tbl_UserManager.GetTbl_UserByUserName(WebCommon.Public.GetUserName()).U_Specialty;
                    //if (WebCommon.Public.ToString(Request.QueryString["ClassName"]) != "") classname = Request.QueryString["ClassName"];
                    //ClassName1.DataSource = null;
                    ClassName1.DataSource = WebBLL.Tbl_ProjectDesignerManager.GetDataTableByPage(10, 1, "UserName='" + WebCommon.Public.GetUserName() + "' and projectid=" + project.ID.ToString(), "");
                    ClassName1.DataTextField = "ClassName";
                    ClassName1.DataValueField = "ClassName";
                    ClassName1.DataBind();
                    ClassName1.Items.Insert(0, new ListItem("选择专业", ""));

                    //卷默认
                    //ClassName2.DataSource = WebBLL.Tbl_ClassManager.GetDataTableByPage(50, 1, "parentid=(select top 1 id from tbl_class where parentid=15 and classname='" + classname + "')", "id asc");
                    //ClassName2.DataTextField = "ClassName";
                    //ClassName2.DataValueField = "ID";
                    //ClassName2.DataBind();
                    //ClassName2.Items.Insert(0, new ListItem("选择卷", ""));

                    //绑定当前任务
                    BindList();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //int ID = Convert.ToInt32(Request.QueryString["ProjectID"]);
            ////更新项目的节点信息
            //WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ID);
            ////直到最后一个主设提交完才进入下一流程
            //if (project.NodeUser.Contains(","))
            //{
            //    string localUser = project.NodeUser + ",";
            //    localUser=localUser.Replace(WebCommon.Public.GetUserName() + ",", "");
            //    project.NodeUser = localUser.Remove(localUser.LastIndexOf(','));
            //}
            //else
            //{
            //    project.NodeNo = "卷册任务书审批";
            //    //遍历查询各位主设的室主任
            //    string NodeUsers = "";
            //    int i = 0;

            //    string zhuanye = "";
            //    string zhuanyeleader = "";

            //    foreach (WebModels.Tbl_ProjectDesigner pd in WebBLL.Tbl_ProjectDesignerManager.GetTbl_ProjectDesignerByProjectId(project.ID))
            //    {
            //        try
            //        {
            //            zhuanye = WebBLL.Tbl_UserManager.GetTbl_UserByUserName(pd.UserName).U_Specialty;
            //            zhuanyeleader = WebBLL.Tbl_ClassManager.GetDataTableByPage(1, 1, "parentid=15 and classname='" + zhuanye + "'", "").Rows[0]["status"].ToString();
            //            if (i == 0) NodeUsers = zhuanyeleader;
            //            if (i > 0 && !NodeUsers.Contains(zhuanyeleader)) NodeUsers += "," + zhuanyeleader;
            //            i++;
            //        }
            //        catch
            //        {
            //            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + pd.UserName + "的室主任查询失败,请检查该人的专业设置是否有误!');", true);
            //            return;
            //        }
            //    }
            //    project.NodeUser = NodeUsers;
            //}
            //WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
            //室主任审批
            string zhuanyeleader = WebBLL.Tbl_ClassManager.GetDataTableByPage(1, 1, "parentid=15 and classname='" + ClassName1.SelectedItem.Text + "'", "").Rows[0]["status"].ToString();
            string Data = "Status='任务审批',NodeUser='" + zhuanyeleader + "'";
            WebCommon.Public.DataTableUpdate("tbl_designtask", Data, "ProjectID=" + ProjectName.SelectedValue + " and className1='" + this.ClassName1.SelectedItem.Text + "'");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交成功,等待室主任" + zhuanyeleader + "审核!');window.external.reload();window.external.close();", true);
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_DesignTask designTask = new WebModels.Tbl_DesignTask();
            designTask.ClassName1 = this.ClassName1.SelectedItem.Text;
            designTask.ClassName2 = this.ClassName2.SelectedItem.Text;
            designTask.ClassName3 = this.ClassName3Value.Text;
            designTask.ProjectID = Convert.ToInt32(this.ProjectName.SelectedValue);
            designTask.ProjectName = this.ProjectName.SelectedItem.Text;
            designTask.ProjectNo = this.ProjectNo.Value;
            designTask.DesignManager = this.DesignManager.Text;
            designTask.DesignMain = this.DesignMain.Text;
            designTask.DT_XuHao = this.DT_XuHao.Text.Trim();
            designTask.DT_TuHao = this.DT_TuHao.Text.Trim();
            designTask.DT_GuGong = Convert.ToDouble(this.DT_GuGong.Text);
            designTask.DT_SheJiRen = this.DT_SheJiRen.SelectedValue;
            if (DT_SheJiTime.Text != "")
            {
                designTask.DT_SheJiTime = Convert.ToDateTime(this.DT_SheJiTime.Text);
            }
            else
            {
                designTask.DT_SheJiTime = new DateTime(1900, 1, 1);
            }
            designTask.DT_JiaoDuiRen = this.DT_JiaoDuiRen.SelectedValue;
            if (DT_JiaoDuiTime.Text != "")
            {
                designTask.DT_JiaoDuiTime = Convert.ToDateTime(this.DT_JiaoDuiTime.Text);
            }
            else
            {
                designTask.DT_JiaoDuiTime = new DateTime(1900, 1, 1);
            }
            designTask.DT_ShenHeRen = this.DT_ShenHeRen.SelectedValue;
            if (DT_ShenHeTime.Text != "")
            {
                designTask.DT_ShenHeTime = Convert.ToDateTime(this.DT_ShenHeTime.Text);
            }
            else
            {
                designTask.DT_ShenHeTime = new DateTime(1900, 1, 1);
            }
            designTask.DT_ShenDingRen = this.DT_ShenDingRen.Text;
            if (DT_ShenDingTime.Text != "")
            {
                designTask.DT_ShenDingTime = Convert.ToDateTime(this.DT_ShenDingTime.Text);
            }
            else
            {
                designTask.DT_ShenDingTime = new DateTime(1900,1,1);
            }
            designTask.DT_HeZhunRen = "";// this.DT_HeZhunRen.SelectedValue;
            designTask.DT_HeZhunTime = DateTime.Now;// Convert.ToDateTime(this.DT_HeZhunTime.Text);
            if (DT_PublishTime.Text != "")
            {
                designTask.DT_PublishTime = Convert.ToDateTime(this.DT_PublishTime.Text);
            }
            else
            {
                designTask.DT_PublishTime = new DateTime(1900, 1, 1);
            }
            designTask.CorrectLevel = "";
            designTask.Remark = VolumeLevel.Value;
            designTask.DealUser = WebCommon.Public.GetUserName();
            designTask.Status = "任务录入";
            designTask.NodeUser = WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_DesignTaskManager.AddTbl_DesignTask(designTask);
            if (count > 0)
            {
                BindList();
                this.DT_XuHao.Text = "";
                this.DT_TuHao.Text = "";
                this.ClassName3.SelectedValue = "";
                this.DT_GuGong.Text = "";
                this.DT_SheJiRen.SelectedValue = "";
                this.DT_SheJiTime.Text = "";
                this.DT_JiaoDuiRen.SelectedValue = "";
                this.DT_JiaoDuiTime.Text = "";
                this.DT_ShenHeRen.SelectedValue = "";
                this.DT_ShenHeTime.Text = "";
                this.DT_ShenHeRen.Text = "";
                this.DT_ShenHeTime.Text = "";
                this.DT_ShenDingRen.Text = "";
                this.DT_ShenDingTime.Text = "";
                this.Remark.Text="";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            }
        }
        protected void ProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            BindList();
        }

        protected void ClassName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //卷
            ClassName2.DataSource = WebBLL.Tbl_ClassManager.GetDataTableByPage(50, 1, "parentid=(select top 1 id from tbl_class where parentid=15 and classname='" + ClassName1.SelectedItem.Text + "')", "");
            ClassName2.DataTextField = "ClassName";
            ClassName2.DataValueField = "ID";
            ClassName2.DataBind();
            ClassName2.Items.Insert(0, new ListItem("选择卷", ""));

            //该专业的人绑定
            DT_SheJiRen.DataSource = WebBLL.Tbl_UserManager.GetDataTableByPage(100, 1, "status='在职' and u_designlimit like '%设计人%' and U_Specialty like '%" + ClassName1.SelectedItem.Text + "%'", "username asc");
            DT_SheJiRen.DataTextField = "UserName";
            DT_SheJiRen.DataValueField = "UserName";
            DT_SheJiRen.DataBind();
            DT_SheJiRen.Items.Insert(0, new ListItem("选设计人", ""));

            DT_JiaoDuiRen.DataSource = WebBLL.Tbl_UserManager.GetDataTableByPage(100, 1, "status='在职' and u_designlimit like '%校对人%' and U_Specialty like '%" + ClassName1.SelectedItem.Text + "%'", "username asc");
            DT_JiaoDuiRen.DataTextField = "UserName";
            DT_JiaoDuiRen.DataValueField = "UserName";
            DT_JiaoDuiRen.DataBind();
            DT_JiaoDuiRen.Items.Insert(0, new ListItem("选校对人", ""));

            DT_ShenHeRen.DataSource = WebBLL.Tbl_UserManager.GetDataTableByPage(50, 1, "status='在职' and u_designlimit like '%审核人%' and U_Specialty like '%" + ClassName1.SelectedItem.Text + "%'", "username asc");
            DT_ShenHeRen.DataTextField = "UserName";
            DT_ShenHeRen.DataValueField = "UserName";
            DT_ShenHeRen.DataBind();
            DT_ShenHeRen.Items.Insert(0, new ListItem("选审核人", ""));

            DT_ShenDingRen.DataSource = WebBLL.Tbl_UserManager.GetDataTableByPage(50, 1, "status='在职' and u_designlimit like '%审定人%' and U_Specialty like '%" + ClassName1.SelectedItem.Text + "%'", "username asc");
            DT_ShenDingRen.DataTextField = "UserName";
            DT_ShenDingRen.DataValueField = "UserName";
            DT_ShenDingRen.DataBind();
            DT_ShenDingRen.Items.Insert(0, new ListItem("选审定人", ""));
            //任务绑定
            BindList();
        }

        protected void BindList()
        {
            string WhereStr = "ProjectID=" + ProjectName.SelectedValue + " and className1='" + this.ClassName1.SelectedValue + "'";
            int count = WebBLL.Tbl_DesignTaskManager.GetDataTableByCount(WhereStr);
            if (count > 0)
            {
                TaskList.DataSource = WebBLL.Tbl_DesignTaskManager.GetDataTableByPage(200, 1, WhereStr, "dt_tuhao asc,dt_xuhao asc");
                TaskList.DataBind();
            }
            else
            {
                TaskList.DataSource = "";
                TaskList.DataBind();
            }
        }

        protected void ClassName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //册
            ClassName3.DataSource = WebBLL.Tbl_DesignVolumeManager.GetDataTableByPage(100,1,"classname2='"+ClassName2.SelectedItem.Text+"'","");
            ClassName3.DataTextField = "VolumeName";
            ClassName3.DataValueField = "ID";
            ClassName3.DataBind();
            ClassName3.Items.Insert(0, new ListItem("选择册", ""));
        }

        protected void ClassName3_DataBound(object sender, EventArgs e)
        {
            ListItemCollection items = ((DropDownList)sender).Items;
            for (int i = 0; i < items.Count; i++)
            {
                ListItem item = items[i];
                item.Attributes.Add("title", item.Text);
            }
        }

        protected void ClassName3_SelectedIndexChanged(object sender, EventArgs e)
        {
            WebModels.Tbl_DesignVolume volume = WebBLL.Tbl_DesignVolumeManager.GetTbl_DesignVolumeById(Convert.ToInt32(ClassName3.SelectedValue));
            DT_TuHao.Text = volume.VolumeNo;
            //查询项目规模
            string ProjectMW=WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(Convert.ToInt32(ProjectName.SelectedValue)).ProjectMW;
            if(ProjectMW=="25MW")DT_GuGong.Text = volume.Volume25MW.ToString();
            if (ProjectMW == "50MW") DT_GuGong.Text = volume.Volume50MW.ToString();
            ClassName3Value.Text = ClassName3.SelectedItem.Text;
            VolumeLevel.Value = volume.VolumeLevel;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            BindList();
        }

    }
}
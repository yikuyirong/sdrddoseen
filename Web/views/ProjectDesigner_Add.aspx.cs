using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectDesigner_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //删除
                if (Request.QueryString["limit"] == "del")
                {
                    int ids = Convert.ToInt32(Request.QueryString["id"].ToString());
                    int count = WebCommon.Public.DataTableDel("Tbl_ProjectDesigner", "id in(" + ids + ")");
                    if (count > 0)
                    {
                        WebCommon.Script.AlertAndGoBack("删除成功！");
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('删除成功!');", true);
                    }
                    else
                    {
                        WebCommon.Script.AlertAndGoBack("删除失败！");
                    }
                }
                //项目信息
                Bind();
                //该项目主设列表
                BindList();
                //专业
                ClassName.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(15);
                ClassName.DataTextField = "ClassName";
                ClassName.DataValueField = "ClassName";
                ClassName.DataBind();
                ClassName.Items.Insert(0, new ListItem("选择专业", ""));
                UserName.Items.Insert(0, new ListItem("选择主设", ""));
            }
        }

        public void Bind()
        {
            int ID = Convert.ToInt32(Request.QueryString["ProjectID"]);
            WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ID);
            this.ProjectName.Value = project.ProjectName;
            this.ProjectNo.Value = project.ProjectNo;

            //绑定主设人员
            UserName.DataSource = WebBLL.Tbl_UserManager.GetDataTableByPage(50, 1, "u_designlimit like '%主设%'", "");
            UserName.DataTextField = "UserName";
            UserName.DataValueField = "UserName";
            UserName.DataBind();
            //UserName.Items.Insert(0, new ListItem("选择主设", ""));
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_ProjectDesigner designer = new WebModels.Tbl_ProjectDesigner();
            designer.ProjectID = Convert.ToInt32(Request.QueryString["ProjectID"]);
            designer.ClassName = this.ClassName.SelectedValue;
            designer.UserName = this.UserName.SelectedValue;
            designer.DesignerType = this.DesignerType.SelectedValue;
            designer.DealUser = WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_ProjectDesignerManager.AddTbl_ProjectDesigner(designer);
            if (count > 0)
            {
                BindList();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            }
        }

        public void BindList()
        {
            int ID = Convert.ToInt32(Request.QueryString["ProjectID"]);
            TaskList.DataSource = WebBLL.Tbl_ProjectDesignerManager.GetDataTableByPage(100, 1, "projectid="+ID.ToString(), "");
            TaskList.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["ProjectID"]);
            //添加合同成功的时候更新项目的节点信息
            WebModels.Tbl_Project project = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(ID);
            project.NodeNo = "主设人员审批";
            //遍历查询各位主设的室主任
            string NodeUsers = "";
            int i = 0;

            string zhuanye = "";
            string zhuanyeleader = "";

            foreach (WebModels.Tbl_ProjectDesigner pd in WebBLL.Tbl_ProjectDesignerManager.GetTbl_ProjectDesignerByProjectId(ID))
            {
                try
                {
                    zhuanye = WebBLL.Tbl_UserManager.GetTbl_UserByUserName(pd.UserName).U_Specialty;
                    zhuanyeleader = WebBLL.Tbl_ClassManager.GetDataTableByPage(1, 1, "parentid=15 and CharINDEX(classname,'" + zhuanye + "')>0", "").Rows[0]["status"].ToString();
                    if (i == 0) NodeUsers = zhuanyeleader;
                    if (i > 0 && !NodeUsers.Contains(zhuanyeleader)) NodeUsers += "," + zhuanyeleader;
                    i++;
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + pd.UserName + "的室主任查询失败,请检查该人的专业设置是否有误!');", true);
                    return;
                }
            }
            project.NodeUser = NodeUsers;
            
            WebBLL.Tbl_ProjectManager.UpdateTbl_Project(project);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交成功，等待" + NodeUsers + "主设人员审批!');window.external.reload();window.external.close();", true);
        }

        protected void ClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //绑定主设人员
            UserName.DataSource = WebBLL.Tbl_UserManager.GetDataTableByPage(50, 1, "u_specialty like '%" + ClassName.SelectedItem.Text + "%' and u_designlimit like '%主设%'", "");
            UserName.DataTextField = "UserName";
            UserName.DataValueField = "UserName";
            UserName.DataBind();
            //UserName.Items.Insert(0, new ListItem("选择主设", ""));
        }
    }
}
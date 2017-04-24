using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace WebCommon
{
    public class Script
    {
        /// <summary>
        /// 将Script写入到页面中
        /// </summary>
        /// <param name="script">script内容</param>
        public static void ResponseScript(string script)
        {
            ResponseScript(null, script);
        }
        public static void ResponseScript(System.Web.UI.Page page,string script)
        {
            if (page != null)
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script>" + script + "</script>");//无白屏(暂时没用)
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("<script>" + script + "</script>");//有白屏
            }
        }

        /// <summary>
        /// 输出警告框
        /// </summary>
        /// <param name="message"></param>
        public static void Alert(string message)
        {
            ResponseScript("alert('" + message + "');");
        }

        /// <summary>
        /// 输出警告框 Ajax下使用
        /// </summary>
        /// <param name="message"></param>
        public static void Alert(string page,string message)
        {
            //ScriptManager.RegisterStartupScript(page, page.GetType(), "message", "alert('" + message + "');", true);
        }

        /// <summary>
        /// 返回上一页
        /// </summary>
        public static void GoBack()
        {
            ResponseScript("window.history.back();");
            System.Web.HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 提示信息并刷新本页面
        /// </summary>
        /// <param name="message"></param>
        public static void AlertAndReload( string message)
        {
            StringBuilder script = new StringBuilder();
            script.AppendFormat("alert('{0}');\n", message);
            script.AppendLine("window.location.reload();");
            ResponseScript(script.ToString());
            System.Web.HttpContext.Current.Response.End();
        }

        public static void PageReload()
        {
            StringBuilder script = new StringBuilder();
            script.AppendLine("window.location.reload();");
            ResponseScript(script.ToString());
            System.Web.HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 重定向到一个新页面
        /// </summary>
        /// <param name="url"></param>
        public static void Redirect(string url)
        {
            System.Web.HttpContext.Current.Response.Redirect(url);
            System.Web.HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 父页面跳转到新页面
        /// </summary>
        /// <param name="url"></param>
        public static void ParentPageRedirect(string url)
        {
            ResponseScript("parent.location.href='" + url + "';");
            System.Web.HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 输出警告框并且返回上一页
        /// </summary>
        /// <param name="message"></param>
        public static void AlertAndGoBack(string message)
        {
            StringBuilder script = new StringBuilder();
            script.AppendFormat("alert('{0}');\n", message);
            script.AppendLine("if(document.referrer!=''){window.history.back();}else{window.external.close();}");
            ResponseScript(script.ToString());
            System.Web.HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 输出警告框并且返回上一页
        /// </summary>
        /// <param name="message"></param>
        public static void AlertAndGoBack(string message, int _depth)
        {
            StringBuilder script = new StringBuilder();
            script.AppendFormat("alert('{0}');\n", message);
            script.AppendLine("window.history.go(" + _depth.ToString() + ");");
            ResponseScript(script.ToString());
            System.Web.HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 输出警告框并且转向新页面
        /// </summary>
        /// <param name="message">警告框内容</param>
        /// <param name="url">转向的页面</param>
        public static void AlertAndRedirect(string message, string url)
        {
            AlertAndRedirect(message, url, false);
        }
        public static void AlertAndRedirect(string message, string url, bool isReferer)
        {
            StringBuilder script = new StringBuilder();
            script.AppendFormat("   alert('{0}');\n", message);
            script.AppendFormat("   var u='{0}';\n", url);
            if (isReferer)
            {
                script.Append(" if(u.toLowerCase().indexOf('ref=') < 0){\n");
                script.Append(" u += ((u.indexOf('?') < 0) ? '?' : '&');\n");
                script.Append(" u += 'ref='+encodeURIComponent(window.location.href);\n");
                script.Append(" }");
            }
            script.Append("   window.location.href=u;\n");
            ResponseScript(script.ToString());
            System.Web.HttpContext.Current.Response.End();
        }


        /// <summary>
        /// 输出警告框并且在父系转向新页面
        /// </summary>
        /// <param name="message">警告框内容</param>
        /// <param name="url">父系转向新的页面URL</param>
        public static void AlertAndParentRedirect(string message, string url)
        {
            AlertAndParentRedirect(message, url, false);
        }
        public static void AlertAndParentRedirect( string message, string url, bool isReferer)
        {
            StringBuilder script = new StringBuilder();
            script.AppendFormat("   alert('{0}');\n", message);
            script.AppendFormat("   var u='{0}';\n", url);
            if (isReferer)
            {
                script.Append(" if(u.toLowerCase().indexOf('ref=') < 0){\n");
                script.Append(" u += ((u.indexOf('?') < 0) ? '?' : '&');\n");
                script.Append(" u += 'ref='+encodeURIComponent(window.location.href);\n");
                script.Append(" }");
            }
            script.Append("   window.parent.location.href=u;\n");
            ResponseScript(script.ToString());
            System.Web.HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 用户弹出页面的关闭该页面后刷新父页面
        /// </summary>
        /// <param name="message"></param>
        public static void AlertAndClose( string message)
        {
            StringBuilder script = new StringBuilder();
            script.AppendFormat("alert('{0}');\n", message);
            script.AppendLine("window.close();");
            ResponseScript(script.ToString());
            System.Web.HttpContext.Current.Response.End();
        }
    }
}

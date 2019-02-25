using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using XiaoBuPark.Entitys;
using XiaoBuPark.Service;

namespace XiaoBuPark.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //程序启动
        protected void Application_Start()
        {
            var model = new LogInfoEntity()
            {
                Title = "程序",
                Message = "程序启动",
                AddTime = DateTime.Now
            };
            LogService.LogInfo(model);

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        //程序错误
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = HttpContext.Current.Server.GetLastError(); //实际出现的异常
            if (ex != null)
            {
                Exception iex = ex.InnerException; //实际发生的异常
                if (iex != null)
                {
                    ex = iex;
                }
                HttpException httpError = ex as HttpException; //http异常
                int httpCode = 500;
                //ASP.NET的400与404错误不记录日志，并都以自定义404页面响应
                if (httpError != null)
                {
                    httpCode = httpError.GetHttpCode();
                    if (httpCode == 400 || httpCode == 404)
                    {
                        HttpContext.Current.Response.StatusCode = 404;//在IIS中配置自定义404页面
                        //Server.ClearError();
                        return;
                    }
                }

                //对于路径错误不记录日志，并都以自定义404页面响应
                if (ex.TargetSite.ReflectedType == typeof(System.IO.Path))
                {
                    HttpContext.Current.Response.StatusCode = 404;
                    //Server.ClearError();
                    return;
                }

                LogWebErrorEntity model = new LogWebErrorEntity();
                model.FilePath = "" + HttpContext.Current.Request.FilePath;
                model.RawUrl = HttpContext.Current.Request.RawUrl;
                model.HttpMethod = HttpContext.Current.Request.HttpMethod;
                model.HttpCode = httpCode;
                model.AddTime = DateTime.Now;

                var queryString = HttpContext.Current.Request.QueryString; //get参数
                StringBuilder sbQueryString = new StringBuilder();
                sbQueryString.Append(queryString.Count + "个：");
                foreach (var key in queryString.AllKeys)
                {
                    sbQueryString.AppendFormat("{0}={1}", key, queryString[key]);
                    if (queryString.AllKeys.LastOrDefault() != key)
                    {
                        sbQueryString.Append(",");
                    }
                }
                model.QueryString = sbQueryString.ToString();

                var form = HttpContext.Current.Request.Form; //post参数
                StringBuilder sbForm = new StringBuilder();
                sbForm.Append(form.Count + "个：");
                foreach (var key in form.AllKeys)
                {
                    sbForm.AppendFormat("{0}={1}", key, form[key]);
                    if (form.AllKeys.LastOrDefault() != key) 
                    {
                        sbForm.Append(",");
                    }
                }
                model.PostData = sbForm.ToString();

                HttpFileCollection files = HttpContext.Current.Request.Files; //文件
                StringBuilder sbFile = new StringBuilder();
                sbFile.Append(files.Count + "个：");
                if (files.Count != 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];
                        sbFile.AppendFormat("文件名：{0}|大小：{1}", file.FileName, file.ContentLength);
                        if (i != files.Count - 1)
                        {
                            sbFile.Append(",");
                        }
                    }
                }
                model.PostFiles = sbFile.ToString();

                model.Message = ex.Message;
                model.SourceError = ex.Source;
                model.StackTrace = ex.StackTrace;
                model.PhysicalPath = HttpContext.Current.Request.PhysicalPath;
                model.TargetSite = ex.TargetSite + "";
                model.UserAgent = HttpContext.Current.Request.UserAgent;
                LogService.LogWebError(model);

            }
        }

        //程序停止
        protected void Application_End(object sender, EventArgs e)
        {
            var model = new LogInfoEntity()
            {
                Title = "程序",
                Message = "程序停止",
                AddTime = DateTime.Now
            };
            LogService.LogInfo(model);
        }
    }
}

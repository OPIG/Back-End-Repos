using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CommonClass.Requires
{
    class Article: IHttpHandler
    {
        public bool IsReusable {
            get { return true; }
        }
        protected string Request = string.Empty;
        public void ProcessRequest(HttpContext context) {
            Request = context.Request["Request"];//获取方法名称
            switch (Request) {
                case "Column": LoadArticleColumn(context); break;
                default:break;
            }
        }
        public void LoadArticleColumn(HttpContext context) {
            string IfContent = "";
            IfContent = context.Request["IfContent"];
            string Size = context.Request["Size"];
            string Page = context.Request["Page"];
            string ColumnId = context.Request["ColumnId"];
            string Orderby = context.Request["Orderby"] == null ? "desc" : context.Request["Orderby"].ToString();//排序
            BLL.News.Article bll_art = new BLL.News.Article();
            int count = 0;
            DataTable dt = bll_art.LoadArticleColumn(ColumnId,"", Int32.Parse(Page), Int32.Parse(Size),out count, Orderby);
            StringBuilder sbArticleList = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sbArticleList.Append("<ArticleColumn Guid=\"" + ColumnId + "\" Count=\"" + count + "\" Size=\""+Size+"\">");
            sbArticleList.Append("<List Page=\"1\">");
            foreach (DataRow dr in dt.Rows) {
                //bool bl_Ip = true;
                //if (dr["C_IsIpControl"].ToString() == "0")
                //{
                //    //查询当前用户IP，是否符合该数据的IP范围控制
                //    long IpInt = ShangYe.WebClient.PlatformAPSBase.Common.PublicClass.GetDB.GetIptoInt();
                //    //ShangYeAPS.CommonClass cc = new ShangYeAPS.CommonClass();
                //    AccessControl ac = new AccessControl();
                //    bl_Ip = ac.GetReaderIpIsInner(IpInt, "Article", dr["C_ArticleGuid"].ToString());
                //}
                sbArticleList.Append("<Article Guid=\"" + dr["C_ArticleGuid"] + "\">");
                //sbArticleList.Append("<IpControl><![CDATA[" + bl_Ip + "]]></IpControl>");
                sbArticleList.Append("<Title><![CDATA[" + dr["C_Title"] + "]]></Title>");
                sbArticleList.Append("<Author><![CDATA[" + dr["C_Author"] + "]]></Author>");
                sbArticleList.Append("<PublishDate><![CDATA[" + dr["C_PublishDate"] + "]]></PublishDate>");
                sbArticleList.Append("<ArticleType><![CDATA[" + dr["C_NewsMediaTypes"] + "]]></ArticleType>");
                sbArticleList.Append("<Color><![CDATA[" + dr["C_HighlightColor"] + "]]></Color>");
                sbArticleList.Append("<Click><![CDATA[" + dr["C_Clicked"] + "]]></Click>");
                sbArticleList.Append("<Image><![CDATA[" + dr["C_Img"] + "]]></Image>");
                if (IfContent == "1")
                {
                    sbArticleList.Append("<ContentText><![CDATA[" + WebClient.PlatformAPSBase.Common.PublicClass.GetDB.NoHTML(dr["C_ContentText"].ToString()) + "]]></ContentText>");
                }
                sbArticleList.Append("</Article>");
            }
            sbArticleList.Append("</List>");
            sbArticleList.Append("</ArticleColumn>");
            context.Response.ContentType="text/xml";
            context.Response.Charset = "UTF-8";
            context.Response.Clear();
            context.Response.Write(sbArticleList.ToString());
        }
    }
}


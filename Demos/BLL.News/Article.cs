using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.News
{
    public class Article
    {
        Access.Article.Article_Base tb = new Access.Article.Article_Base();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="searchContent"></param>
        /// <param name="currPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="zCount"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public DataTable LoadArticleColumn(string typeId, string searchContent, int currPage, int pageSize, out int zCount, string orderBy)
        {
            DataTable dt = new DataTable();

            dt=tb.QueryTable(d=>d.C_ColumnGuid==typeId&&d.C_Deleted==1&&d.C_Isvalid==1, out zCount, d => d.C_ShowOrder, orderBy, null, pageSize, currPage);
            return dt;
        }
    }
}

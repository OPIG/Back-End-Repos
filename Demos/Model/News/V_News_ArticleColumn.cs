using Dos.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.News
{
    [Table("V_News_ArticleColumn")]
    [Serializable]
    public class V_News_ArticleColumn:Entity
    {
        /// <summary>
        /// 唯一编号
        /// </summary>
        public string C_Guid { get; set; }
        /// <summary>
        /// 文章编号
        /// </summary>
        public string C_ArticleGuid { get; set; }
        /// <summary>
        /// 新闻媒体类型编号
        /// </summary>
        public int? C_NewsMediaTypes { get; set; }
        /// <summary>
        /// 主标题
        /// </summary>
        public string C_Title { get; set; }
        /// <summary>
        /// 状态（草稿\正文）：0是草稿，1是正文
        /// </summary>
        public int? C_Status { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public int? C_Ispublished { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime? C_PublishDate { get; set; }
        /// <summary>
        /// 点击率
        /// </summary>
        public int? C_Clicked { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? C_CreatedDate { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public int? C_Isvalid { get; set; }
        /// <summary>
        /// 是否审核通过
        /// </summary>
        public int? C_IsAudit { get; set; }
        /// <summary>
        /// 高亮颜色
        /// </summary>
        public string C_HighlightColor { get; set; }
        /// <summary>
        /// 是否高亮
        /// </summary>
        public int? C_IsHighlight { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string C_ProjectGuid { get; set; }
        /// <summary>
        /// 栏目表编号
        /// </summary>
        public string C_ColumnGuid { get; set; }
        /// <summary>
        /// 导航表编号
        /// </summary>
        public string C_ChannelGuid { get; set; }
        /// <summary>
        /// 是否主文章
        /// </summary>
        public string C_IsPrimaryNews { get; set; }
        /// <summary>
        /// 原文章编号
        /// </summary>
        public string C_OriginalNewsGuids { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? C_ShowOrder { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? C_Deleted { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string C_Img { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string C_Keyword { get; set; }
        /// <summary>
        /// 剔除HTML文章内容
        /// </summary>
        public string C_ContentText { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string C_Content { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public int? C_Istop { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int? C_Type { get; set; }
        /// <summary>
        /// 是否IP控制
        /// </summary>
        public int? C_IsIpControl { get; set; }
        /// <summary>
        /// 是否范围控制
        /// </summary>
        public int? C_IsRangeControl { get; set; }
        /// <summary>
        /// 类别是否有效
        /// </summary>
        public int? NewsIsvalid { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string C_Author { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime C_BeginDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime C_EndDate { get; set; }
        /// <summary>
        /// 是否是重要新闻
        /// </summary>
        public int IsImportant { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string C_Source { get; set; }
    }
}


/*************************************************************************************************/

/// <reference path="../../jQuery/jquery-1.9.1-vsdoc.js" />

(function ($)
{
    $.fn.Pagination = function (Count, Size, Page, MaxButtonNum)
    {
        ///<summary>
        ///    加载分页
        ///</summary>
        ///<param name="Count">栏目下列表总条数</param>
        ///<param name="Size"></param>
        $(this).html("");
        Count = parseInt(Count);
        Size = parseInt(Size);
        Page = parseInt(Page);
        var PageCount = parseInt(Count % Size == 0 ? Count / Size : Count / Size + 1);
        var PageHtml = "";
        var NumCount = MaxButtonNum == null ? 5 : MaxButtonNum;//中间区域总数1,3,5.......
     
        var SpaceNum = 2;//当前页单侧边页码个数0,1,2.....
        if (PageCount > 1) {
            //添加上一页与第一页
            PageHtml += "<a href='javascript://' ref='Pre' class=\"prePage\">上一页</a>";
            PageHtml += "<a href='javascript://' ref='page'  value='1'>1</a>";

            //添加...及当前页之前的页码
            if ((Page - 1) > (SpaceNum + 1)) {
                if (((Page - SpaceNum) - 1) > 1) {
                    PageHtml += "<a href='javascript://' ref='page' id='Ellipsis_Prev'  >...</a>";
                }
                for (var i = (Page - SpaceNum) > 1 ? (Page - SpaceNum) : 2 ; i < Page; i++) {
                    PageHtml += "<a href='javascript://' ref='page'  value='" + i + "'>" + i + "</a>";
                }
            }
            else if ((Page - 1) > 0) {
                for (var i = 2; i < Page; i++) {
                    PageHtml += "<a href='javascript://' ref='page'  value='" + i + "'>" + i + "</a>";
                }
            }

            //添加当前页
            if (Page > 1 && Page < PageCount) {
                PageHtml += "<a href='javascript://' ref='page'  value='" + Page + "'>" + Page + "</a>";
            }

            //添加当前页之后的页码及...
            if ((PageCount - Page) > (SpaceNum + 1)) {
                for (var i = (Page + 1) ; i <= ((PageCount < (Page + SpaceNum)) ? PageCount : (Page + SpaceNum)) ; i++) {
                    PageHtml += "<a href='javascript://' ref='page'  value='" + i + "'  >" + i + "</a>";
                }
                if ((PageCount - (Page + SpaceNum)) > 1) {
                    PageHtml += "<a href='javascript://' ref='page' id='Ellipsis_Next'>...</a>";
                }
            }
            else if ((PageCount - Page) > 0) {
                for (var i = (Page + 1) ; i < PageCount ; i++) {
                    PageHtml += "<a href='javascript://' ref='page'  value='" + i + "'  >" + i + "</a>";
                }
            }

            //添加最后一页及下一页
            PageHtml += "<a href='javascript://' ref='page'  value='" + PageCount + "' >" + PageCount + "</a>";
            PageHtml += "<a href='javascript://' ref='Next' class=\"nextPage\">下一页</a>";
            PageHtml += '<a class="pageInput"><input type="text" value=""></a>';
            PageHtml += '<a class="pageButton"><input type="button" value="GO"></a>';

            $(this).html(PageHtml);
            $(this).children("a").removeClass("e");
            $(this).children("a[value=" + Page + "]").addClass("e");

            if (parseInt($.trim($(this).children("a[class=e]").attr("value"))) == 1)
            {
                $(this).children("a[ref=Pre]").addClass("Unable");
            }
            if (parseInt($.trim($(this).children("a[class=e]").attr("value"))) == PageCount)
            {
                $(this).children("a[ref=Next]").addClass("Unable");
            }

            $(this).off("click", "a[ref=Next]"); $(this).off("click", "a[ref=Pre]"); $(this).off("click", "a[ref=page]"); $(this).off("click", ".pageButton"); $(this).off("focus", ".pageInput input");

            //下一页按钮点击
            $(this).on("click", "a[ref=Next]", function ()
            {
                if ($("div.page a[ref=Next]").attr("class").indexOf("Unable") < 0)
                {
                    Target = (parseInt($.trim($("div.page a[class=e]").attr("value"))) + 1);
                    //  $.hash.set('{"Page":"' + Target + '"}');
                  
                }
            })

            //上一页按钮点击
            $(this).on("click", "a[ref=Pre]", function ()
            {
                if ($("div.page a[ref=Pre]").attr("class").indexOf("Unable") < 0)
                {
                    Target = (parseInt($.trim($("div.page a[class=e]").attr("value"))) - 1);
                    //    $.hash.set('{"Page":"' + Target + '"}');
                 
                }
             
            })

            //数字及省略号点击
            $(this).on("click", "a[ref=page]", function ()
            {
                var Target = 0;
                if ($(this).attr("id") == "Ellipsis_Next")//省略号-后
                {
                    Target = (parseInt($.trim($("div.page a[id='Ellipsis_Next']").prev("div.page a[ref=page]").attr("value"))) + 1);
                }
                else if ($(this).attr("id") == "Ellipsis_Prev") //省略号-前
                {
                    Target = (parseInt($.trim($("div.page a[id='Ellipsis_Prev']").next("div.page a[ref=page]").attr("value"))) - 1);
                }
                else
                {
                    Target = parseInt($.trim($(this).attr("value")));
                }
                //   $.hash.set('{"Page":"' + Target + '"}');
            
            })
            //转跳按钮点击
            $(this).on("click", ".pageButton", function ()
            {
                var Target = parseInt($(this).siblings(".pageInput").children("input").val());
                if (Target >= 1 && Target <= PageCount)
                {
                    //  $.hash.set('{"Page":"' + Target + '"}');
                
                }
                else
                {
                    $(this).siblings(".pageInput").addClass("error");
                    $(this).siblings(".pageInput").addClass("shake");
                    setTimeout(function () { $(".page .pageInput").removeClass("shake"); }, 400);
                }
            })
            //
            $(this).on("focus", ".pageInput input", function ()
            {
                $(this).select();
                $(this).parent(".pageInput").removeClass("error");
            })
        }
    };

})(jQuery);
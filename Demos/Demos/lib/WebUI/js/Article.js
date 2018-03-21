/// <reference path="script/require.min.js" />
/// <reference path="script/jquery-1.9.1.min.js" />

define(['jquery', 'tool', 'Addon/Pagination/Pagination'], function ($) {
    var Article = {
        Data: function () {
            var text = "<Articles></Articles>";
            return CreatXML(text);
        },
        LoadListContent: function (ArticleData, ColumnId, Page) {
            if ($(ArticleData).find('ArticleColumn[Guid="' + ColumnId + '"]').children('List[Page="' + Page + '"]').length > 0) {
                {
                    var Count = $(ArticleData).find('ArticleColumn[Guid="' + ColumnId + '"]').attr("Count");

                    var Size = $(ArticleData).find('ArticleColumn[Guid="' + ColumnId + '"]').attr("Size");
                    var htm_List = "";
                    $(ArticleData).find('ArticleColumn[Guid="' + ColumnId + '"]').children('List[Page="' + Page + '"]').children("Article").each(function (i) {
                        var Title = $(this).children("Title").text();
                        var Guid = $(this).attr("Guid");
                        var Date = $(this).children("PublishDate").text();
                        var Author = $(this).children("Author").text();
                        var Click = $(this).children("Click").text();
                        var Color = $(this).children("Color").text();
                        var Content = SubString($(this).children("ContentText").text(), 160);
                        Date = DateConversion(Date);
                        /**************************************内容绑定********************************************************************************************************************/
                        htm_List += '<li  Guid="' + Guid + '">';
                        htm_List += '    <div class="tit col-lg-6 col-md-6 col-sm-6 col-xs-6"><a href="javascript://" Guid="' + Guid + '" title="' + Title + '">' + Title + '</a></div>';
                        htm_List += ' <span class="col-lg-3 hidden-md hidden-sm hidden-xs">浏览次数：' + Click + '</span>  ';
                        htm_List += '    <span class="pull-right">' + Date + '</span>';
                        htm_List += '</li>';

                        //
                        /**************************************内容绑定********************************************************************************************************************/
                    })
                    $("#ArticleList ul").html(htm_List);
                    $("#ArticleList .page").Pagination(Count, Size, Page, 3);

                }

            } else {                                                                   
                //   Article.PageData(ArticleData, ColumnId, Page);
                Article.ColumnData(ArticleData, ColumnId, Page);//首先加载栏目初始数据
                Article.LoadListContent(ArticleData, ColumnId, Page);
            }
        },
        ColumnData: function (ArticleData, ColumnId, Page) {
            $.ajax({
                type: "POST",
                url: "Article.axd?Column",
                data: {
                    Request: "Column",
                    Size: 12,
                    Page:Page,
                    ColumnId: ColumnId,
                    IfContent: 0
                },
                dataType: "xml",
                async: false,
                success: function (data)  {
                    if (Page > 1) {
                        $(ArticleData).find('ArticleColumn[Guid="' + ColumnId + '"]').append($(xml).find("List"));
                    }else{
                        $(ArticleData).find("Articles").append($(data).find("ArticleColumn"));
                    }
                  
                }
            });
        },
        PageData: function (ArticleData, ColumnId, Page) {
            if ($(ArticleData).find('ArticleColumn[Guid="' + ColumnId + '"]').length > 0) {
                if (Page > 1) {
                    //栏目初始数据中本身包含第1页数据
                    var Size = $(ArticleData).find('ArticleColumn[Guid="' + ColumnId + '"]').attr("Size");
                    $.ajax({
                        type: "POST",
                        url: "Article.axd?Page",
                        data: {
                            Request: "Page",
                            Size: GloblePrarmeter.ArticleSize,
                            Page: Page,
                            ColumnId: ColumnId,
                            IfContent: 1
                        },
                        dataType: "xml",
                        async: false,
                        success: function (xml) {
                            //向指定栏目数据中追加指定页面的数据
                            $(ArticleData).find('ArticleColumn[Guid="' + ColumnId + '"]').append($(xml).find("List"));
                        }
                    });
                }
                else {
                    return;
                }
            }
            else {
                //若变量中无指定栏目的数据
                Article.ColumnData(ArticleData, ColumnId);//首先加载栏目初始数据
                Article.PageData(ArticleData, ColumnId, Page);//而后加载指定页面数据
            }
        }
    }
    return {
        Data: Article.Data,
        LoadListContent: Article.LoadListContent,
        //ColumnData: ColumnData,
        //PageData: PageData
    }
})
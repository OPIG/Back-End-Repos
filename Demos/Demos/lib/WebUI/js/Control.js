/// <reference path="script/require.min.js" />
/// <reference path="script/jquery-1.9.1.min.js" />
 
//$(function () {
//    var ArticleData = Article.Data();
//    var LoadContentText = "";
//    LoadContentText = Article.LoadListContent(ArticleData, '', 1);
//})
require.config({
    paths: {
        tool: 'Tool',
        jquery: 'script/jquery-1.9.1.min',
        article: 'Article'
    }                                         
});
require(['Article'], function (art) {
    var ArticleData = art.Data();
    art.LoadListContent(ArticleData, '32368b39-1bf8-45bf-aaf9-88fcd416d638',1);
})
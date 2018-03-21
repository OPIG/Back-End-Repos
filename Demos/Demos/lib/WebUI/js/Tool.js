/// <reference path="../../../WebUI/js/jquery-1.9.1.js" />
function CreatXML(text) {
    var XMLtext = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + text;
    var xmlDoc = null;
    xmlDoc = $.parseXML(XMLtext)
    return xmlDoc;
}
function SubString(str, n) {

    if (n != null && n != "" && n != 0) {

        var r = /[^\x00-\xff]/g;
        if ($.trim(str).replace(r, "mm").length <= n) { return str; }
        var m = Math.floor(n / 2);
        for (var i = m; i < str.length; i++) {
            if (str.substr(0, i).replace(r, "mm").length >= n) {
                return str.substr(0, i) + "...";
            }
        }
    }
    return str;
}
function DateConversion(date, format) {
    /// <summary>
    ///    根据样式转化时间
    /// </summary>
    /// <param name="date" type="string">
    ///     需要转化的时间
    /// </param>
    /// <param name="format" type="string">
    ///       转化的时间格式
    ///&#10;  默认为yyyy-MM-dd
    /// </param>
    /// <returns type="date">返回日期</returns>
    //var DateStr = date.replace(/\//g, "-");
    var DateStr = date.replace(/-/g, "/");
    var ForString = "yyyy-MM-dd";
    if (format != null && format != "") {
        ForString = format;
    }
    var DateTime = new Date(DateStr);
    var DateCon = DateTime.format(ForString);
    return DateCon;
}
Date.prototype.format = function (style) {
    /// <summary>格式化日期</summary>
    /// <param name="name" type="string">格式：例yyyy-MM-dd</param>
    /// <returns type="Date">返回日期</returns>
    var o = {
        "M+": this.getMonth() + 1, //month
        "d+": this.getDate(),      //day
        "h+": this.getHours(),     //hour
        "m+": this.getMinutes(),   //minute
        "s+": this.getSeconds(),   //second
        "w+": "天一二三四五六".charAt(this.getDay()),   //week
        "q+": Math.floor((this.getMonth() + 3) / 3),  //quarter
        "S": this.getMilliseconds() //millisecond
    }
    if (/(y+)/.test(style)) {
        style = style.replace(RegExp.$1,
    (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(style)) {
            style = style.replace(RegExp.$1,
        RegExp.$1.length == 1 ? o[k] :
        ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return style;
}
$.ajax({
    type: "POST",
    url: "test.axd?Column",
    data: {
        Request: "Column"
    },
    dataType: "xml",
    async: false,
    success: function (data) {
    }
});
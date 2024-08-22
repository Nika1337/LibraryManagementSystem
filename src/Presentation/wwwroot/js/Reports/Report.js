$('#exportButton').click(function () {
    var wb = XLSX.utils.table_to_book($('#reportTable')[0], { sheet: "Report" });
    var wbout = XLSX.write(wb, { bookType: 'xlsx', type: 'binary' });

    function s2ab(s) {
        var buf = new ArrayBuffer(s.length);
        var view = new Uint8Array(buf);
        for (var i = 0; i < s.length; i++) view[i] = s.charCodeAt(i) & 0xFF;
        return buf;
    }

    var filename = 'report.xlsx';
    saveAs(new Blob([s2ab(wbout)], { type: "application/octet-stream" }), filename);
});

class Base {
    constructor() {
        this.loadData();
        //this.loadData2();
        this.InitEventsBase();
    }

    InitEventsBase() {

    }

    /*Đổ dữ liệu vào mảng data */
    getData() {
        var pageIndex = $('.page-index').val();
        var pageSize = $('.page-size option:selected').val();
        var fakeData = [];
        $.ajax({
            method: 'GET',
            url: '/refs/' + pageIndex + '/' + pageSize,
            async: false,
            success: function (res) {
                if (res.Success) {
                    fakeData = res.Data;

                } else {
                    alert(res.Message);
                }
            }
        });
        return fakeData;
    }

    /*Load dữ liệu từ mảng lên màn hình */
    //loadData() {
    //    var data = this.getData();
    //    var fields = $('.main-table th[fieldName]');
    //    $('.main-table tbody').empty();
    //    $.each(data, function (index, item) {
    //        var rowHTML = $('<tr recordID = "{0}"></tr>'.format(item["RefID"]));
    //        $.each(fields, function (fieldIndex, fieldItem) {
    //            var fieldName = fieldItem.getAttribute('fieldName');

    //            var value = item[fieldName];
    //            var cls = 'text-left';
    //            if (fieldName === "RefDate") {
    //                value = new Date(value);
    //            }
    //            var type = $.type(value);
    //            switch (type) {
    //                case "date": value = value.formatddMMyyyy();
    //                    cls = 'text-center';
    //                    break;
    //                case "number": value = value.formatMoney();
    //                    cls = 'text-right';

    //                    break;
    //            }
    //            if (fieldName) {

    //                rowHTML.append('<td class="' + fieldName + ' ' + cls + '">' + value + '</td>');
    //            } else {
    //                rowHTML.append('<td class ="uncheck"></td>');
    //            }
    //        });
    //        $('.main-table tbody').append(rowHTML);
    //    });
    //}


    loadData() {
        debugger
        var data = this.getData();
        var fields = $('.main-table th[fieldName]');
        $('.main-table tbody').empty();
        $.each(data, function (index, item) {
            var rowHTML = $('<tr></tr>').data("recordID", item["RefID"]);
            $.each(fields, function (fieldIndex, fieldItem) {
                var fieldName = fieldItem.getAttribute('fieldName');
                var value = item[fieldName];
                var cls = 'text-left';
                if (fieldName === "RefDate") {
                    value = new Date(value);
                }
                var type = $.type(value);
                switch (type) {
                    case "date": value = value.formatddMMyyyy();
                        cls = 'text-center';
                        break;
                    case "number": value = value.formatMoney();
                        cls = 'text-right';
                        break;
                }
                if (fieldName) {
                    rowHTML.append('<td class = "{1}">{0}</td>'.format(value, cls));
                } else {
                    rowHTML.append('<td class ="uncheck"></td>');
                }
            });
            $('.main-table tbody').append(rowHTML);
        });
    }
    SetStatusButton() {
        var sizeTable = $('.main-table tbody tr').length;
        if (sizeTable == 0) {
            $('button.delete').attr('disabled', 'disabled');
        }
    }




}
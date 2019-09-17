$(document).ready(function () {
    var ref = new Ref();
});

class Ref extends Base {
    constructor() {
        super();
        this.InitEventsRef();
    }

    InitEventsRef() {
        //$('.listReceipt').on('click', 'tr', this.RowOnClick);
        $('.main-table tbody').on('click', 'tr', { "jsObject": this }, this.RowOnClick);
        $('.toolbar').on('click', 'button.delete', this.DeleteOnClick.bind(this));
        $('.main-table tbody').on('click', 'tr .uncheck', this.tickRow);
        $('.toolbar').on('click', 'button.add-new', this.OpenDialogAdd);
        $('#dialog').on('click', 'button.save', this.AddNewRef.bind(this));
        $('.toolbar').on('click', 'button.edit', this.OpenDialogAdd);

        $(document).on('keyup', 'input.page-index', this.pagingData.bind(this));
        $(document).on('change', '.page-size', this.loadDataByPageSize.bind(this));
    }

    pagingData(event) {
        if (event.keyCode === 13) {
            this.loadData();
        }
    }

    /*
     Hàm thay đổi giao diện dòng khi click
    */
    RowOnClick(event) {
        var me = event.data["jsObject"];
        $('button').removeAttr('disabled');
        $('tr').removeClass('select');
        if ($(this).hasClass('select')) {
            $(this).removeClass('select');
        } else {
            $(this).addClass('select');
            me.LoadDetailTable();
        }

    }

    LoadDetailTable() {
        var me = this;
        var refid = me.GetRowID();
        var fakeData = [];
        $.ajax({
            method: 'GET',
            url: '/refdetails/' + refid,
            success: function (res) {
                if (res.Success) {
                    var fields = $('.detail-table th[fieldName]');
                    fakeData = res.Data;
                    $('.detail-table tbody').empty();
                    $.each(fakeData, function (index, item) {
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

                                rowHTML.append('<td class="' + fieldName + ' ' + cls + '">' + value + '</td>');
                            } else {
                                rowHTML.append('<td class ="uncheck"></td>');
                            }
                        });
                        $('.detail-table tbody').append(rowHTML);
                    })
                } else {
                    alert(res.Message);
                }
            }
        })
    }

    /**
     * Hàm thực hiện lấy id của hàng 
     * Người tạo: VDThang
     * Ngày tạo: 31/07/2019
     * */

    GetRowID() {
        var rowid = $('.select,.tick');
        var list = [];
        $.each(rowid, function (index, rowItem) {
            var item = $(rowItem).data('recordID');
            list.push(item);
        })
        return list;
    }
    /**
     * Delete index by click button delete
     * Creator: Nguyen Giang 19-07-2019
     * */
    DeleteOnClick() {
        var me = this;
        var listID = me.GetRowID();
        debugger
        $.ajax({
            method: 'DELETE',
            url: '/refs',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(listID),
            success: function (res) {
                if (res.Success) {
                    me.loadData();
                    $('button.delete').attr('disabled', 'disabled');
                    me.SetStatusButton();
                } else {
                    alert(res.Message);
                }

            }
        });
    }

    /**
     * Hàm chọn nhiều mục sản phẩm
     * */
    tickRow() {
        $(this).parent().addClass('tick');
        $(this).addClass('check');
        $(this).parent().removeClass('uncheck');
    }

    /*
     * Hàm thực hiện chức năng thêm mới 
     * Mở dialog nhập thêm mới
     * */
    OpenDialogAdd() {
        $("#dialog").dialog({
            modal: true,
            height: 400,
            width: 600
        });

    }

    /* Hàm thực hiện chức năng thêm mới */
    AddNewRef() {
        var me = this;
        var listInput = $('#dialog [property]');
        var object = {};
        $.each(listInput, function (index, item) {
            var propertyName = item.getAttribute('property');
            var value = $(this).val();
            object[propertyName] = value;
        });
        debugger
        $.ajax({
            method: 'POST',
            url: '/refs',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(object),
            async: true,
            success: function (res) {
                if (res.Success) {
                    $('#dialog').dialog('close');
                    me.loadData();
                } else {
                    alert(res.Message);
                }
            }
        });
    }

    loadDataByPageSize() {
        var me = this;
        me.loadData();
    }

    loadData() {
        super.loadData();
    }

}
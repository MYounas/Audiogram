
$(function () {


    $('#AddLubricantContainer').jtable({

        columnResizable: false,
        defaultSorting: 'ID ASC',
        sorting: true,
        selecting: true,
        //gotoPageArea: 'combobox',
        paging: true, //Enables paging
        pageSize: 50,
        columnSelectable: false,
        timeZoneConversionOnReload: true,
        actions: {
            listAction: '/Modules/Trip/Report.aspx/LORecordList',
        },

        fields: {
            ID: {
                title: 'ID',
                key: true,
                edit: false,
                list: false,
                create: false,
                sequenceNumber: 1
            },
            Date: {
                title: 'Date',
                edit: false,
                list: true,
                create: false,
                type: 'date',
                displayFormat: 'yy-mm-dd',
                width: '10%',
                maxlength: '50',
                sequenceNumber: 2
            },
            Workshop_Brand: {
                title: 'Workshop Brand',
                edit: false,
                list: true,
                create: false,
                width: '10%',
                maxlength: '50',
                sequenceNumber: 3
            },
            Qty_Ltr: {
                title: 'Qty Ltr',
                edit: false,
                list: true,
                create: false,
                width: '10%',
                maxlength: '50',
                sequenceNumber: 4
            },
            Amount: {
                title: 'Amount',
                edit: false,
                list: true,
                create: false,
                width: '10%',
                maxlength: '50',
                sequenceNumber: 5
            },
        },

    });
    $('#AddLubricantContainer').jtable('load');

    $('#AddDACLContainer').jtable({

        columnResizable: false,
        defaultSorting: 'ID ASC',
        sorting: true,
        selecting: true,
        // gotoPageArea: 'combobox',
        paging: true, //Enables paging
        pageSize: 50,
        columnSelectable: false,
        timeZoneConversionOnReload: true,
        actions: {
            listAction: '/Modules/Trip/Report.aspx/DACLRecordList',
        },

        fields: {
            ID: {
                title: 'ID',
                key: true,
                edit: false,
                list: false,
                create: false,
                sequenceNumber: 1
            },
            Date: {
                title: 'Date',
                edit: true,
                list: true,
                create: true,
                type: 'date',
                displayFormat: 'yy-mm-dd',
                width: '10%',
                maxlength: '50',
                sequenceNumber: 2
            },
            SlipNo: {
                title: 'Slip No',
                edit: true,
                list: true,
                create: true,
                width: '10%',
                maxlength: '50',
                sequenceNumber: 3
            },
            Pump: {
                title: 'Pump',
                edit: true,
                list: true,
                create: true,
                width: '10%',
                maxlength: '50',
                sequenceNumber: 4
            },
            Qty_Ltr: {
                title: 'Qty Ltr',
                edit: true,
                list: true,
                create: true,
                width: '10%',
                maxlength: '50',
                sequenceNumber: 4
            },
            Amount: {
                title: 'Amount',
                edit: true,
                list: true,
                create: true,
                width: '10%',
                maxlength: '50',
                sequenceNumber: 5
            },
            CashLoan: {
                title: 'Cash Loan',
                edit: true,
                list: true,
                create: true,
                width: '10%',
                maxlength: '50',
                sequenceNumber: 5
            },
        },

    });
    $('#AddDACLContainer').jtable('load');

    $('#AddCTDContainer').jtable({

        columnResizable: false,
        defaultSorting: 'ID ASC',
        sorting: true,
        selecting: true,
        // gotoPageArea: 'combobox',
        paging: true, //Enables paging
        pageSize: 50,
        columnSelectable: false,
        timeZoneConversionOnReload: true,
        actions: {
            listAction: '/Modules/Trip/Report.aspx/CTDRecordList',
        },

        fields: {
            ID: {
                title: 'ID',
                key: true,
                edit: false,
                list: false,
                create: false,
                sequenceNumber: 1
            },
            Date: {
                title: 'Date',
                edit: true,
                list: true,
                create: true,
                type: 'date',
                displayFormat: 'yy-mm-dd',
                width: '10%',
                maxlength: '50',
                sequenceNumber: 2
            },
            TrSource: {
                title: 'Tr.Source',
                edit: true,
                list: true,
                create: true,
                width: '10%',
                maxlength: '50',
                sequenceNumber: 3
            },
            TrDetail: {
                title: 'Tr.Detail',
                edit: true,
                list: true,
                create: true,
                width: '10%',
                maxlength: '50',
                sequenceNumber: 4
            },
            Debit: {
                title: 'Debit',
                edit: true,
                list: true,
                create: true,
                width: '10%',
                maxlength: '50',
                sequenceNumber: 4
            },
            Credit: {
                title: 'Amount',
                edit: true,
                list: true,
                create: true,
                width: '10%',
                maxlength: '50',
                sequenceNumber: 5
            },
        },
    });
    $('#AddCTDContainer').jtable('load');


});



_this = new (function _userManagement() {
    var searchword = "";
    var txtAutoCompleteDelay = null;
    var arrayCompany = [];
    var arrayId = [];
    var indexId = 0;
    var arrayCompany1 = [];


    this._PageLoaded = function _PageLoaded() {
        console.log(global.pageName, 'Page');

        _this.is_PageLoaded = true;

        $('#AddExpensesContainer').jtable({

            columnResizable: false,
            defaultSorting: 'ID ASC',
            sorting: true,
            selecting: true,
            // gotoPageArea: 'combobox',
            paging: true, //Enables paging
            pageSize: 50,
            columnSelectable: false,
            timeZoneConversionOnReload: true,
            messages: {
                deleteConfirmation: 'Are you sure you want to delete?',
                deleteSuccessfully: 'Data has been deleted successfully.',
                updateSuccessfully: 'Data is updated successfully.',
                addSuccessfully: 'Data is saved successfully.'
            },
            actions: {
                listAction: '/Modules/Trip/AddExpenses.aspx/RecordList',
                createAction: '/Modules/Trip/AddExpenses.aspx/CreateRecord',
                updateAction: '/Modules/Trip/AddExpenses.aspx/UpdateRecord',
                deleteAction: '/Modules/Trip/AddExpenses.aspx/DeleteRecord'
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
                Fix: {
                    title: 'Fix',
                    edit: true,
                    list: true,
                    create: true,
                    //type: 'date',
                    //displayFormat: 'yy-mm-dd',
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 2
                },
                Pallytaree: {
                    title: 'Pallytaree',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 3
                },
                ToolTax: {
                    title: 'ToolTax',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 4
                },
                ContPort: {
                    title: 'ContPort',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 4
                },
                Munshiana: {
                    title: 'Munshiana',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 5
                },
                Food: {
                    title: 'Food',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 7
                },
                Godown: {
                    title: 'Godown',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 8
                },
                Tyre: {
                    title: 'Tyre',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 9
                },
                Accident: {
                    title: 'Accident',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 10
                },
                Police: {
                    title: 'Police',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 11
                },
                PartsMaint: {
                    title: 'Parts Maint',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 12
                },
                LabourMaint: {
                    title: 'Labour Maint',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 13
                },
                Salary: {
                    title: 'Salary',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 14
                },
                Misc1: {
                    title: 'Misc1',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 15
                },
                Misc2: {
                    title: 'Misc2',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 16
                },
                Misc3: {
                    title: 'Misc3',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 17
                },
            },
            formCreated: function (event, data) {
                if (indexId == ' ') {
                    indexId = 0;
                }

                data.form.find('input[name="Number"]').addClass('validate[required,maxSize[50],minSize[4]]');//,custom[onlyLetterNumber]
                data.form.validationEngine();

            },
            formSubmitting: function (event, data) {
                $(".formError").css('display', 'block');
                return data.form.validationEngine('validate');
            },
            formClosed: function (event, data) {

                $(".formError").css('display', 'none');
                // $('#UserTableContainer').jtable('load', { Id: indexId });
            },
            addRecordButton: $('#addrecord-AddExpensesContainer')

        });

        $('#AddExpensesContainer').jtable('load');

    };

    this._$document_ready = (function () {
        $(document).ready(function () {
            // BIND PRM EVENTS
            //global.page.Prm.add_initializeRequest(_this._InitRequest);

            // _this.checkPassword();


            //link
            // $("#helpTooltip").click(function () { alert("call"); });

            $(window).keydown(function (event) {
                if (event.keyCode == 13) {
                    event.preventDefault();
                    return false;
                }
            });
        });
        $(window).load(function () {

        });

    })();

})();
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
            messages: {
                deleteConfirmation: 'Are you sure you want to delete?',
                deleteSuccessfully: 'Data has been deleted successfully.',
                updateSuccessfully: 'Data is updated successfully.',
                addSuccessfully: 'Data is saved successfully.'
            },
            actions: {
                listAction: '/Modules/Trip/AddLubricant.aspx/RecordList',
                createAction: '/Modules/Trip/AddLubricant.aspx/CreateRecord',
                updateAction: '/Modules/Trip/AddLubricant.aspx/UpdateRecord',
                deleteAction: '/Modules/Trip/AddLubricant.aspx/DeleteRecord'
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
                Workshop_Brand: {
                    title: 'Workshop Brand',
                    //options: { '1': 'hehe', '2': 'fdffd' },
                    //type: 'radiobutton',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 3
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
                Remarks: {
                    title: 'Remarks',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    type: 'textarea',
                    sequenceNumber: 6
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
            addRecordButton: $('#addrecord-AddLubricantContainer')

        });

        $('#AddLubricantContainer').jtable('load');

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
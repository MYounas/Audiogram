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

        $('#AddBuiltyContainer').jtable({

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
                listAction: '/Modules/Trip/AddBuilty.ascx/RecordList',
                createAction: '/Modules/Trip/AddBuilty.ascx/CreateRecord',
                updateAction: '/Modules/Trip/AddBuilty.ascx/UpdateRecord',
                deleteAction: '/Modules/Trip/AddBuilty.ascx/DeleteRecord'
            },

            fields: {
                No: {
                    title: 'No',
                    key: true,
                    edit: false,
                    list: false,
                    create: false,
                    sequenceNumber: 1
                },
                Client: {
                    title: 'Client',
                    edit: true,
                    list: true,
                    create: true,
                    //type: 'date',
                    //displayFormat: 'yy-mm-dd',
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 2
                },
                Station: {
                    title: 'Station',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 3
                },
                Destination: {
                    title: 'Destination',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 4
                },
                Quantity: {
                    title: 'Quantity',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 5
                },
                Scale: {
                    title: 'Scale',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 6
                },
                Freight: {
                    title: 'Freight',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 7
                },
                paidOrNot: {
                    title: 'Paid Or Not',
                    edit: true,
                    list: true,
                    options: { 'paid': 'Paid', 'not_paid': 'Not Paid' },
                    type:'radiobutton',
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 8
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
            addRecordButton: $('#addrecord-AddBuiltyContainer')

        });

        $('#AddBuiltyContainer').jtable('load');

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
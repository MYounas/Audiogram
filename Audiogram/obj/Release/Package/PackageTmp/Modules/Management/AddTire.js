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

        $('#TireTableContainer').jtable({

            columnResizable: false,
            defaultSorting: 'Number ASC',
            sorting: true,
            selecting: true,
           // gotoPageArea: 'combobox',
            paging: true, //Enables paging
            pageSize: 50,
            columnSelectable: false,
            timeZoneConversionOnReload: true,
            messages: {
                deleteConfirmation: 'Are you sure you want to delete driver?',
                deleteSuccessfully: 'Driver has been deleted successfully.',
                updateSuccessfully: 'Driver is updated successfully.',
                addSuccessfully: 'Driver is saved successfully.'
            },
            actions: {
                listAction: '/Modules/Management/AddTire.aspx/RecordList',
                createAction: '/Modules/Management/AddTire.aspx/CreateRecord',
                updateAction: '/Modules/Management/AddTire.aspx/UpdateRecord',
                deleteAction: '/Modules/Management/AddTire.aspx/DeleteRecord'
            },
            
            fields: {
                ID: {
                    title: 'ID',
                    key: true,
                    edit: false,
                    list: false,
                    create: false,
                    sequenceNumber:1
                },
                Number: {
                    title: 'Number :*',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 2
                },
                Pattern: {
                    title: 'Number :',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 2
                },
                LotNumber: {
                    title: 'Lot #:*',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 2
                },
                TireAddOn: {
                    title: 'Tire Add On:',
                    edit: true,
                    displayFormat: 'yy-mm-dd',
                    list: true,
                    create: true,
                    type: 'date',
                    maxDate: 0,
                    //endDate: new Date(),
                    sequenceNumber: 6
                },
                TireRemoveOn: {
                    title: 'Tire Removed On:',
                    edit: true,
                    displayFormat: 'yy-mm-dd',
                    list: true,
                    create: true,
                    type: 'date',
                    maxDate: 0,
                    //endDate: new Date(),
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
            addRecordButton: $('#addrecord-TireTableContainer')

        });

        $('#TireTableContainer').jtable('load');

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

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
            messages: {
                deleteConfirmation: 'Are you sure you want to delete?',
                deleteSuccessfully: 'Data has been deleted successfully.',
                updateSuccessfully: 'Data is updated successfully.',
                addSuccessfully: 'Data is saved successfully.'
            },
            actions: {
                listAction: '/Modules/Trip/AddCTD.aspx/RecordList',
                createAction: '/Modules/Trip/AddCTD.aspx/CreateRecord',
                updateAction: '/Modules/Trip/AddCTD.aspx/UpdateRecord',
                deleteAction: '/Modules/Trip/AddCTD.aspx/DeleteRecord'
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
                SourceType: {
                    title: 'Tr.Source',
                    edit: true,
                    options:'/Modules/Trip/AddCTD.aspx/GetSourceType',
                    create: true,
                    width: '10%',
                    sequenceNumber: 3,
                    list : false
                },
                SourceValue: {
                    title: 'Value',
                    dependsOn: 'SourceType', //Countries depends on continentals. Thus, jTable builds cascade dropdowns!
                    options: function (data) {
                        if (data.source == 'list') {
                            //Return url of all countries for optimization. 
                            //This method is called for each row on the table and jTable caches options based on this url.
                            return '/Modules/Trip/AddCTD.aspx/GetSourceValue?sourceTypeId=0';
                        }

                        //This code runs when user opens edit/create form or changes continental combobox on an edit/create form.
                        //data.source == 'edit' || data.source == 'create'
                        return '/Modules/Trip/AddCTD.aspx/GetSourceValue?sourceTypeId=' + data.dependedValues.SourceType;
                    },
                    list: false
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
                Remarks: {
                    title: 'Remarks',
                    edit: true,
                    type: 'textarea',
                    list: false,
                    create: true,
                    maxlength: '500',
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
            addRecordButton: $('#addrecord-AddCTDContainer')

        });

        $('#AddCTDContainer').jtable('load');

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
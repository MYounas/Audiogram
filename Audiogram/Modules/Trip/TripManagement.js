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

        $('#TripTableContainer').jtable({

            columnResizable: false,
            defaultSorting: 'Vehicle ASC',
            sorting: true,
            selecting: true,
           // gotoPageArea: 'combobox',
            paging: true, //Enables paging
            pageSize: 50,
            columnSelectable: false,
            timeZoneConversionOnReload: true,
            messages: {
                //deleteConfirmation: 'Are you sure you want to delete driver?',
                //deleteSuccessfully: 'Driver has been deleted successfully.',
                //updateSuccessfully: 'Driver is updated successfully.',
                //addSuccessfully: 'Driver is saved successfully.'
            },
            actions: {
                listAction: '/Modules/Trip/TripManagement.aspx/RecordList',
                //createAction: '/Modules/Management/AddTire.aspx/CreateRecord',
                //updateAction: '/Modules/Trip/AddExpenses.aspx/UpdateRecord', //open for testing
                //deleteAction: '/Modules/Trip/AddExpenses.aspx/UpdateRecord'
                //updateAction: function (postData, jtParams) {
                //    return $.Deferred(function ($dfd) {
                //        $.ajax({
                //            url: '/AddTire.aspx/UpdateRecord?jtStartIndex=' + jtParams.jtStartIndex + '&jtPageSize=' + jtParams.jtPageSize + '&jtSorting=' + jtParams.jtSorting,
                //            type: 'GET',
                //            dataType: 'json',
                //            data: postData,
                //            success: function (data) {
                //                $dfd.resolve(data);
                //            },
                //            error: function () {
                //                $dfd.reject();
                //            }
                //        });
                //    });
                //},
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
                Vehicle: {
                    title: 'Vehicle :*',
                    edit: false,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 2
                },
                FirstDriver: {
                    title: 'First Driver',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 3
                },
                SecondDriver: {
                    title: 'Second Driver',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 4
                },
                StartDate: {
                    title: 'Start Date',
                    edit: true,
                    displayFormat: 'yy-mm-dd',
                    list: true,
                    create: true,
                    type: 'date',
                    maxDate: 0,
                    //endDate: new Date(),
                    sequenceNumber: 5
                },
                Expenses: {
                    title: 'Expenses',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 6
                },
                Settlement: {
                    title: 'Settlement',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 7
                },
                CustomAction1: {
                    title: '',
                    //width: '1%',
                    sorting: false,
                    create: false,
                    edit: false,
                    list: true,
                    display: function (data) {
                        if (data.record) {
                            return '<a target="_blank" href="./AddExpenses.aspx?id=' + data.record.ID + '";>Expenses</a>';
                        }
                    }
                },
                CustomAction2: {
                    title: '',
                    //width: '1%',
                    sorting: false,
                    create: false,
                    edit: false,
                    list: true,
                    display: function (data) {
                        if (data.record) {
                            return '<a target="_blank" href="./AddSettlement.aspx?id=' + data.record.ID + '";>Settlement</a>';
                        }
                    }
                },
                CustomAction3: {
                    title: '',
                    width: '1%',
                    sorting: false,
                    create: false,
                    edit: false,
                    list: true,
                    display: function (data) {
                        if (data.record) {
                            return '<button title="Add Lubricant Oil" class="jtable-command-button jtable-oil-command-button" onclick="LO(' + data.record.ID + ')";><span>Add Lubricant Oil</span></button>';
                        }
                    }
                },
                CustomAction4: {
                    title: '',
                    width: '1%',
                    sorting: false,
                    create: false,
                    edit: false,
                    list: true,
                    display: function (data) {
                        if (data.record) {
                            return '<button title="Add Diesal & Cash Loan" class="jtable-command-button jtable-diesal-command-button" onclick="DACL(' + data.record.ID + ')";><span>Add Diesal & Cash Loan</span></button>';
                        }
                    }
                },
                CustomAction5: {
                    title: '',
                    width: '1%',
                    sorting: false,
                    create: false,
                    edit: false,
                    list: true,
                    display: function (data) {
                        if (data.record) {
                            return '<button title="Cash Transaction Detail" class="jtable-command-button jtable-cash-command-button" onclick="CTD(' + data.record.ID + ')";><span>Cash Transaction Detail</span></button>';
                        }
                    }
                },
                CustomAction6: {
                    title: '',
                    width: '1%',
                    sorting: false,
                    create: false,
                    edit: false,
                    list: true,
                    display: function (data) {
                        if (data.record) {
                            return '<button title="Print Report" class="jtable-command-button jtable-report-command-button" onclick="report(' + data.record.ID + ')";><span>Print Report</span></button>';
                        }
                    }
                },
                CustomAction7: {
                    title: '',
                    width: '1%',
                    sorting: false,
                    create: false,
                    edit: false,
                    list: true,
                    display: function (data) {
                        if (data.record) {
                            return '<button title="Edit Trip" class="jtable-command-button jtable-edit-command-button" onclick="EditTrip(' + data.record.ID + ')";><span>Edit Trip</span></button>';
                        }
                    }
                },
            },
            formCreated: function (event, data) {
                if (indexId === ' ') {
                    indexId = 0;
                }
            
                //data.form.find('input[name="Number"]').addClass('validate[required,maxSize[50],minSize[4]]');//,custom[onlyLetterNumber]
                //data.form.validationEngine();
                
            },
            formSubmitting: function (event, data) {
                //$(".formError").css('display', 'block');
                //return data.form.validationEngine('validate');
            },
            formClosed: function (event, data) {
             
                //$(".formError").css('display', 'none');
                // $('#UserTableContainer').jtable('load', { Id: indexId });
            },
            //addRecordButton: $('#addrecord-TireTableContainer')

        });

        $('#TripTableContainer').jtable('load');

    };

    this._$document_ready = (function () {
        $(document).ready(function () {
            // BIND PRM EVENTS
            //global.page.Prm.add_initializeRequest(_this._InitRequest);

            // _this.checkPassword();


            //link
           // $("#helpTooltip").click(function () { alert("call"); });

            $(window).keydown(function (event) {
                if (event.keyCode === 13) {
                    event.preventDefault();
                    return false;
                }
            });
        });
        $(window).load(function () {

        });

    })();

})();

function LO(id) {
    $(document).ready(function () {
        id = validateId(id)
        if (id != '') {
            window.open(window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1) + 'AddLubricant.aspx?id=' + id)
        }
    });
}

function DACL(id) {
    $(document).ready(function () {
        id = validateId(id)
        if (id != '') {
            window.open(window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1) + 'AddDACL.aspx?id=' + id)
        }

    });
}

function CTD(id) {
    $(document).ready(function () {
        id = validateId(id)
        if (id != '') {
            window.open(window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1) + 'AddCTD.aspx?id=' + id)
        }
    });
}

function report(id) {
    $(document).ready(function () {
        id = validateId(id)
        if (id != '') {
            window.open(window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1) + 'Report.aspx?id=' + id)
        }
        //window.open(window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1) + 'Report.aspx')
    });
}
function EditTrip(id) {
    $(document).ready(function () {
        id = validateId(id)
        if (id != '') {
            window.open(window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1) + 'StartTrip.aspx?id=' + id)
        }
        //window.open(window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1) + 'Report.aspx')
    });
}

function validateId(id) {

        if (id == '') {
            id = $('#SelectedId').val()
        }
        if (id == '') {
            alert('please select record')
            return id;
        }
        
        return id;
}




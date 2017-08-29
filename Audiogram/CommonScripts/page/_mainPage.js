_this = new (function _mainPage() {

    this._PageLoaded = function _PageLoaded() {
        console.log(global.pageName, 'Page');
        
        _this.is_PageLoaded = true;

        // Validation Engine

        // SEARCH CONTROL SEARCH BUTTON
        $('#btnSave').on('click', { fieldgroup: 'fg1' }, global.click_validate_group);

    };
    this.customValidations = (function () {
        return {
            //From Date must be less than To Date
            checkDates: function (field, rules, i, options) {
                var is_fg1 = field.hasClass('fg1');
                var StartDate, EndDate;
                if (is_fg1) {
                    StartDate = $('#txtFromDate').val();
                    EndDate = $('#txtToDAte').val();
                }
                var eDate = new Date(EndDate);
                var sDate = new Date(StartDate);
                if ((StartDate != '' && StartDate != '') && (sDate > eDate)) {
                    return "\"To Date\" must be greater than \"From Date\"";
                }
            }
        }
    })();
    this._$document_ready = (function () {
        $(document).ready(function () {
            // BIND PRM EVENTS
            //global.page.Prm.add_initializeRequest(_this._InitRequest);
            $('#VehicleTableContainerOnTrip').jtable({

                sorting: true,
                columnResizable: false,
                defaultSorting: 'Name ASC',
                paging: true, //Enables paging
                pageSize: 30, //per page record 30
                selecting: true,
                columnSelectable: false,
                messages: {
                    //deleteConfirmation: 'Are you sure you want to delete account holder?',
                    //deleteSuccessfully: 'Account holder has been deleted successfully.',
                    //updateSuccessfully: 'Vehicle is updated successfully.',
                    //addSuccessfully: 'Vehicle is saved successfully.'
                },
                actions: {
                    listAction: '/Modules/Management/VehicleManagement.aspx/RecordListOnTrip',
                    //createAction: '/Modules/Management/VehicleManagement.aspx/CreateRecord',
                    //updateAction: '/Modules/Management/VehicleManagement.aspx/UpdateRecord',
                    //deleteAction: '/Modules/Management/VehicleManagement.aspx/DeleteRecord'

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
                    Name: {
                        title: 'Vehicle',
                        edit: false,
                        list: true,
                        width: '15%',
                        create: true,
                        maxlength: '50',
                        sequenceNumber: 1
                    },
                  

                },
                formCreated: function (event, data) {

                },
                formSubmitting: function (event, data) {

                },
                formClosed: function (event, data) {
                 
                },
              
            });

            $('#VehicleTableContainerIdle').jtable({

                sorting: true,
                columnResizable: false,
                defaultSorting: 'Name ASC',
                paging: true, //Enables paging
                pageSize: 30, //per page record 30
                selecting: true,
                columnSelectable: false,
                messages: {
                    //deleteConfirmation: 'Are you sure you want to delete account holder?',
                    //deleteSuccessfully: 'Account holder has been deleted successfully.',
                    //updateSuccessfully: 'Vehicle is updated successfully.',
                    //addSuccessfully: 'Vehicle is saved successfully.'
                },
                actions: {
                    listAction: '/Modules/Management/VehicleManagement.aspx/RecordListIdle',
                    //createAction: '/Modules/Management/VehicleManagement.aspx/CreateRecord',
                    //updateAction: '/Modules/Management/VehicleManagement.aspx/UpdateRecord',
                    //deleteAction: '/Modules/Management/VehicleManagement.aspx/DeleteRecord'

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
                    Name: {
                        title: 'Vehicle',
                        edit: false,
                        list: true,
                        width: '15%',
                        create: true,
                        maxlength: '50',
                        sequenceNumber: 1
                    },


                },
                formCreated: function (event, data) {

                },
                formSubmitting: function (event, data) {

                },
                formClosed: function (event, data) {

                },

            });


            $('#VehicleTableContainerOnTrip').jtable('load', { Make: '' });
            $('#VehicleTableContainerIdle').jtable('load', { Make: '' });
        });





        $(window).load(function () {

        });
    })();

})();

$(document).ready(function () {

    this.checkPassword = function checkPassword(field, rules, i, options) {

        if (field.val() != $('#Edit-Password').val()) {
            return "Please Confirm Password";
        }
    };
    

    var txtAutoCompleteDelay = null;
    $(window).keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });
    $('#txtAutoComplete').focus();
    $('#txtAutoComplete').val('');
    $('#VehicleTableContainer').jtable({

        sorting: true,
        columnResizable: false,
        defaultSorting: 'Make ASC',
        paging: true, //Enables paging
        pageSize: 50, //per page record 30
        selecting: true,
        columnSelectable: false,
        messages: {
            //deleteConfirmation: 'Are you sure you want to delete account holder?',
            //deleteSuccessfully: 'Account holder has been deleted successfully.',
            updateSuccessfully: 'Vehicle is updated successfully.',
            addSuccessfully: 'Vehicle is saved successfully.'
        },
        actions: {
            listAction: '/Modules/Management/VehicleManagement.aspx/RecordList',
            createAction: '/Modules/Management/VehicleManagement.aspx/CreateRecord',
            updateAction: '/Modules/Management/VehicleManagement.aspx/UpdateRecord',
            deleteAction: '/Modules/Management/VehicleManagement.aspx/DeleteRecord'
            
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
            Make: {
                title: 'Make :*',
                edit: true,
                list: true,
                width: '15%',
                create: true,
                maxlength: '50',
                sequenceNumber: 1
            },
            Model: {
                title: 'Model :*',
                edit: true,
                list: true,
                create: true,
                width: '11%',
                maxlength: '50',
                sequenceNumber: 2
            },

            Version: {
                title: 'Version :',
                list: true,
                edit: true,
                create: true,
                maxlength: '50',
                sequenceNumber: 3
            },
            Year: {
                title: 'Year :',
                edit: true,
                list: true,
                width: '15%',
                create: true,
                maxlength: '250',
                sequenceNumber: 4
            },
            CC: {
                title: 'Horse Power(CC) :',
                edit: true,
                list: true,
                width: '15%',
                create: true,
                maxlength: '250',
                sequenceNumber: 5
            },
            NumberPlate: {
                title: 'Number Plate',
                edit: true,
                list: true,
                width: '15%',
                create: true,
                maxlength: '250',
                sequenceNumber: 6
            },
            Color: {
                title: 'Colour',
                edit: true,
                list: true,
                width: '15%',
                create: true,
                maxlength: '250',
                sequenceNumber: 7
            },
            IsActive: {
                title: 'Status:',
                list: true,
                edit: true,
                width: '8%',
                type: 'checkbox',
                defaultValue: 'true',
                values: { 'false': 'InActive', 'true': 'Active' },
                sequenceNumber: 8,
                inputClass: 'subject-edit-status'
            },
            CustomAction1: {
                title: '',
                width: '1%',
                sorting: false,
                create: false,
                edit: false,
                list: true,
                display: function (data) {
                    if (data.record) {
                        return '<button title="Add Document" class="jtable-command-button jtable-adddocument-command-button" "><span>Add Document</span></button>';
                    }
                }
            },
            CustomAction2: {
                title: '',
                width: '1%',
                sorting: false,
                create: false,
                edit: false,
                list: true,
                display: function (data) {
                    if (data.record) {
                        return '<button title="Add Tire" class="jtable-command-button jtable-addtire-command-button" onclick="abc('+data.record.ID+');"><span>Add Tire</span></button>';
                    }
                }
            }

        },
        formCreated: function (event, data) {

           

            data.form.find('input[name="Make"]').addClass('validate[required,maxSize[50]]');
            data.form.find('input[name="Model"]').addClass('validate[required,maxSize[50]]');
            //data.form.find('input[name="AccountHolderName"]').addClass('validate[required,maxSize[50],minSize[4]]');
            data.form.find('input[name="Year"]').addClass('validate[maxSize[250],minSize[4]]');
            data.form.find('input[name="Version"]').addClass('validate[maxSize[250],minSize[2]]');
            data.form.find('input[name="CC"]').addClass('validate[required,maxSize[50],minSize[2]]');
            data.form.find('input[name="NumberPlate"]').addClass('validate[required,maxSize[60],minSize[4]]');
            data.form.find('input[name="Color"]').addClass('validate[maxSize[15]]');
            //data.form.find('input[name="ID"]').css('background-color', '#DEDEDE');
            data.form.parent().removeClass("ui-draggable ui-resizable")
            //data.form.find('input[name="ID"]').attr('readonly', true);

            data.form.validationEngine();


            data.form.parent().css('width', '334px').css('height', '370px');
            $(data.form).addClass("custom_horizontal_form_field");
            var headerText = $(data.form).parents('.ui-dialog').find('.ui-dialog-title').text() || '';
            if (headerText == 'Add new record') {
                headerText = 'Add New Vehicle';
            } else if (headerText == 'Edit Record') {
                headerText = 'Edit Vehicle';
            }

            $('.account-edit-status').on('change', function () {
                $(this).next('.jtable-option-text-clickable').text('Active');
            }).next('.jtable-option-text-clickable').text('Active');

            $(data.form).parents('.ui-dialog').find('.ui-dialog-title').text(headerText);

            ////setInterval(function () {
            //    data.form.find('input[name="Company"]').focus();
            ////}, 200);
        },
        formSubmitting: function (event, data) {
            //return data.form.validationEngine('validate');
            //console.log(data.form.find('input[name="MemberShipId"]').val())

            console.log(event);
            console.log(data);


            if (data.form.find('input[name="UserId"]').val() == '') {
                data.form.find('input[name="UserId"]').val(0)
            }
            $(".formError").css('display', 'block');
            return data.form.validationEngine('validate');
        },
        formClosed: function (event, data) {
            $('#VehicleTableContainer').jtable('load', { Make: '' });

            $(".formError").css('display', 'none');
        },
        //recordsLoaded: function (e, data) {
        //    global.addTopPanelPagination(e, data);
        //},
        addRecordButton: $('#addrecord-VehicleTableContainer')
    });
    //////////////////////Account Holder Search box Loads jtable on clear//////////////////////////////////
    $("#txtBoxAutoComplete").keyup(function () {
        if (!this.value) {
            //indexId = ' ';
            TxtAutoComplete();

        }

    });
    //////////////////////

    $('#VehicleTableContainer').jtable('load', { Make: '' });
    $("#txtAutoComplete").keyup(function () {
        searchword = $(this).val();


        if (txtAutoCompleteDelay) {

            window.clearTimeout(txtAutoCompleteDelay);
        }
        //if (searchword.length >= 1) {
        txtAutoCompleteDelay = window.setTimeout(TxtAutoComplete, 500);
        //}

    });

});

function abc(id) {
    $(document).ready(function () {

        //var obj = {};
        //obj.Id = id
        //$.ajax({
        //    type: "POST",
        //    url: "/Modules/Management/VehicleManagement.aspx/Redirect",
        //    data: JSON.stringify(obj),
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",
        //    success: function (r) {
        //        alert(r.d);
        //    }
        //});

        window.open(window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1) + 'addtire.aspx?id=' + id)

    });

}

function TxtAutoComplete() {
    $('#VehicleTableContainer').jtable('load', { Make: searchword });
    $('#txtAutoComplete').focus();
}




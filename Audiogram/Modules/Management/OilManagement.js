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

        $('#OilTableContainer').jtable({

            columnResizable: false,
            defaultSorting: 'Name ASC',
            sorting: true,
            selecting: true,
           // gotoPageArea: 'combobox',
            paging: true, //Enables paging
            pageSize: 50,
            columnSelectable: false,
            timeZoneConversionOnReload: true,
            messages: {
                deleteConfirmation: 'Are you sure you want to delete Data?',
                deleteSuccessfully: 'Data has been deleted successfully.',
                updateSuccessfully: 'Data is updated successfully.',
                addSuccessfully: 'Data is saved successfully.'
            },
            actions: {
                listAction: '/Modules/Management/OilManagement.aspx/RecordList',
                createAction: '/Modules/Management/OilManagement.aspx/CreateRecord',
                updateAction: '/Modules/Management/OilManagement.aspx/UpdateRecord',
                deleteAction: '/Modules/Management/OilManagement.aspx/DeleteRecord'
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
                Name: {
                    title: 'Name :*',
                    edit: true,
                    list: true,
                    create: true,
                    width: '10%',
                    maxlength: '50',
                    sequenceNumber: 2
                },
               
                Company: {
                    title: 'Company:*',
                    edit: true,
                    list: true,
                    create: true,
                    width: '11%',
                    maxlength: '50',
                    sequenceNumber:3
                },
                Type: {
                    title: 'Type:*',
                    edit: true,
                    list: true,
                    create: true,
                    width: '11%',
                    maxlength: '50',
                    sequenceNumber:4
                },
                
            },
            formCreated: function (event, data) {
                if (indexId === ' ') {
                    indexId = 0;
                }
            

                //data.form.find('input[name="DOB"]').addClass('validate[custom[dateFormat]]');
                //data.form.find('input[name="Name"]').addClass('validate[required,maxSize[50],minSize[4]]');//,custom[onlyLetterNumber]
                //data.form.find('input[name="FatherName"]').addClass('validate[maxSize[50]]');
                //data.form.find('input[name="NIC"]').addClass('validate[maxSize[40]]');
               //data.form.parent().css('width', '340px').css('height', '400px');
               $(data.form).addClass("custom_horizontal_form_field");
             
               var headerText = $(data.form).parents('.ui-dialog').find('.ui-dialog-title').text() || '';
               if (headerText === 'Add new record') {
                   headerText = 'Add New record';
               } else if (headerText === 'Edit Record') {
                   headerText = 'Edit Record';
               }

               $('.subject-edit-status').on('change', function () {
                   $(this).next('.jtable-option-text-clickable').text('Active');
               }).next('.jtable-option-text-clickable').text('Active');

               $(data.form).parents('.ui-dialog').find('.ui-dialog-title').text(headerText);

               //$('#Edit-BirthdateCreate').datepicker({ dateFormat: 'dd-mm-yy', maxDate: 0 });
               //if (headerText == 'Add New Driver') {
               //    $("#Edit-BirthdateCreate").datepicker().datepicker("setDate", new Date());
                   
               //}

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
            addRecordButton: $('#addrecord-oilTableContainer')

        });



        indexId = $('#hdnAccountHolderSignup').val();
        var AccountwithUser = "{'searchWord':'" + searchword + "'," + " 'AccountHolderId':' " + indexId + "'}";
        $('#OilTableContainer').jtable('load', { Id: AccountwithUser });


        //////////////////////User Search box Loads jtable on key up//////////////////////////////////
        $("#txtAutoCompleteoils").keyup(function () {
            searchword = $(this).val();


            if (txtAutoCompleteDelay) {

                window.clearTimeout(txtAutoCompleteDelay);
            }
            //if (searchword.length >= 1) {
            txtAutoCompleteDelay = window.setTimeout(TxtAutoComplete, 500);
            //}
            
        });

        function TxtAutoComplete() {
            var AccountwithUser = "{'searchWord':'" + searchword + "'," + " 'AccountHolderId':' " + indexId + "'}";
            $('#OilTableContainer').jtable('load', { Id: AccountwithUser });
            $('#txtAutoCompleteoils').focus();
        }
        //////////////////////Account Holder Search box Loads jtable on clear//////////////////////////////////
        $("#txtBoxAutoComplete").on('keyup', function () {
            if (!this.value) {
                indexId = ' ';
                TxtAutoComplete();
                
                    $("#ctl00_SitePlaceHolder_divUser1").css({ display: "none" });
                    $("#ctl00_SitePlaceHolder_divUser2").css({ display: "none" });
                    $("#ctl00_SitePlaceHolder_divUser3").css({ display: "none" });

                    $("#lblUserFirstNameDisplay").html("");
                    $("#lblUserLastNameDisplay").html("");
                    $("#lblBirthdateDisplay").html("");
               
              
            }
        });
        //////////////////////
        if (indexId === '' || indexId === 0) { $('#addrecord-oilTableContainer').show(); }


        $("#txtBoxAutoComplete").on('focus mouseup', function () {
            if ($.trim($(this).val() === '')) {
                $(this).autocomplete("search", "*");
            } else {
                $(this).autocomplete("search", $(this).val());
            }
        });

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
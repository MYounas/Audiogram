_this = new (function _userManagement() {
    var searchword = "";
    var txtAutoCompleteDelay = null;
    var arrayCompany = [];
    var arrayId = [];
    var indexId = 0;
    var arrayCompany1 = [];


    //////////////////////////////////

    //this.SearchText = function SearchText(str) {
    //    $("#txtBoxAutoComplete").autocomplete({
    //        source: function (request, response) {
    //            $.ajax({
    //                type: "POST",
    //                contentType: "application/json; charset=utf-8",
    //                url: "DriverManagement.aspx/GetDrivers",
    //                data: "{'Customers':'" + document.getElementById('txtBoxAutoComplete').value + "'}",
    //                dataType: "json",
    //                success: function (data) {

    //                    var listCustomers = [];
    //                    listCustomers = data.d;

    //                    console.log(data.d);

    //                    arrayCompany.length = 0;
    //                    arrayId.length = 0;
    //                    for (var aIndex = 0; aIndex < listCustomers.length; aIndex++) {
    //                        var aIndexvalue = listCustomers[aIndex].split('|');
    //                        arrayCompany.push(aIndexvalue[0]);
    //                        arrayId.push(aIndexvalue[1]);
    //                    }
    //                    console.log(arrayId, 'arrayId');
    //                    //alert(arrayId);
    //                    //alert(arrayCompany);

    //                    var limit = parseInt($("#txtBoxAutoComplete").attr('data-limit'));
    //                    if (limit > 0) {
    //                        arrayCompany = arrayCompany.splice(0, limit);
    //                    }

    //                    response(arrayCompany);
    //                },
    //                error: function (result) {
    //                    console.log(arrayId, 'arrayId');
    //                },
    //            });
    //        },
    //        minLength: 1,
    //        cacheLength: 0,
    //        select: function (event, ui) {

    //            //here write a trim logic
    //            console.log(ui.item.value);
    //            var getResponse = ui.item.value;
    //            var matchFound = getResponse.match(/\((.*)\)/);
    //           // alert(matchFound[1]);
    //            $('#hdnUserName').val(matchFound[1]);
    //            //ui.item.value = matchFound[1];

    //            var userDemographicArray = getResponse.split('(');
    //           console.log(userDemographicArray);
    //           var userNameArray = userDemographicArray[0];
    //            var userBirthDate = userDemographicArray[1].split(')')[1].trim();
    //            userBirthDate = userBirthDate.split(':');
    //            userBirthDate = userBirthDate[1];

    //            console.log(userNameArray);
    //            var userNames = userNameArray.trim().split(',');
    //            console.log(userNames);
    //            var userFirstName = userNames.length > 1 ? userNames[1].trim() : "";
    //            var userLastName = userNames[0].trim();

    //            console.log("userFirstName");
    //            console.log(userFirstName);
    //            console.log(userLastName);

    //            ui.item.value = userLastName + " " + userFirstName;

    //            //alert(userFirstName);
    //            //alert(userLastName);
    //            //alert(userBirthDate);

    //            $("#ctl00_SitePlaceHolder_divUser1").css({ display: "block" });
    //            $("#ctl00_SitePlaceHolder_divUser2").css({ display: "block" });
    //            $("#ctl00_SitePlaceHolder_divUser3").css({ display: "block" });

    //            userFirstName != "" ? $("#lblUserFirstNameDisplay").html(userFirstName) : $("#lblUserFirstNameDisplay").html("Not found");
    //            userLastName != "" ? $("#lblUserLastNameDisplay").html(userLastName) : $("#lblUserLastNameDisplay").html("Not found");
    //            userBirthDate != "" ? $("#lblBirthdateDisplay").html(userBirthDate) : $("#lblBirthdateDisplay").html("Not found");
    //            if (userBirthDate == undefined) { $("#lblBirthdateDisplay").html("Not found"); userBirthDate = ""; }


    //            //old logic
    //            var selectedItem = ui.item.value;
    //            //document.getElementById("txtCustomerName").innerHTML = selectedItem + ' Users';
    //            console.log(arrayCompany);

    //            arrayCompany1.length = 0;
    //            for (var aIndex = 0; aIndex < arrayCompany.length; aIndex++) {
    //                var aIndexvalue = arrayCompany[aIndex].split(',');
    //                var fullName = "";
    //                if (aIndexvalue[1].trim().match(/\((.*?)\)/))
    //                    fullName = aIndexvalue[0].trim();
    //                else if (!aIndexvalue[1].trim().match(/\((.*?)\)/)) {
    //                    if(aIndexvalue[1].trim().indexOf(':')==-1)
    //                    fullName = aIndexvalue[0].trim() + " " + aIndexvalue[1].trim();
    //                }
                    
    //                    arrayCompany1.push(fullName.trim()); 
                    
    //            }
    //            console.log(arrayCompany1);
    //            console.log(selectedItem);
    //            var indexItem = arrayCompany1.indexOf(selectedItem.trim());

    //            indexId = arrayId[indexItem];
    //            arrayId.length = 0;

             
    //            var AccountwithUser = "{'searchWord':'" + searchword + "'," + " 'AccountHolderId':' " + indexId + "'}";
    //            $('#DriverTableContainer').jtable('load', { Id: AccountwithUser });
    //            $('#txtAutoCompletedrivers').focus();
    //            $('#addrecord-driverTableContainer').show();
    //        }
    //    });
    //}
    //////////////////////////////////

    this._PageLoaded = function _PageLoaded() {
        console.log(global.pageName, 'Page');

        _this.is_PageLoaded = true;

        $('#DriverTableContainer').jtable({

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
                deleteConfirmation: 'Are you sure you want to delete driver?',
                deleteSuccessfully: 'Driver has been deleted successfully.',
                updateSuccessfully: 'Driver is updated successfully.',
                addSuccessfully: 'Driver is saved successfully.'
            },
            actions: {
                listAction: '/Modules/Management/DriverManagement.aspx/RecordList',
                createAction: '/Modules/Management/DriverManagement.aspx/CreateRecord',
                updateAction: '/Modules/Management/DriverManagement.aspx/UpdateRecord',
                deleteAction: '/Modules/Management/DriverManagement.aspx/DeleteRecord'
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
               
                FatherName: {
                    title: 'Father Name:*',
                    edit: true,
                    list: true,
                    create: true,
                    width: '11%',
                    maxlength: '50',
                    sequenceNumber:3
                },
                NIC: {
                    title: 'NIC:',
                    edit: true,
                    list: true,
                    create: true,
                    width: '11%',
                    maxlength: '50',
                    sequenceNumber:4
                },
                NICExpiryDate: {
                    title: 'NIC Expiry Date:',
                    edit: true,
                    displayFormat: 'yy-mm-dd',
                    list: true,
                    create: true,
                    type: 'date',
                    maxDate: 0,
                    //endDate: new Date(),
                    sequenceNumber: 5
                },
                DOB: {
                    title: 'Date Of Birth:',
                    edit: true,
                    displayFormat: 'yy-mm-dd',
                    list: true,
                    create: true,
                    type: 'date',
                    maxDate: 0,
                    //endDate: new Date(),
                    sequenceNumber: 6
                },
                Cell: {
                    title: 'Cell :',
                    edit: true,
                    list: true,
                    create: true,
                    width: '11%',
                    maxlength: '50',
                    sequenceNumber: 7
                },
                License: {
                    title: 'Driving License :',
                    edit: true,
                    list: true,
                    create: true,
                    width: '11%',
                    maxlength: '50',
                    sequenceNumber: 8
                },
                LicenseExpiryDate: {
                    title: 'License Expiry Date:',
                    edit: true,
                    displayFormat: 'yy-mm-dd',
                    list: true,
                    create: true,
                    type: 'date',
                    maxDate: 0,
                    //endDate: new Date(),
                    sequenceNumber: 9
                },
                Address: {
                    title: 'Address:',
                    list: false,
                    type: 'textarea',
                    edit: 'true',
                    create: 'true',
                    maxlength: '250',
                    onpaste: "return global.TextAreaMaxLengthOnPaste(this,'250',event);",
                    onpress: "return global.TextAreaMaxLength(this,'250',event);",
                    sequenceNumber:10
                },
                CurrentAddress: {
                    title: 'Current Address:',
                    list: false,
                    type: 'textarea',
                    edit: 'true',
                    create: 'true',
                    maxlength: '250',
                    onpaste: "return global.TextAreaMaxLengthOnPaste(this,'250',event);",
                    onpress: "return global.TextAreaMaxLength(this,'250',event);",
                    sequenceNumber: 11
                },
                IsActive: {
                    title: 'Status:',
                    list: true,
                    edit: true,
                    width: '8%',
                    type: 'checkbox',
                    defaultValue: 'true',
                    values: { 'false': 'InActive', 'true': 'Active' },
                    sequenceNumber: 12,
                    inputClass: 'subject-edit-status'
                }
            },
            formCreated: function (event, data) {
                if (indexId == ' ') {
                    indexId = 0;
                }
            

                data.form.find('input[name="DOB"]').addClass('validate[custom[dateFormat]]');
                data.form.find('input[name="Name"]').addClass('validate[required,maxSize[50],minSize[4]]');//,custom[onlyLetterNumber]
                data.form.find('input[name="FatherName"]').addClass('validate[maxSize[50]]');
                data.form.find('input[name="NIC"]').addClass('validate[maxSize[40]]');
               data.form.parent().css('width', '340px').css('height', '400px');
               $(data.form).addClass("custom_horizontal_form_field");
             
               var headerText = $(data.form).parents('.ui-dialog').find('.ui-dialog-title').text() || '';
               if (headerText == 'Add new record') {
                   headerText = 'Add New Driver';
               } else if (headerText == 'Edit Record') {
                   headerText = 'Edit Driver';
               }

               $('.subject-edit-status').on('change', function () {
                   $(this).next('.jtable-option-text-clickable').text('Active');
               }).next('.jtable-option-text-clickable').text('Active');

               $(data.form).parents('.ui-dialog').find('.ui-dialog-title').text(headerText);

               $('#Edit-BirthdateCreate').datepicker({ dateFormat: 'dd-mm-yy', maxDate: 0 });
               if (headerText == 'Add New Driver') {
                   $("#Edit-BirthdateCreate").datepicker().datepicker("setDate", new Date());
                   
               }

              

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
            addRecordButton: $('#addrecord-driverTableContainer')

        });



        indexId = $('#hdnAccountHolderSignup').val();
        var AccountwithUser = "{'searchWord':'" + searchword + "'," + " 'AccountHolderId':' " + indexId + "'}";
        $('#DriverTableContainer').jtable('load', { Id: AccountwithUser });


        //////////////////////User Search box Loads jtable on key up//////////////////////////////////
        $("#txtAutoCompletedrivers").keyup(function () {
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
            $('#DriverTableContainer').jtable('load', { Id: AccountwithUser });
            $('#txtAutoCompletedrivers').focus();
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
        if (indexId == '' || indexId == 0) { $('#addrecord-driverTableContainer').show(); }


        $("#txtBoxAutoComplete").on('focus mouseup', function () {
            if ($.trim($(this).val() == '')) {
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
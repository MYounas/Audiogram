/// <reference path="../Service/WebService.asmx" />

if (!window.global) {
    var global = {};
    global.page = {};
    global.customValidations = {};
};


global.pageLoaded = function pageLoaded() {
    //fuellevelgaug
    global.is_PageLoaded = true;


    // Validation Engine
    /*
    var ve_defaults = $.validationEngine.defaults;
    ve_defaults.scroll = true;
    ve_defaults.focusFirstField = true;
    ve_defaults.autoHidePrompt = true;
    ve_defaults.autoHideDelay = 7000;
    ve_defaults.addFailureCssClassToField = 'invalid';
    ve_defaults.promptPosition = "topRight";
    */

    $(".ve").on("blur", function () {
        var item = $(this);
        var delay = 200;
        setTimeout(function () {
            item.validationEngine('validate');
        }, delay);
        //$(this).validationEngine('validate');
    });

    /*
    ve_defaults.onValidationComplete = onValidationComplete;
    ve_defaults.onSuccess = onSuccess;
    ve_defaults.onFailure = onFailure;
    ve_defaults.onFieldFailure = onFieldFailure;
    */

    // Zebra DatePicker
    /***************************************************************
    $('.zdatepicker').Zebra_DatePicker({
        direction: 0,    // boolean true would've made the date picker future only
        // but starting from today, rather than tomorrow
        format: 'Y-m-d',
        default_position: 'below',
        inside: false,
        readonly_element: false,
        start_date: false,
        onOpen: function () {
            var offleft = $(this).offset().left + 'px';
            var offtop = $(this).offset().top + 23 + 'px';
            $('.Zebra_DatePicker.dp_visible').css({
                'left': offleft,
                'top': offtop,
            });
            // Fixes autocomplete issue
            $(this).attr('autocomplete', 'off');

            // Fixes hide on blur and fixes updating value after selecting date
            $('.Zebra_DatePicker_Icon').on('keydown', function (e) {
                $(this).unbind('keydown');
                $(this).prev('.zdatepicker').data('Zebra_DatePicker').hide();
            });

        },
        onSelect: function (date, date_format, date_obj, item) {
            // Fixes Validation on Selecting Date
            item.validationEngine('validate');
        }

    });

    // Future-Only Datepicker starting with today
    (function datepicker_future() {
        var datepicker = $('.zdatepicker.future-dates');
        var datepicker_data = datepicker.data('Zebra_DatePicker') ? datepicker.data('Zebra_DatePicker') : false;
        if (datepicker_data) {
            datepicker_data.update({
                direction: true,
            });
        }
        // Add Validation Class
        var date = new Date(Date.now());
        var today = date.format('yyyy-MM-dd');
        datepicker.each(function () {
            if (!$(this).hasClass('validate[future[' + today + ']]')) {
                $(this).addClass('validate[future[' + today + ']]');
            }
        });
    })();

    // All Common Masks
    (function common_masks() {

        var decimalMaskOpt = {
            "placeholder": '_',
        };

        function changeMaskColor(this_elem, placeholder) {
            var defaultColor = '#555';
            var lastPlaceholderChar = placeholder.substr(-1);
            var this_elem_val = ($(this_elem).val()) ? $(this_elem).val() : '';
            if (this_elem_val == '' || this_elem_val.lastIndexOf(lastPlaceholderChar) != -1) {
                this_elem.css('color', '#999');
            } else {
                this_elem.css('color', defaultColor);
            }
        }

        function maskPointColor(e) {
            if (e.type == 'keyup') {
                if ($(this).val() == '' && (e.keyCode == 190 || e.keyCode == 110)) {
                    $(this).val('0.');
                }
            }
            var placeHolder = decimalMaskOpt.placeholder;
            var this_ = $(this);
            setTimeout(function () {
                changeMaskColor(this_, placeHolder);
            }, 10);
        }

        // Decimal Masks
        (function decimal_masks() {
            var maskDecimalStr = '';

            $('.mask-decimal').each(function () {
                var maxMaskDecimals = ($(this).attr('data-maskdecimals')) ? parseInt($(this).attr('data-maskdecimals')) : 2;
                var has_maxValue = ($(this).attr('data-maskmaxvalue')) ? true : false;
                var maxValue = has_maxValue ? $(this).attr('data-maskmaxvalue') : '1000000';
                maxVal_len = maxValue.length;
                for (var i = 1; i <= maxMaskDecimals; i++) {
                    maskDecimalStr += '9';
                }
                if (has_maxValue) {
                    $(this).inputmask('9{1,' + maxVal_len + '}[.' + maskDecimalStr + ']');
                }
            }).on('mouseenter keyup mouseleave blur', maskPointColor);


            // Rate Mask
            $('.mask-6decimal').inputmask('9{1,2}[.999999]', decimalMaskOpt).on('mouseenter keyup mouseleave blur', maskPointColor)
        })();

        // Masked DatePicker
        (function datepicker_mask() {
            var dateMaskOpt = {
                "placeholder": 'yyyy-mm-dd',
            };
            $('.zdatepicker').inputmask('yyyy-mm-dd', dateMaskOpt).on('mouseenter keyup blur', function () {
                var placeHolder = dateMaskOpt.placeholder;
                changeMaskColor($(this), placeHolder);
            });
        })();
    })();
    ****************************************************************/

    /******  JQUERY MENU  *******/

    // MENU JSON

    global.mJson = [
            {
                "id": "content",
                "name": "Content",
                "url": "",
                "children": [
                    {
                        "pid": "content",
                        "id": "search_content",
                        "name": "Search Content",
                        "url": "Modules/Content/ContentSearch.aspx",
                        "children": ""
                    },
                    {
                        "pid": "content",
                        "id": "add_content",
                        "name": "Add Content",
                        "url": "",
                        // LEVEL 2
                        "children": [
                            {
                                "pid": "add_content",
                                "id": "image",
                                "name": "Image",
                                "url": "Modules/Content/ManageImage.aspx",
                                "children": ""
                            },
                            {
                                "pid": "add_content",
                                "id": "video",
                                "name": "Video",
                                "url": "Modules/Content/ManageVideo.aspx",
                                "children": ""
                            },
                            {
                                "pid": "add_content",
                                "id": "description",
                                "name": "Description",
                                "url": "Modules/Content/ManageDescription.aspx",
                                "children": ""
                            }
                        ]
                    }
                ]
            },

            // SUB ITEMS
            {
                "id": "customer",
                "name": "Customer",
                "url": "",
                "children": [
                    {
                        "pid": "customer",
                        "id": "customer_content",
                        "name": "Customer Content",
                        "url": "Modules/Content/CustomerContent.aspx",
                        "children": ""
                    },
                    {
                        "pid": "customer",
                        "id": "default_content",
                        "name": "Default Content",
                        "url": "Modules/Content/DefaultContent.aspx",
                        "children": ""
                    }
                ]
            },
            // SUB2 ITEMS
            {
                "id": "globals",
                "name": "Globals",
                "url": "",
                "children": [
                    {
                        "pid": "globals",
                        "id": "add_global_defaults",
                        "name": "Add Global Defaults",
                        "url": "",
                        "children": [
                            {
                                "pid": "add_global_defaults",
                                "id": "add_image",
                                "name": "Image",
                                "url": "Modules/Content/ManageImage.aspx?IsGlobal=true",
                                "children": ""
                            },
                            {
                                "pid": "add_global_defaults",
                                "id": "add_video",
                                "name": "Video",
                                "url": "Modules/Content/ManageVideo.aspx?IsGlobal=true",
                                "children": ""
                            },
                            {
                                "pid": "add_global_defaults",
                                "id": "add_description",
                                "name": "Description",
                                "url": "Modules/Content/ManageDescription.aspx?IsGlobal=true",
                                "children": ""
                            }
                        ]
                    }
                ],
            },
            {
                "id": "management",
                "name": "Management",
                "url": "",
                "children": [
                    {
                        "pid": "management",
                        "id": "manage_users",
                        "name": "Manage Users",
                        "url": "Modules/Management/ParticipantManagement.aspx",
                        "children": ""
                    },
                    {
                        "pid": "management",
                        "id": "manage_customers",
                        "name": "Manage Customers",
                        "url": "Modules/Management/OperatorManagement.aspx",
                        "children": ""
                    }
                ]
            },
            //{ "id": "5", "name": "test5", "url": "http://www.eee.com" }
    ];

    //var menuJsonString = JSON.stringify(global.mJson);
    //$('#menudata').val(menuJsonString);
    var menuJson = $.parseJSON($('#menudata').val());

    populateMenu(menuJson);
    // POPULATE MENU
    function populateMenu(jsonObj) {
        var mJson = jsonObj;
        //var mJsonString = JSON.stringify(mJson);
        //global.menuJson = $.parseJSON(mJsonString);
        
        var caretStr = '<span class="caret"></span>';

        setTopLevel(mJson);

        function setTopLevel(mJson) {
            var topItem = '';
            $(mJson).each(function (i, topElem) {
                var top = topElem;
                var topItem_ID = top.id;
                var topItem_NAME = top.name;
                var topItem_URL = ((top.url !='') && (top.url.split('/')[0] == '/')) ? top.url : '/' + top.url;
                var topItem_hasChild = top.children && top.children.length ? true : false;
                //topItem += '<li  id="' + topItem_ID + '" class="top-item"><a href="' + ((topItem_hasChild) ? '#' : topItem_URL) + '">' + topItem_NAME + '</a>' + ((topItem_hasChild) ? caretStr : '') + '</li>';
                $('.menu.top > ul').append('<li  id="' + topItem_ID + '" class="top-item"><a href="' + ((topItem_hasChild) ? '#' : topItem_URL) + '">' + topItem_NAME + '</a>' + ((topItem_hasChild) ? caretStr : '') + '</li>');
                //console.log(topItem_ID, 'TopID');
                if (topItem_hasChild) {
                    setSubLevel(topItem_ID, topElem);
                }
            });

        };

        function setSubLevel(parentID, jsonObj) {
            var levelClass = 'sub';
            $('#' + parentID).append('<ul class="' + levelClass + '"></ul>');
            //console.log(jsonObj, 'JsonObj');
            $(jsonObj.children).each(function (i, subElem) {
                var sub = subElem;
                var subItem_PID = sub.pid;
                var subItem_ID = sub.id;
                var subItem_NAME = sub.name;
                var subItem_URL = ((sub.url != '') && (sub.url.split('/')[0] == '/')) ? sub.url : '/' + sub.url;
                var subItem_hasChild = sub.children && sub.children.length ? true : false;
                //subItem += '<li class="' + ((subItem_hasChild) ? 'item' : '') + '"  id="' + subItem_ID + '"><a href="' + ((subItem_hasChild) ? '#' : subItem_URL) + '">' + subItem_NAME + '</a></li>';
                $('#' + parentID + ' .' + levelClass).append('<li class="' + ((subItem_hasChild) ? 'item' : '') + '"  id="' + subItem_ID + '"><a href="' + ((subItem_hasChild) ? '#' : subItem_URL) + '">' + subItem_NAME + '</a></li>');
                //console.log(subItem, 'subItems');
                if (subItem_hasChild) {
                    setSubLevel2(subItem_ID, subElem);
                }

            });
        }

        function setSubLevel2(parentID, jsonObj) {
            var levelClass = 'sub2';
            $('#' + parentID).append('<ul class="' + levelClass + '"></ul>');
            //console.log(jsonObj, 'JsonObj');
            $(jsonObj.children).each(function (i, subElem) {
                var sub = subElem;
                var subItem_PID = sub.pid;
                var subItem_ID = sub.id;
                var subItem_NAME = sub.name;
                var subItem_URL = ((sub.url != '') && (sub.url.split('/')[0] == '/')) ? sub.url : '/' + sub.url;
                var subItem_hasChild = sub.children && sub.children.length ? true : false;
                $('#' + parentID + ' .' + levelClass).append('<li class="' + ((subItem_hasChild) ? 'item' : '') + '"  id="' + subItem_ID + '"><a href="' + ((subItem_hasChild) ? '#' : subItem_URL) + '">' + subItem_NAME + '</a></li>');
            });
        }

    };

    
    // Level 1 Menu Items
    $('.top-item').on('mouseover', function () {
        $('.sub', this).stop(true).delay(70).slideDown(100);
    });
    $('.top-item').on('mouseout', function () {
        $('.sub', this).stop(true, true).delay(70).slideUp(100);
    });
    
    // Level 2 Menu Items

    // Add > sign to Sub-level Parent 
    $('.sub .item').each(function () {
        var itemText = $(this).children('a').text();
        $(this).children('a').html(itemText + '&nbsp;<span class="menu-right-arrow"></span>');
    });

    $('.sub .item').on('mouseover', function () {
        // Get Position Top of Item
        var itemPosTop = $(this).position().top;
        //var sub2elemPos = $('.sub2', this).position().top;
        //console.log(sub2elemPos, 'sub2elemPos');
        $('.sub2', this).stop(true).delay(200).fadeIn(
            {
                duration: 300,
                start: function () {
                    //$(this).css('top', itemPosTop - 31 + 'px');
                    $(this).css('top', itemPosTop - 2 + 'px');
                }
            }
        );
        //$('.sub2', this).stop(true).delay(200).effect('slide', {direction: 'left'}, 200);
    });
    $('.sub .item').on('mouseout', function () {
        $('.sub2', this).stop(true,true).delay(400).fadeOut(300);
    });

    /********* // JQUERY MENU  **********/

    // Fix Jtable Preloader Position
    $('.jtable-busy-message').each(function () {
        var parentWidth = $(this).parent('.jtable-main-container').width();
        var thisWidth = $(this).innerWidth();
        var width = ((parentWidth/2) - thisWidth) - 40;
        $(this).css({
            'left': width + 'px' 
        });
    });

    (function jtableStateChange() {
        //$('.jt-wrap').each(function () {
            $('.jt-header').each(function () {
                var dataHeadId = $(this).attr('data-jtableindex');
                if ($('input', this).prop('disabled')) {
                    $('.jt-body').each(function () {
                        var dataBodyId = $(this).attr('data-jtableindex');
                        if (dataBodyId == dataHeadId) {
                            $('input', this).attr('disabled', 'disabled');
                        }
                    })
                }
            });
        //});
    })();

    (function addHoverTitle() {
        $('.jt-header .title').each(function () {
            var titleText = $.trim($(this).text());
            if ($(this).attr('title') == undefined)
            {
                $(this).attr('title', titleText);
            } 
        });
    })();

    
    (function fix_width_overflow() {
        if ($(document).width() > screen.availWidth && screen.availWidth <= 1024) {
            var width = $(document).width() + 60;
            $('html').css('width', width + 'px');
        }
    })();

    (function select_picker() {
        
           $(document).on('mouseup', function (e) {
               $('.dropdown-menu.open:visible').each(function () {
                   $(this).hide();
               })
           });
           

        $('button.selectpicker').each(function () {
            $(this).on('click', function () {
                $(this).next('.dropdown-menu.open').toggle();
            });

            var this_selectpicker = $(this);
            
            $(this).next('.dropdown-menu.open').on('keydown', function (e) {
                this_elem = $(this);
                if (e.keyCode == '13') {
                    setTimeout(function () {
                        $('li.active a', this_elem).trigger('click');
                        this_elem.hide();
                    }, 100)
                }
                if (e.keyCode == '9') {
                    this_elem.hide();
                }
            });

            $(this).next('.dropdown-menu.open li.active a').find('li').on('click', function () {
                console.log('a clicked');
                setTimeout(function () {
                    this_selectpicker.next('.dropdown-menu.open').hide();
                }, 50)
            })

        });
        
    })();


    $(document).on('click', function (e) {
        var is_menu = $(e.target).parents('.menu-wrap.collapse').length == 0 ? false : true;
        var is_trigger = $(e.target).parents('.trigger-menu').length == true || $(e.target).hasClass('trigger-menu') == true;
        if (!is_menu && !is_trigger) {
            $('.menu-wrap.collapse').removeClass('in');
        }
        // Menu Open Resize Fix
            $(window).on('resize', function (e) {
                if ($('.trigger-menu-wrap.visible-xs').is(':visible')) {
                    $('.menu-wrap.collapse').removeClass('in');
                }
            });
    });

    
    console.log("Global PageLoaded");
};


//if (global.page._company.is_executed) {
//};

///////////////////////////////////

$.fn.setCursorToTextEnd = function () {
    $initialVal = this.val();
    this.val($initialVal + ' ');
    this.val($initialVal);
};


//global.addTopPanelPagination = function (e, data) {
//    if ($('#' + e.target.id + ' .top-panel').length > 0) {
//        $('#' + e.target.id + ' .top-panel').remove();
//    }
//    $('.jtable-goto-page', '#' + e.target.id + ' .jtable-bottom-panel').not('.top-panel').each(function () {
//        var elem = $(this);
//        if ($(this).siblings('.jtable-page-list').length > 0) {
//            $(this).prependTo(elem.parent('.jtable-left-area'));
//        } else {
//           // $(this).insertAfter(elem.siblings('.jtable-page-number-previous'));
//        }
//    });
    
  
//    var cloned = $('#' + e.target.id + ' .jtable-bottom-panel').clone().prependTo('#' + e.target.id + ' .jtable-main-container').addClass('top-panel');

//    $('.jtable-page-list', cloned).each(function (i, elem) {
//        $('span', this).each(function (j, el) {
//            if ($(el).hasClass('jtable-page-info')) {
//                return;
//            }
//            $(this).attr('data-index', j);
//        });
//        $('span', this).on('click', function () {
//            var dataindex = parseInt($(this).attr('data-index'));
//            $('.jtable-page-list span', $('#' + e.target.id + ' .jtable-bottom-panel').not('.top-panel'))
//            .eq(dataindex).trigger('click');
//        });
//    });

//    var bottompanelOnly = $('#' + e.target.id + ' .jtable-bottom-panel').not('.top-panel');

//    var gotopage_selected = $('.jtable-goto-page select option:selected', bottompanelOnly).val();
//    var pagesize_selected = $('.jtable-page-size-change select option:selected', bottompanelOnly).val();

//    $('.jtable-goto-page select', cloned).val(gotopage_selected);
//    $('.jtable-page-size-change select', cloned).val(pagesize_selected);
    
//    $('.jtable-goto-page select', cloned).on('change', function () {
//        var elem = $(this);
//        setTimeout(function () {
//            var pageselected = $('option:selected', elem).val();
//            $('.jtable-goto-page select', bottompanelOnly).val(pageselected).change();
//        }, 150)
//    });

//    $('.jtable-page-size-change select', cloned).on('change', function () {
//        var elem = $(this);
//        setTimeout(function () {
//            var pageSizeSelected = $('option:selected', elem).val();
//            $('.jtable-page-size-change select', bottompanelOnly).val(pageSizeSelected).change();
//        }, 150)
//    });

//}

global.avoidKeys = function () {
    // Left
    // Up
    // Right
    // Down
    // Add KeyCodes Below to avoid in Jtable Textboxes
    return [37, 38, 39, 40];
}

global.getBrowser = (function () {
    var BrowserDetect = {
        init: function () {
            this.browser = this.searchString(this.dataBrowser) || "Other";
            this.version = this.searchVersion(navigator.userAgent) || this.searchVersion(navigator.appVersion) || "Unknown";
        },
        searchString: function (data) {
            for (var i = 0; i < data.length; i++) {
                var dataString = data[i].string;
                this.versionSearchString = data[i].subString;

                if (dataString.indexOf(data[i].subString) !== -1) {
                    return data[i].identity;
                }
            }
        },
        searchVersion: function (dataString) {
            var index = dataString.indexOf(this.versionSearchString);
            if (index === -1) {
                return;
            }

            var rv = dataString.indexOf("rv:");
            if (this.versionSearchString === "Trident" && rv !== -1) {
                return parseFloat(dataString.substring(rv + 3));
            } else {
                return parseFloat(dataString.substring(index + this.versionSearchString.length + 1));
            }
        },

        dataBrowser: [
            { string: navigator.userAgent, subString: "Chrome", identity: "Chrome" },
            { string: navigator.userAgent, subString: "MSIE", identity: "Explorer" },
            { string: navigator.userAgent, subString: "Trident", identity: "Explorer" },
            { string: navigator.userAgent, subString: "Firefox", identity: "Firefox" },
            { string: navigator.userAgent, subString: "Safari", identity: "Safari" },
            { string: navigator.userAgent, subString: "Opera", identity: "Opera" }
        ]

    };

    //console.log(BrowserDetect.browser + BrowserDetect.version);
    BrowserDetect.init();
    return {
        'name': BrowserDetect.browser,
        'version': BrowserDetect.version
    }
})();

global.pageName = (function () {
    if (global.getBrowser.name == 'Explorer' || global.getBrowser.name == 'Safari') {
        var page = {};
        page.pathname = document.location.pathname;
    } else {
        var page = new URL(document.URL);
    }
    var path = page.pathname;
    var path_arr = path.split('/');
    var pagename = path_arr[path_arr.length - 1];
    return pagename;
})();

global.ConcatMessage = function (str1, str2) {
    if (str1 != "undefined" && str1 != null && str1.length > 0) {
        return str1 + '\n' + str2;
    } else {
        return str2;
    }
};

/* TextArea MaxLength */
global.MaxLengthOnPaste = function MaxLengthOnPaste(element, maxLength, e) {
    var pastText = e.clipboardData.getData("Text");
    if ((element.value.length + pastText.length) >= maxLength) {
        e.preventDefault();
    }
};

global.MaxLength = function MaxLength(element, maxLength, e) {
    var trimmed, is_limit;
    $(element).on('blur', function (e) {
        is_limit = $(this).val().length > maxLength;
        if (is_limit) {
            trimmed = $.trim($(element).val().substr(0, maxLength));
            $(this).val(trimmed);
        }
    });
    $(element).on('paste', function (e) {
        setTimeout(function () {
            var val = $(element).val();
            is_limit = val.length > maxLength;
            if (is_limit) {
                var truncated_val = val.substr(maxLength, val.length);
                $(element).val($.trim(val.substr(0, maxLength)));
                console.log('Truncated: ' + truncated_val);
            }
        }, 100)
    });
    $(element).on('keydown', function (e) {
        is_limit = $(this).val().length >= maxLength;
        if (is_limit) {
            var charCode = (e.which) ? e.which : event.keyCode
            switch (charCode) {
                case 8:
                case 37:
                case 38:
                case 39:
                case 40:
                case 46:
                    return true;
                    break;
                default:
                    e.preventDefault();
                    return false;
                    break;
            }
        }
    });
};

global.TextAreaMaxLength = function callmaxlength(field, maxChars, event) {
    var key = event.which;
    console.log(key);
    //all keys including return.
    if (key >= 33 || key == 13 || key == 32) {
        var maxLength = maxChars;
        console.log(maxLength);
        var length = $(field).val().length;
        if (length >= maxLength) {
            event.preventDefault();
        }
    }
};

global.TextAreaMaxLengthOnPaste = function maxLengthPaste(field, maxChars, e) {

    console.log("maxchars " + field);
    var length = $(field).val().length;
    // event.returnValue = false;
    setTimeout(function () {
        $(field).val($(field).val().substr(0, maxChars));
    }, 100)

};

global.customValidations.required_Dropdown = function required_Dropdown(field, rules, i, options) {
    if (field.val() == "0") {
        return options.allrules.required.alertText;
    }
};

global.click_validate_group = function click_validate_group(e) {

    var fgclass = '.' + e.data.fieldgroup;
    var btnID = $(this).attr('id');
    _this.is_form_valid = true;
    _this.invalid_fields = [];
    _this.num_invalid_fields = 0;

    $(".ve" + fgclass).each(function (i, elem) {
        _this.is_field_valid = (!$(this).prop('disabled')) ? $(this).validationEngine('validate') : true;
        _this.is_form_valid = _this.is_form_valid && _this.is_field_valid;
 

        if ((!_this.is_field_valid) && (!_this.is_form_valid)) {
            // Form Invalid
            e.preventDefault();
            global.page.Prm.abortPostBack();
            _this.invalid_fields[_this.num_invalid_fields] = { elem: $(elem) };
            _this.num_invalid_fields++;
        };
    });

    if (_this.num_invalid_fields > 0) {
        _this.first_invalid_field = $(_this.invalid_fields).first().get(0).elem;
        _this.last_invalid_field = $(_this.invalid_fields).last().get(0).elem;

        // Force Auto Scroll Animate to First Invalid Field
        $('html,body').animate({
            scrollTop: $('.invalid').eq(0).position().top - 50
        }, '500', 'swing', function () {
            _this.first_invalid_field.focus();
        });
    }
    console.log(_this.is_form_valid, "is_form_valid?");
};

global.detach_group_validation = function detach_group_validation(e) {
    var fgclass = '.' + e.data.fieldgroup;
    $("#aspnetForm").validationEngine('detach');
    $(".ve" + fgclass).each(function () {
        $(this).validationEngine('attach');
    });
};

global.customValidations.required_Dropdown = function required_Dropdown(field, rules, i, options) {
    if (field.val() == "0") {
        return options.allrules.required.alertText;
    }
};

global.customValidations.name_plus_email = function name_plus_email(field, rules, i, options) {
    if (field.val().indexOf('@') != -1) {
        var regx = options.allrules.email.regex;
        if (!regx.test(field.val())) {
            return options.allrules.email.alertText;
        }
    }
};

global.customValidations.time = function time(field, rules, i, options) {
    var timestring = field.val();
    var timestring_arr = timestring.split(':');
    var hour = parseInt(timestring_arr[0]);
    var min = parseInt(timestring_arr[1]);
    var sec = parseInt(timestring_arr[2]);
    var is_time_valid = (hour >= 0 && hour < 24) && (min >= 0 && min <= 60) && (sec >= 0 && sec <= 60);
    if (!is_time_valid) {
        return 'Invalid Time';
    }
};

// Max X Decimal Numbers
global.customValidations.decimal_x = function decimal_x(field, rules, i, options) {
    var number = parseInt(field.val());
    var is_NaN = isNaN(number);
    var has_decimal = (field.val().indexOf('.') != -1) ? true : false;
    var val_arr_valid = !(field.val().split('.').length > 2) ? true : false;
    var val_arr = (val_arr_valid) ? field.val().split('.') : [];
    var max_decimal_len = (field.attr('data-maxdecimals')) ? field.attr('data-maxdecimals') : 2;
    var valid_decimal_length = (val_arr[val_arr.length - 1].length > 0) && (val_arr[val_arr.length - 1].length <= max_decimal_len);
    if (!val_arr_valid || is_NaN) {
        return "Invalid Decimal Number";
    }
    if (!valid_decimal_length && has_decimal) {
        return "Maximum " + max_decimal_len + " Decimal places allowed";
    }
};

// Integer Only Between 0 and 65535
global.customValidations.IntegerOnly_limit = function IntegerOnly_limit(field, rules, i, options) {
    var int = (parseInt(field.val()) >= 0) ? parseInt(field.val()) : "NaN";
    if (int == "NaN") {
        return "Invalid Integer, Must be between 0 and 65535";
    }
    if (int > 65535) {
        return "Integer must be between 0 and 65535";
    }
};

// Digits and Commas Only
global.customValidations.digits_commas_only = function digits_commas_only(field, rules, i, options) {
    var val = field.val();
    var val_len = val.length;
    var is_comma_start_end = (val[val_len - 1] == ',' || val[0] == ',') ? true : false;
    var is_comma_extra = (val.match(/,,+/g) != null) ? true : false;
    if (is_comma_start_end || is_comma_extra) {
        return "Invalid comma character";
    }
    var regex = /^(\d+)(,\d+)*$/;
    if (!regex.test(val)) {
        return "Only digits and commas are allowed";
    }
};


// Global Document Ready
global.$document_ready = (function $document_ready() {
    $(document).ready(function () {
        global.page.Prm = Sys.WebForms.PageRequestManager.getInstance();
        global.page.Prm.add_pageLoaded(global.pageLoaded);
        if (typeof _this !== "undefined")
        global.page.Prm.add_pageLoaded(_this._PageLoaded);
        //console.log('Global DocReady');
    });
    $(window).load(function () {

    });
})();

///////////////////////////////////



if (typeof anychart === 'undefined')
{
}
else
    {
    // javed Khan //

    //****************************** speedometer start here ******************************//

    var gaugephase1;
    var gaugephase2;
    var gaugephase3;
    var gaugecurrentimb;
    var gaugeacvolts;
    var gaugefreq;
    var gaugetemp;
    var gaugepressure;
    var gaugedcvolts;
    var gaugefuel;

//Phase 1 start here//
    anychart.onDocumentReady(function () {
        var stage = anychart.graphics.create('phase1');
        

        gaugephase1 = anychart.circularGauge();
        gaugephase1.container(stage);

        gaugephase1.title(null)
            .fill(null)
            .stroke(null);

        gaugephase1.title().fontWeight('normal')
            .fontFamily('Verdana')
            .fontColor('#474747')
            .fontSize('14px');

        gaugephase1.axis().labels().fontWeight('normal')
            .fontFamily('arial')
            .fontColor('#474747')
            .fontSize('12px');

        gaugephase1.data([90]);

        gaugephase1.axis().scale()
            .minimum(0)
            .maximum(220)
            .ticks({ interval: 20 })
            .minorTicks({ interval: 5 });

        gaugephase1.axis()
            .startAngle(260)
            .fill('#929292')
            .width(0)
            .sweepAngle(200)
            .ticks({ type: 'trapezium', fill: '#474747', length: 0 })
            .minorTicks({ type: 'trapezium', fill: '#474747', length: 0 });

        gaugephase1.range(0, {
            from: 0,
            to: 60,
            position: 'i',
            fill: '#d8d8d8',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugephase1.range(1, {
            from: 60,
            to: 180,
            position: 'i',
            fill: '#008b06',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugephase1.range(2, {
            from: 180,
            to: 220,
            position: 'i',
            fill: '#d50000',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugephase1.needle()
            .fill('#929292')
            .stroke('0px rgba(2,2,2,.2)')
            .startRadius('0%')
            .endRadius('90%')
            .middleRadius(0)
            .startWidth('0.1%')
            .endWidth('0.1%')
            .middleWidth('5%');

        gaugephase1.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge = anychart.circularGauge();

        internalGauge
            .data([81])
            .bounds('20%', '60%', '25%', '35%')
            .fill('none')
            .stroke('none');

        internalGauge.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge.range(1, {
            from: 95,
            to: 100,
            position: 'i',
            fill: '#731728',
            stroke: '1 #000',
            startSize: 6,
            endSize: 6,
            radius: 113,
            zIndex: 1
        });

        gaugephase1.draw();
        internalGauge.draw()
    });
    // Phase 1 close here //

//Phase 2 start here//
    anychart.onDocumentReady(function () {
        var stage = anychart.graphics.create('phase2');

        gaugephase2 = anychart.circularGauge();
        gaugephase2.container(stage);

        gaugephase2.title(null)
            .fill(null)
            .stroke(null);

        gaugephase2.title().fontWeight('normal')
            .fontFamily('Verdana')
            .fontColor('#474747')
            .fontSize('14px');

        gaugephase2.axis().labels().fontWeight('normal')
            .fontFamily('arial')
            .fontColor('#474747')
            .fontSize('12px');

        gaugephase2.data([120]);

        gaugephase2.axis().scale()
            .minimum(0)
            .maximum(220)
            .ticks({ interval: 20 })
            .minorTicks({ interval: 5 });

        gaugephase2.axis()
            .startAngle(260)
            .fill('#929292')
            .width(0)
            .sweepAngle(200)
            .ticks({ type: 'trapezium', fill: '#474747', length: 0 })
            .minorTicks({ type: 'trapezium', fill: '#474747', length: 0 });

        gaugephase2.range(0, {
            from: 0,
            to: 60,
            position: 'i',
            fill: '#d8d8d8',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugephase2.range(1, {
            from: 60,
            to: 180,
            position: 'i',
            fill: '#008b06',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugephase2.range(2, {
            from: 180,
            to: 220,
            position: 'i',
            fill: '#d50000',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugephase2.needle()
            .fill('#929292')
            .stroke('0px rgba(2,2,2,.2)')
            .startRadius('0%')
            .endRadius('90%')
            .middleRadius(0)
            .startWidth('0.1%')
            .endWidth('0.1%')
            .middleWidth('5%');

        gaugephase2.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge = anychart.circularGauge();

        internalGauge
            .data([81])
            .bounds('20%', '60%', '25%', '35%')
            .fill('none')
            .stroke('none');

        internalGauge.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge.range(1, {
            from: 95,
            to: 100,
            position: 'i',
            fill: '#731728',
            stroke: '1 #000',
            startSize: 6,
            endSize: 6,
            radius: 113,
            zIndex: 1
        });

        gaugephase2.draw();
        internalGauge.draw()
    });
    // Phase 2 close here //

    //Phase 3 start here//
    anychart.onDocumentReady(function () {
        var stage = anychart.graphics.create('phase3');

        gaugephase3 = anychart.circularGauge();
        gaugephase3.container(stage);

        gaugephase3.title(null)
            .fill(null)
            .stroke(null);

        gaugephase3.title().fontWeight('normal')
            .fontFamily('Verdana')
            .fontColor('#474747')
            .fontSize('14px');

        gaugephase3.axis().labels().fontWeight('normal')
            .fontFamily('arial')
            .fontColor('#474747')
            .fontSize('12px');

        gaugephase3.data([160]);

        gaugephase3.axis().scale()
            .minimum(0)
            .maximum(220)
            .ticks({ interval: 20 })
            .minorTicks({ interval: 5 });

        gaugephase3.axis()
            .startAngle(260)
            .fill('#929292')
            .width(0)
            .sweepAngle(200)
            .ticks({ type: 'trapezium', fill: '#474747', length: 0 })
            .minorTicks({ type: 'trapezium', fill: '#474747', length: 0 });

        gaugephase3.range(0, {
            from: 0,
            to: 60,
            position: 'i',
            fill: '#d8d8d8',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugephase3.range(1, {
            from: 60,
            to: 180,
            position: 'i',
            fill: '#008b06',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugephase3.range(2, {
            from: 180,
            to: 220,
            position: 'i',
            fill: '#d50000',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugephase3.needle()
            .fill('#929292')
            .stroke('0px rgba(2,2,2,.2)')
            .startRadius('0%')
            .endRadius('90%')
            .middleRadius(0)
            .startWidth('0.1%')
            .endWidth('0.1%')
            .middleWidth('5%');

        gaugephase3.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge = anychart.circularGauge();

        internalGauge
            .data([81])
            .bounds('20%', '60%', '25%', '35%')
            .fill('none')
            .stroke('none');

        internalGauge.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge.range(1, {
            from: 95,
            to: 100,
            position: 'i',
            fill: '#731728',
            stroke: '1 #000',
            startSize: 6,
            endSize: 6,
            radius: 113,
            zIndex: 1
        });

        gaugephase3.draw();
        internalGauge.draw()
    });
    // Phase 3 close here //

    //Temp start here//
    anychart.onDocumentReady(function () {
        var stage = anychart.graphics.create('temp');

        gaugetemp = anychart.circularGauge();
        gaugetemp.container(stage);

        gaugetemp.title(null)
            .fill(null)
            .stroke(null);

        gaugetemp.title().fontWeight('normal')
            .fontFamily('Verdana')
            .fontColor('#474747')
            .fontSize('14px');

        gaugetemp.axis().labels().fontWeight('normal')
            .fontFamily('arial')
            .fontColor('#474747')
            .fontSize('12px');

        gaugetemp.data([90]);

        gaugetemp.axis().scale()
            .minimum(0)
            .maximum(220)
            .ticks({ interval: 20 })
            .minorTicks({ interval: 5 });

        gaugetemp.axis()
            .startAngle(260)
            .fill('#929292')
            .width(0)
            .sweepAngle(200)
            .ticks({ type: 'trapezium', fill: '#474747', length: 0 })
            .minorTicks({ type: 'trapezium', fill: '#474747', length: 0 });

        gaugetemp.range(0, {
            from: 0,
            to: 60,
            position: 'i',
            fill: '#d8d8d8',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugetemp.range(1, {
            from: 60,
            to: 180,
            position: 'i',
            fill: '#008b06',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugetemp.range(2, {
            from: 180,
            to: 220,
            position: 'i',
            fill: '#d50000',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        //gaugetemp.range(3, {
        //    from: 140,
        //    to: 180,
        //    position: 'i',
        //    fill: '#c44242',
        //    stroke: '0 #000',
        //    startSize: 4,
        //    endSize: 4,
        //    radius: 108
        //});
        gaugetemp.needle()
            .fill('#929292')
            .stroke('0px rgba(2,2,2,.2)')
            .startRadius('0%')
            .endRadius('90%')
            .middleRadius(0)
            .startWidth('0.1%')
            .endWidth('0.1%')
            .middleWidth('5%');

        gaugetemp.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge = anychart.circularGauge();

        internalGauge
            .data([81])
            .bounds('20%', '60%', '25%', '35%')
            .fill('none')
            .stroke('none');

        internalGauge.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge.range(1, {
            from: 95,
            to: 100,
            position: 'i',
            fill: '#731728',
            stroke: '1 #000',
            startSize: 6,
            endSize: 6,
            radius: 113,
            zIndex: 1
        });

        gaugetemp.draw();
        internalGauge.draw()
    });
    // Temp close here //

    // Oil Pressure start here //

    anychart.onDocumentReady(function () {
        var stage = anychart.graphics.create('oil');

        gaugepressure = anychart.circularGauge();
        gaugepressure.container(stage);

        gaugepressure.title(null)
            .fill(null)
            .stroke(null);

        gaugepressure.title().fontWeight('normal')
            .fontFamily('Verdana')
            .fontColor('#474747')
            .fontSize('14px');

        gaugepressure.axis().labels().fontWeight('normal')
            .fontFamily('arial')
            .fontColor('#474747')
            .fontSize('12px');

        gaugepressure.data([45]);

        gaugepressure.axis().scale()
            .minimum(0)
            .maximum(120)
            .ticks({ interval: 20 })
            .minorTicks({ interval: 5 });

        gaugepressure.axis()
            .startAngle(260)
            .fill('#929292')
            .width(0)
            .sweepAngle(200)
            .ticks({ type: 'trapezium', fill: '#474747', length: 0 })
            .minorTicks({ type: 'trapezium', fill: '#474747', length: 0 });

        gaugepressure.range(0, {
            from: 0,
            to: 30,
            position: 'i',
            fill: '#d8d8d8',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugepressure.range(1, {
            from: 30,
            to: 100,
            position: 'i',
            fill: '#008b06',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugepressure.range(2, {
            from: 100,
            to: 120,
            position: 'i',
            fill: '#d50000',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugepressure.needle()
            .fill('#929292')
            .stroke('0px rgba(2,2,2,.2)')
            .startRadius('0%')
            .endRadius('90%')
            .middleRadius(0)
            .startWidth('0.1%')
            .endWidth('0.1%')
            .middleWidth('5%');

        gaugepressure.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge = anychart.circularGauge();

        internalGauge
            .data([81])
            .bounds('20%', '60%', '25%', '35%')
            .fill('none')
            .stroke('none');

        internalGauge.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge.range(1, {
            from: 95,
            to: 100,
            position: 'i',
            fill: '#731728',
            stroke: '1 #000',
            startSize: 6,
            endSize: 6,
            radius: 113,
            zIndex: 1
        });

        gaugepressure.draw();
        internalGauge.draw()
    });

    // Oil Pressure close here //

    // DC Voltage start here //

    anychart.onDocumentReady(function () {
        var stage = anychart.graphics.create('dcvoltage');

        gaugedcvolts = anychart.circularGauge();
        gaugedcvolts.container(stage);

        gaugedcvolts.title(null)
            .fill(null)
            .stroke(null);

        gaugedcvolts.title().fontWeight('normal')
            .fontFamily('Verdana')
            .fontColor('#474747')
            .fontSize('14px');

        gaugedcvolts.axis().labels().fontWeight('normal')
            .fontFamily('arial')
            .fontColor('#474747')
            .fontSize('12px');

        gaugedcvolts.data([28]);

        gaugedcvolts.axis().scale()
            .minimum(0)
            .maximum(30)
            .ticks({ interval: 5 })
            .minorTicks({ interval: 5 });

        gaugedcvolts.axis()
            .startAngle(260)
            .fill('#929292')
            .width(0)
            .sweepAngle(200)
            .ticks({ type: 'trapezium', fill: '#474747', length: 0 })
            .minorTicks({ type: 'trapezium', fill: '#474747', length: 0 });

        gaugedcvolts.range(0, {
            from: 0,
            to: 5,
            position: 'i',
            fill: '#d8d8d8',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugedcvolts.range(1, {
            from: 5,
            to: 25,
            position: 'i',
            fill: '#008b06',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugedcvolts.range(2, {
            from: 25,
            to: 30,
            position: 'i',
            fill: '#d50000',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugedcvolts.needle()
            .fill('#929292')
            .stroke('0px rgba(2,2,2,.2)')
            .startRadius('0%')
            .endRadius('90%')
            .middleRadius(0)
            .startWidth('0.1%')
            .endWidth('0.1%')
            .middleWidth('5%');

        gaugedcvolts.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge = anychart.circularGauge();

        internalGauge
            .data([81])
            .bounds('20%', '60%', '25%', '35%')
            .fill('none')
            .stroke('none');

        internalGauge.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge.range(1, {
            from: 95,
            to: 100,
            position: 'i',
            fill: '#731728',
            stroke: '1 #000',
            startSize: 6,
            endSize: 6,
            radius: 113,
            zIndex: 1
        });

        gaugedcvolts.draw();
        internalGauge.draw()
    });

    // DC Voltage close here //

    // AC Voltage start here //
    anychart.onDocumentReady(function () {
        var stage = anychart.graphics.create('acvoltage');

        gaugeacvolts = anychart.circularGauge();
        gaugeacvolts.container(stage);

        gaugeacvolts.title(null)
            .fill(null)
            .stroke(null);

        gaugeacvolts.title().fontWeight('normal')
            .fontFamily('Verdana')
            .fontColor('#474747')
            .fontSize('14px');

        gaugeacvolts.axis().labels().fontWeight('normal')
            .fontFamily('arial')
            .fontColor('#474747')
            .fontSize('12px');

        gaugeacvolts.data([20]);

        gaugeacvolts.axis().scale()
            .minimum(0)
            .maximum(60)
            .ticks({ interval: 10 })
            .minorTicks({ interval: 5 });

        gaugeacvolts.axis()
            .startAngle(260)
            .fill('#929292')
            .width(0)
            .sweepAngle(200)
            .ticks({ type: 'trapezium', fill: '#474747', length: 0 })
            .minorTicks({ type: 'trapezium', fill: '#474747', length: 0 });

        gaugeacvolts.range(0, {
            from: 0,
            to: 10,
            position: 'i',
            fill: '#d8d8d8',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugeacvolts.range(1, {
            from: 10,
            to: 50,
            position: 'i',
            fill: '#008b06',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugeacvolts.range(2, {
            from: 50,
            to: 60,
            position: 'i',
            fill: '#d50000',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugeacvolts.needle()
            .fill('#929292')
            .stroke('0px rgba(2,2,2,.2)')
            .startRadius('0%')
            .endRadius('90%')
            .middleRadius(0)
            .startWidth('0.1%')
            .endWidth('0.1%')
            .middleWidth('5%');

        gaugeacvolts.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge = anychart.circularGauge();

        internalGauge
            .data([81])
            .bounds('20%', '60%', '25%', '35%')
            .fill('none')
            .stroke('none');

        internalGauge.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge.range(1, {
            from: 95,
            to: 100,
            position: 'i',
            fill: '#731728',
            stroke: '1 #000',
            startSize: 6,
            endSize: 6,
            radius: 113,
            zIndex: 1
        });

        gaugeacvolts.draw();
        internalGauge.draw()
    });

    // AC Voltage close here //

    // Current Imbalance start here //

    anychart.onDocumentReady(function () {
        var stage = anychart.graphics.create('current');

        gaugecurrentimb = anychart.circularGauge();
        gaugecurrentimb.container(stage);

        gaugecurrentimb.title(null)
            .fill(null)
            .stroke(null);

        gaugecurrentimb.title().fontWeight('normal')
            .fontFamily('Verdana')
            .fontColor('#474747')
            .fontSize('14px');

        gaugecurrentimb.axis().labels().fontWeight('normal')
            .fontFamily('arial')
            .fontColor('#474747')
            .fontSize('12px');

        gaugecurrentimb.data([40]);

        gaugecurrentimb.axis().scale()
            .minimum(0)
            .maximum(60)
            .ticks({ interval: 10 })
            .minorTicks({ interval: 5 });

        gaugecurrentimb.axis()
            .startAngle(260)
            .fill('#929292')
            .width(0)
            .sweepAngle(200)
            .ticks({ type: 'trapezium', fill: '#474747', length: 0 })
            .minorTicks({ type: 'trapezium', fill: '#474747', length: 0 });

        gaugecurrentimb.range(0, {
            from: 0,
            to: 10,
            position: 'i',
            fill: '#d8d8d8',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugecurrentimb.range(1, {
            from: 10,
            to: 50,
            position: 'i',
            fill: '#008b06',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugecurrentimb.range(2, {
            from: 50,
            to: 60,
            position: 'i',
            fill: '#d50000',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugecurrentimb.needle()
            .fill('#929292')
            .stroke('0px rgba(2,2,2,.2)')
            .startRadius('0%')
            .endRadius('90%')
            .middleRadius(0)
            .startWidth('0.1%')
            .endWidth('0.1%')
            .middleWidth('5%');

        gaugecurrentimb.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge = anychart.circularGauge();

        internalGauge
            .data([81])
            .bounds('20%', '60%', '25%', '35%')
            .fill('none')
            .stroke('none');

        internalGauge.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge.range(1, {
            from: 95,
            to: 100,
            position: 'i',
            fill: '#731728',
            stroke: '1 #000',
            startSize: 6,
            endSize: 6,
            radius: 113,
            zIndex: 1
        });

        gaugecurrentimb.draw();
        internalGauge.draw()
    });
//Current Imbalance close here//


// frequency start here //

 anychart.onDocumentReady(function () {
     var stage = anychart.graphics.create('frequency');

        gaugefreq = anychart.circularGauge();
        gaugefreq.container(stage);

        gaugefreq.title(null)
            .fill(null)
            .stroke(null);

        gaugefreq.title().fontWeight('normal')
            .fontFamily('Verdana')
            .fontColor('#474747')
            .fontSize('14px');

        gaugefreq.axis().labels().fontWeight('normal')
            .fontFamily('arial')
            .fontColor('#474747')
            .fontSize('12px');

        gaugefreq.data([55]);

        gaugefreq.axis().scale()
            .minimum(0)
            .maximum(60)
            .ticks({ interval: 10 })
            .minorTicks({ interval: 5 });

        gaugefreq.axis()
            .startAngle(260)
            .fill('#929292')
            .width(0)
            .sweepAngle(200)
            .ticks({ type: 'trapezium', fill: '#474747', length: 0 })
            .minorTicks({ type: 'trapezium', fill: '#474747', length: 0 });

        gaugefreq.range(0, {
            from: 0,
            to: 10,
            position: 'i',
            fill: '#d8d8d8',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugefreq.range(1, {
            from: 10,
            to: 52,
            position: 'i',
            fill: '#008b06',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugefreq.range(2, {
            from: 52,
            to:60,
            position: 'i',
            fill: '#d50000',
            stroke: '0 #000',
            startSize: 4,
            endSize: 4,
            radius: 108
        });
        gaugefreq.needle()
            .fill('#929292')
            .stroke('0px rgba(2,2,2,.2)')
            .startRadius('0%')
            .endRadius('90%')
            .middleRadius(0)
            .startWidth('0.1%')
            .endWidth('0.1%')
            .middleWidth('5%');

        gaugefreq.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge = anychart.circularGauge();

        internalGauge
            .data([81])
            .bounds('20%', '60%', '25%', '35%')
            .fill('none')
            .stroke('none');

        internalGauge.cap()
            .radius('10%')
            .fill('#474747');

        internalGauge.range(1, {
            from: 95,
            to: 100,
            position: 'i',
            fill: '#731728',
            stroke: '1 #000',
            startSize: 6,
            endSize: 6,
            radius: 113,
            zIndex: 1
        });

        gaugefreq.draw();
        internalGauge.draw()
    });
//frequency close here//


    // fuel level gauge start here //

anychart.onDocumentReady(function () {
    var stage = anychart.graphics.create('fuellevelgauge');

    gaugefuel = anychart.circularGauge();
    gaugefuel.container(stage);

    gaugefuel.title(null)
        .fill(null)
        .stroke(null);

    gaugefuel.title().fontWeight('normal')
        .fontFamily('Verdana')
        .fontColor('#474747')
        .fontSize('14px');

    gaugefuel.axis().labels().fontWeight('normal')
        .fontFamily('arial')
        .fontColor('#474747')
        .fontSize('12px');

    gaugefuel.data([120]);

    gaugefuel.axis().scale()
        .minimum(0)
        .maximum(320)
        .ticks({ interval: 10 })
        .minorTicks({ interval: 5 });

    gaugefuel.axis()
        .startAngle(260)
        .fill('#929292')
        .width(0)
        .sweepAngle(200)
        .ticks({ type: 'trapezium', fill: '#474747', length: 0 })
        .minorTicks({ type: 'trapezium', fill: '#474747', length: 0 });

    gaugefuel.range(0, {
        from: 0,
        to: 60,
        position: 'i',
        fill: '#d8d8d8',
        stroke: '0 #000',
        startSize: 4,
        endSize: 4,
        radius: 108
    });
    gaugefuel.range(1, {
        from: 60,
        to: 300,
        position: 'i',
        fill: '#008b06',
        stroke: '0 #000',
        startSize: 4,
        endSize: 4,
        radius: 108
    });
    gaugefuel.range(2, {
        from: 300,
        to: 320,
        position: 'i',
        fill: '#d50000',
        stroke: '0 #000',
        startSize: 4,
        endSize: 4,
        radius: 108
    });
    //gaugefuel.range(3, {
    //    from: 40,
    //    to: 50,
    //    position: 'i',
    //    fill: '#c44242',
    //    stroke: '0 #000',
    //    startSize: 4,
    //    endSize: 4,
    //    radius: 108
    //});
    gaugefuel.needle()
        .fill('#929292')
        .stroke('0px rgba(2,2,2,.2)')
        .startRadius('0%')
        .endRadius('90%')
        .middleRadius(0)
        .startWidth('0.1%')
        .endWidth('0.1%')
        .middleWidth('5%');

    gaugefuel.cap()
        .radius('10%')
        .fill('#474747');

    internalGauge = anychart.circularGauge();

    internalGauge
        .data([81])
        .bounds('20%', '60%', '25%', '35%')
        .fill('none')
        .stroke('none');

    internalGauge.cap()
        .radius('10%')
        .fill('#474747');

    internalGauge.range(1, {
        from: 95,
        to: 100,
        position: 'i',
        fill: '#731728',
        stroke: '1 #000',
        startSize: 6,
        endSize: 6,
        radius: 113,
        zIndex: 1
    });

    gaugefuel.draw();
    internalGauge.draw()
});
}
//fuel level gauge close here//


//****************************** speedometer close here ******************************//

function browserType() {
    var ua = navigator.userAgent.toLowerCase();
    if (ua.indexOf('safari') != -1) {
        if (ua.indexOf('chrome') > -1) {
            return "Chrome"
        } else {
            return "Safari";
        }
    }
}


$(document).ready(function () {
    //****************************** Edit User Info pop up satrt here  ***********************//


    $(function () {
        $.datepicker.setDefaults({
            dateFormat: 'mm/dd/yy'
        });
    });

    var IsPaswordChange = false;
    
    $(function () {
        $("#form").validationEngine('attach', { promptPosition: "topRight" });
    });

    $("#Password").focus(function () {
        $("#Password").val('');        
        $("#ConfirmPassword").val('');
        IsPaswordChange = true;
    });

    $("#CreateBirthdate").focus(function () {
        $('#CreateBirthdate').datepicker({ dateFormat: 'yy-mm-dd', maxDate: 0 });
    });

    $("#CreateBirthdate").click(function () {
        $('#CreateBirthdate').datepicker({ dateFormat: 'yy-mm-dd', maxDate: 0 });
    });

    $('#CreateBirthdate').datepicker({
        dateFormat: 'yy-mm-dd', maxDate: 0
    });

    $("#BirthdateCreate").focus(function () {
        $('#BirthdateCreate').datepicker({ dateFormat: 'yy-mm-dd', maxDate: 0 });
    });

    $("#BirthdateCreate").click(function () {
        $('#BirthdateCreate').datepicker({ dateFormat: 'yy-mm-dd', maxDate: 0 });
    });

    $('#BirthdateCreate').datepicker({
        dateFormat: 'yy-mm-dd', maxDate: 0,
       // endDate: new Date()
    });
    
   

    $("#cancel").click(function () {
        //$(this).parent.parent().parent().hide();
        $('#contactdiv').hide();
        $('#contactdiv2').hide();
        $('#form').validationEngine('hideAll');
    });

    $("#onclick").click(function () {
        /*
        if (browserType() == "Safari") {   
            var dataString = '';
        } else {
            var dataString = JSON.stringify();
        }*/
        
        $.ajax({
            url: "../../Service/WebService.asmx/GetUserInfo",
            type: "POST",
            //data: dataString,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                console.log(result, 'result');
                var obj = jQuery.parseJSON(JSON.stringify(result.d));
                console.log(obj, 'obj');

                $("#FirstName").val(obj.FirstName == "undefined" ? '' : obj.FirstName);
                $("#LastName").val(obj.LastName == "undefined" ? '' : obj.LastName);
                var birthDateValue = "";

                if (obj.BirthdateCreate == "undefined" || obj.BirthdateCreate == null)
                    birthDateValue = "";
                else if (obj.BirthdateCreate != "undefined" || obj.BirthdateCreate != null) {
                    birthDateValue = $.datepicker.formatDate('yy-mm-dd', new Date(parseInt(obj.BirthdateCreate.replace('/Date(', ''))));
                    //Convert UTC Time to Local Time
                    var currentTime = new Date(parseInt(obj.BirthdateCreate.replace('/Date(', '')));
                    var timeZone = currentTime.getTimezoneOffset();
                    var offset = -(currentTime.getTimezoneOffset() / 60);
                    var newDate = new Date(currentTime.getTime() + currentTime.getTimezoneOffset() * 60 * 1000);
                    var offset = currentTime.getTimezoneOffset() / 60;
                    var hoursUTC = currentTime.getHours();
                    newDate.setHours(hoursUTC - offset);

                    var month = newDate.getMonth() + 1;
                    var day = newDate.getDate();
                    var year = newDate.getFullYear();
                    if (month < 10)
                        month = "0" + month;
                    if (day < 10)
                        day = "0" + day;
                    console.log(day);
                    //obj.BirthdateCreate == "undefined" ? '' : $.datepicker.formatDate('yy-mm-dd', new Date(parseInt(obj.BirthdateCreate.replace('/Date(', ''))));
                    birthDateValue = year + "-" + month + "-" + day;
                }
                $("#BirthdateCreate").val(birthDateValue);
                
                var timestamp = parseInt(birthDateValue.replace('/Date(', ''));
                birthDate = new Date(timestamp);
                if(birthDate.getFullYear() === 1) {
                    $("#BirthdateCreate").val('');
                }
                
                $("#Password").val(obj.Password);
                $("#ConfirmPassword").val(obj.Password);
                $("#Email").val(obj.Email);
                $("#EmailCreate").val(obj.EmailCreate);
                $("#TelephoneNumber").val(obj.TelephoneNumber);
                $("#TelephoneNumberCreate").val(obj.TelephoneNumberCreate);
                //var UserName = $("#FirstName").val()+" "+$("#LastName").val();
                var roleId = $("#hdnRoleType").val();
                console.log($("#hdnRoleType").val());
                if(roleId==2)
                    $("#txtShowUserName").closest('.jtable-input-field-container').children('.jtable-input-label').text('Username:');
                else if (roleId != 2)
                    $("#txtShowUserName").closest('.jtable-input-field-container').children('.jtable-input-label').text('Username:');
                $("#txtShowUserName").val(obj.UserNameCreate);
            },
            error: function (xhr, status) {
                alert("An error occurred: " + status);
            }
        });
        $("#contactdiv").fadeIn("fast");
        $('#FirstName').focus();
        $('#form1').addClass("custom_horizontal_form_field");
        $('#ui-id-Edit-User-Info').addClass("custom_horizontal_form_field");
        $('#ui-id-Edit-User-Info').prev().find('.ui-dialog-title').text('Edit Account Information');
        $(".ui-widget-overlay").appendTo($("#form1"));
        $(".ui-widget-overlay").css('display', 'block');
        //setTimeout(function () {
           
        //    $('#ui-id-Edit-User-Info #form').prepend('<div class="jtable-input-field-container"><div class="jtable-input-label">Username:</div><div class="jtable-input jtable-text-input" style="font-size: 15px; padding-left: 4px;">' + username + '</div></div>');
        //}, 200);
    });
   

    $("#contact #cancel").click(function () {
        $(this).parent().parent().hide();
    });

    $("#send").click(function () {
        var fname = $("#FirstName").val();
        var lname = $("#LastName").val();
        var BirthDate = $("#BirthdateCreate").val();
        var email = $("#EmailCreate").val();
        var contactno = $("#TelephoneNumberCreate").val();
        var Password = $("#Password").val();

       
        if (!$("#form").validationEngine('validate')) {
            return false;
        }
        else {

            if (BirthDate == '') {
                BirthDate = null;
            }

                $.ajax({
                    url: "../../Service/WebService.asmx/EditUser",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: "{'FirstName': '" + fname +
                        "', 'LastName': '" + lname +
                        "', 'BirthdateCreate': '" + BirthDate +
                        "', 'emailCreate': '" + email +
                        "', 'contactnoCreate': '" + contactno +
                        "', 'Password': '" + Password +
                        "', 'IsPaswordChange': '" + IsPaswordChange +
                        "'}",
                    dataType: "json",
                    success: function (result) {
                        $.msgBox({
                            title: "Alert",
                            content: result.d,
                            type: "info",
                            opacity: 0.1,
                            success: function (result) {

                                $("#contactdiv").css("display", "none")
                                $("#form1").removeClass(".ui-widget-overlay");
                                $(".ui-widget-overlay").css('display', 'none');
                                //$('#search').val($('select[name=selector]').val());
                            }
                        });

                    },
                    error: function (xhr, status) {
                        alert("An error occurred: " + status);
                        console.log(xhr);
                    }
                });
            
            
        }
           
       // }
    });
//****************************** Edit User Info pop up end here  ******************************//



//****************************** Contact Us pop up start here **********************************//
 $(function () {
        $("#form2").validationEngine('attach', { promptPosition: "topRight" });
    });

 $("#contactus").click(function () {
     
     
     $('#form2').addClass("custom_horizontal_form_field");
     $('#ui-id-ContactUs').addClass("custom_horizontal_form_field");
     $("#contactdiv2").fadeIn("fast");
     $('#Name').focus();

    
 });

 $("#cancel2").click(function () {
     
     $('#contactdiv2').hide();
     
     $('#form2').validationEngine('hideAll');
 });

 $("#submit").click(function () {     
     var Name = $("#Name").val();
     var txtEmail = $("#txtEmail").val(); 
     var txtMessage = $("#txtMessage").val();     
     if (!$("#form").validationEngine('validate')) {
         return false;
     }
     else {    
         $.ajax({
             url: "../../Service/WebService.asmx/SendMessage",
             type: "POST",
             contentType: "application/json; charset=utf-8",
             data: "{'Name': '" + Name +
                 "', 'Email': '" + txtEmail +
                 "', 'Message': '" + txtMessage +
                 "'}",
             dataType: "json",
             success: function (result) {
                 //if (result.d) {
                 //$.msgBox({
                 //    title: "Message",
                 //    content: 'Sent',
                 //    type: "info",
                 //    opacity: 0.1,
                 //    success: function (result) {
                 //        $("#contactdiv2").css("display", "none");
                 //        //$("#form2").removeClass(".ui-widget-overlay");
                 //        //$(".ui-widget-overlay").css('display', 'none');
                 //    }
                 //});
                 //}
                 //else {
                 //    $("#Message").removeAttr('style').css({'color': '#B51F1F','font-size': 'initial'});
                 //    $("#Message").html(result.d)
                 //}

             },
             error: function (xhr, status) {
                 
                     $.msgBox({
                         title: "Error",
                         content: status,
                         type: "error",
                         opacity: 0.1,
                         success: function (result) {

                             // $("#contactdiv2").css("display", "none")
                             //$('#search').val($('select[name=selector]').val());
                         }
                     });
                 
                // alert("An error occurred: " + status);
             }
         });
         $("#contactdiv2").css("display", "none");

         //setTimeout(function () { $("#contactdiv2").css("display", "none"); }, 1000);
     } 
         
     
      
 });
    //******************************Contact us pop end here **************************************//
});

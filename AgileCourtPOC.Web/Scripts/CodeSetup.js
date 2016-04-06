$(document).ready(function () {
 
    var oTable;

    var mode='new';

    var parseValidationGroupCodes = function (data) {
        var groupCodes = data.ValidationGroupCodes;

        $.each(groupCodes, function (i, code) {
            $('#selectCodeGroup').append($('<option>', {
                value: code.Id,
                text: code.Code
             }));

        });

    }

    $('#selectCodeGroup').change(function () {

        var groupCodeId = $('#selectCodeGroup').val();
        
        if (groupCodeId != '' || groupCodeId==undefined){

            getCodetypes(groupCodeId);
        }

        
    })


    var parseValidationGroupCodesError= function()
    {
       // toastr.error('Error occured while loading group codes', '', { showDuration: 50 })
    }

    var getGroupCodes = $.ajax({
        type: "GET",
        url: "http://localhost:62218/api/ValidationGroupCode/",
        datatype: 'json',
        xhrFields: {
            withCredentials: false
        }, success: parseValidationGroupCodes,
        crossDomain: true,
        error: parseValidationGroupCodesError
        
    });


    var parseValidationCodeTypes = function (data) {      

        var groupCodes = data.ValidationCategoryCodes;

        $('#selectCodeType').empty();

        $('#selectCodeType').append($('<option>', {
            value: '',
            text: '--Select--'
        }));

        $.each(groupCodes, function (i, code) {
            $('#selectCodeType').append($('<option>', {
                value: code.Id,
                text:  code.Code
            }));

        });
    }

    var parseValidationCodeTypeError = function () {
        toastr.error('Error occured while loading code types', '', { showDuration: 50 })
    }

    var getCodetypes = function(groupCode){
        
        $.ajax({
            type: "GET",
            url: "http://localhost:62218/api/ValidationCategoryCodes/GetByGroupCode/" + groupCode,
            datatype: 'json',
            xhrFields: {
                withCredentials: false
            }, success: parseValidationCodeTypes,
            crossDomain: true,
            error: parseValidationCodeTypeError

        });
    }

    $("#btnSave").click(function () {
       
        var id = 0;
        var methodType = 'POST';
        if (mode == 'edit') {
            id = recid;
            methodType = 'PUT';
        }
        var code = $("#txtCode").val();
        var description = $("#txtDescription").val();
        var beginDate=$("#txtEffectiveFrom").val();
        var endDate = $("#txtEffectiveTo").val();
        var codeType = $("#selectCodeType").val();
       
        $.ajax({
            url: "http://localhost:62218/api/ValidationCodes/",
            type: methodType,
            data: {
                Code: code,
                Description: description,
                BeginDate: beginDate,
                EndDate: endDate,
                ValidationCategoryCodeRefID: codeType,
                Id: id
            },
            dataType: "json"
        }).done(function (data) {
            toastr.success('Saved Successfully', '', { showDuration: 50 })
            var codes = getValidationCodes();
            loadDataTable(codes);
            clearInputFields();
        })
    });

    initPolicyTab();

    $("#btnCancel").click(function () {

        // window.location.href = "http://localhost:60051/HtmlTmpls/CodeSetup.html";

        clearInputFields();

    });

    var clearInputFields = function () {

        $("#txtCode").val('');
        $("#txtDescription").val('');
        $("#txtEffectiveFrom").val('');
        $("#txtEffectiveTo").val('');

        recid = 0;

        mode = 'new';

    }

    function initPolicyTab() {
        oTable = $("#validationCodes").dataTable({
            "bProcessing": true,
            "bServerSide": false,
            "language": {
                "emptyTable": "No Records Found"
            },
            "sPaginate": false,
           // "sPaginationType": "full_numbers",
            "bFilter": false,
            "bSort": true,
            "bDeferRender": true,
            "renderer": "bootstrap",
            "deferLoading": 0,
            "aaSorting": [],
            "fixedHeader": {header:true,footer:false},
            "aoColumns": [
                { "mData": "Code" },
                { "mData": "Description" },
                {
                    "mData": "BeginDate",
                    "mRender": function (oObj) {
                        var aDate = oObj;
                        if (aDate != '' && aDate != 'undefined') {
                            aDate = moment(aDate).format("MM/DD/YYYY");
                        }
                        return aDate;
                    },
                    "sType": "date",
                    "sSortDataType": "date"
                },
                {
                    "mData": "EndDate",
                    "mRender": function (oObj) {
                        var aDate = oObj;
                        if (aDate != '' && aDate != 'undefined') {
                            aDate = moment(aDate).format("MM/DD/YYYY");
                        }
                       
                        return aDate;
                    },
                    "sType": "date",
                    "sSortDataType": "date"
                },                
                {
                    "mData": "ValidationCategoryCodeRefID",
                    "mRender": function (oObj) {
                        return '<input type="hidden" id="codeTypeId" data-codType="' + oObj + '" />';
                    },

                    "bSortable": false,
                    "bVisible":false
                },
                {
                    "mData": "Id",
                    "mRender": function (oObj) {
                        var html = '<a href="#"><i class="fa  fa-pencil-square-o fa-2x editcode" data-codeid="'+oObj+'"/></a>';

                        return html;
                    },

                    "bSortable": false
                    
                }

            ]
        });
    }

    $("#validationCodes").on('click', '.editcode', function (event) {

        var id = $(this).data("codeid");
        
        //Load data from validation codes and fill for edit

        var code = getValidationCode(id);


    });

    var getValidationCode= function (id)
    {
        $.ajax({
            type: "GET",
            url: "http://localhost:62218/api/ValidationCodes/GetById/" + id,
            datatype: 'json',
            xhrFields: {
                withCredentials: false
            }, success: parseValidationCode,
            crossDomain: true,
            error: parseValidationGroupCodesError

        });
    }

    var parseValidationCode = function (data) {

        if (data != '' || data.length != 0) {

            var validationCode = data.ValidationCode;

            $("#txtCode").val(validationCode.Code);
            $("#txtDescription").val(validationCode.Description);
            $("#txtEffectiveFrom").val(moment(validationCode.BeginDate).format("MM/DD/YYYY"));
            $("#txtEffectiveTo").val(moment(validationCode.EndDate).format("MM/DD/YYYY"));

            recid = validationCode.Id;

            mode = 'edit';

        }
        
    }


    $("#selectCodeType").change(function () {
       
            getValidationCodes();       

        }
    );

    var getValidationCodes = function () {

        var codeType = $("#selectCodeType").val();

        if (codeType != '') {

            $.ajax({
                url: "http://localhost:62218/api/ValidationCodes/GetByCodeType/" + codeType,
                type: "GET",
                dataType: "json",
                xhrFields: {
                    withCredentials: false
                },
                crossDomain: true,
                success: loadDataTable,
                error: parseErrorValidationCodes
            });
        }

    }

    function parseErrorValidationCodes()
    {
        alert('error');
    }

    function loadDataTable (data) {
         
        if (data != '' && data != undefined)
        {
            var validationCodes = data.ValidationCodes;


            oTable.fnClearTable();

            if (validationCodes.length > 0) {
                oTable.fnAddData(validationCodes);
            }
        }
       
    }

    //Load data on blur

    $("#txtCode").blur(function () {

        var code = $("#txtCode").val();
        var codeType=$("#selectCodeType").val();
        if (codeType != '') {
            getValidationCodeByCode(code);
        } else {
            toastr.warning('Select code type', '', { showDuration: 50 });
        }
        

    });

    var getValidationCodeByCode = function (code) {
        $.ajax({
            type: "GET",
            url: "http://localhost:62218/api/ValidationCodes/GetByCode/" + code,
            datatype: 'json',
            xhrFields: {
                withCredentials: false
            }, success: parseValidationCode,
            crossDomain: true,
            error: parseValidationGroupCodesError

        });
    }

});
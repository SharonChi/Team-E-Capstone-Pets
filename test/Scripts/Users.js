﻿var $dialog;

$(document).ready(function () {

    // populate Users
    LoadUsers();

    // Open Pop Up
    $('body').on("click", "a.popup", function (e) {
        e.preventDefault();
        var page = $(this).attr('href');
        OpenPopup(page);
    });

    //Save Users
    $("body").on('submit', '#saveForm', function (e) {
        e.preventDefault();
        SaveUser();
    });

    //Update Users
    $("body").on('submit', '#updateForm', function (e) {
        e.preventDefault();
        UpdateUser();
    });

    //Delete Users
    $('body').on('submit', '#deleteForm', function (e) {
        e.preventDefault();
        DeleteUser();
    });
});




// populate Users
function LoadUsers() {
    $('#update_panel').html('Loading Data...');

    $.ajax({
        type: 'GET',
        url: '/TUsers/GetUsers',
        dataType: 'json',
        success: function (d) {
            if (d.length > 0) {

                var $data = $('<table></table>').addClass('table table-responsive table-striped');
                var header = "<thead><tr><th style='background-color: darkgray; color: black; font: bold; font - size: large; font - weight: bold;'>User</th><th style='background-color: darkgray; color: black; font: bold; font - size: large; font - weight: bold;'>Action</th></tr></thead>";
                $data.append(header);
                $.each(d, function (i, row) {
                    var $row = $('<tr/>');
                    $row.append($('<td/>').html(row.strUserName));
                    $row.append($('<td/>').html("<a href='/TUsers/Update/" + row.intUsertID + "' class='popup'><i class='fas fa-pencil-alt'></i></a> | <a style='color: red;' href='/TUsers/Delete/" + row.intUserID + "' class='popup'><i class='fas fa-trash-alt'></i></a>"));
                    $data.append($row);
                });

                $('#update_panel').html($data);
            }
            else {
                var $noData = $('<div/>').html('No Data Found!');
                $('#update_panel').html($noData);
            }
        },
        error: function () {
            alert('Error! AJAX is broken.');
        }
    });

}

//open popup  
function OpenPopup(Page) {

    var $pageContent = $('<div/>');
    $pageContent.load(Page);
    $dialog = $('<div class="popupWindow" style="overflow:hidden"></div>')
        .html($pageContent)
        .dialog({
            title: "Capstone Pets",
            draggable: true,
            autoOpen: false,
            resizable: true,
            model: true,
            height: 450,
            width: 500,
            closeText: "",
            close: function () {
                $dialog.dialog('destroy').remove();
            }
        })
    $dialog.dialog('open');
}






//Save Users
function SaveUser() {
    //Validation  
    if ($('#strUserName').val().trim() == '' ||
        $('#strPassword').val().trim() == '') //||
        //$('#intRoleID').val().trim() == '') 
    {
        $('#msg').html('<div class="failed">All fields are required.</div>');
        return false;
    }

    var user = {
        intUserID: $('#intUserID').val() == '' ? '0' : $('#intUserID').val(),
        strUserName: $('#strUserName').val().trim(),
        strPassword: $('#strPassword').val().trim(),
        intRoleID: $('#intRoleID').val().trim()
    };


    //Add validation token  
    user.__RequestVerificationToken = $('input[name=__RequestVerificationToken]').val();


    //Save Users
    $.ajax({
        url: '/TUsers/Save',
        type: 'POST',
        data: user,
        dataType: 'json',
        success: function (data) {
            alert(data.message);
            if (data.status) {
                $('#intUserID').val('');
                $('#strUserName').val('');
                $('#strPassword').val('');
                $('#intRoleID').val('');
                LoadUsers();
                $dialog.dialog('close');
            }
        },
        error: function () {
            $('#msg').html('<div class="failed">Error! Please try again.</div>');
        }
    });
}

//Update Users
function UpdateUser() {
    //Validation  
    if ($('#strUserName').val().trim() == '') {
        $('#msg').html('<div class="failed">All fields are required.</div>');
        return false;
    }

    var user = {

        intUserID: $('#intUserID').val() == '' ? '0' : $('#intUserID').val(),
        strUserName: $('#strUserName').val().trim(),
		strPassword: $('#strPassword').val().trim(),
        intRoleID: $('#intRoleID').val() == '' ? '0' : $('#intRoleID').val()

    };


    //Add validation token  
    user.__RequestVerificationToken = $('input[name=__RequestVerificationToken]').val();


    //Update Users
    $.ajax({
        url: '/TUsers/Update',
        type: 'POST',
        data: user,
        dataType: 'json',
        success: function (data) {
            alert(data.message);
            if (data.status) {
                $('#intUserID').val('');
                $('#strUserName').val('');
                $('#strPassword').val('');
                $('#intRoleID').val('');


                LoadUsers();
                $dialog.dialog('close');
            }
        },
        error: function () {
            $('#msg').html('<div class="failed">Error! Please try again.</div>');
        }
    });
}

//Delete Users  
function DeleteUser() {
    $.ajax({
        url: '/TUsers/Delete',
        type: 'POST',
        dataType: 'json',
        data: {
            'id': $('#intUserID').val(),
            '__RequestVerificationToken': $('input[name=__RequestVerificationToken]').val()
        },
        success: function (data) {
            alert(data.message);
            if (data.status) {
                $dialog.dialog('close');
                LoadUsers();
            }
        },
        error: function () {
            $('#msg').html('<div class="failed">Error ! Please try again.</div>');
        }
    });
}  

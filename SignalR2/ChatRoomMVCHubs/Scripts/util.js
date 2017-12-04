$(function () {

    $('#chatBody').hide();
    $('#loginBlock').show();


    //Reference to the auto- generated hub proxy
    var chat = $.connection.chatHub;

    // Declare the function that the hub calls when it receives messages
    chat.client.addMessage = function (name, message) {

        // Adding messages to a web page
        $('#chatroom').append('<p><b>' + htmlEncode(name)
            + '</b>: ' + htmlEncode(message) + '</p>');
    };

    // Function that is called when a new user is connected
    chat.client.onConnected = function (id, userName, allUsers) {

        $('#loginBlock').hide();
        $('#chatBody').show();

        // set the hidden name and id of the current user
        $('#hdId').val(id);
        $('#username').val(userName);
        $('#header').html('<h3>Wellcome, ' + userName + '</h3>');

        // Add all users
        for (i = 0; i < allUsers.length; i++) {
            AddUser(allUsers[i].ConnectionId, allUsers[i].Name);
        }
    }

    // Add a new user
    chat.client.onNewUserConnected = function (id, name) {
        AddUser(id, name);
    }

    // Delete the user
    chat.client.onUserDisconnected = function (id, userName) {
        $('#' + id).remove();
    }

    // Open the connection
    $.connection.hub.start().done(function () {

        $('#sendmessage').click(function () {

            // Call the Send method on the hub
            chat.server.send($('#username').val(), $('#message').val());
        });

        // handle login
        $("#btnLogin").click(function () {

            var name = $("#txtUserName").val();
            if (name.length > 0) {
                chat.server.connect(name);
            }
            else {
                alert("Enter name");
            }
        });
    });
});

// Encode tag
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}

// Add a new user
function AddUser(id, name) {

    var userId = $('#hdId').val();

    if (userId != id) {
        $("#chatusers").append('<p id="' + id + '"><b>' + name + '</b></p>');
    }
}
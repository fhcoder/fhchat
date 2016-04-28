$(function () {
    var nome = $('#nickname').val();
    var chat = $.connection.chatHub;
    var idNick = $('#nickname').attr('data-id');
    $('#display-names ul').on('click', 'li', function () {
        return false;
    });
 
    chat.client.sendStatus = function (name, listusers) {
        if (!$('#' + name).length) {
            $('#display-names ul').append('<li id="' + name + '"><a href="#">' + name + '</a></li>');
        }
        var users = listusers.split(",");
        
        for (var i = 0; i < users.length; i++) {
            if (users[i] != "") {
                if ($("#" + users[i]).length < 1) {
                    $('#display-names ul').append('<li class="remove" id="' + users[i] + '"><a href="#">' + users[i] + '</a></li>');
                }
            }
        }
        $('#display-names').scrollTop($('#display-names').height());
    };

    chat.client.sendRemoveStatus = function (name) {
        $('#' + name).remove();
    };
    /*chat.client.sendUpdateStatus = function(names)
    {
        for(var i = 0; i < names.lenght;i++)
        {
            
        }
    }*/
    chat.client.sendMessageToPage = function (name, message) {
        $('#display-message ul').append('<li><span>' + name + ': </span>' + message + '</li>');
        $('#display-message').scrollTop($('#display-message').height());
    };
  
    $.connection.hub.qs = { 'name': nome,'id':idNick };
    $.connection.hub.start().done(function () {
        $('#message').on('click','#enviar',function(){
            var message = $('#msg').val();
            chat.server.sendMessage(nome, message);
            $('#msg').val('');
            
        });
        $(document).keypress(function (e) {
            if (e.which == 13) {
                var message = $('#msg').val();
                chat.server.sendMessage(nome, message);
                $('#msg').val('');
            }
        });

    });
    $('div[style*="opacity: 0.9"]').remove();
    $('a[href*="http://somee.com"]').remove();
    $('div[style*="position: fixed"]').remove();
    $('#msg').focus();
});

// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

"use strict";

function setupSignalR()
{
    const connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

    connection.on("ReceiveMessage", function (user, message) {

        const $notificationBell = $('#notification-bell .badge');
        const notificationCount = +$notificationBell.html() || 0;

        $notificationBell.html(notificationCount + 1);
        $notificationBell.removeClass('d-none');

        console.log(user, message, notificationCount, $notificationBell);
    });

    connection.start().then(function () {
        console.log('Connected!')
    }).catch(function (err) {
        return console.error(err.toString());
    });
}

function setupNotificationDropdown() 
{
    const $notificationContainer = $('.notification-container');
    
    $notificationContainer.hide();
    $('*[data-toggle="notification-container"]').click(() => {

        if ($notificationContainer.is(':hidden')) {
            
            const $overlay = $("<div id='overlay' style='position: absolute; width: 100vw; height: 100vh; z-index: 10; left: 0; top: 0;'></div>");
            $overlay.click(function () {
                $(this).remove();
                $notificationContainer.hide();
            });
            
            $(document.body).append($overlay);
        }
        
        $notificationContainer.toggle();
    });
}


setupSignalR();
setupNotificationDropdown();

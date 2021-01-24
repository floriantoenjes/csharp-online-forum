// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established

connection.on("ReceiveMessage", function (user, message) {
    
    const $notificationBell = $('#notification-bell .badge');
    const notificationCount = +$notificationBell.html();
    
    $notificationBell.html(notificationCount + 1);
    $notificationBell.css("visibility", "");
    
});

connection.start().then(function () {
    console.log('Connected!')
}).catch(function (err) {
    return console.error(err.toString());
});

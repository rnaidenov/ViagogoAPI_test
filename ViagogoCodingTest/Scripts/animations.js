/// <reference path="animations.js" />
$("#artistName").delay(1000).animate({ "opacity": "1" }, 700);
$(".eventContainer").delay(1500).animate({ "opacity": "1" }, 700);
$('#ticketOption').each(function (index) {
    $(this).delay(400 * index).fadeIn(300);
});



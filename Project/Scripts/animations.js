$("#artistName").delay(1000).animate({ "opacity": "1" }, 700);
$(".eventContainer").delay(1500).animate({ "opacity": "1" }, 700);
$(".eventContainer-cheapestEvent").delay(1500).animate({ "opacity": "1" }, 700);

function goGreen() {
    var ctnr = $(".eventContainer-cheapestEvent");
    ctnr.css({
        "background-color": "#74d583",
        "transition": "background-color 1s ease"
    });


    setTimeout(function () {
        ctnr.css({
            "background-color": "#D6D5C9",
            "transition": "background-color 1s ease"
        })
    }, 1000);


};

window.setInterval(goGreen, 6000);


$(function () {
    $(".eventContainer-cheapestEvent").hover(hoverIn, hoverOut);
});

function hoverIn() {
    $("#cheapestEventLabel").css({
        "left": "145px",
        "transition": "left 1s ease",
        "opacity": "1",
        "z-index": "-1"
    });
}

function hoverOut() {
    $("#cheapestEventLabel").css({
        "left": "0px",
        "transition": "left 1s ease",
        "z-index": "-1"
    });
}

$(document).ready(function () {
    // Show dropdown on hover
    $('.nav-item.dropdown').hover(function () {
        $(this).children('.dropdown-menu').addClass('show');
    }, function () {
        $(this).children('.dropdown-menu').removeClass('show');
    });

    // Show nested dropdown on hover
    $('.dropdown-submenu').hover(function () {
        $(this).children('.dropdown-menu').addClass('show');
    }, function () {
        $(this).children('.dropdown-menu').removeClass('show');
    });

    // Handle click to navigate
    $('a.nav-link, a.dropdown-item').click(function (event) {
        var targetUrl = $(this).attr('href');
        if (targetUrl && targetUrl !== '#' && targetUrl !== 'undefined') {
            window.location.href = targetUrl;
        }
    });
});
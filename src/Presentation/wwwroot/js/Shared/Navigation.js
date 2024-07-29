$(function () {
    // Show dropdown on hover
    $(document).on('mouseenter', '.nav-item.dropdown', function () {
        $(this).children('.dropdown-menu').addClass('show');
    }).on('mouseleave', '.nav-item.dropdown', function () {
        $(this).children('.dropdown-menu').removeClass('show');
    });

    // Show nested dropdown on hover
    $(document).on('mouseenter', '.dropdown-submenu', function () {
        $(this).children('.dropdown-menu').addClass('show');
    }).on('mouseleave', '.dropdown-submenu', function () {
        $(this).children('.dropdown-menu').removeClass('show');
    });

    // Handle click to navigate
    $(document).on('click', 'a.nav-link, a.dropdown-item', function (event) {
        var targetUrl = $(this).attr('href');
        if (targetUrl && targetUrl !== '#' && targetUrl !== 'undefined') {
            window.location.href = targetUrl;
        }
    });
});
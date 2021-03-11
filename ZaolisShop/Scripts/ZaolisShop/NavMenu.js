jQuery(document).ready(function () {
    $(".dropdown").hover(
        function () {
            $('.dropdown-menu', this).stop().fadeIn("fast");
        },
        function () {
            $('.dropdown-menu', this).stop().fadeOut("fast");
        });
});



window.addEventListener('scroll', function () {
    if (document.documentElement.getBoundingClientRect().top == 0) {
        $('#top-nav-index').css('background-color', 'rgba(0,0,0,0)');
        $('#top-nav-index').css('border-bottom', '0.5px solid rgb(199, 199, 199)');
    }
    else {
        $('#top-nav-index').css('background-color', 'black');
        $('#top-nav-index').css('border-bottom', '0px solid black');
    }
});
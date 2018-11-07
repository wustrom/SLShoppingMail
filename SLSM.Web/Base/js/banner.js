$(document).ready(function () {
    var t;
    var index = 0;
    var times = 6000;//间隔时间
    t = setInterval(play, times);
    var count = $(".cirbox .cir").length - 1;
    function play() {
        index++;
        if (index > count) { index = 0 }
        $('.img').eq(index).fadeIn(500).siblings().fadeOut(500);
        $('.cir').eq(index).addClass('cr').siblings().removeClass('cr')
    }

    $('.cir').click(function () {
        $(this).addClass('cr').siblings().removeClass('cr')
        var index = $(this).index()
        $('.img').eq(index).fadeIn(300).siblings().fadeOut(300);
    })

    $('.pre').click(function () {
        index--
        if (index < 0) { index = count }
        $('.img').eq(index).fadeIn(500).siblings().fadeOut(500);
        $('.cir').eq(index).addClass('cr').siblings().removeClass('cr');
        disableButton();
    })
    $('.next').click(function () {
        index++
        if (index > count) { index = 0 }
        $('.img').eq(index).fadeIn(500).siblings().fadeOut(500);
        $('.cir').eq(index).addClass('cr').siblings().removeClass('cr');
        disableButton();
    })

    function disableButton() {
        $('.pre').unbind();
        $('.next').unbind();
        setTimeout(function () {
            $('.pre').click(function () {
                index--
                if (index < 0) { index = count }
                $('.img').eq(index).fadeIn(500).siblings().fadeOut(500);
                $('.cir').eq(index).addClass('cr').siblings().removeClass('cr');
                disableButton();
            })
            $('.next').click(function () {
                index++
                if (index > count) { index = 0 }
                $('.img').eq(index).fadeIn(500).siblings().fadeOut(500);
                $('.cir').eq(index).addClass('cr').siblings().removeClass('cr');
                disableButton();
            })
        }, 500);

    }

    $('.banner').hover(
        function () {
            clearInterval(t)
        },
        function () {
            t = setInterval(play, times)
            function play() {
                index++
                if (index > count) { index = 0 }
                $('.img').eq(index).fadeIn(1000).siblings().fadeOut(1000);
                $('.cir').eq(index).addClass('cr').siblings().removeClass('cr')
            }
        }
    );

});


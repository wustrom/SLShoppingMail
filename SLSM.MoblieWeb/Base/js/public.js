var slideoutMain;
/*公共侧边栏*/
(function () {
    // #region 是否禁用左滑
    var disableSlideOut = $("#disableSlideOut").val();
    var width = $(window).width();
    if (disableSlideOut == "true") {
        if (width > 1079) {
            slideoutMain = new Slideout({
                'panel': document.getElementById('panel'),
                'menu': document.getElementById('menu'),
                'padding': 780,
                'touch': false
            });
        } else if (width <= 768) {
            slideoutMain = new Slideout({
                'panel': document.getElementById('panel'),
                'menu': document.getElementById('menu'),
                'padding': 540,
                'touch': false
            });
        }
        if (width <= 520) {
            slideoutMain = new Slideout({
                'panel': document.getElementById('panel'),
                'menu': document.getElementById('menu'),
                'padding': 256,
                'touch': false
            });
        }
    }
    else {
        if (width > 1079) {
            slideoutMain = new Slideout({
                'panel': document.getElementById('panel'),
                'menu': document.getElementById('menu'),
                'padding': 780
            });
        } else if (width <= 768) {
            slideoutMain = new Slideout({
                'panel': document.getElementById('panel'),
                'menu': document.getElementById('menu'),
                'padding': 540
            });
        }
        if (width <= 520) {
            slideoutMain = new Slideout({
                'panel': document.getElementById('panel'),
                'menu': document.getElementById('menu'),
                'padding': 256
            });
        }
    }
    // #endregion



    /*Toggle button*/
    document.querySelector('.toggle-button').addEventListener('click', function () {
        slideoutMain.toggle();
        $('')
    });

    $('.btn-select').click(function () {
        slideoutMain.toggle();
        $('')
        SelectComm()
    })

})();

function disableTouch() {
    slideoutMain.disableTouch();
}

function enableTouch() {
    slideoutMain.enableTouch();
}
/*公共轮播*/
(function () {
    var swiper = new Swiper('.public-news', {
        loop: true,
        speed: 1000,
        autoplay: true
    });
})();

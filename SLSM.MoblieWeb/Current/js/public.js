
/*公共侧边栏*/
(function () {

    var width = $(window).width();
    console.log(width);
    if (width > 1079) {
        var slideout = new Slideout({
            'panel': document.getElementById('panel'),
            'menu': document.getElementById('menu'),
            'padding': 780,
        });
        console.log(1);
    }else if(width <= 768){
        var slideout = new Slideout({
            'panel': document.getElementById('panel'),
            'menu': document.getElementById('menu'),
            'padding': 540,
        });
        console.log(2);
    }
    if(width <= 520) {
        var slideout = new Slideout({
            'panel': document.getElementById('panel'),
            'menu': document.getElementById('menu'),
            'padding': 256,
        });
        console.log(3);
    }


    /*Toggle button*/
    document.querySelector('.toggle-button').addEventListener('click', function () {
        slideout.toggle();
        $('')
    });
})();

/*公共轮播*/
(function () {
    var swiper = new Swiper('.public-news', {
        loop: true,
        speed: 1000,
        autoplay: true
    });
})();

/*回到顶部*/

(function(){
    $(window).scroll(function(){
        var sc=$(window).scrollTop();
        var rwidth=$(window).width()
        if(sc>0){
            $(".go-top").css("display","block");
        }else{
            $(".go-top").css("display","none");
        }
    })
    $(".go-top").click(function(){
        $('body,html,.gundong').animate({scrollTop:0},500);
        var sec = 1; //time
	        var interval = setInterval(function () {
	          sec--;
	          if(sec == 0){
	          	var h = $("html,body,.gundong").scrollTop();
//	          	console.log(h);
				if(h != 0){
					$("html,body,.gundong").scrollTop(0);
				}
	            clearInterval(interval); //close
	          };
	        }, 500);
    })
})();


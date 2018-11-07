!function (a, b, c) {
    function d(a) {
        var c = "default";
        a.self_redirect === !0 ? c = "true" : a.self_redirect === !1 && (c = "false");
        var d = b.createElement("iframe"),
            e = "https://open.weixin.qq.com/connect/qrconnect?appid=" + a.appid + "&scope=" + a.scope + "&redirect_uri=" + a.redirect_uri + "&state=" + a.state + "&login_type=jssdk&self_redirect=" + c;
        e += a.style ? "&style=" + a.style : "",
            e += a.href ? "&href=" + a.href : "",
            d.src = e,
            d.frameBorder = "0",
            d.allowTransparency = "true",
            d.scrolling = "no",
            d.width = "314px",
            d.height = "400px";
        var f = b.getElementById(a.id);
        f.innerHTML = "",
            f.appendChild(d)
    }
    a.WxLogin = d
}(window, document);
var obj = new WxLogin({
    self_redirect: true,
    id: "login_container",
    appid: "wx6cf2e87f65bb78f2",
    scope: "snsapi_login",
    redirect_uri: encodeURIComponent("http://www.syloon.cn/Api/Home/WeChatLoginIn"),
    state: "",
    style: "write",
    //href: ""
});
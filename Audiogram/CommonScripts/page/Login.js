    //Detect browser and write the corresponding name
    function detectBrowser() {
        navigator.sayswho = (function () {
            var ua = navigator.userAgent, tem,
            M = ua.match(/(opera|chrome|safari|firefox|msie|trident(?=\/))\/?\s*(\d+)/i) || [];
            if (/trident/i.test(M[1])) {
                tem = /\brv[ :]+(\d+)/g.exec(ua) || [];
                return 'IE ' + (tem[1] || '');
            }
            if (M[1] === 'Chrome') {
                tem = ua.match(/\b(OPR|Edge)\/(\d+)/);
                if (tem != null) return tem.slice(1).join(' ').replace('OPR', 'Opera');
            }
            M = M[2] ? [M[1], M[2]] : [navigator.appName, navigator.appVersion, '-?'];
            if ((tem = ua.match(/version\/(\d+)/i)) != null) M.splice(1, 1, tem[1]);
            return M.join(' ');
        })();
        var browserNames = navigator.sayswho.split(' ');
        var name = browserNames[0];
        var version = parseInt(browserNames[1]);
        if ((name == 'Chrome' && version >= 41) ||
           // (name == 'IE' && version >= 11) ||
            (name == 'Firefox' && version >= 36) ||
            (name == 'Opera' && version >= 28) ||
            (name == 'Safari' && version >= 5)) {
            //alert("Suported");
            return true;
        }
        else {
            return false;
        }
    }

if (!detectBrowser()) {
    window.onload = function () {
        el = function (a) {
            var elname = a.substr(1);
            var el = document.getElementById(elname);
            return el;
        }
        el('#btnLogin').disabled = true;
        el('#btnLogin').style.backgroundColor = '#333';
        el('#btnLogin').style.cursor = 'default';
        el('#lblunSuccessfulLogin').innerHTML = "This product does not support the version of the web browser you are using. To log in please upgrade to the latest version.";
    };
}

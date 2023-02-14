!(function (window) {
    var functions = {
        sendAjaxRequest: function (opts) {
            var self = this;
            $.ajax({
                type: opts.type || "post",
                url: opts.url,
                data: opts.data || {},
                contentType: opts.contentType === null ? true : opts.contentType,
                cache: opts.cache === null ? true : opts.cache,
                processData: opts.processData === null ? true : opts.processData,
                beforeSend: function (XMLHttpRequest) {
                    XMLHttpRequest.setRequestHeader(UTIL.getAuthorizationKey(), "");
                },
                dataType: opts.dataType || "json",
                success: function (result) {
                    if (Object.prototype.toString.call(opts.callBack) === "[object Function]") {               
                        opts.callBack(result);
                    } else {
                        console.log("CallBack is not a function");
                    }
                }
            });
        },
        getRequestHeaderAuthorizationToken: function () {
            var document_cookie = document.cookie;
            //var reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
            //if (document_cookie = document.cookie.match(reg))
            //    return unescape(arr[2]);
            //else
            //    return null;
            console.log(document_cookie);
            return document_cookie;
        },
        getAuthorizationKey: function () {
            return 'Authorization';
        },
        setCookie: function (name,value,minutes) {
            let expires = "";
            if (minutes) {
                let date = new Date();
                date.setTime(date.getTime() + (minutes*60*1000));
                expires = "; expires=" + date.toUTCString();
            }
            // Set-Cookie: jwt=OUR_TOKEN_CONTENT; secure; httpOnly; sameSite=Lax;
            // prevent XSS and CSRF
            document.cookie = name + "=" + (value || "")  + expires + "; secure; sameSite=Lax;";
        },
        getCookie: function (name) {
            var nameEQ = name + "=";
            var ca = document.cookie.split(';');
            for(var i=0;i < ca.length;i++) {
                var c = ca[i];
                while (c.charAt(0)==' ') c = c.substring(1,c.length);
                if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
            }
            return null;
        },
        eraseCookie: function(name) {
            document.cookie = name +'=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;';
        }
        
    };

    window.UTIL = functions;
})(this);

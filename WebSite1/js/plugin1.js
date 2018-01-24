;(function (gloable) {
    "use strict";

    var M=function (el) {
        gloable.el= typeof el==="string"?document.querySelector(el):el;
    };

    M.prototype={
        setBg:function (bg) {
            gloable.el.style.backgroundColor=bg;
            console.log("sdfsd4444444444");
            
        }
    };


    if(typeof module !=='undefined' &&module.exports)  module.exports=M;
    if(typeof  define==='function') define(function () {
        return M;
    });
    gloable.ModifyDivBg=M;

})(window);
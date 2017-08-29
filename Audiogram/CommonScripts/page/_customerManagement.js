_this = new (function _customerManagement() {

    this._PageLoaded = function _PageLoaded() {
        console.log(global.pageName, 'Page');
        
        _this.is_PageLoaded = true;

    };

    this._$document_ready = (function () {
        $(document).ready(function () {
            // BIND PRM EVENTS
            //global.page.Prm.add_initializeRequest(_this._InitRequest);
            console.log('Page DocReady');
        });
        $(window).load(function () {

        });
    })();

})();

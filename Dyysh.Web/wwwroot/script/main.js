"use strict";
var ko = require('knockout');
var $ = require('jquery');
var HelloViewModel = (function () {
    function HelloViewModel(language, framework) {
        var _this = this;
        this.language = ko.observable(language);
        this.framework = ko.observable(framework);
        this.ebalo = ko.computed(function () { return 'idi nahui ' + _this.language; }, self);
        console.warn('Ebososina roompenji');
    }
    return HelloViewModel;
}());
$(document).ready(function () { return ko.applyBindings(new HelloViewModel("TypeScript Ebosos1", "Knockout")); });
//# sourceMappingURL=main.js.map
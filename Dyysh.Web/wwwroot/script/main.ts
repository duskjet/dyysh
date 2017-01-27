import * as ko from 'knockout';
import * as $ from 'jquery';

class HelloViewModel {
    language: KnockoutObservable<string>
    framework: KnockoutObservable<string>
    ebalo: KnockoutComputed<string>

    constructor(language: string, framework: string) {
        this.language = ko.observable(language);
        this.framework = ko.observable(framework);

        this.ebalo = ko.computed(() => { return 'idi nahui ' + this.language; }, self);
        console.warn('Ebososina roompenji');
    }
}

$(document).ready(() => ko.applyBindings(new HelloViewModel("TypeScript Ebosos1", "Knockout")));

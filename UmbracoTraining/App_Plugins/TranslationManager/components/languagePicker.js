﻿(function () {

    var languagePickerComponent = {
        templateUrl: Umbraco.Sys.ServerVariables.application.applicationPath + 'App_Plugins/TranslationManager/components/languagePicker.html',
        bindings: {
            sets: '=',
            picked: '='
        },
        controllerAs: 'vm',
        controller: languagePickerController
    };

    function languagePickerController($scope) {

        var vm = this;
        vm.toggle = toggle;

        vm.showDropdown = false; 
        vm.picked = 0;

        vm.$onInit = function () {

            var languages = getLanguageCount();
            if (languages >= 10) {
                vm.showDropdown = true;
            }

        };

        vm.addLanguage = addLanguage;
        vm.removeLanguage = removeLanguage;

        function addLanguage() {

            var selected = vm.selectedSet.split('_');

            if (selected[0] === 'SET') {
                // add all the languages
            }
            else {
                var setId = selected[0] * 1;
                var siteId = selected[1] * 1;
                var culture = selected[2];

                for (var s = 0; s < vm.sets.length; s++) {
                    if (setId === vm.sets[s].Id) {
                        for (var t = 0; t < vm.sets[s].Sites.length; t++) {

                            if (siteId === vm.sets[s].Sites[t].Id
                                && culture === vm.sets[s].Sites[t].Culture.Name) {
                                vm.sets[s].Sites[t].checked = true;
                            }
                        }
                    }
                }
            }

            pushSites();
        }

        function removeLanguage($event, site) {
            $event.preventDefault();
            site.checked = false;
            pushSites();
        }


        function toggle(site) {
            site.checked = !site.checked;
            pushSites();
        }

        function pushSites() {
            vm.picked = [];
            angular.forEach(vm.sets, function (set, key) {
                angular.forEach(set.Sites, function (s, key) {
                    if (s.checked) {
                        vm.picked.push({ siteId: s.Id, cultureId: s.CultureId, setId: set.Id });
                    }
                });
            });
        }

        function getLanguageCount() {
            var count = 0;
            for (var s = 0; s < vm.sets.length; s++) {
                count += vm.sets[s].Sites.length;
            }

            return count;
        }

    }

    angular.module('umbraco')
        .component('translateLanguagePicker', languagePickerComponent);

})();
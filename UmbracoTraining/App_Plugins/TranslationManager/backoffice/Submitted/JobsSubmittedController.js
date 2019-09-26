(function () {

    'use strict';

    function jobsController($routeParams,
        localizationService,
        notificationsService,
        translateCultureService) {

        var vm = this;

        vm.page = {
            title: 'Submitted Jobs : ',
            description: 'Jobs that have been submitted for translation'
        };

        vm.cultureId = $routeParams.id;
        vm.statusRange = [1, 9];
        vm.loaded = true;

        getCultureInfo(vm.cultureId);

        function getCultureInfo(cultureId) {
            translateCultureService.getCultureInfo(cultureId)
                .then(function (result) {
                    vm.page.title += result.data.DisplayName;
                });

        }
    }

    angular.module('umbraco')
        .controller('translateJobsSubmittedController', jobsController);

})();
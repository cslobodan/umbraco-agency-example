(function () {

    'use strict';

    function jobsController($routeParams,
        localizationService,
        notificationsService,
        translateCultureService) {

        var vm = this;

        vm.page = {
            title: 'Archived Jobs : ',
            description: 'Jobs that have been completed or closed'
        };

        vm.cultureId = $routeParams.id;
        vm.statusRange = [20, 100];
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
        .controller('translateJobsArchiveController', jobsController);

})();
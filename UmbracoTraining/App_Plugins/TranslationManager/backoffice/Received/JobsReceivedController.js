(function () {

    'use strict';

    function jobsController($routeParams,
        localizationService,
        notificationsService,
        translateCultureService) {

        var vm = this;

        vm.page = {
            title: 'Received Jobs : ',
            description: 'Jobs that have been returned from translation'
        };

        vm.cultureId = $routeParams.id;
        vm.statusRange = [10, 19];
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
        .controller('translateJobsReceivedController', jobsController);

})();
(function () {

    'use strict';

    function summaryArchiveController(translateJobService, $location) {

        var vm = this;

        vm.pageTitle = 'Archived Jobs';
        vm.loading = true;

        vm.viewJobs = viewJobs;

        loadJobInfo();

        ///////////////
        function loadJobInfo() {
            translateJobService.getSummaryRange(20, 100)
                .then(function (result) {
                    vm.info = result.data;
                    vm.loading = false;
                });
        }

        function viewJobs(id) {
            $location.path('/translation/archive/list/' + id);
        }
    }

    angular.module('umbraco')
        .controller('translateSummaryArchiveController', summaryArchiveController);

})();
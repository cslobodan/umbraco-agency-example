(function () {

    'use strict';

    function summaryReceivedController(translateJobService, $location) {

        var vm = this;

        vm.pageTitle = 'Submitted Jobs';
        vm.loading = true;

        vm.viewJobs = viewJobs;

        loadJobInfo();

        ///////////////
        function loadJobInfo() {
            translateJobService.getSummaryRange(10, 19)
                .then(function (result) {
                    vm.info = result.data;
                    vm.loading = false;
                });
        }

        function viewJobs(id) {
            $location.path('/translation/received/list/' + id);
        }
    }

    angular.module('umbraco')
        .controller('translateSummaryReceivedController', summaryReceivedController);

})();
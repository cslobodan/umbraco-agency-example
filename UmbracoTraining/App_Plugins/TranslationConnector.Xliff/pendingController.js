(function () {

    'use strict';

    function xliffPendingController($scope) {

        var vm = this;

        // we just pass through all the options to the job
        $scope.vm.job.providerOptions = $scope.vm.settings;

        $scope.$watch('vm.settings', function (newValue, oldValue) {
            if (newValue !== undefined) {
                $scope.vm.job.providerOptions = $scope.vm.settings;
            }
        });
    }

    angular.module('umbraco')
        .controller('translateXliffPendingController', xliffPendingController);

})();
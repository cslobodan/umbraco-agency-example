(function () {
    'use strict';

    function fileService($http, Upload) {

        var service = {
            upload: uploadFileToServer
        };

        return service;


        function uploadFileToServer(file, jobId) {

            return Upload.upload({
                url: 'backoffice/translationManager/XliffConnectorFileApi/uploadFile',
                fields: {
                    'jobId': jobId
                },
                file: file
            });
        }
    }

    angular.module('umbraco.resources')
        .factory('xliffFileUploadService', fileService);
})();
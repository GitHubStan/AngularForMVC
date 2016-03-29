(function() {
    'use strict';

    angular.module('angularFormsApp').controller('HomeController',
        ['$scope', '$location', 'DataService',
        function ($scope, $location, DataService) {

            DataService.getEmployees().then(
                function (results) {
                    var data = results.data;
                },
                function(results) {
                    var data = results.data;
                }
            );

            $scope.showCreateNewEmployeeForm = function () {
                $location.path('/newEmployeeForm');
            };
            $scope.showUpdateEmployeeForm = function(employeeId) {
                $location.path('/updateEmployeeForm/' + employeeId);
            };
        }]);
})();

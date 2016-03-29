(function() {

    'use strict';

    angular.module('angularFormsApp').controller('efController',
        function efController($scope, $window, $routeParams, DataService) {

            if ($routeParams.id) {
                $scope.employee = DataService.getEmployee($routeParams.id);
            } else {
                $scope.employee = {
                    id: 0
                };
            }
            
            $scope.editableEmployee = angular.copy($scope.employee);

            $scope.departments = ['Engineering', 'Marketing', 'Finance', 'Administration'];
            $scope.programmingLanguages = ['C', 'C++', 'C#', 'Java', 'JavaScript', 'Perl', 'Lisp', 'Scala', 'Go'];

            $scope.hoveringOver = function(value) {
                $scope.overStar = value;
                $scope.percent = 100 * (value / 10);
            };

            $scope.submitForm = function () {

                $scope.$broadcast('show-errors-event');

                if ($scope.employeeForm.$invalid) {
                    return;
                }

                if ($scope.editableEmployee.id === 0) {
                    DataService.insertEmployee($scope.editableEmployee);
                } else {
                    DataService.updateEmployee($scope.editableEmployee);
                }

                $scope.employee = angular.copy($scope.editableEmployee);
                $window.history.back();
            };

            $scope.cancelForm = function () {
                $window.history.back();
            };

            $scope.resetForm = function() {
                $scope.$broadcast('hide-errors-event');
            };
        });
})();

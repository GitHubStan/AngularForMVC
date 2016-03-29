(function() {

    'use strict';

    angular.module('angularFormsApp').directive('employeeForm',
        function () {

            return {
                restrict: 'E',
                templateUrl: '/app/EmployeeForm/efTemplate.html'
            }
    });    
})();


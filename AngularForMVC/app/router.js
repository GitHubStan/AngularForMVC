(function() {
    'use strict';

    angular.module('angularFormsApp').config(
        ['$routeProvider', '$locationProvider',
        function ($routeProvider, $locationProvider) {
            $routeProvider
                .when("/home", {
                    templateUrl: "app/Home.html",
                    controller: "HomeController"
                })
                .when("/newEmployeeForm", {
                    templateUrl: "app/EmployeeForm/efTemplate.html",
                    controller: "efController"
                })
                .when("/updateEmployeeForm/:id", {
                    templateUrl: "app/EmployeeForm/efTemplate.html",
                    controller: "efController"
                })
                .otherwise({
                    redirectTo: "/home"
                });
            $locationProvider.html5Mode({
                enabled: true,
                requireBase: false
            });
    }]);
})();


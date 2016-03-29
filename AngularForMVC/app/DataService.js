(function() {
    'use strict';

    angular.module('angularFormsApp').factory('DataService',
        ['$http', 
        function ($http) {

            var employees = [];

            initialize();

            return {
                getEmployees: getEmployees,
                getEmployee: getEmployee,
                insertEmployee: insertEmployee,
                updateEmployee: updateEmployee
            };

            function initialize() {
                employees[0] = {
                    id: 0,
                    fullName: "Milton Waddams",
                    emailAddress: "Milton@RedStapler.com",
                    notes: "The ideal employee.  Just don't touch his red stapler.",
                    department: "Administration",
                    dateHired: "July 11 2014",
                    breakTime: Date(),
                    topProgrammingLanguage: "C#",
                    interviewRating: 1,
                    perkCar: true,
                    perkStock: false,
                    perkSixWeeks: true,
                    payrollType: "none",
                    isUnderNonCompete: true,
                    nonCompeteNotes: "The employee is non-competitive ;)"

                }
            }

            function insertEmployee (newEmployee) {
                return $http.post("Employee/Create", newEmployee);
            }

            function updateEmployee(employee) {
                employees[employee.id] = employee;
            }

            function getEmployee(id) {
                return employees[id];
            }

            function getEmployees() {
                return $http.get("Employee/GetEmployees");
            }
        }]);
})();


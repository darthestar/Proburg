console.log("app loaded");

const app = angular.module("main", ["ngRoute"]);

app.config(function ($routeProvider) {

    $routeProvider.when("/events", {
        templateUrl: "/Scripts/app/views/events.html",
        controller: "allEventsController"
    })

    $routeProvider.when("/events/:eventID", {
        templateUrl: "/Scripts/app/views/eventDetails.html",
        controller: "eventDetailsController"
    })
    $routeProvider.otherwise({ redirectTo: "/events" });

})

app.controller("eventDetailsController", ["$scope", "$routeParams", "$http", function ($scope, $routeParams, $http) {
    console.log($routeParams);
    $http({
        method: "GET",
        url: "/api/events/" + $routeParams.eventID
    }).then(resp => {
        console.log(resp);
        $scope.event = resp.data;
    })
}])

app.controller("allEventsController", ["$scope", "$http", function($scope, $http) {

    $http({
        method: "GET",
        url: "/api/events"
    }).then(resp => {
        $scope.events = resp.data
    })
}])



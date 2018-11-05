var app = angular.module("sportSy", ["ngRoute"]);
app.config(['$routeProvider',function ($routeProvider) {
    $routeProvider
        .when("/users",
        {
            templateUrl: "/pages/users.html",
            controller:"usersMainViewModel"
        })
        .otherwise("/");
   
}]);
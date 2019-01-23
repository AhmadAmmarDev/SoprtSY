var app = angular.module("sportSy", ["ngRoute"]);
app.config(['$routeProvider',function ($routeProvider) {
    $routeProvider
        .when("/",
        {
            templateUrl: "index.html"
        })
        .when("/registerUser",
        {
            templateUrl: "/pages/users/userRegestraion.html",
            controller:"usersMainViewModel"
        })
        .otherwise("/");
   
}]);
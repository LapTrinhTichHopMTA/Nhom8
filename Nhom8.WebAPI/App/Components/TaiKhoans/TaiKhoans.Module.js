/// <reference path="../../../assets/admin/libs/angular.js" />

(function () {
    angular.module('MayTinh.TaiKhoan', ['MayTinh.Common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('TaiKhoans', {
            url: "/TaiKhoans",
            templateUrl: "/App/Components/TaiKhoans/TaiKhoansListView.html",
            controller: "TaiKhoansController"
        });
    }
})();
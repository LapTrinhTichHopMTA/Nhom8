/// <reference path="../../../assets/admin/libs/angular.js" />

(function () {
    angular.module('MayTinh.SanPham', ['MayTinh.Common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('SanPhams', {
            url: "/SanPhams",
            templateUrl: "/App/Components/SanPham/SanPhamListView.html",
            controller: "SanPhamListController"
        }).state('SanPhams_Add', {
            url: "/SanPhams_Add",
            templateUrl: "/App/Components/SanPham/SanPhamAddView.html",
            controller: "SanPhamAddController"
        });
    }
})();
/// <reference path="../../../assets/admin/libs/angular.js" />

(function () {
    angular.module('MayTinh.SanPham', ['MayTinh.Common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('SanPhams', {
            url: "/SanPhams",
            templateUrl: "/App/Components/SanPham/SanPhamListView.html",
            controller: "SanPhamListController"

        }); 

        $stateProvider.state('addSanPhams', {
            url: "/addSanPhams",
            templateUrl: "/App/Components/SanPham/SanPhamAddView.html",
            controller: "SanPhamAddController"
        }); 

        $stateProvider.state('PutSanPham', {
            url: "/PutSanPham/:Ma",
            templateUrl: "/App/Components/SanPham/SanPhamPutView.html",
            controller: "PutSanPhamController"
        });

    }
})();
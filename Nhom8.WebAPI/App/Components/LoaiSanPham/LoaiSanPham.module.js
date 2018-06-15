/// <reference path="../../../assets/admin/libs/angular.js" />

(function () {
    angular.module('MayTinh.LoaiSanPham', ['MayTinh.Common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('LoaiSanPhams', {
            url: "/LoaiSanPhams",
            templateUrl: "/App/Components/LoaiSanPham/LoaiSanPhamListView.html",
            controller: "LoaiSanPhamListController"
        });

        $stateProvider.state('addLoaiSanPham', {
            url: "/addLoaiSanPham",
            templateUrl: "/App/Components/LoaiSanPham/LoaiSanPhamAddView.html",
            controller: "LoaiSanPhamAddController"
        }); 

    }
})();
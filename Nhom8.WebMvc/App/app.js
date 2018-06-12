/// <reference path="../assets/admin/libs/angular.js" />


(function () {
    angular.module('BanMayTinh', [
     
        'MayTinh.NhaSanXuat',
        'MayTinh.LoaiSanPham',
        'MayTinh.SanPham',
        'MayTinh.Common'

    ]).config(config); 

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('TrangChu', {
            url: "/admin",
            templateUrl: "/App/Components/TrangChu/TrangChuView.html",
            controller:"TrangChuController"
        }); 
        $urlRouterProvider.otherwise('/admin');
    }
})();
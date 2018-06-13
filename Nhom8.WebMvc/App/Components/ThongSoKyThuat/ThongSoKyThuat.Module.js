/// <reference path="../../../assets/admin/libs/angular.js" />

(function () {
    angular.module('MayTinh.ThongSoKyThuat', ['MayTinh.Common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('ThongSoKyThuats', {
            url: "/ThongSoKyThuats",
            templateUrl: "/App/Components/ThongSoKyThuat/ThongSoKyThuatListView.html",
            controller: "ThongSoKyThuatController"
        });
    }
})();
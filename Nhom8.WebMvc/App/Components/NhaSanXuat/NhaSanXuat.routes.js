/// <reference path="../../../assets/admin/libs/angular.js" />

(function () {
    angular.module('MayTinh.NhaSanXuat', ['MayTinh.Common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('NhaSanXuats', {
            url: "/NhaSanXuats",
            templateUrl: "/App/Components/NhaSanXuat/NhaSanXuatListView.html",
            controller: "NhaSanXuatListController"
        });
    }
})();
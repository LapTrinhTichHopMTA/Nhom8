
(function (app) {
    app.controller('SanPhamListController', SanPhamListController);
    SanPhamListController.$inject = ['$scope', 'apiService']; 

    function SanPhamListController($scope, apiService) {
        $scope.ListSanPham = []; 
        $scope.GetListSanPham = GetListSanPham; 

        function GetListSanPham() {
            apiService.get('/api/sanpham', null, function (result) {
                $scope.ListSanPham = result.data
            }, function () {
                console.log('Loi Load Du Lieu'); 
            })
        }
        $scope.GetListSanPham(); 
    }
})(angular.module('MayTinh.SanPham'));
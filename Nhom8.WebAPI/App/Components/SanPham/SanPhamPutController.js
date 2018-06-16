
(function (app) {
    app.controller('PutSanPhamController', PutSanPhamController);

    PutSanPhamController.$inject = ['$scope', 'apiService', 'ThongBaoService','$stateParams'];

    function PutSanPhamController($scope, apiService, ThongBaoService,$stateParams) {

        $scope.DanhSachLoaiSanPham = [];
        $scope.DanhSachNhaSanXuat = [];
        $scope.SanPham = null;



        function LoadSanPhamTheoMa() {

            apiService.get('/api/SanPham?MaSanPham=' + $stateParams.Ma, null, function (resulte) {
                $scope.SanPham = resulte.data;
            }, function () {
                console.log('Khong load Dươc Loai San Pham');
            });
        }
        LoadSanPhamTheoMa(); 



        function LoadDanhSachLoaiSanPham() {

            apiService.get('/api/LoaiSanPhams', null, function (resulte) {
                $scope.DanhSachLoaiSanPham = resulte.data;
            }, function () {

                console.log('Khong load Dươc Loai San Pham');
            });
        }



        function LoadDanhSachNhaSanXuat() {

            apiService.get('/api/NhaSanXuats', null, function (resulte) {
                $scope.DanhSachNhaSanXuat = resulte.data;

            }, function () {

                console.log('Khong load Dươc Nha Sản Xuat');
            });
        }


        LoadDanhSachNhaSanXuat();
        LoadDanhSachLoaiSanPham();

        $scope.UpdateSanPham = UpdateSanPham;

        function UpdateSanPham(SanPham) {
            $.ajax({
                url: "/api/SanPham",
                type: "put",
                contentType: "application/json",
                dataType: "json",
                data: JSON.stringify($scope.SanPham),
                success: function (data) {
                    ThongBaoService.displaySuccess('cap nhap san pham thanh cong')
                },
                error: function () {
                    ThongBaoService.displayError('cap nhap san pham khong thanh cong');
                }
            });
        }
    }


})(angular.module('MayTinh.SanPham'));
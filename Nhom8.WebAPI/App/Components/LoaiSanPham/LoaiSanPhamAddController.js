
/// <reference path="../../../assets/admin/plugins/jquery/jquery-2.1.4.min.js" />

(function (app) {
    app.controller('LoaiSanPhamAddController', LoaiSanPhamAddController);
    LoaiSanPhamAddController.$inject = ['$scope', 'apiService', 'ThongBaoService'];

    function LoaiSanPhamAddController($scope, apiService, ThongBaoService) {
        $scope.LoaiSanPham = {
            HienThi: true
        }

        $scope.AddLSanPham = AddLSanPham;
        function AddLSanPham(LoaiSanPham) {
            LoaiSanPham = $scope.LoaiSanPham;
            $.ajax({
                type: "POST",
                data: JSON.stringify($scope.LoaiSanPham),
                url: "/api/LoaiSanPhams",
                dataType: "json",
                contentType: "application/json",
                success: function (data) {
                    ThongBaoService.displaySuccess('Thêm Mới Sản Phâm Thành Công')
                },
                error: function () {
                    ThongBaoService.displayError('Thêm Mới Sản Phẩm Không Thành Công');
                }
            });
        }


    }
})(angular.module('MayTinh.LoaiSanPham'));
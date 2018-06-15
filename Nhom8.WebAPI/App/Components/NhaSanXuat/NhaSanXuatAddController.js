
/// <reference path="../../../assets/admin/plugins/jquery/jquery-2.1.4.min.js" />

(function (app) {
    app.controller('NhaSanXuatAddController', NhaSanXuatAddController);
    NhaSanXuatAddController.$inject = ['$scope', 'apiService', 'ThongBaoService'];

    function NhaSanXuatAddController($scope, apiService, ThongBaoService) {
        $scope.NhaSanXuat = {
            HienThi: true
        }

        $scope.AddNhaSanXuat = AddNhaSanXuat;
        function AddNhaSanXuat(NhaSanXuat) {
            NhaSanXuat = $scope.NhaSanXuat;
            $.ajax({
                type: "POST",
                data: JSON.stringify($scope.NhaSanXuat),
                url: "/api/NhaSanXuats",
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
})(angular.module('MayTinh.NhaSanXuat'));
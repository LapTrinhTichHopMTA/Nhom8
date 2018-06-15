
///// <reference path="../../../assets/admin/plugins/jquery/jquery-2.1.4.min.js" />

//(function (app) {
//    app.controller('ThongSoKyThuatAddController', ThongSoKyThuatAddController);
//    ThongSoKyThuatAddController.$inject = ['$scope', 'apiService', 'ThongBaoService'];

//    function ThongSoKyThuatAddController($scope, apiService, ThongBaoService) {
//        $scope.ThongSoKyThuat = {
//            HienThi: true
//        }

//        $scope.AddThongSoKyThuat = AddThongSoKyThuat;
//        function AddThongSoKyThuat() {
         
//            $.ajax({
//                type: "POST",
//                data: JSON.stringify($scope.ThongSoKyThuat),
//                url: "/api/ThongSoKyThuats",
//                dataType: "json",
//                contentType: "application/json",
//                success: function (data) {
//                    ThongBaoService.displaySuccess('Thêm Mới Sản Phâm Thành Công')
//                },
//                error: function () {
//                    ThongBaoService.displayError('Thêm Mới Sản Phẩm Không Thành Công');
//                }
//            });
//        }
//    }
//})(angular.module('MayTinh.ThongSoKyThuat'));
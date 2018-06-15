/// <reference path="../../../assets/admin/plugins/jquery/jquery-2.1.4.min.js" />



(function (app) {
    app.controller('SanPhamAddController', SanPhamAddController);

    SanPhamAddController.$inject = ['$scope', 'apiService', 'ThongBaoService']; 

    function SanPhamAddController($scope, apiService, ThongBaoService) {

         


        $scope.SanPham = {
            HienThi: true
        }

       

        $scope.DanhSachLoaiSanPham = [];
        function LoadDanhSachLoaiSanPham() {

            apiService.get('/api/LoaiSanPhams', null, function (resulte) {
                $scope.DanhSachLoaiSanPham = resulte.data;
            }, function () {

                console.log('Khong load Dươc Loai San Pham'); 
            }); 
        }
        LoadDanhSachLoaiSanPham(); 

        $scope.DanhSachNhaSanXuat = []; 

        function LoadDanhSachNhaSanXuat() {

            apiService.get('/api/NhaSanXuats', null, function (resulte) {
                $scope.DanhSachNhaSanXuat = resulte.data;

            }, function () {

                console.log('Khong load Dươc Nha Sản Xuat');
            });
        }
        LoadDanhSachNhaSanXuat(); 
        
        $scope.AddSanPham = AddSanPham;



        $scope.AddSanPham = AddSanPham; 
        function AddSanPham(SanPham) {
            SanPham = $scope.SanPham; 
            $.ajax({
                type: "POST",
                data: JSON.stringify($scope.SanPham),
                url: "/api/SanPhams", 
                dataType:"json", 
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
})(angular.module('MayTinh.SanPham'));
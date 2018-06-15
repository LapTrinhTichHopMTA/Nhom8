(function (app) {
    app.controller('SanPhamAddController', SanPhamAddController);

    SanPhamAddController.$inject = ['$scope', 'apiService', 'ThongBaoService']; 

    function SanPhamAddController($scope, apiService, ThongBaoService) {

        $scope.DanhSachLoaiSanPham = []; 

        $scope.SanPham = {
            HienThi: true
        }

       


        function LoadDanhSachLoaiSanPham() {

            apiService.get('http://localhost:51208/api/LoaiSanPhams', null, function (resulte) {
                $scope.DanhSachLoaiSanPham = resulte.data;
            }, function () {

                console.log('Khong load Dươc Loai San Pham'); 
            }); 
        }
        LoadDanhSachLoaiSanPham(); 

        $scope.DanhSachNhaSanXuat = []; 

        function LoadDanhSachNhaSanXuat() {

            apiService.get('http://localhost:51208/api/NhaSanXuats', null, function (resulte) {
                $scope.DanhSachNhaSanXuat = resulte.data;

            }, function () {

                console.log('Khong load Dươc Nha Sản Xuat');
            });
        }
        LoadDanhSachNhaSanXuat(); 
        
        $scope.AddSanPham = AddSanPham;
        /**
         * + $scope.SanPham.MaSanPham
                + '&TenSanPham=' + $scope.SanPham.TenSanPham
                + '&SoLuongTon=1'
                + '&DonGia=' + $scope.SanPham.DonGia
                + '&MoTa=' + $scope.SanPham.MoTa
                + '&AnhBia=' + $scope.SanPham.AnhBia
                + '&MaNhaSanXuat=' + $scope.SanPham.MaNhaSanXuat
                + '&MaLoaiSanPham=' + $scope.SanPham.MaLoaiSanPham
                + '&HienThi=' + $scope.SanPham.HienThi
         */
        function AddSanPham(SanPham) {
            apiService.post('http://localhost:51208/api/sanpham?sanPham=' +SanPham 
                , null,
                function (resulte) {
                ThongBaoService.displaySuccess(resulte.data.TenSanPhan + ' đã được thêm thành công')


            }, function () {

                console.log('Khong Add Đươc Sản Phẩm');
            });
        }
    }
})(angular.module('MayTinh.SanPham'));
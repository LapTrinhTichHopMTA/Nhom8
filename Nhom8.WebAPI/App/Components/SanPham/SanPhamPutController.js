
//(function (app) {
//    app.controller('PutSanPhamController', PutSanPhamController);

//    PutSanPhamController.$inject = ['$scope', 'apiService', 'ThongBaoService'];

//    function PutSanPham($scope, apiService, ThongBaoService) {

//        $scope.DanhSachLoaiSanPham = [];

//        $scope.SanPham = null; 

//        LoadSanPhamTheoMa(); 

//        function LoadSanPhamTheoMa() {

//            apiService.get('/api/SanPham?MaSanPham='+SanPham.MaSanPham, null, function (resulte) {
//                $scope.SanPham = resulte.data;
//            }, function () {
//                console.log('Khong load Dươc Loai San Pham');
//            });
//        }





//        function LoadDanhSachLoaiSanPham() {

//            apiService.get('/api/LoaiSanPhams', null, function (resulte) {
//                $scope.DanhSachLoaiSanPham = resulte.data;
//            }, function () {

//                console.log('Khong load Dươc Loai San Pham');
//            });
//        }
//        LoadDanhSachLoaiSanPham();

//        $scope.DanhSachNhaSanXuat = [];

//        function LoadDanhSachNhaSanXuat() {

//            apiService.get('/api/NhaSanXuats', null, function (resulte) {
//                $scope.DanhSachNhaSanXuat = resulte.data;

//            }, function () {

//                console.log('Khong load Dươc Nha Sản Xuat');
//            });
//        }
//        LoadDanhSachNhaSanXuat();

//        $scope.AddSanPham = AddSanPham;


//        function AddSanPham(SanPham) {
//            SanPham = $scope.SanPham;
//            $.ajax({
//                type: "PUT",
//                data: JSON.stringify($scope.SanPham),
//                url: "/api/SanPhams",
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
//})(angular.module('MayTinh.SanPham'));
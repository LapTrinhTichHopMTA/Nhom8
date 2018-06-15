(function (app) {
    app.controller('ThongSoKyThuatController', ThongSoKyThuatController);
    ThongSoKyThuatController.$inject = ['$scope', 'apiService', 'ThongBaoService'];

    function ThongSoKyThuatController($scope, apiService, ThongBaoService) {

        $scope.NhaSanXuat = null; 
        $scope.SanPham = {
            MaNhaSanXuat: 1010, 
            MaLoaiSanPham:15
        };
        $scope.LoaiSanPham = null; 
        $scope.DanhSachLoaiSanPham = [];
        $scope.DanhSachNhaSanXuat = [];
        function LoadDanhSachLoaiSanPham() {

            apiService.get('http://localhost:51208/api/LoaiSanPhams', null, function (resulte) {
                $scope.DanhSachLoaiSanPham = resulte.data;
            }, function () {

                console.log('Khong load Dươc Loai San Pham');
            });
        }





        function LoadDanhSachNhaSanXuat() {

            apiService.get('http://localhost:51208/api/NhaSanXuats', null, function (resulte) {
                $scope.DanhSachNhaSanXuat = resulte.data;

            }, function () {

                console.log('Khong load Dươc Nha Sản Xuat');
            });
        }

        LoadDanhSachNhaSanXuat();
        LoadDanhSachLoaiSanPham();

        function search1() {
            $scope.LoadDanhSachSanPham();
        }
        $scope.LoadDanhSachSanPham = LoadDanhSachSanPham; 
        $scope.ListSanPham = [];
        $scope.page1 = 0;
        $scope.pagesCount1 = 0;
        $scope.totalCount1 = 0; 


       

        LoadDanhSachSanPham(); 

        function LoadDanhSachSanPham(page1) {
  
            page1 = page1 || 0;
            var chuoiKetNois = ''; 
            if ($scope.SanPham.MaLoaiSanPham != 15 && $scope.SanPham.MaNhaSanXuat != 1010) {
                chuoiKetNois = 'http://localhost:51208/api/sanpham?trang='+page1+'&SoBanGhi=4&MaLoaiSanPham=' + $scope.SanPham.MaLoaiSanPham + '&MaNhaSanXuat=' + $scope.SanPham.MaNhaSanXuat;
            }
            else {
                if ($scope.SanPham.MaLoaiSanPham == 15 && $scope.SanPham.MaNhaSanXuat != 1010) {
                    chuoiKetNois = 'http://localhost:51208/api/sanpham?MaNhaSanXuat=' + $scope.SanPham.MaNhaSanXuat + '&trang=' + page1 + '&SoBanGhi=4'
                }
                else if ($scope.SanPham.MaLoaiSanPham != 15 && $scope.SanPham.MaNhaSanXuat == 1010) {
                    chuoiKetNois = 'http://localhost:51208/api/sanpham?trang=' + page1 +'&SoBanGhi=4&MaLoaiSanPham=' + $scope.SanPham.MaLoaiSanPham; 
                }
                else {
                    chuoiKetNois = 'http://localhost:51208/api/sanpham?trang=' + page1+ '&SoBanGhi=4'
                }
            }
            
         
      
            apiService.get(chuoiKetNois, null, function (result) {

                $scope.ListSanPham = result.data.DanhSach;
                $scope.page1 = result.data.Trang;
                $scope.pagesCount1 = result.data.SoTrang;
                $scope.totalCount1 = result.data.SoBanGhi;
                if (result.data.DoDai == 0) {
                    ThongBaoService.displayError('Không Có Bản Ghi Nào Được Tìm Thầy');
                }

            }, function () {
                console.log('Loi Load Du Lieu');
            })

        }
        LoadDanhSachSanPham(); 





        $scope.list = [];
        $scope.getlist = getlist;
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = null;
        $scope.search = search;

        function search() {
            $scope.getlist();
        }

        function getlist(page, keyword) {
            page = page || 0;
            keyword = keyword || null;
            var chuoiketnoi = '';

            var chuoiketnoi1 = 'http://localhost:51208/api/ThongSoKyThuats?trang=' + page + '&SoBanGhi=1&TuKhoa=' + $scope.keyword;
            var chuoiketnoi2 = 'http://localhost:51208/api/ThongSoKyThuats?trang=' + page + '&SoBanGhi=1'


            if ($scope.keyword == null) {
                chuoiketnoi += chuoiketnoi2;
            }
            else {
                chuoiketnoi += chuoiketnoi1;
            }

            apiService.get(chuoiketnoi, null, function (result) {
                $scope.list = result.data.DanhSach;
                $scope.page = result.data.Trang;
                $scope.pagesCount = result.data.SoTrang;
                $scope.totalCount = result.data.SoBanGhi;
            }, function () {
                console.log('Loi Load Du Lieu');
            })
        }
        $scope.getlist();

    }
})(angular.module('MayTinh.ThongSoKyThuat'));
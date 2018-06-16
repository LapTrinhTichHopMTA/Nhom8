
(function (app) {
    app.controller('SanPhamListController', SanPhamListController);
    SanPhamListController.$inject = ['$scope', 'apiService', 'ThongBaoService'];

    function SanPhamListController($scope, apiService, ThongBaoService) {


        $scope.ListSanPham = [];
        $scope.GetListSanPham = GetListSanPham;
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = null;
        $scope.search = search;

        function search() {
            $scope.GetListSanPham();
        }



        function GetListSanPham(page, keyword) {
            var count = 0;
            page = page || 0;
            keyword = keyword || null;
            var chuoiketnoi = '';

            var chuoiketnoi1 = 'http://localhost:51208/api/sanpham?trang=' + page + '&SoBanGhi=10&TuKhoa=' + $scope.keyword;
            var chuoiketnoi2 = 'http://localhost:51208/api/sanpham?trang=' + page + '&SoBanGhi=10'


            if ($scope.keyword == null) {
                chuoiketnoi += chuoiketnoi2;
            }
            else {
                chuoiketnoi += chuoiketnoi1;
            }

            apiService.get(chuoiketnoi, null, function (result) {

                $scope.ListSanPham = result.data.DanhSach;
                $scope.page = result.data.Trang;
                $scope.pagesCount = result.data.SoTrang;
                $scope.totalCount = result.data.SoBanGhi;
                if (result.data.DoDai == 0) {
                    ThongBaoService.displayError('Không Có Bản Ghi Nào Được Tìm Thầy');
                }

            }, function () {
                console.log('Loi Load Du Lieu');
            })
        }
        GetListSanPham();


        $scope.DeleteSanPham = DeleteSanPham;

        function DeleteSanPham(MaSanPham) {

            var chuoiketnoi = 'http://localhost:51208/api/sanpham?MaSanPham=' + MaSanPham;

            $.ajax({
                url: chuoiketnoi,
                type: "delete",
                success: function (data) {
                    ThongBaoService.displaySuccess('Xóa Sản Phâm Thành Công');
                    search();
                },
                error: function () {
                    ThongBaoService.displayError('cap nhap san pham khong thanh cong');
                }
            });
        }
    }
})(angular.module('MayTinh.SanPham'));
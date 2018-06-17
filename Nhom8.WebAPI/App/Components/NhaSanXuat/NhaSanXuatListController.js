(function (app) {
    app.controller('NhaSanXuatListController', NhaSanXuatListController);
    NhaSanXuatListController.$inject = ['$scope', 'apiService','ThongBaoService'];

    function NhaSanXuatListController($scope, apiService, ThongBaoService) {

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

            var chuoiketnoi1 = 'http://localhost:51208/api/nhasanxuats?trang=' + page + '&SoBanGhi=10&TuKhoa=' + $scope.keyword;
            var chuoiketnoi2 = 'http://localhost:51208/api/nhasanxuats?trang=' + page + '&SoBanGhi=10'


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

        $scope.DelNhaSanXuat = DelNhaSanXuat;

        function DelNhaSanXuat(MaNhaSanXuat) {
            var chuoiketnoi = 'http://localhost:51208/api/NhaSanXuats?MaNhaSanXuat=' + MaNhaSanXuat;

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
})(angular.module('MayTinh.NhaSanXuat'));
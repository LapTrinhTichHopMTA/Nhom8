(function(app){
    app.controller('LoaiSanPhamListController', LoaiSanPhamListController);
    LoaiSanPhamListController.$inject = ['$scope', 'apiService'];

    function LoaiSanPhamListController($scope, apiService) {

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

            var chuoiketnoi1 = 'http://localhost:51208/api/loaisanphams?trang=' + page + '&SoBanGhi=1&TuKhoa=' + $scope.keyword;
            var chuoiketnoi2 = 'http://localhost:51208/api/loaisanphams?trang=' + page + '&SoBanGhi=1'


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
})(angular.module('MayTinh.LoaiSanPham'));
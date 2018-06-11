
(function (app) {
    app.controller('SanPhamListController', SanPhamListController);
    SanPhamListController.$inject = ['$scope', 'apiService']; 

    function SanPhamListController($scope, apiService) {
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
            page = page || 0; 
            keyword = keyword || null;
            var chuoiketnoi = '';
            
            var chuoiketnoi1 = 'http://localhost:51208/api/sanpham?trang=' + page + '&SoBanGhi=5&TuKhoa=' + $scope.keyword; 
            var chuoiketnoi2 = 'http://localhost:51208/api/sanpham?trang=' + page + '&SoBanGhi=5'


            if ($scope.keyword == null) {
                chuoiketnoi += chuoiketnoi2;
            }
            else {
                chuoiketnoi += chuoiketnoi1;
            }

            apiService.get(chuoiketnoi,null, function (result) {
                $scope.ListSanPham = result.data.DanhSach; 
                $scope.page = result.data.Trang;
                $scope.pagesCount = result.data.SoTrang;
                $scope.totalCount = result.data.SoBanGhi; 
            }, function () {
                console.log('Loi Load Du Lieu'); 
            })
        }
        $scope.GetListSanPham(); 
    }
})(angular.module('MayTinh.SanPham'));
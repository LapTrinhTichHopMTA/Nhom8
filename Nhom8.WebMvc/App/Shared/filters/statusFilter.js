(function (app) {
    app.filter('KichHoatDoiTuong', function () {
        return function (input) {
            if (input == true)
                return 'Kích hoạt';
            else
                return 'Khóa';
        }
    });

    app.filter('KiemTraRong', function () {
        return function (input) {
            if (input == null)
                return 'Chưa Cập Nhập';
            else {
                return input; 
            }
        }
    });



})(angular.module('MayTinh.Common'));
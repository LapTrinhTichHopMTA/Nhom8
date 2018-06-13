(function (app) {
    app.factory('ThongBaoService', ThongBaoService); //tao mới sevice 

    function ThongBaoService() { 
        toastr.options = {
            "debug": false,
            "positionClass": "toast-top-right", // vị trí hiển thị cho thông báo 
            "onclick": null,
            "fadeIn": 300,
            "fadeOut": 1000,
            "timeOut": 3000,
            "extendedTimeOut": 1000
        };

        function displaySuccess(message) { // thông báo 
            toastr.success(message);
        }

        function displayError(error) { // thông báo lỗi
            if (Array.isArray(error)) {
                error.each(function (err) {
                    toastr.error(err);
                });
            }
            else {
                toastr.error(error);
            }
        }

        function displayWarning(message) {
            toastr.warning(message);
        }
        function displayInfo(message) {
            toastr.info(message);
        }

        return {
            displaySuccess: displaySuccess,
            displayError: displayError,
            displayWarning: displayWarning,
            displayInfo: displayInfo
        }
    }
})(angular.module('MayTinh.Common'));
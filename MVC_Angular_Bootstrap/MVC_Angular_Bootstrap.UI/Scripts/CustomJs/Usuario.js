var app = angular.module("usuariosApp", []);

app.controller("usuariosCtrl", function ($scope, $http) {

    $scope.GetUsuarios = function()
    { 
        $http.get('/Usuario/GetUsuarios').then(
        function successCallback(response) {
            $scope.usuarios = response.data;
        }, function errorCallback(error) {
            console.log(error);
        });
    }

    $scope.GetUsuario = function (matricula) {
        $http.post('/Usuario/GetUsuario', { matricula: matricula}).then(
            function successCallback(response) {
                $scope.usuario = response.data;
            }, function errorCallback(error) {
                console.log(error);
            });
    }

    $scope.GravaUsuario = function (usuario) {
        $http.post('/Usuario/Create', { usuario: usuario }).then(
            function successCallback(response) {
                location.href = '../Usuario';
            }, function errorCallback(error) {
                console.log(error);
            });
    }


    //chama o  método ExcluirProduto do controlador
    $scope.DeletaUsuario = function (usuario) {
        $http.post('/Usuario/Delete', { matricula: usuario.Cpf }).then(
            function successCallback(response) {
                $scope.usuarios = response.data;
            }, function errorCallback(error) {
                console.log(error);
            });
    }

    //chama o  método ExcluirProduto do controlador
    $scope.Redirect = function (url) {
        location.href = url;
    }

});
$(document).ready(function () {
    $.ajax({
        url: "https://mi00259039/aspnetcoremvc/Api/UsuApi/",
        contentType: 'application/json',
        type: "GET",
        success: function (response) {

            for (i = 0; i < response.length; i++) {
                var row = "<tr><td>" + response[i].cpf + "</td>"
                row = row + "<td>" + response[i].nome + "</td>"
                row = row + "<td>" + response[i].email + "</td>"
                row = row + "<td>" + response[i].telefone + "</td>" 
                row = row + "<td><img src=\"../images/icons/application_edit.png\" title=\"Editar\" style=\"cursor: pointer; \" onclick=\"javascript:LoadData('" + response[i].matricula + "')\" /><img src=\"../images/icons/application_delete.png\" title=\"Excluir\" style=\"cursor: pointer; \" onclick=\"javascript:DeletaUsu(" + response[i].matricula + ")\" /></td>"
                //row = row + '<td><img src="~/Images/icons/application_edit.png" title="Editar" style="cursor: pointer; " onclick="Redirect('../ Usuario / Create ? matricula = ')" /> & nbsp; <img src="~/Images/icons / application_delete.png" title="Excluir" style="cursor: pointer; " onclick="DeletaUsuario(usuario)" /></td >';

                $('#tblUser tr:last').after(row);
            }

        },
        failure: function (response) {
            alert(response);
        }
    });
});

function DeletaUsu(id) {
    $.ajax({
        url: "https://mi00259039/aspnetcoremvc/Api/UsuApi/" + id,
        type: "DELETE",
        success: function (response) {
            if (response == "ok")
                location.href = "Usuario"
        },
        failure: function (response) {
            alert(response);
        }
    });
}
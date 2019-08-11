$(document).ready(function () {

    LoadGrid()

    $("#userForm").submit(function (a) {

        a.preventDefault();

        var dat = new FormData(this);

        var object = {};
        dat.forEach(function (value, key) {
            object[key] = value;
        });
        var json = JSON.stringify(object);

        if (object.Matricula == "")
            Insert(json);
        else
            Update(json, object.Matricula);
    });
});

function Insert(json) {
    $.ajax({
        url: "http://mi00259039/aspnetcoremvc/Api/UsuApi/",
        data: json,
        contentType: 'application/json',
        type: "POST",
        success: function (response) {
            if (response == "ok") {
                $('#userForm')[0].reset();
                LoadGrid();
            }
            else
                alert(response);
        },
        failure: function (response) {
            alert(response);
        }
    });
}

function Update(json, mat) {
    $.ajax({
        url: "http://mi00259039/aspnetcoremvc/Api/UsuApi/" + mat,
        data: json,
        contentType: 'application/json',
        type: "PUT",
        success: function (response) {
            if (response == "ok") {
                $('#userForm')[0].reset();
                LoadGrid();
            }
            else
                alert(response);
        },
        failure: function (response) {
            alert(response);
        }
    });
}

function LoadData(id) {
    $.ajax({
        url: "http://mi00259039/aspnetcoremvc/Api/UsuApi/" + id,
        type: "GET",
        success: function (response) {
            var form = $("#userForm")[0];

            form.elements["Cpf"].value = response.cpf
            form.elements["Nome"].value = response.nome
            form.elements["Telefone"].value = response.telefone
            form.elements["Email"].value = response.email
            form.elements["Matricula"].value = response.matricula
        },
        failure: function (response) {
            alert(response);
        }
    });
}

function LoadGrid() {
    $.ajax({
        url: "http://mi00259039/aspnetcoremvc/Api/UsuApi",
        contentType: 'application/json',
        type: "GET",
        success: function (response) {

            $("#tblUser").find("tr:gt(0)").remove();

            for (i = 0; i < response.length; i++) {
                var row = "<tr><td>" + response[i].cpf + "</td>"
                row = row + "<td>" + response[i].nome + "</td>"
                row = row + "<td>" + response[i].email + "</td>"
                row = row + "<td>" + response[i].telefone + "</td>"
                row = row + "<td><img src=\"images/icons/application_edit.png\" title=\"Editar\" style=\"cursor: pointer; \" onclick=\"javascript:LoadData('/" + response[i].matricula + "')\" /><img src=\"images/icons/application_delete.png\" title=\"Excluir\" style=\"cursor: pointer; \" onclick=\"javascript:DeletaUsu(" + response[i].matricula + ")\" /></td>"

                $('#tblUser tr:last').after(row);
            }

        },
        failure: function (response) {
            alert(response);
        }
    });
}

function DeletaUsu(id) {
    $.ajax({
        url: "http://mi00259039/aspnetcoremvc/Api/UsuApi/" + id,
        type: "DELETE",
        success: function (response) {
            if (response == "ok")
                LoadGrid();
        
        },
        failure: function (response) {
            alert(response);
        }
    });
}
var caminho = "Api/Usuapi"
$(document).ready(function () {

    $($("#userForm")[0].elements["Cpf"]).mask("000.000.000-00")
    $($("#userForm")[0].elements["Telefone"]).mask("(00)00000-0000")

    LoadGrid()

    $("#userForm").submit(function (a) {

        a.preventDefault();
        var fd = new FormData(this);

        if (this.elements["Matricula"].value == "")
            Insert(fd);
        else
            Update(fd, this.elements["Matricula"].value);
    });

    $('#userForm')[0]["Cpf"].focus();
});

function limpaForm() {
    $('#userForm')[0].reset();
    $('#userForm')[0]["Matricula"].value = ''
    $('#userForm')[0]["Cpf"].focus();
}

function Insert(json) {
    $.ajax({
        url: caminho,
        data: json,
        contentType: false,
        processData: false,
        type: "POST",
        success: function (response) {
            if (response == "ok") {
                limpaForm();
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
        url: caminho + '/' + mat,
        data: json,
        contentType: false,
        processData: false,
        type: "PUT",
        success: function (response) {
            if (response == "ok") {
                limpaForm();
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
        url: caminho + '/' + id,
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
        url: caminho,
        contentType: 'application/json',
        type: "GET",
        success: function (response) {

            //$("#tblUser").find("tr:gt(0)").remove();
            //$("#tblUser > tbody").html("");
            //$("#tblUser > tbody").children().remove();
            $("#tblUser > tbody").empty();

            for (i = 0; i < response.length; i++) {
                var row = "<tr><td>" + response[i].cpf + "</td>"
                row = row + "<td>" + response[i].nome + "</td>"
                row = row + "<td>" + response[i].email + "</td>"
                row = row + "<td>" + response[i].telefone + "</td>"
                row = row + "<td><img src=\"images/icons/application_edit.png\" title=\"Editar\" style=\"cursor: pointer; \" onclick=\"javascript:LoadData('/" + response[i].matricula + "')\" /><img src=\"images/icons/application_delete.png\" title=\"Excluir\" style=\"cursor: pointer; \" id='del_" + response[i].matricula + "'  onclick='javasctipt:exclui(" + response[i].matricula + ")' /></td></tr>"

                $('#tblUser > tbody').append(row);
            }

        },
        failure: function (response) {
            alert(response);
        }
    });
}     

function exclui(matr) {

    var template = '<div class="popover"><div class="arrow"></div><h3 class="popover-title" style="color: #A94442; background-color: #F2DEDE;"></h3><div class="popover-content" style="text-align: center;"></div></div>';

    var elemento = '#del_' + matr;

    var conteudo = '<button type="button" class="btn btn-primary btn-xs" onclick="DeletaUsu(' + matr + ')" ><i class="glyphicon glyphicon-ok"></i> Sim</button>' +
        '<button type="button"  class="btn btn-default btn-xs" onclick="$(\'' + elemento + '\').popover(\'destroy\')"><i class="glyphicon glyphicon-remove"></i> Não</button>'


    $(elemento).popover({
        title: "Deseja realmente Excluir?",
        html: true,
        content: conteudo,
        placement: 'bottom',
        template: template
    });

    $(elemento).popover('show');
}

function DeletaUsu(id) {
    $.ajax({
        url: caminho + '/' + id,
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
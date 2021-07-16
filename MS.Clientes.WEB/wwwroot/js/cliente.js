var datatable;

$(document).ready(function () {
    loadDatable();
    var id = document.getElementById("Id");

    if (id.value > 0) {
        $('#myModal').modal('show');
    }
});


function limpiar() {
    var clienteId = document.getElementById('Id');
    var nombres = document.getElementById('Nombres');
    var apellidos = document.getElementById('Apellidos');
    var direccion = document.getElementById('Direccion');
    var telefono = document.getElementById('Telefono');
    var estado = document.getElementById('Estado');

    clienteId.value = 0;
    nombres.value = "";
    apellidos.value = "";
    direccion.value = "";
    telefono.value = "";
    estado.value = true;
}

function loadDatable() {
    datatable = $('#tbData').DataTable({
        "ajax": {
            "url": "/Cliente/Listar"
        },
        "columns": [
            { "data": "nombres", "with": "20%" },
            { "data": "apellidos", "with": "20%" },
            { "data": "direccion", "with": "20%" },
            { "data": "telefono", "with": "10%" },
            {
                "data": "estado",
                "render": function (data) {
                    if (data == true) {
                        return "Activo";
                    }
                    else {
                        return "Inactivo";
                    }
                }, "with" : "10%",
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div>
                                <a href="/Cliente/Crear/${data}" class= "btn btn-success text-white" style="cursor:pointer;" > Editar </a>
                            </div>
                           `;
                }, "with": "10%"
            }
        ]
    });
}

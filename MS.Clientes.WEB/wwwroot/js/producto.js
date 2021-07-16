var datatable;

$(document).ready(function () {
    loadDataTable();
    var id = document.getElementById("IdProducto");

    if (id.value > 0) {
        $('#myModalProducto').modal('show');
    }
});

function loadDataTable() {
    datatable = $('#tdDataProd').DataTable({
        "ajax": {
            "url": "/Producto/Listar"
        },
        "columns": [
            { "data": "nombre", "with": "30%" },
            { "data": "fechaVencimiento", "with": "20%" },
            { "data": "precioUnitario", "with": "20%" },
            {
                "data": "estado",
                "render": function (data) {
                    if (data == true){
                        return "Activo";
                    }
                    else {
                        return "Inactivo";
                    }
                }, "with": "10%",
            },
            {
                "data": "idProducto",
                "render": function (data) {
                    return `
                            <div>
                                <a href="/Producto/Crear/${data}" class= "btn btn-success text-white" style="cursor:pointer;" > Editar </a>
                            </div>
                           `;
                }, "with": "10%"
            }
        ]
    });
}
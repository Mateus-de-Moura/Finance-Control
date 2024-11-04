$(document).ready(function () {

    const dataTables = $("#table-user").DataTable({
        length: false,
        ajax: {
            url: "/AppUser/GetDataTables",
            type: "POST",
            datatype: "json",
            data: function (data) {
                data.query = $("#input-search").val();
            }
        },
        columns: [
            {
                data: "isActive",
                autoWidth: true,
                render: function (data) {
                    return data
                        ? `<i class="fas fa-check text-success"></i>`
                        : `<i class="fas fa-times text-danger"></i>`;
                }
            },
            { data: "name", autoWidth: true },
            { data: "email", autoWidth: true },
            {
                data: "role",
                autoWidth: true,
                render: function (data) {
                    return `<span class="badge bg-info">${data}</span>`;
                }
            },           
            {
                data: "id",
                autoWidth: true,
                render: function (data) {

                    return `<a href="/AppUser/Edit/${data}" class="my-4" title="Editar">
                                <i class="far fa-edit"></i>
                            </a>`;
                }
            }
        ]
    });

    //$('#input-search').keypress(function (event) {

    //    var keycode = (event.keyCode ? event.keyCode : event.which);

    //    if (keycode == '13') {
    //        dataTables.ajax.reload();
    //    }

    //    event.stopPropagation();
    //});

    $("button").click(() => dataTables.ajax.reload());

});
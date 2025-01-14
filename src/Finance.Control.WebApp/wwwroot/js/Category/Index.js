$(document).ready(function () {

    const dataTables = $("#table-category").DataTable({
        length: false,
        ajax: {
            url: "/Category/GetDataTables",
            type: "POST",
            datatype: "json",
            data: function (data) {
                data.query = $("#search").val();
            }
        },
        columns: [
            {
                data: "active",
                autoWidth: true,
                render: function (data) {
                    return data
                        ? `<i class="fas fa-check text-success"></i>`
                        : `<i class="fas fa-times text-danger"></i>`;
                }
            },
            { data: "name", autoWidth: true },
            { data: "type", autoWidth: true },           
            {
                data: "id",
                autoWidth: true,
                render: function (data) {
                    console.log(data)
                    return `<a href="/Category/Edit?CategoryId=${data}" class="my-4" title="Editar">
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
$(document).ready(function () {

    const dataTables = $("#table-accountsPayable").DataTable({
        length: false,
        ajax: {
            url: "/AccountsPayable/GetDataTables",
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
            { data: "description", autoWidth: true },
            {
                data: "value",
                autoWidth: true,
                render: function (data) {                  
                    let result = (parseFloat(data) || 0).toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' }).toString();
                    debugger
                    return result.toString();
                }
            },            {
                data: "maturityDate",
                autoWidth: true,
                render: function (data) {                   
                    var date = new Date(data);
                    return date.toLocaleDateString('pt-BR');  
                }
            },       
            { data: "status", autoWidth: true },           
            {
                data: "id",
                autoWidth: true,
                render: function (data) {
                    console.log(data)
                    return `<a href="/AccountsPayable/Edit?CategoryId=${data}" class="my-4" title="Editar">
                                <i class="far fa-edit"></i>
                            </a>`;
                }
            }
        ]
    });

    $("button").click(() => dataTables.ajax.reload());

});
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
                    return result;
                },
                type: 'string'
            },
            {
                data: "maturityDate",
                autoWidth: true,
                render: function (data) {
                    var date = new Date(data);
                    return date.toLocaleDateString('pt-BR');
                }
            },
            {
                data: "status",
                autoWidth: true,
                type: 'string',
                render: function (data, type, row) {
                    return getStatusName(data);
                }
            },
            {
                data: "id",
                autoWidth: true,
                render: function (data) {
                    console.log(data)
                    return `<a href="/AccountsPayable/Edit?AccountPayableId=${data}" class="my-4" title="Editar">
                                <i class="far fa-edit"></i>
                            </a>`;
                }
            }
        ]
    });

    $("button").click(() => dataTables.ajax.reload());

});

function getStatusName(status) {
    const statusMap = {
        0: 'Pendente',
        1: 'Pago',
        2: 'Vencido'
    };
    return statusMap[status] || 'Desconhecido';
}
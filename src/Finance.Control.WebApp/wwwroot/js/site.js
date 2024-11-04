window.addEventListener('DOMContentLoaded', event => {

    if (document.querySelector('#sidebar-wrapper')) {
        // Toggle the side navigation
        const sidebarToggle = document.body.querySelector('#sidebarToggle');
        const closeSidebar = document.body.querySelector('#close-sidebar');

        const submenusLabel = document.body.querySelectorAll('.submenu-label');

        for (let submenu of submenusLabel) {
            submenu.onclick = function () { this.classList.toggle('active'); }
        }

        if (sidebarToggle && closeSidebar) {
            // Uncomment Below to persist sidebar toggle between refreshes
            if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
                document.body.classList.toggle('sb-sidenav-toggled');
            }
            closeSidebar.addEventListener('click', handleToggle);
            sidebarToggle.addEventListener('click', handleToggle);
        }
    }

    /*====================
Datatables
====================*/

    $.extend(true, $.fn.dataTable.defaults, {
        searching: false,
        ordering: false,
        processing: true,
        serverSide: true,
        filter: false,
        lengthChange: false,
        pageLength: 10,
        pagingType: "full_numbers",
        language: {
            processing: `<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>`,
            emptyTable: "Sem dados disponíveis",
            sLengthMenu: "Mostrar _MENU_ registros",
            sZeroRecords: "Não foram encontrados resultados",
            sInfo: "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            sInfoEmpty: "Mostrando de 0 até 0 de 0 registros",
            sInfoFiltered: "",
            sInfoPostFix: "",
            sSearch: "Procurar:",
            sUrl: "",
            oPaginate: {
                sNext: '<i class="fa fa-chevron-right"></i>',
                sPrevious: '<i class="fa fa-chevron-left"></i>',
                sFirst: '<i class="fa fa-angle-double-left"></i>',
                sLast: '<i class="fa fa-angle-double-right"></i>'
            }
        }, layout: {
            topStart: null,
            bottom: 'paging',
            bottomStart: 'info',
            bottomEnd: null
        }
    });

});

function handleToggle(event) {
    event.preventDefault();
    document.body.classList.toggle('sb-sidenav-toggled');
    localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
}

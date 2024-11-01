//const $button = document.querySelector('#sidebar-toggle');
//const $wrapper = document.querySelector('#wrapper');
//const $titles = document.querySelectorAll('.sidebar-title');
//const $icons = document.querySelectorAll('.sidebar-icons');


//$wrapper.classList.add('toggled');
//$('.sidebar-brand').hide();

//if ($button) {
//    $button.addEventListener('click', (e) => {
//        e.preventDefault();
//        $wrapper.classList.toggle('toggled');
//        if ($wrapper.classList.contains('toggled')) {
           
//            $('.sidebar-brand').hide();

//        } else {         
//            $('.sidebar-brand').show();
//        }
//    });
//}
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

});

function handleToggle(event) {
    event.preventDefault();
    document.body.classList.toggle('sb-sidenav-toggled');
    localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
}

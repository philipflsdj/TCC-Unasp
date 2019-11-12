$(document).ready(function () {
    // Setup - add a text input to each footer cell
    $('#dataTable tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
        
    });

    // DataTable
    var table = $('#dataTable').DataTable();

    //cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Portuguese-Brasil.json
    // Apply the search
    table.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change clear', function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });
    });

});
//$(document).ready(function () {

//    $('#dataTable').DataTable({
//        // Setup - add a text input to each footer cell

//        language: {
            
//            "decimal": "",
//            "emptyTable": "Nenhum item encontrado",
//            "info": "Exibindo _START_ at&eacute _END_ de _TOTAL_ item(s)",
//            "infoEmpty": "Exibindo 0 at&eaccute; 0 de 0 item(s)",
//            "infoFiltered": "(filtrado de _MAX_ item(s))",
//            "infoPostFix": "",
//            "thousands": ",",
//            "lengthMenu": "Exibir _MENU_ item(s)",
//            "loadingRecords": "carregando...",
//            "processing": "Processando...",
//            "search": "Buscar:",
//            "zeroRecords": "Nenhum registro encontrado",
//            "paginate": {
//                "first": "Primeiro",
//                "last": "&Uacuteltimo",
//                "next": "Pr&oacuteximo",
//                "previous": "Anterior"
//            },
//            "aria": {
//                "sortAscending": ": activate to sort column ascending",
//                "sortDescending": ": activate to sort column descending"
//            }
//        }
      
//    });
//});

//$(document).ready(function () {
//    $('#dataTable').DataTable({
//        "language": {
//            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Portuguese-Brasil.json"
//        }
//    });
//});
function ListagemConsulta(table, url, colunas) {

    LigaAguarde();

    $('#' + table).dataTable().fnDestroy();
    
    $.ajax({
        url: url,
        type: "post",
        dataType: "json",
        success: function (data) {

            oTable = $('#' + table).dataTable({
                dom: 'Blfrtip',
                buttons: ['excel', 'pdf', 'print'],
                "fnDrawCallback": function (settings) { DesligueAguarde(); },
                "bAutoWidth": true,
                "destroy": true,
                "stateSave": true,
                "Info": false,
                "bPaginate": true,
                "bLengthChange": true,
                "pageLength": 5,
                "lengthMenu": [5, 10, 20, 30, 40, 50, 70, 80, 90, 100],
                "oLanguage": {
                    "decimal": ",",
                    "thousands": ".",
                    "sProcessing": "Aguarde o processamento...",
                    "sLengthMenu": "Por Pagina _MENU_",
                    "sInfo": "",
                    "sZeroRecords": "Nao foram encontrados resultados",
                    "sInfoEmpty": "",
                    "sInfoFiltered": "Filtrado de _MAX_ registros n total)",
                    "sInfoPosFix": "",
                    "sSearch": "Buscar",
                    "sUrl": "",
                    "oPaginate": {
                        "sFirst": "Primeiro",
                        "sPrevius": "Anterior",
                        "sNext": "Proximo",
                        "sLast": "Ultimo"
                    },
                },
                "data": data,

                "columns": colunas,

            });
            alert('passou')
        },
        error: function (data) {
            alert(JSON.stringify(data))
        }
    });

    jquery.extend(jQuery.fn.dataTableExt.oSort, {

        "currency-pre": function (a) {
            a = replaceall(a, ".", "");
            a = (a === "-") ? 0 : a.replace(/[^\d-\.]/g, "");
            return parseFloat(a);
        },

        "currency-asc": function (a, b) {
            return a - b;
        },

        "currency-desc": function (a, b) {
            return b - a;
        },

        "date-uk-pre": function (a) {
            var ukDatea = a.split('/');
            return (ukDatea[2] + ukDatea[1] + ukDatea[0]) * 1;
        },

        "date-uk-asc": function (a, b) {
            return ((a < b) ? -1 : ((a > b) ? 1 : 0));
        },

        "date-uk-asc": function (a, b) {
            return ((a < b) ? 1 : ((a > b) ? -1 : 0));
        },

    });

} //ListagemConsulta

function replaceall(str, replace, with_this) {
    var str_hasil = "";
    var temp;

    for (var i = 0; i < str.length; i++) // not need to be equal. it causes the last change: undefined..
    {
        if (str[i] == replace) {
            temp = with_this;
        }
        else {
            temp = str[i];
        }

        str_hasil += temp;
    }

    return str_hasil;

} //replaceall

function LigaAguarde() {
    $("#aguarde").modal('show');
}

function LigaAguarde() {
    $("#aguarde").modal('hide');
}


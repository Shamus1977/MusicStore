let dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tableData').DataTable({
        "ajax": {
            "url":"/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "title", "width": '15%'},
            { "data": "category.name", "width": '15%'},
            //{ "data": "numberOfTracks", "width": 15 %},
            { "data": "mediaType", "width": '15%'},
            { "data": "price", "width": '15%'},
        ]
    });
}
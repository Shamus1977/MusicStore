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
            { "data": "price", "width": '15%' },
            {
                "data": "id",
                "render": function (data) {
                    return `
                                <div class="w-75 btn-group" role="group">
                                    <a href="/Admin/Product/Upsert?id=${data}"
                                        class="btn btn-primary">
                                        Edit
                                    </a>
                                    <a
                                        onClick=Delete('/Admin/Product/Delete/${data}')
                                        class="btn btn-danger">
                                        Delete
                                    </a>
                                </div>
                            `
                },
                "width": '15%'
            }
        ]
    });
}

function Delete(url) {
    if (confirm("Are You Sure You Would Like To Delete This Product?") === true) {
        $.ajax({
            url: url,
            type: "DELETE",
            success: function (data) {
                if (data.success) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                } else {
                    toastr.error(data.message);
                }
            }
        });
    } else {
        alert("Delete Has Been Canceled");
    }
}
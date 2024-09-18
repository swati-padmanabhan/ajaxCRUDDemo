function loadItems() {
    $.ajax({
        url: "/Home/GetAllItems",
        type: "GET",
        success: function (data) {
            $("#tblBody").empty()

            $.each(data, function (index, item) {
                var row = `<tr>
                <td>${item.Name}</td>
                 <td>${item.Description}</td>
                  <td>${item.Price}</td>
                   <td>
                   <button onclick="editItem(${item.Id})" value="Edit" class="btn btn-success">Edit</button>
                   </td>
                   <td>
                   <button onclick="deleteRecord(${item.Id})" value="Delete" class="btn btn-danger">Delete</button>
                   </td>
                   </tr>`
                   $("#tblBody").append(row)
            })
        },
        error: function (err) {
            $("#tblBody").empty()
            alert("No Data Available")
        }
    })
}

//toggling views
$("#btnAdd").click(() => {
    $("#itemList").hide();
    $("#newRecord").show();
})

function addNewRecord(newItem) {
    $.ajax({
        url: "/Home/Add",
        type: "POST",
        data: newItem,

        success: function (item) {
            alert("New Item Added Successfully")
            loadItems()
        },
        error: function (err) {
            alert("Error Adding New Record")
        }
    })
}

function deleteRecord(itemId) {
    if (confirm("Do you wish to delete this item?")) {
        $.ajax({
            url: "/Home/Delete",
            type: "POST",
            data: { id: itemId },
            success: function (item) {
                alert("Record Deleted Sucessfully")
                loadItems();
            },
            error: function (err) {
                alert("Record Does Not Exist")
            }
        })
    }
}
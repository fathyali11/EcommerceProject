function Delete(_url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: _url,
                type: 'DELETE', // Use 'DELETE' instead of 'Delete'
                success: function (data) {
                    toastr.success(data.message); // Show success message using toastr
                    // Assuming you have a function to reload data or update UI
                    reloadData(); // Call a function to reload data or update UI
                },
                error: function (xhr, status, error) {
                    toastr.error("Failed to delete item."); // Show error message if deletion fails
                }
            });
        }
    });
}

// Example function to reload data (replace with your actual implementation)
function reloadData() {
    // Code to reload your data table or update UI element
    dataTable.ajax.reload(); // Reload data table assuming 'dataTable' is initialized
}

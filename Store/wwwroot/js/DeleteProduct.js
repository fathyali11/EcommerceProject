function Delete(_url) {
    console.log("Deleting:", _url); // Log to check if function is called correctly
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
                type: 'DELETE',
                success: function (data) {
                    console.log("Delete successful:", data); // Log success data
                    window.location.reload(); // Reload the page after successful deletion
                    toastr.success(data.message); // Show a success message using toastr (if applicable)
                },
                error: function (xhr, status, error) {
                    console.error("Delete request failed:", error); // Log any errors
                    toastr.error("Delete request failed"); // Show an error message using toastr (if applicable)
                }
            });
        }
    });
}

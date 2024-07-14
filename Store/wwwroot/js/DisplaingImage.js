function previewImage(event) {
    var file = event.target.files[0];
    if (file) {
        var reader = new FileReader();
        reader.onload = function () {
            var output = document.getElementById('imagePreview');
            output.innerHTML = '<img src="' + reader.result + '" class="img-fluid" />';
        }
        reader.readAsDataURL(file);
    } else {
        document.getElementById('imagePreview').innerHTML = ''; // Clear preview if no file selected
    }
}

function clearPreview() {
    document.getElementById('imagePreview').innerHTML = '';
    document.getElementById('imageFile').value = ''; // Clear selected file
}
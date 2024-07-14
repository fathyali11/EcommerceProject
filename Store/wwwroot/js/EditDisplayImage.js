function previewImage(event)
{
    var reader = new FileReader();
    reader.onload = function() {
        var output = document.getElementById('imagePreview');
        output.innerHTML = '<img src="' + reader.result + '" class="img-fluid" />';
    }
    reader.readAsDataURL(event.target.files[0]);
}

function clearPreview()
{
    var output = document.getElementById('imagePreview');
    output.innerHTML = '';
    document.getElementById('imageFile').value = '';
}
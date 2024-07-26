document.addEventListener("DOMContentLoaded", function () {
    var roleSelect = document.querySelector('select[name="Input.Role"]');
    var companySelect = document.getElementById('companySelection');

    roleSelect.addEventListener('change', function () {
        if (roleSelect.value === 'Admin') {
            companySelect.style.display = 'block';
        } else {
            companySelect.style.display = 'none';
        }
    });

    // Trigger change event on page load to set initial state
    roleSelect.dispatchEvent(new Event('change'));
});

document.querySelectorAll('.sort-option').forEach(function (element) {
    element.addEventListener('click', function () {
        var sortType = element.getAttribute('data-sort');
        var sortLabel = document.getElementById('sortLabel');
        sortLabel.innerText = element.innerText;
        sort(sortType);
    });
});

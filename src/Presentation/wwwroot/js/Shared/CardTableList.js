document.addEventListener('DOMContentLoaded', function () {
    var tableViewIcon = document.getElementById('tableViewIcon');
    var cardViewIcon = document.getElementById('cardViewIcon');
    tableViewIcon.classList.add('selected');
});

function toggleView(view) {
    var cardView = document.getElementById('cardView');
    var tableView = document.getElementById('tableView');
    var cardViewIcon = document.getElementById('cardViewIcon');
    var tableViewIcon = document.getElementById('tableViewIcon');

    if (view === 'card') {
        cardView.classList.remove('d-none');
        tableView.classList.add('d-none');
        cardViewIcon.classList.add('selected');
        tableViewIcon.classList.remove('selected');
    } else if (view === 'table') {
        cardView.classList.add('d-none');
        tableView.classList.remove('d-none');
        cardViewIcon.classList.remove('selected');
        tableViewIcon.classList.add('selected');
    }
}
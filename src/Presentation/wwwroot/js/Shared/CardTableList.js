document.addEventListener('DOMContentLoaded', function () {
    var tableViewIcon = document.getElementById('tableViewIcon');
    var cardViewIcon = document.getElementById('cardViewIcon');

    // Load the stored view preference or default to 'table'
    var savedView = localStorage.getItem('viewPreference') || 'table';
    toggleView(savedView);
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
    } else if (view == 'table') {
        tableView.classList.remove('d-none');
        cardView.classList.add('d-none');
        tableViewIcon.classList.add('selected');
        cardViewIcon.classList.remove('selected');
    }

    // Store the choice in localStorage
    localStorage.setItem('viewPreference', view);
}
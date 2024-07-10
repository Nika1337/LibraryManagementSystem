function showLogDetails(log) {
    const modal = document.getElementById('logDetailsModal');

    modal.querySelector('#logApplication').textContent = log.applicationName;
    modal.querySelector('#logId').textContent = log.id;
    modal.querySelector('#logUserId').textContent = log.userId;
    modal.querySelector('#logEntityName').textContent = log.entityName;
    modal.querySelector('#logModifiedRowId').textContent = log.modifiedRowId;
    modal.querySelector('#logAction').textContent = log.action;
    modal.querySelector('#logTimestamp').textContent = new Date(log.timestamp).toLocaleString();

    const changesContent = modal.querySelector('#logChanges');
    try {
        const formattedChanges = JSON.stringify(JSON.parse(log.changes), null, 2);
        changesContent.textContent = formattedChanges;
    } catch (e) {
        changesContent.textContent = log.changes;
    }


    const bootstrapModal = new bootstrap.Modal(modal);
    bootstrapModal.show();
}
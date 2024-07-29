function showLogDetails(log) {
    const $modal = $('#logDetailsModal');

    $modal.find('#logApplication').text(log.applicationName);
    $modal.find('#logId').text(log.id);
    $modal.find('#logUserId').text(log.userId);
    $modal.find('#logEntityName').text(log.entityName);
    $modal.find('#logModifiedRowId').text(log.modifiedRowId);
    $modal.find('#logAction').text(log.action);
    $modal.find('#logTimestamp').text(new Date(log.timestamp).toLocaleString());

    const $changesContent = $modal.find('#logChanges');
    try {
        const formattedChanges = JSON.stringify(JSON.parse(log.changes), null, 2);
        $changesContent.text(formattedChanges);
    } catch (e) {
        $changesContent.text(log.changes);
    }

    const bootstrapModal = new bootstrap.Modal($modal[0]);
    bootstrapModal.show();
}

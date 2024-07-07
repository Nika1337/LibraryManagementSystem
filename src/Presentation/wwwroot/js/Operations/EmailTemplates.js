


loadEmailTemplates();


tinymce.init({
    selector: '#tinymce-editor',
    plugins: [
        'advlist', 'autolink', 'link', 'image', 'lists', 'charmap', 'preview', 'anchor', 'pagebreak',
        'searchreplace', 'wordcount', 'visualblocks', 'code', 'fullscreen', 'insertdatetime', 'media',
        'table', 'emoticons', 'help'
    ],
    toolbar: 'undo redo | styles | bold italic | alignleft aligncenter alignright alignjustify | ' +
        'bullist numlist outdent indent | link image | print preview media fullscreen | ' +
        'forecolor backcolor emoticons | help',
    menubar: 'favs file edit view insert format tools table help',
    content_style: 'body { font-family: Helvetica, Arial, sans-serif; font-size: 16px }',
    height: 800,
    resize: true,
});

document.getElementById('confirmAction').addEventListener('click', function () {
    var fetchPath = `/Operations/EmailTemplates/${userAction}/${id}`;
    var afterFetchPath = `/Operations/EmailTemplates/${id}`;

    performAction(fetchPath, afterFetchPath);
});
function loadEmailTemplates() {
    $.ajax({
        url: '/Operations/EmailTemplates',
        method: 'GET',
        success: function (data) {
            var emailTemplatesList = $('#emailTemplatesList');
            var offcanvasEmailTemplatesList = $('#offcanvasEmailTemplatesListe');
            emailTemplatesList.empty();
            offcanvasEmailTemplatesList.empty();



            data.forEach(function (template) {
                var isSelected = template.id == id;
                var templateItem = `
                                        <a href="/Operations/EmailTemplates/${template.id}" class="list-group-item list-group-item-action ${isSelected ? 'selected' : ''} py-3 lh-tight w-100">
                                            <div class="d-flex justify-content-between">
                                                <div class="row">
                                                    <h5 class="mb-1">${template.name}</h5>
                                                    <p class="mb-1">${template.briefDescription}</p>
                                                </div>
                                                <div>
                                                    <span class="badge ${template.isActive ? 'bg-success' : 'bg-danger'}">
                                                        ${template.isActive ? 'Active' : 'Deleted'}
                                                    </span>
                                                </div>
                                            </div>
                                        </a>`;
                emailTemplatesList.append(templateItem);
                offcanvasEmailTemplatesList.append(templateItem);
            });
            showContent();
        }
    });
}

function showContent() {
    $('#loadingIndicator').hide();
    $('#mainContent').show();
}
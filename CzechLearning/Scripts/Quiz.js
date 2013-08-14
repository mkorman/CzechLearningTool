// Clear user error icon on user keypress
$(function () {
    $('#userTranslation').keydown(function () {
        $('.resultIcon').hide();
    });
});

// Initially hide all icons
$(function () {
    $(".resultIcon").hide();
});
// Bind space to 'next' action
$(document).bind('keydown', 'space', getNext);

// Reload page and get a new word
function getNext(evt) {
    evt.preventDefault();
    // We reload the page, knowing that we'll get a new word
    location.reload();
    return false;
};

// AJAX callback to conditionally display result icon
function updateIcon(event) {
    $("#successIcon").toggle(event);
    $("#errorIcon").toggle(!event);
};

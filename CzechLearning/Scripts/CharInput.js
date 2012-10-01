//
// Adds a character (char) into an element with id 'dest'
//
function addChar(char, dest) {

    var destElement, text, textBefore, textAfter, insertPoint;


    destElement = $("#" + dest);
    text = destElement.val();

    // Quirky logic to get current caret position... does not work for IE!
    insertPoint = destElement[0].selectionStart || text.length;

    textBefore = text.substring(0, insertPoint);
    textAfter = text.substring(insertPoint, text.length);
    text = textBefore + char + textAfter;
    destElement.val(text);

    // Set caret to previous position + 1
    destElement[0].selectionStart = insertPoint + 1;
    destElement[0].selectionEnd = insertPoint + 1;

    // Return focus to element
    destElement.focus();
}

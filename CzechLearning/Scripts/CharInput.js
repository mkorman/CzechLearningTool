//
// Adds a character (char) into an element with id 'dest'
//
function addChar(event, char, dest) {

    var destElement, text, textBefore, textAfter, selectionStart, selectionEnd, textBox;

    // convert to uppercase
    if (event.shiftKey) char = char.toUpperCase();

    destElement = $("#" + dest);
    textBox = destElement[0];
    text = destElement.val();

    // Get caret/selection
    selectionStart = textBox.selectionStart;
    selectionEnd = textBox.selectionEnd;

    textBefore = text.substring(0, selectionStart);
    textAfter = text.substring(selectionEnd);
    text = textBefore + char + textAfter;
    destElement.val(text);

    // Set caret to previous position + 1
    textBox.selectionStart = selectionStart + 1;
    textBox.selectionEnd = selectionStart + 1;

    // Return focus to element
    destElement.focus();
}

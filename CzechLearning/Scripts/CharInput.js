
function addChar(char, dest) {

    var destElement, text;


    destElement = $("#" + dest);
    text = destElement.val();
    text += char;
    destElement.val(text);
    destElement.focus();

}
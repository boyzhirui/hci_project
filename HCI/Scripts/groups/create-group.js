function addList() {

    var dropdown = "#SFdropMenu-0";
    var ce = $('<li id="SF1"><a onclick="getStudyField1(this)">Computer Engineering</a></li>');
    var cs = $('<li id="SF2"><a onclick="getStudyField1(this)">Computer Science</a></li>');
    var math = $('<li id="SF3"><a onclick="getStudyField1(this)">Mathematics</a></li>');
    var none = $('<li id="SFN"><a onclick="getStudyField1(this)">None</a></li>')
    $(dropdown).empty();
    $(dropdown).append(ce);
    $(dropdown).append(cs);
    $(dropdown).append(math);
    $(dropdown).append(none);

    var dropdown = "#SFdropMenu-1";
    var ce = $('<li id="SF1"><a onclick="getStudyField2(this)">Computer Engineering</a></li>');
    var cs = $('<li id="SF2"><a onclick="getStudyField2(this)">Computer Science</a></li>');
    var math = $('<li id="SF3"><a onclick="getStudyField2(this)">Mathematics</a></li>');
    var none = $('<li id="SFN"><a onclick="getStudyField2(this)">None</a></li>')
    $(dropdown).empty();
    $(dropdown).append(ce);
    $(dropdown).append(cs);
    $(dropdown).append(math);
    $(dropdown).append(none);

    var dropdown = "#SFdropMenu-3";
    var ce = $('<li id="SF1"><a onclick="getStudyField3(this)">Computer Engineering</a></li>');
    var cs = $('<li id="SF2"><a onclick="getStudyField3(this)">Computer Science</a></li>');
    var math = $('<li id="SF3"><a onclick="getStudyField3(this)">Mathematics</a></li>');
    var none = $('<li id="SFN"><a onclick="getStudyField3(this)">None</a></li>')
    $(dropdown).empty();
    $(dropdown).append(ce);
    $(dropdown).append(cs);
    $(dropdown).append(math);
    $(dropdown).append(none);
}
function removeList(current) {
    for (var i = 0; i <= 2; i++) {
        var dropdown = "#SFdropMenu-" + i;

        for (var j = 1; j <= 3; j++) {
            var list = "#SF" + j;
            for (var k = 1; k <= 3; k++) {
                if (i != k - 1) {
                    var inputBox = "#studyField" + k;
                    var inputValue = $(inputBox).val();
                    if ($(dropdown).children(list).text() == inputValue) {
                        $(dropdown).children(list).remove();
                    }
                }
            }
        }
    }
}
function getStudyField1(sender) {
    var sf = sender.textContent;
    $('#studyField1').val(sf);
    addList();
    removeList(1);
}
function getStudyField2(sender) {
    var sf = sender.textContent;
    $('#studyField2').val(sf);
    addList();
    removeList(2);
}
function getStudyField3(sender) {
    var sf = sender.textContent;
    $('#studyField3').val(sf);
    addList();
    removeList(3);
}
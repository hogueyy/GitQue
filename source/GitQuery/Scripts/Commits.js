function confirmQuery(numRows) {
    window.alert('Success! The query has been made and ' + numRows + ' entries were affected.');
    window.location.href = '/Dbases';
}

function showError(err) {
    document.getElementById("error").innerHTML = err;
}

function analyze(itemID) {
    document.getElementById("commit") = "<input type='submit' value=" + itemID + ">";
    document.getElementById("user") = "<label class='control-label col-md-2' for='Username'>Username</label>" +
                                        "<div class='col-md-10'>" +
                                            "<input class='form-control text-box single-line' id='username' name='username' type='text' value='' />" +
                                        "</div>";

    document.getElementById("pass") = "<label class='control-label col-md-2' for='password'>Password</label>" +
                                        "<div class='col-md-10'>" +
                                            "<input class='form-control text-box single-line' id='password' name='pass' type='text' value='' />" +
                                        "</div>";
    document.getElementById("submitLogin").innerHTML = "<input type='submit' value='Submit' formaction='Undo' class='btn btn-default' />";
}

function success(numRows) {
    window.alert('Success! Your query has been undone and ' + numRows + ' entries were affected.');
    window.location.href = '/Commits/Undo';
}

function selectDB(type) {
    //document.getElementById(type).style.border = "solid #8a8a8a";
    window.location.href = '/Dbases/Create?step=1&dbType=' + type;
}
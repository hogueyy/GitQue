function showError() {
    window.alert('Login failed. Please ensure that you have entered the correct information, have permission to update this database, and have enabled the server to accecpt remote connections.');
    window.location.href = '/Dbases/Create';
}

function analyze(itemID) {
    document.getElementById("LoginMessage").innerHTML = "Please help us keep your database secure by logging in";
    document.getElementById("commit").innerHTML = "<input type='hidden' name='id' value=" + itemID + ">";
    document.getElementById("user").innerHTML = "<label class='control-label col-md-2' for='Username'>Username</label>" +
                                        "<div class='col-md-10'>" +
                                            "<input class='form-control text-box single-line' id='username' name='username' type='text' value='' />" +
                                        "</div>";

    document.getElementById("pass").innerHTML = "<label class='control-label col-md-2' for='password'>Password</label>" +
                                        "<div class='col-md-10'>" +
                                            "<input class='form-control text-box single-line' id='password' name='pass' type='password' value='' />" +
                                        "</div>";
    document.getElementById("submitLogin").innerHTML = "<input type='submit' value='Submit' formaction='Undo' class='btn btn-default' />";
}
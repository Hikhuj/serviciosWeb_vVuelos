function comparePw() {
    let password = document.getElementById("new_password").value;
    let confirmPw = document.getElementById("confirmacion").value;
    
        if (password != confirmPw) {
            document.getElementById("validation-confirmation").style.display = 'block';
            document.getElementById("validation-confirmation").className = 'text-danger'
            document.getElementById("validation-confirmation").innerText = 'Las contraseñas no coinciden'
        } else {
            document.getElementById("validation-confirmation").style.display = 'block';
            document.getElementById("validation-confirmation").className = 'text-info'
            document.getElementById("validation-confirmation").innerText = 'Requisitos en regla'
        }
    
}

function validateData() {
    let current = document.getElementById("old_password").value;
    let password = document.getElementById("new_password").value;
    let confirmPw = document.getElementById("confirmacion").value;
    if (password.length > 8 && current != "" && confirmPw == password) {
        return true;

    } else {
        document.getElementById("validation").style.display = 'block';
        document.getElementById("validation").innerText = 'Revise todos los campos por favor';
        return false;
    }
}

function checkPasswordField(id) {
    let password = document.getElementById(id).value;
    if (password.length > 8 && password.length < 16) {
        document.getElementById(id + "-span").className = "text-info";
        document.getElementById(id + "-span").style.display = 'block';
        document.getElementById(id + "-span").innerText = "Cumple los requisitos"
    } else {
        document.getElementById(id + "-span").className = "text-danger";
        document.getElementById(id + "-span").style.display = 'block';
        document.getElementById(id + "-span").innerText = "No cumple los requisitos"
    }
}
(function () {
    const compraGet = function () {
        let destino = document.getElementById('btnComprar').value;
        alert("Se realizó la compra del boleto");
    }

    const initializer = function () {
        compraGet();
    }

    initializer();

})()
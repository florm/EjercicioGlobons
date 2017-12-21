var Nombre = $("#Nombre");
var errorNombre = $("#errorNombre");

var Apellido = $("#Apellido");
var errorApellido = $("#errorApellido");

var NumeroDocumento = $("#NumeroDocumento");
var errorNumeroDocumento = $("#errorNumeroDocumento");

var FechaNacimiento = $("#FechaNacimiento");
var errorFechaNacimiento = $("#errorFechaNacimiento");

var Direccion_calle = $("#Direccion_calle");
var errorCalle = $("#errorCalle");

var Direccion_numero = $("#Direccion_numero");
var errorNumero = $("#errorNumero");

function validarNombre() {
    //Si no se ha introducido nada en el campo
    if (Nombre.val().length < 1) {

        Nombre.addClass("novalido");
        errorNombre.addClass("error");
        errorNombre.text("Debe completar su nombre");

        return false;
    }
    //si se ha introducido valor
    else {

        Nombre.removeClass("novalido");
        errorNombre.removeClass("error");
        errorNombre.text("");
        return true;
    }
}

function validarApellido() {
    //Si no se ha introducido nada en el campo
    
    if (Apellido.val().length < 1) {

        Apellido.addClass("novalido");
        errorApellido.addClass("error");
        errorApellido.text("Debe completar su apellido");

        return false;
    }
    //si se ha introducido valor
    else {

        Apellido.removeClass("novalido");
        errorApellido.removeClass("error");
        errorApellido.text("");
        return true;
    }
}

//Numero de Documento
function validarNumeroDocumento() {
    //Si no se ha introducido nada en el campo

    if (NumeroDocumento.val().length < 1) {

        NumeroDocumento.addClass("novalido");
        errorNumeroDocumento.addClass("error");
        errorNumeroDocumento.text("Debe completar su apellido");

        return false;
    }
    //si se ha introducido valor
    else {

        NumeroDocumento.removeClass("novalido");
        errorNumeroDocumento.removeClass("error");
        errorNumeroDocumento.text("");
        return true;
    }
}

//Fecha de Nacimiento

$(function () { 
    //esta funncion es para modificar el validate de jquery que no acepta validacion con cultrua distinta a en-US
    $.validator.methods.date = function (value, element) {
        return this.optional(element) || moment(value, "DD/MM/YYYY", true).isValid();
    }

    //llama al datepicker
    FechaNacimiento.datepicker({
        dateFormat: "dd/mm/yy",
        changeMonth: true,
        changeYear: true
    })

   
});

function validarFechaNacimiento() {

    
    var fechaActual = new Date();
    var fechaUsuario = new Date(FechaNacimiento.datepicker('getDate'));


    if (fechaUsuario > fechaActual) {
        FechaNacimiento.addClass("novalido");
        errorFechaNacimiento.text("La fecha no puede ser posterior a la fecha actual");
        errorFechaNacimiento.addClass("error");
        return false;
    }
    else {
        FechaNacimiento.removeClass("novalido");
        errorFechaNacimiento.text("");
        errorFechaNacimiento.removeClass("error");
        return true;
    }
}

function validarDireccionCalle() {
    if (Direccion_calle.val().length < 1) {
        Direccion_calle.addClass("novalido");
        errorCalle.addClass("error");
        errorCalle.text("Debe ingresar un nombre de calle");

        return false;
    }
    else {
        Direccion_calle.removeClass("novalido");
        errorCalle.removeClass("error");
        errorCalle.text("");
        return true;
    }
}

function validarDireccionNumero() {
    if (Direccion_numero.val().length < 1) {
        Direccion_numero.addClass("novalido");
        errorNumero.addClass("error");
        errorNumero.text("Debe ingresar un numero de calle");

        return false;
    }
    else {
        Direccion_numero.removeClass("novalido");
        errorNumero.removeClass("error");
        errorNumero.text("");
        return true;
    }
}

Nombre.blur(validarNombre);
Apellido.blur(validarApellido);
NumeroDocumento.blur(validarNumeroDocumento);
FechaNacimiento.blur(validarFechaNacimiento);
Direccion_calle.blur(validarDireccionCalle);
Direccion_numero.blur(validarDireccionNumero);





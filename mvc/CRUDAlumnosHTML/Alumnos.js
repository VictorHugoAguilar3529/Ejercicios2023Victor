'use strict'
var id = document.getElementById('id');
var error = document.getElementById('error');


function enviarFormulario(){
    console.log('Enviar formulario...');

    var mensajesError =[];
if(id === null || id === ''){
    window.alert('Ingrese el id');
}

    return false;
}
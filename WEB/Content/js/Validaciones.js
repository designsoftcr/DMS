function validar() {
    var nombre_archivo = jQuery("#MainContent_myFile").val(); // Obtengo la extensión
    alert(nombre_archivo);
    var RegExPattern = /^[\w0-9 -]+.xlsx$/;
    if (!(RegExPattern.test(nombre_archivo))) {
        alert('Verifique que el nombre del archivo no contenga caracteres especiales como por ejemplo (;.) y que su extension sea .xlsx');
        jQuery("#MainContent_myFile").val('');
    } 
}
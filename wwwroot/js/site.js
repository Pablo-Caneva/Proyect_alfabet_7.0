// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function EmailVal() {
	let mail = document.getElementById("email_ing");
	let formato = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
	if (mail.value.match(formato)) {
		return (true)
	} else {
		alert("¡El email ingresado es incorrecto!")
		return (false)
	}
}
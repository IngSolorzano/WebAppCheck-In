// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const $tiempo = document.querySelector('.tiempo'),
	$fecha = document.querySelector('.fecha');

function digitalClock() {
	let f = new Date(),
		dia = f.getDate(),
		mes = f.getMonth() + 1,
		year = f.getFullYear(),
		diaSemana = f.getDay();

	dia = ('0' + dia).slice(-2);
	mes = ('0' + mes).slice(-2);

	let timeString = f.toLocaleTimeString();
	$tiempo.innerHTML = timeString;

	let semana = ['SUN', 'MON', 'TUE', 'WED', 'THU', 'FRI', 'SAT'];
	let showSemana = (semana[diaSemana]);
	$fecha.innerHTML = `${year}-${mes}-${dia} ${showSemana}`
}
setInterval(() => {
	digitalClock()
}, 1000);
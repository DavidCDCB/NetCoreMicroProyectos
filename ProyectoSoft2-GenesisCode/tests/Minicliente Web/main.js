// Este archivo se modifica con el fin de hacer peticiones desde un cliente web que usa Axios

const TIPO = 'POST';
/*
const URL = 'http://localhost:5000/api/publicaciones';
const data = {
	idPublicacion: 102,
	idUsuario: 1,
	fecha: "1980-01-18T16:31:37.94",
	descripcion: "NUEVO",
	imagen: "http://vehistito.com/ereentfor/er/esnt/reevebutha.bmp",
	com: [9,9,1,1,1]
}*/


const URL = 'http://localhost:5000/api/consultarTurnos/turnos';
const data = {
	idMeseros:1,
	fechaIncial:"1980-01-18T16:31:37.94",
	fechaFinal:"1980-01-18T16:31:37.94"
}

request(TIPO,URL,data); 

const apiUrl = 'http://192.168.2.152:8080/api';function getRequestConfig(config) {


const defaultConfig = {
		contentType : "application/json",
		accept: "application/json",
		type: 'POST',
    dataType: 'json',
    headers: {
      Authorization: 'Bearer '+localStorage.token,
    }
	};
  
  // const apiUrl = 'http://codexphelp.azurewebsites.net/api/Usuario'
  
	const customConfig = {
		url: apiUrl + config.url,
		data: JSON.stringify(config.data),
  }
  
  const a = Object.assign({}, defaultConfig, customConfig);
  
  console.log(a);
  return a;
}


function carregaInstituicoes() {
	$.ajax(getRequestConfig({
		url: '/instituicoes'
	}))
}


$('#cadastrar-tarefa select').change(function() {
	var display = this.value == 2 ? 'none' : 'block';
	$('.alternativas').css ({
		display:display,
	});
});

$('#add-pergunta').click(function() {
	const pergunta = $('.pergunta').last().clone();
	$('#cadastrar-tarefa .body #perguntas').append(pergunta);
})

$('#cadastrar-tarefa').submit(function() {
	const titulo = $('#tarefa-titulo').val();
	const conteudo = $('#tarefa-conteudo').val();
	const alternativas = $('.alternativas');
	const titulo = $('#tarefa-titulo').val();
});


/*************************************
 * APRENDIZ
 ************************************/
$('#cadastro-aprendiz').submit(function(e) {
	e.preventDefault();
	const data = {
		nome: $('#aprendiz-nome').val(),
		sobrenome: $('#aprendiz-sobrenome').val(),
		instituicao: $('#aprendiz-instituicao').val(),
		senha: $('#aprendiz-senha').val(),
		beginDate: $('#aprendiz-dataEntrada').val(),
		dataSaida: $('#aprendiz-dataSaida').val(),
	};
	
	$.ajax(getRequestConfig({
		url: '/usuario', 
		data: data,
		sucess: function(response) {
			console.log(response);
		}
	}));
});



/*************************************
 * APRENDIZ
 ************************************/
// $('#cadastro-aprendiz').submit(function() {
// 	const data = {
// 		nome: $('#aprendiz-nome').val(),
// 		sobrenome: $('#aprendiz-sobrenome').val(),
// 		instituicao: $('#aprendiz-instituicao').val(),
// 		senha: $('#aprendiz-senha').val(),
// 		dataEntrada: $('#aprendiz-dataEntrada').val(),
// 		dataSaida: $('#aprendiz-dataSaida').val(),
// 	};

// 	$.ajax(getRequestConfig({
// 		url: '/user', 
// 		data: data,
// 		sucess: function(response) {
// 			console.log(response);
// 		}
// 	}));
// });



/*************************************
 * INSTITUICAO
 ************************************/
$('#cadastro-instituicao').submit(function(e) {
	e.preventDefault();
	const data = {
		nome: $('#instituicao-nome').val(),
		email: $('#instituicao-email').val(),
    password: $('#instituicao-senha').val(),
    discriminator: 'Instituicao',
	};

	$.ajax(getRequestConfig({
		url: '/usuario', 
		data: data,
		sucess: function(response) {
			console.log(response);
		}
	}));
});



/*************************************
 * GESTOR
 ************************************/
$('#cadastro-gestor').submit(function(e) {
	e.preventDefault();
	const data = {
    nome: $('#gestor-nome').val(),
    sobrenome: $('#gestor-sobrenome').val(),
		email: $('#gestor-email').val(),
		// area: $('#gestor-area').val(),
    password: $('#gestor-senha').val(),
    discriminator: 'Gestor',
	};
	console.log(data);
	$.ajax(getRequestConfig({
		url: '/usuario', 
		data: data,
		sucess: function(response) {
			console.log(response);
		}
	}));
});



/*************************************
 * BOLETIM
 ************************************/
$('#cadastro-boletim').submit(function(e) {
	e.preventDefault();
	const data = {
		instituicao: $('#boletim-instituicao').val(),
		aluno: $('#boletim-aluno').val(),
		media: $('#boletim-media').val(),
		frequencia: $('#boletim-frequencia').val(),
		dataFechamento: $('#boletim-dataFechamento').val(),
		observacoes: $('#boletim-observacoes').val(),
	};

	$.ajax(getRequestConfig({
		url: '/boletim', 
		data: data,
		sucess: function(response) {
			console.log(response);
		}
	}));
});




$('#sign_in').submit(function(e) {
  e.preventDefault();
  var usuario = $("#usuario").val();
  var senha = $("#senha").val();
console.log(usuario);
  var request = $.ajax({
      contentType : "application/json",
      accept: "application/json",
      url: apiUrl + "/auth",
      type: 'POST',
      data: JSON.stringify({ username : usuario, password: senha }),
      dataType: 'json'
  });

  request.done(function( response ) {
      $("#usuario").val("");
      $("#senha").val("");
      localStorage.token = response.token;
      window.location.href = 'desempenho.html';
  });

  request.fail(function( jqXHR, textStatus ) {
      console.error( "Request Error: " + jqXHR.status + " - " + textStatus );
  });
})
﻿const apiUrl = 'http://192.168.2.152:8080/api';

function getRequestConfig(config, method) {
  const defaultConfig = {
		contentType : "application/json",
		accept: "application/json",
		type: method || 'POST',
    dataType: 'json',
    headers: {
      Authorization: 'Bearer '+localStorage.token,
    }
	};
  
	const customConfig = {
		url: apiUrl + config.url,
		data: config.dataRaw || JSON.stringify(config.data),
  }
  
	const a = Object.assign({}, defaultConfig, config, customConfig);
	console.log(a)
	return a;
}


function successFeedback() {
	const alertHtml = `<div class="alert bg-green alert-dismissible" role="alert">
		<button type="button" class="close" data-dismiss="alert" aria-label="Close">
				<span aria-hidden="true">&times;</span>
		</button>
		Cadastro realizado com sucesso!
	</div>`;

	$('form .body').prepend(alertHtml);
	$('form input, textarea').val('');
	console.log('Success');
}


function failFeedback() {
	const alertHtml = `<div class="alert bg-pink alert-dismissible" role="alert">
		<button type="button" class="close" data-dismiss="alert" aria-label="Close">
				<span aria-hidden="true">&times;</span>
		</button>
		Erro ao cadastrar. Por favor, tente novamente!
	</div>`;

	$('form .body').prepend(alertHtml);
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
	$('input[type="radio"]',  pergunta).attr('name', 'pergunta'+$('.pergunta').length+1);
	// $('.demo-radio-button label')
  $('input, textarea', pergunta).val('');
	$('#cadastrar-tarefa .body #perguntas').append(pergunta);
})


/*************************************
 * TAREFA
 * Falta titulo, nivel
 ************************************/
$('#cadastrar-tarefa').submit(function(e) {
  e.preventDefault();
  const perguntas = $('#perguntas .pergunta');
  const perguntasData = [];
  $(perguntas).each(function(pergunta) {
		const alternativas = [];
		$('.alternativas input[type="text"]', pergunta).each(function () {
			alternativas.push(this.value);
		});
		const alternativasRadio = $('.alternativas input[type="radio"]');
		const alternativaCorreta = alternativasRadio.index(alternativasRadio.filter(':checked'));

    const perguntaInfos = {
      titulo: $('.pergunta-titulo', $(this)).val(),
			descricao: $('.pergunta-conteudo', $(this)).val(),
			alternativas: alternativas,
			alternativaCorreta: alternativaCorreta,
    }
    perguntasData.push(perguntaInfos);
  });

  const data = {
		titulo: $('.tarefa-titulo').val(),
		nivel: $('.tarefa-nivel').val(),
    questoes: perguntasData,
  };
	console.log(data);
	$.ajax(getRequestConfig({
		url: '/tarefa', 
		data: data,
		success: successFeedback,
	}));
});

var aprendizCsv;
/*************************************
 * APRENDIZ
 ************************************/
$('#cadastro-aprendiz').submit(function(e) {
	e.preventDefault();
	const data = {
		gestor: $('#aprendiz-gestor').val(),
		instituicaoId: $('#aprendiz-instituicao').val(),
	};

	const formData = new FormData();
	// formData.append('id', data.gestor);
  // formData.append('instituicaoId', data.instituicaoId);
  formData.append('file', aprendizCsv);

	
	
	$.ajax(getRequestConfig({
		url: '/usuario/'+data.gestor+'/'+data.instituicaoId, 
		dataRaw: formData,
		success: successFeedback,
		cache: false,
		contentType: false,
		processData: false,

	}));
});


$('#aprendiz-csv').change(function(e) {
  aprendizCsv = this.files[0];
})



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
		success: successFeedback,
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
		success: successFeedback
	}));
});



/*************************************
 * BOLETIM
 ************************************/
$('#cadastro-boletim').submit(function(e) {
	e.preventDefault();
	const data = {
		// instituicao: $('#boletim-instituicao').val(),
    aprendizId: Number($('#boletim-aluno').val()),
		nota: $('#boletim-media').val(),
		frequencia: $('#boletim-frequencia').val(),
		mesReferencia: $('#boletim-mesReferencia').val(),
		anoReferencia: $('#boletim-anoReferencia').val(),
		observacao: $('#boletim-observacoes').val(),
	};

	$.ajax(getRequestConfig({
		url: '/boletim', 
		data: data,
		success: successFeedback,
	}));
});

var aprendiz = [];
var aprendizOptions = null;
function loadAprendiz() {
  $.ajax(getRequestConfig({
    url: '/aprendiz',
    success: function(response) {
      aprendizOptions = ['<option value="">SELECIONE O APRENDIZ</option>'];
      aprendizOptions.push(response.map(item => '<option value="'+item.id+'">'+item.nome+' '+item.sobrenome+'</option>'));
      aprendizOptions = aprendizOptions.join('');
      $('.loadAprendiz select').html(aprendizOptions);
      $('select:not(.ms)').selectpicker('refresh');
    }
  }, 'get'));
}

var instituicaoOptions = null;
function loadInstituicao() {
  $.ajax(getRequestConfig({
    url: '/instituicao',
    success: function(response) {
      instituicaoOptions = ['<option value="">SELECIONE A INSTITUIÇÃO</option>'];
      instituicaoOptions.push(response.map(item => '<option value="'+item.id+'">'+item.nome+'</option>'));
      instituicaoOptions = instituicaoOptions.join('');
      $('.loadInstituicao select').html(instituicaoOptions);
      $('select:not(.ms)').selectpicker('refresh');
    }
  }, 'get'));
}

var gestorOptions = null;
function loadGestor() {
  $.ajax(getRequestConfig({
    url: '/gestor',
    success: function(response) {
      gestorOptions = ['<option value="">SELECIONE O GESTOR</option>'];
      gestorOptions.push(response.map(item => '<option value="'+item.id+'">'+item.nome+'</option>'));
      gestorOptions = gestorOptions.join('');
      $('.loadGestor select').html(gestorOptions);
      $('select:not(.ms)').selectpicker('refresh');
    }
  }, 'get'));
}
loadInstituicao();
loadAprendiz();
loadGestor();


$('#sign_in').submit(function(e) {
  e.preventDefault();
  var usuario = $("#usuario").val();
  var senha = $("#senha").val();
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
      window.location.href = 'index.html';
  });

  request.fail(function( jqXHR, textStatus ) {
      console.error( "Request Error: " + jqXHR.status + " - " + textStatus );
  });
})


function loadDesempenho() {
	
}

if($('#desempenho-aprendiz').length > 0) {
	$('.loadAprendiz').change(function() {
		$.ajax(getRequestConfig({
			url: '/aprendiz/'+this.value, 
			success: function(response) {
				$('.nivel').text('Nível '+response.nivel);
				$('.nome').text(response.nome+' '+response.sobrenome);
				$('.dataEntrada').text(moment(response.entrada).format('DD/MM/YYYY'));
				$('.dataSaida').text(moment(response.saida).format('DD/MM/YYYY'));
			},
		}, 'get'));
	})
	
}
$('#cadastrar-tarefa select').change(function() {
  console.log(this.value, 123);
  var display = this.value == 2 ? 'none' : 'block'
  $('#alternativas').css({
    display: display,
  })
});
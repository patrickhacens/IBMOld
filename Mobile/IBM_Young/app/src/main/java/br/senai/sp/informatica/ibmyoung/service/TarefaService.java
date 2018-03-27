package br.senai.sp.informatica.ibmyoung.service;

import java.util.List;

import br.senai.sp.informatica.ibmyoung.model.Autorizacao;
import br.senai.sp.informatica.ibmyoung.model.Tarefa;
import br.senai.sp.informatica.ibmyoung.model.Usuario;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;

public interface TarefaService {
    //TODO: definir os metodos que serao criados com base no codigo de backend
    @GET("Tarefas")
    Call<List<Tarefa>> consultaAtividades(@Body Usuario usuario);
}

package br.senai.sp.informatica.ibmyoung.service;

import java.util.List;

import br.senai.sp.informatica.ibmyoung.model.Tarefa;
import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

public interface TarefaService {
    @GET("Tarefas/{id}")
    Call<List<Tarefa>> listaTarefas(@Path("id") int usuarioId);
}

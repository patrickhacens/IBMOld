package br.senai.sp.informatica.ibmyoung.service;

import java.util.List;

import br.senai.sp.informatica.ibmyoung.model.Topico;
import br.senai.sp.informatica.ibmyoung.model.Usuario;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;

public interface TarefaService {
    //TODO: definir os metodos que serao criados com base no codigo de backend
    @GET("Tarefas")
    Call<List<Topico>> consultaAtividades(@Body Usuario usuario);
}

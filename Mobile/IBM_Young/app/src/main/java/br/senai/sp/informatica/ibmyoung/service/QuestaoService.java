package br.senai.sp.informatica.ibmyoung.service;

import java.util.List;

import br.senai.sp.informatica.ibmyoung.model.Questao;
import br.senai.sp.informatica.ibmyoung.model.Tarefa;
import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

public interface QuestaoService {
    @GET("Questoes/{id}")
    Call<List<Questao>> listaQuestionario(@Path("id") int tarefaId);

    @GET("Questao/{tarefaId}/{questaoId}")
    Call<Questao> localizar(@Path("tarefaId") int tarefaId, @Path("questaoId") int questaoId);
}

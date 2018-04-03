package br.senai.sp.informatica.ibmyoung.service;

import java.util.List;

import br.senai.sp.informatica.ibmyoung.model.Questao;
import br.senai.sp.informatica.ibmyoung.model.Resposta;
import br.senai.sp.informatica.ibmyoung.model.Tarefa;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Path;

public interface QuestaoService {
    @GET("Questoes/{tarefaId}/{aprendizId}")
    Call<List<Questao>> listaQuestionario(@Path("tarefaId") int tarefaId, @Path("aprendizId") int aprendizId);

    @GET("Questao/{tarefaId}/{questaoId}")
    Call<Questao> localizar(@Path("tarefaId") int tarefaId, @Path("questaoId") int questaoId);

    @POST("Questao/{tarefaId}/{questaoId}/responder")
    Call<Void> responder(@Path("tarefaId") int tarefaId, @Path("questaoId") int questaoId, @Body Resposta resposta);
}

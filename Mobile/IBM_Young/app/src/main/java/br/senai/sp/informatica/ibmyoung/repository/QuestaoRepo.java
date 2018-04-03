package br.senai.sp.informatica.ibmyoung.repository;

import java.util.ArrayList;
import java.util.List;

import br.senai.sp.informatica.ibmyoung.config.CallBackImpl;
import br.senai.sp.informatica.ibmyoung.config.RetrofitConfig;
import br.senai.sp.informatica.ibmyoung.config.WebServiceData;
import br.senai.sp.informatica.ibmyoung.model.Questao;
import br.senai.sp.informatica.ibmyoung.model.Resposta;
import br.senai.sp.informatica.ibmyoung.model.Tarefa;
import br.senai.sp.informatica.ibmyoung.model.Topico;
import br.senai.sp.informatica.ibmyoung.service.QuestaoService;
import br.senai.sp.informatica.ibmyoung.service.TarefaService;
import retrofit2.Call;

public class QuestaoRepo {
    public static QuestaoRepo dao = new QuestaoRepo();
    private QuestaoService svc = RetrofitConfig.getInstance().getQuestaoService();

    public void getTarefas(int tarefaId, int aprendizId, WebServiceData<List<Questao>> data) {
        Call<List<Questao>> call = svc.listaQuestionario(tarefaId, aprendizId);
        call.enqueue(new CallBackImpl<List<Questao>>(data));
    }

    public void localizar(int tarefaId, int questaoId, WebServiceData<Questao> data) {
        Call<Questao> call = svc.localizar(tarefaId, questaoId);
        call.enqueue(new CallBackImpl<Questao>(data));
    }

    public void responder(int tarefaId, int questaoId, Resposta resposta, WebServiceData<Void> data) {
        Call<Void> call = svc.responder(tarefaId, questaoId, resposta);
        call.enqueue(new CallBackImpl<Void>(data));

    }
}

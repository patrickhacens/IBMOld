package br.senai.sp.informatica.ibmyoung.repository;

import java.util.List;

import br.senai.sp.informatica.ibmyoung.config.CallBackImpl;
import br.senai.sp.informatica.ibmyoung.config.RetrofitConfig;
import br.senai.sp.informatica.ibmyoung.config.WebServiceData;
import br.senai.sp.informatica.ibmyoung.model.Tarefa;
import br.senai.sp.informatica.ibmyoung.model.Topico;
import br.senai.sp.informatica.ibmyoung.service.TarefaService;
import br.senai.sp.informatica.ibmyoung.service.TopicoService;
import retrofit2.Call;

public class TarefaRepo {
    public static TarefaRepo dao = new TarefaRepo();
    private TarefaService svc = RetrofitConfig.getInstance().getTarefaService();

    public void getTarefas(int aprendizId, WebServiceData<List<Tarefa>> data) {
        Call<List<Tarefa>> call = svc.listaTarefas(aprendizId);
        call.enqueue(new CallBackImpl<List<Tarefa>>(data));
    }
}

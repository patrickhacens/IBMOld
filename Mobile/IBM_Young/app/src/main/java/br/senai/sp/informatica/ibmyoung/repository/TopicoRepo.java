package br.senai.sp.informatica.ibmyoung.repository;

import java.util.ArrayList;
import java.util.List;

import br.senai.sp.informatica.ibmyoung.config.CallBackImpl;
import br.senai.sp.informatica.ibmyoung.config.RetrofitConfig;
import br.senai.sp.informatica.ibmyoung.config.WebServiceData;
import br.senai.sp.informatica.ibmyoung.model.Aprendiz;
import br.senai.sp.informatica.ibmyoung.model.Topico;
import br.senai.sp.informatica.ibmyoung.service.AprendizService;
import br.senai.sp.informatica.ibmyoung.service.TopicoService;
import retrofit2.Call;

public class TopicoRepo {
    public static TopicoRepo dao = new TopicoRepo();
    private TopicoService svc = RetrofitConfig.getInstance().getTopicoService();

    public void getTopicos(WebServiceData<List<Topico>> data) {
        Call<List<Topico>> call = svc.listaAprendizes();
        call.enqueue(new CallBackImpl<List<Topico>>(data));
    }

    public void localizar(int topicoId, WebServiceData<Topico> data) {
        Call<Topico> call = svc.localizar(topicoId);
        call.enqueue(new CallBackImpl<Topico>(data));
    }
}

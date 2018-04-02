package br.senai.sp.informatica.ibmyoung.repository;

import java.util.List;

import br.senai.sp.informatica.ibmyoung.config.CallBackImpl;
import br.senai.sp.informatica.ibmyoung.config.RetrofitConfig;
import br.senai.sp.informatica.ibmyoung.config.WebServiceData;
import br.senai.sp.informatica.ibmyoung.model.NovaReplica;
import br.senai.sp.informatica.ibmyoung.model.Replica;
import br.senai.sp.informatica.ibmyoung.model.Topico;
import br.senai.sp.informatica.ibmyoung.service.ReplicaService;
import br.senai.sp.informatica.ibmyoung.service.TopicoService;
import retrofit2.Call;
import retrofit2.Response;

public class ReplicaRepo {
    public static ReplicaRepo dao = new ReplicaRepo();
    private ReplicaService svc = RetrofitConfig.getInstance().getReplicaService();

    public void getReplicas(int topicoId, WebServiceData<List<Replica>> data) {
        Call<List<Replica>> call = svc.listaReplicas(topicoId);
        call.enqueue(new CallBackImpl<List<Replica>>(data));
    }

    public void novaReplica(NovaReplica replica, WebServiceData<Void> data) {
        Call<Void> call = svc.enviarReplica(replica);
        call.enqueue(new CallBackImpl<Void>(data) {
            @Override
            public void onResponse(Call<Void> call, Response<Void> response) {
                data.processaDados(null);
            }
        });
    }
}

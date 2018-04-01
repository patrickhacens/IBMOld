package br.senai.sp.informatica.ibmyoung.repository;

import java.util.ArrayList;
import java.util.List;

import br.senai.sp.informatica.ibmyoung.config.CallBackImpl;
import br.senai.sp.informatica.ibmyoung.config.RetrofitConfig;
import br.senai.sp.informatica.ibmyoung.config.WebServiceData;
import br.senai.sp.informatica.ibmyoung.lib.Alerta;
import br.senai.sp.informatica.ibmyoung.model.Aprendiz;
import br.senai.sp.informatica.ibmyoung.model.Autorizacao;
import br.senai.sp.informatica.ibmyoung.model.Usuario;
import br.senai.sp.informatica.ibmyoung.service.AprendizService;
import br.senai.sp.informatica.ibmyoung.service.LoginService;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class AprendizRepo {
    public static AprendizRepo dao = new AprendizRepo();
    private AprendizService svc = RetrofitConfig.getInstance().getAprendizService();

    public void getIds(WebServiceData<List<Aprendiz>> data) {
        Call<List<Aprendiz>> call = svc.listaAprendizes();
        call.enqueue(new CallBackImpl<List<Aprendiz>>(data));
    }

    public void localizar(int apendizId, WebServiceData<Aprendiz> data) {
        Call<Aprendiz> call = svc.localizar(apendizId);
        call.enqueue(new CallBackImpl<Aprendiz>(data));
    }
}

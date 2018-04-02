package br.senai.sp.informatica.ibmyoung.service;

import java.util.List;

import br.senai.sp.informatica.ibmyoung.model.Aprendiz;
import br.senai.sp.informatica.ibmyoung.model.Topico;
import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

public interface TopicoService {
    @GET("Topicos")
    Call<List<Topico>> listaTopicos();

    @GET("Topico/{id}")
    Call<Topico> localizar(@Path("id") int id);
}

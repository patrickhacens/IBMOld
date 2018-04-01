package br.senai.sp.informatica.ibmyoung.service;

import java.util.List;

import br.senai.sp.informatica.ibmyoung.model.Aprendiz;
import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

public interface AprendizService {
    @GET("Aprendiz")
    Call<List<Aprendiz>> listaAprendizes();

    @GET("Aprendiz/{id}")
    Call<Aprendiz> localizar(@Path("id") int id);
}

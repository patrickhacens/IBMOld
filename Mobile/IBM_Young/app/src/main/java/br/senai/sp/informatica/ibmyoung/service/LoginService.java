package br.senai.sp.informatica.ibmyoung.service;

import br.senai.sp.informatica.ibmyoung.model.Autorizacao;
import br.senai.sp.informatica.ibmyoung.model.Usuario;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

public interface LoginService {
    @POST("Usuario/login")
    Call<Autorizacao> efetuarLogin(@Body Usuario usuario);
}

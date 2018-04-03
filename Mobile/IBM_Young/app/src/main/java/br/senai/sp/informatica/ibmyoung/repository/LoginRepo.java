package br.senai.sp.informatica.ibmyoung.repository;

import android.content.SharedPreferences;
import android.preference.PreferenceManager;
import android.util.Log;

import java.util.Date;

import br.senai.sp.informatica.ibmyoung.Main;
import br.senai.sp.informatica.ibmyoung.config.RetrofitConfig;
import br.senai.sp.informatica.ibmyoung.config.WebServiceData;
import br.senai.sp.informatica.ibmyoung.model.Autorizacao;
import br.senai.sp.informatica.ibmyoung.model.Usuario;
import br.senai.sp.informatica.ibmyoung.service.LoginService;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LoginRepo {
    public static LoginRepo dao = new LoginRepo();
    private LoginService svc = RetrofitConfig.getInstance().getLoginService();

    public void efetuaLogin(Usuario usuario, final WebServiceData<Autorizacao> data) {
        Log.e("LoginRepo", "User: " + usuario.getUsername() + " Pass: " + usuario.getPassword());
        Call<Autorizacao> call = svc.efetuarLogin(usuario);
        call.enqueue(new Callback<Autorizacao>() {
            @Override
            public void onResponse(Call<Autorizacao> requisicao, Response<Autorizacao> resposta) {
                if(resposta.isSuccessful()) {
                   data.processaDados(resposta.body());
                } else {
                    Log.e("LoginRepo", "Sucesso? " + resposta.isSuccessful());
                   data.houveErro();
                }
            }

            @Override
            public void onFailure(Call<Autorizacao> requisicao, Throwable erro) {
                Log.e("LoginRepo", "Erro: " + erro.getMessage());
                data.houveErro();
            }
        });
    }

    public void salvarAutorizacao(Autorizacao dados) {
        SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(Main.context);
        SharedPreferences.Editor editor = preferences.edit();
        editor.putString("TOKEN", dados.getToken());
        editor.putLong("EXPIRATION", dados.getExpiration().getTime());
        editor.putString("DISCRIMINATOR", dados.getDiscriminator());
        editor.putInt("ID", dados.getId());
        editor.apply();
    }

    public Autorizacao obterAutorizacao() {
        SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(Main.context);
        Autorizacao auth = new Autorizacao();
        auth.setToken(preferences.getString("TOKEN", null));
        auth.setExpiration(new Date(preferences.getLong("EXPIRATION", new Date().getTime())));
        auth.setDiscriminator(preferences.getString("DISCRIMINATOR", null));
        auth.setId(preferences.getInt("ID", -1));
        return auth;
    }
}

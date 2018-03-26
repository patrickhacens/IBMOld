package br.senai.sp.informatica.ibmyoung.repository;

import android.content.SharedPreferences;
import android.preference.PreferenceManager;

import br.senai.sp.informatica.ibmyoung.Main;
import br.senai.sp.informatica.ibmyoung.config.RetrofitConfig;
import br.senai.sp.informatica.ibmyoung.model.Autorizacao;
import br.senai.sp.informatica.ibmyoung.model.Usuario;
import br.senai.sp.informatica.ibmyoung.service.LoginService;
import retrofit2.Call;
import retrofit2.Callback;

public class LoginRepo {
    public static LoginRepo dao = new LoginRepo();
    private LoginService svc = RetrofitConfig.getInstance().getLoginService();

    public void efetuaLogin(Usuario usuario, Callback<Autorizacao> callback) {
        Call<Autorizacao> call = svc.efetuarLogin(usuario);
        call.enqueue(callback);
    }

    public void salvarToken(String token) {
        SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(Main.context);
        SharedPreferences.Editor editor = preferences.edit();
        editor.putString("TOKEN", token);
        editor.apply();
    }

    public String obterToken() {
        SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(Main.context);
        String token = preferences.getString("TOKEN", null);
        return token;
    }
}

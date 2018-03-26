package br.senai.sp.informatica.ibmyoung.view;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.model.Autorizacao;
import br.senai.sp.informatica.ibmyoung.model.Usuario;
import br.senai.sp.informatica.ibmyoung.repository.LoginRepo;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LoginActivity extends AppCompatActivity {
    private EditText edLogin;
    private EditText edSenha;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.login_activity);

        edLogin = findViewById(R.id.edLogin);
        edSenha = findViewById(R.id.edSenha);

//        if(LoginRepo.dao.obterToken() != null)
//            abreTelaPrincipal();
    }

    public void abreTelaPrincipal() {
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }

    public void enviaClick(View view) {
        String login = edLogin.getText().toString();
        String senha = edSenha.getText().toString();

        Usuario usuario = new Usuario();
        usuario.setLogin(login);
        usuario.setSenha(senha);

        LoginRepo.dao.efetuaLogin(usuario, new Callback<Autorizacao>() {
            @Override
            public void onResponse(Call<Autorizacao> requisicao, Response<Autorizacao> resposta) {
                if(resposta.isSuccessful()) {
//                    LoginRepo.dao.salvarToken(resposta.headers().get("authorization"));
                    LoginRepo.dao.salvarToken(resposta.body().getToken());
                    Log.e("LoginActivity",  "Token: " + resposta.body().getToken());
                    abreTelaPrincipal();
                }
            }

            @Override
            public void onFailure(Call<Autorizacao> requisicao, Throwable erro) {
                Toast.makeText(LoginActivity.this, "Falha na Autenticação", Toast.LENGTH_LONG).show();
            }
        });
    }
}

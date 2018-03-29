package br.senai.sp.informatica.ibmyoung.view;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.config.WebServiceData;
import br.senai.sp.informatica.ibmyoung.model.Autorizacao;
import br.senai.sp.informatica.ibmyoung.model.Usuario;
import br.senai.sp.informatica.ibmyoung.repository.LoginRepo;
import br.senai.sp.informatica.ibmyoung.view.old.MainActivity;

public class LoginActivity extends AppCompatActivity {
    private EditText edLogin;
    private EditText edSenha;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.login_activity);

        edLogin = findViewById(R.id.edLogin);
        edSenha = findViewById(R.id.edSenha);
    }

    public void abreTelaPrincipal() {
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }

    public void enviaClick(View view) {
        String login = edLogin.getText().toString();
        String senha = edSenha.getText().toString();

        Usuario usuario = new Usuario();
        usuario.setUsername(login);
        usuario.setPassword(senha);

        LoginRepo.dao.efetuaLogin(usuario, new WebServiceData<Autorizacao>() {
            @Override
            public void processaDados(Autorizacao dados) {
                LoginRepo.dao.salvarAutorizacao(dados);

                abreTelaPrincipal();
            }

            @Override
            public void houveErro() {
                Toast.makeText(LoginActivity.this, "Falha na Autenticação", Toast.LENGTH_LONG).show();
            }
        });
    }
}

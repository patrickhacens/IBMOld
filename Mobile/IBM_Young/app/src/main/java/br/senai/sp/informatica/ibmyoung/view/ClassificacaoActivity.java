package br.senai.sp.informatica.ibmyoung.view;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;

import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.config.WebServiceData;
import br.senai.sp.informatica.ibmyoung.lib.Alerta;
import br.senai.sp.informatica.ibmyoung.model.Aprendiz;
import br.senai.sp.informatica.ibmyoung.repository.AprendizRepo;
import br.senai.sp.informatica.ibmyoung.repository.LoginRepo;
import br.senai.sp.informatica.ibmyoung.view.adapter.ClassificacaoAdapter;

/**
 * Created by CodeXP on 19/03/2018.
 */

public class ClassificacaoActivity extends AppCompatActivity implements View.OnClickListener {
    private ListView listView;
    private ImageView ivQuestoes;
    private TextView tvNome;
    private TextView tvNivel;
    private ClassificacaoAdapter adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.classificacao_activity);

        adapter = new ClassificacaoAdapter();
        listView = findViewById(R.id.listView);
        listView.setAdapter(adapter);

        ivQuestoes = findViewById(R.id.ivQuestoes);
        ivQuestoes.setOnClickListener(this);

        tvNome = findViewById(R.id.tvTitulo);
        tvNivel = findViewById(R.id.tvNivel);
    }

    @Override
    protected void onStart() {
        super.onStart();
        int apendizId = LoginRepo.dao.obterAutorizacao().getId();
        AprendizRepo.dao.localizar(apendizId, new WebServiceData<Aprendiz>() {
            @SuppressLint("DefaultLocale")
            @Override
            public void processaDados(Aprendiz dados) {
                tvNome.setText(String.format("%s %s", dados.getNome(), dados.getSobrenome()));
                tvNivel.setText(String.format("Nível %d", dados.getNivel()));
            }

            @Override
            public void houveErro() {
                Alerta.showToast("Falha ao carregar aos dados Aprendiz Logado");
            }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu_principal, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();
        switch (id) {
            case R.id.forum_action:
                startActivity(new Intent(this, ForumActivity.class));
                break;
            case R.id.logout_action:
                LoginRepo.dao.resetAutorizacao();
                startActivity(new Intent(this, LoginActivity.class));
                finish();
                break;
        }

        return true;
    }

    @Override
    public void onClick(View view) {
        startActivity(new Intent(this, TarefasActivity.class));
    }
}

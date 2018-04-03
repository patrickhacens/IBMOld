package br.senai.sp.informatica.ibmyoung.view;

import android.app.ActionBar;
import android.content.Intent;
import android.os.Bundle;
import android.os.PersistableBundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;

import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.lib.Messager;
import br.senai.sp.informatica.ibmyoung.lib.OnComplete;
import br.senai.sp.informatica.ibmyoung.model.Questao;
import br.senai.sp.informatica.ibmyoung.model.Tarefa;
import br.senai.sp.informatica.ibmyoung.view.adapter.QuestionariosAdapter;
import br.senai.sp.informatica.ibmyoung.view.adapter.TarefasAdapter;

/**
 * Created by CodeXP on 19/03/2018.
 */


public class QuestionariosActivity extends AppCompatActivity
        implements AdapterView.OnItemClickListener, OnComplete {
    private ListView listView;
    private QuestionariosAdapter adapter;
    private Integer tarefaId;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.questionarios_activity);

        if(tarefaId == null)
            tarefaId = getIntent().getExtras().getInt("id");
        adapter = new QuestionariosAdapter(tarefaId);

        listView = findViewById(R.id.listView);
        listView.setAdapter(adapter);
        listView.setOnItemClickListener(this);

        ActionBar bar = getActionBar();
        if(bar != null) {
            bar.setHomeButtonEnabled(true);
            bar.setDisplayHomeAsUpEnabled(true);
        }
    }

    @Override
    public void onItemClick(AdapterView<?> viewGroup, View view, int linha, long id) {
        Integer questaoId = ((Questao)adapter.getItem(linha)).getOrdem();
        Intent intent = new Intent(this, AlternativasActivity.class);
        intent.putExtra("questaoId", questaoId);
        intent.putExtra("tarefaId", tarefaId);
        Messager.balcao.add(this);
        startActivity(intent);
    }

    @Override
    public void execute() {
        adapter.recarrega();
    }

    @Override
    public void onSaveInstanceState(Bundle outState) {
        outState.putInt("tarefaId", tarefaId);
        super.onSaveInstanceState(outState);
    }

    @Override
    protected void onRestoreInstanceState(Bundle savedInstanceState) {
        super.onRestoreInstanceState(savedInstanceState);
        tarefaId = savedInstanceState.getInt("tarefaId");
    }
}

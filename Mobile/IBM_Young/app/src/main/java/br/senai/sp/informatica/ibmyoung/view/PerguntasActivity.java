package br.senai.sp.informatica.ibmyoung.view;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;

import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.model.Questao;
import br.senai.sp.informatica.ibmyoung.view.adapter.PerguntasAdapter;

/**
 * Created by CodeXP on 19/03/2018.
 */

public class PerguntasActivity extends AppCompatActivity implements AdapterView.OnItemClickListener {
    private ListView listView;
    private PerguntasAdapter adapter;
    private final static int RESPONDE_QUESTAO = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.perguntas_activity);

        adapter = new PerguntasAdapter();

        listView = findViewById(R.id.listView);
        listView.setAdapter(adapter);
        listView.setOnItemClickListener(this);
    }

    @Override
    public void onItemClick(AdapterView<?> viewGroup, View view, int linha, long id) {
        Integer questaoId = ((Questao)adapter.getItem(linha)).getId();
        Intent intent = new Intent(this, PerguntasAdapter.class);
        intent.putExtra("id", questaoId);
        startActivityForResult(intent, RESPONDE_QUESTAO);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        // TODO: verificar como identificar se a questão foi respondida para que o item da lista seja pintado com outra cor e/ou bloqueado de edição

        // URI: /api/Tarefa/current
        // será construido um endpoint que retornará a tarefa e uma listas de questoes e cada questao indicará se já foi respondida

        super.onActivityResult(requestCode, resultCode, data);
    }
}

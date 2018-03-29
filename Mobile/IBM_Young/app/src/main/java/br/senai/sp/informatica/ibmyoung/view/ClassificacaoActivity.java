package br.senai.sp.informatica.ibmyoung.view;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.ImageView;
import android.widget.ListView;

import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.view.adapter.ClassificacaoAdapter;

/**
 * Created by CodeXP on 19/03/2018.
 */

public class ClassificacaoActivity extends AppCompatActivity implements View.OnClickListener {
    private ListView listView;
    private ImageView ivQuestoes;
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
                // TODO: chamar o ForumActivity;
                startActivity(new Intent(this, ForumActivity.class));
                break;
            case R.id.logout_action:
                // TODO: executar o Logout e chamar o LoginActivity seguido
                startActivity(new Intent(this, LoginActivity.class));
                fileList();
                break;
        }

        return true;
    }

    @Override
    public void onClick(View view) {
        // TODO: chamar o PerguntasActivity
        startActivity(new Intent(this, PerguntasActivity.class));

    }
}

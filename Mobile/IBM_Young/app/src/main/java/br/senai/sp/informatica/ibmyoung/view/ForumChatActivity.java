package br.senai.sp.informatica.ibmyoung.view;

import android.app.ActionBar;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;
import android.view.View;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;

import java.util.List;

import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.config.WebServiceData;
import br.senai.sp.informatica.ibmyoung.lib.Alerta;
import br.senai.sp.informatica.ibmyoung.model.NovaReplica;
import br.senai.sp.informatica.ibmyoung.model.Replica;
import br.senai.sp.informatica.ibmyoung.model.Topico;
import br.senai.sp.informatica.ibmyoung.repository.LoginRepo;
import br.senai.sp.informatica.ibmyoung.repository.ReplicaRepo;
import br.senai.sp.informatica.ibmyoung.repository.TopicoRepo;
import br.senai.sp.informatica.ibmyoung.view.adapter.ForumAdapter;
import br.senai.sp.informatica.ibmyoung.view.adapter.ForumChatAdapter;

/**
 * Created by pena on 01/04/2018.
 */

public class ForumChatActivity extends AppCompatActivity implements View.OnClickListener {
    private TextView tvTitulo;
    private TextView tvTexto;
    private ListView listView;
    private EditText edMsg;
    private ImageView ivEnviar;
    private ForumChatAdapter adapter;
    private Topico topico;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.forum_chat_activity);

        tvTitulo = findViewById(R.id.tvTitulo);
        tvTexto = findViewById(R.id.tvTexto);
        edMsg = findViewById(R.id.edMsg);
        ivEnviar = findViewById(R.id.ivEnviar);
        ivEnviar.setOnClickListener(this);
        listView = findViewById(R.id.listView);

        ActionBar bar = getActionBar();
        if(bar != null) {
            bar.setHomeButtonEnabled(true);
            bar.setDisplayHomeAsUpEnabled(true);
        }

        int id = getIntent().getExtras().getInt("id");
        TopicoRepo.dao.localizar(id, new WebServiceData<Topico>() {
            @Override
            public void processaDados(Topico dados) {
                topico = dados;
                adapter = new ForumChatAdapter(topico.getId());
                listView.setAdapter(adapter);

                tvTitulo.setText(topico.getTitulo());
                tvTexto.setText(topico.getTexto());
            }

            @Override
            public void houveErro() {
                Alerta.showToast("Falha ao carregar o Tópico");
            }
        });
    }

    @Override
    public void onClick(View view) {
        NovaReplica replica = new NovaReplica();
        replica.setTexto(edMsg.getText().toString());
        replica.setTopicoId(topico.getId());
        replica.setAprendizId(LoginRepo.dao.obterAutorizacao().getId());

        ReplicaRepo.dao.novaReplica(replica, new WebServiceData<Void>() {
            @Override
            public void processaDados(Void dados) {
                adapter.recarrega();
                edMsg.setText("");
            }

            @Override
            public void houveErro() {
                Alerta.showToast("Falha ao enviar a Réplica");
            }
        });
    }
}

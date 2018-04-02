package br.senai.sp.informatica.ibmyoung.view.adapter;

import android.content.Context;
import android.util.SparseArray;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.LinearLayout;
import android.widget.TextView;

import java.text.DateFormat;
import java.util.List;

import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.config.WebServiceData;
import br.senai.sp.informatica.ibmyoung.lib.Alerta;
import br.senai.sp.informatica.ibmyoung.model.Replica;
import br.senai.sp.informatica.ibmyoung.repository.ReplicaRepo;

/**
 * Created by pena on 27/03/2018.
 */

public class ForumChatAdapter extends BaseAdapter {
    private int topicoId;
    private ReplicaRepo dao = ReplicaRepo.dao;
    private SparseArray<Replica> mapa;
    private static final DateFormat fmt = DateFormat.getDateInstance(DateFormat.LONG);

    public ForumChatAdapter(int topicoId) {
        this.topicoId = topicoId;
        criarMapa(topicoId);
    }

    private void criarMapa(int topicoId) {
        mapa = new SparseArray<>();
        dao.getReplicas(topicoId, new WebServiceData<List<Replica>>() {
            @Override
            public void processaDados(List<Replica> dados) {
                List<Replica> ids = dados;
                for (int linha = 0; linha < ids.size(); linha++) {
                    mapa.put(linha, ids.get(linha));
                }
                ForumChatAdapter.this.notifyDataSetChanged();
            }

            @Override
            public void houveErro() {
                Alerta.showToast("Falha ao carregar a lista das Réplicas");
            }
        });
    }

    public void recarrega() {
        criarMapa(topicoId);
    }

    @Override
    public int getCount() {
        return mapa.size();
    }

    @Override
    public Object getItem(int linha) {
        return mapa.get(linha);
    }

    @Override
    public long getItemId(int linha) {
        return mapa.get(linha).getId();
    }

    @Override
    public View getView(int linha, View view, ViewGroup viewGroup) {
        LinearLayout layout;

        if(view == null) {
            Context ctx = viewGroup.getContext();
            LayoutInflater svc = (LayoutInflater)ctx.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            layout = new LinearLayout(ctx);
            svc.inflate(R.layout.forum_chat_adapter, layout);
        } else {
            layout = (LinearLayout)view;
        }

        Replica obj = mapa.get(linha);
        TextView tvReplica = layout.findViewById(R.id.tvReplica);
        tvReplica.setText(obj.getTexto());
        TextView tvData = layout.findViewById(R.id.tvData);
        tvData.setText(fmt.format(obj.getDataCriacao()));
        TextView tvNome = layout.findViewById(R.id.tvTitulo);
        tvNome.setText(obj.getNomeAprendiz());

        return layout;
    }
}

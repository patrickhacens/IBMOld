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
import br.senai.sp.informatica.ibmyoung.model.Topico;
import br.senai.sp.informatica.ibmyoung.repository.TopicoRepo;

/**
 * Created by pena on 27/03/2018.
 */

public class ForumAdapter extends BaseAdapter {
    private TopicoRepo dao = TopicoRepo.dao;
    private SparseArray<Topico> mapa;
    private static final DateFormat fmt = DateFormat.getDateInstance(DateFormat.LONG);

    public ForumAdapter() {
        criarMapa();
    }

    private void criarMapa() {
        mapa = new SparseArray<>();
        dao.getTopicos(new WebServiceData<List<Topico>>() {
            @Override
            public void processaDados(List<Topico> dados) {
                List<Topico> ids = dados;
                for (int linha = 0; linha < ids.size(); linha++) {
                    mapa.put(linha, ids.get(linha));
                }
                ForumAdapter.this.notifyDataSetChanged();
            }

            @Override
            public void houveErro() {
                Alerta.showToast("Falha ao carregar a lista dos Tópicos");
            }
        });
    }

    public void recarrega() {
        criarMapa();
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
            svc.inflate(R.layout.forum_adapter, layout);
        } else {
            layout = (LinearLayout)view;
        }

        Topico obj = mapa.get(linha);
        TextView tvTitulo = layout.findViewById(R.id.tvTitulo);
        tvTitulo.setText(obj.getTitulo());
        TextView tvCriacao = layout.findViewById(R.id.tvCriacao);
        tvCriacao.setText(fmt.format(obj.getDataCriacao()));

        return layout;
    }
}

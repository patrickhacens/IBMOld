package br.senai.sp.informatica.ibmyoung.view.adapter;

import android.content.Context;
import android.util.SparseLongArray;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import java.util.List;

import br.senai.sp.informatica.ibmyoung.R;
import br.senai.sp.informatica.ibmyoung.model.Aprendiz;
import br.senai.sp.informatica.ibmyoung.model.Questao;
import br.senai.sp.informatica.ibmyoung.repository.AprendizRepo;
import br.senai.sp.informatica.ibmyoung.repository.QuestaoRepo;

/**
 * Created by pena on 27/03/2018.
 */

public class PerguntasAdapter extends BaseAdapter {
    private QuestaoRepo dao = QuestaoRepo.dao;
    private SparseLongArray mapa;

    public PerguntasAdapter() {
        criarMapa();
    }

    private void criarMapa() {
        mapa = new SparseLongArray();
        List<Long> ids = dao.getIds();
        for (int linha = 0; linha < ids.size(); linha++) {
            mapa.put(linha, ids.get(linha));
        }
    }

    @Override
    public void notifyDataSetChanged() {
        criarMapa();
        super.notifyDataSetChanged();
    }

    @Override
    public int getCount() {
        return mapa.size();
    }

    @Override
    public Object getItem(int linha) {
        return dao.localizar(mapa.get(linha));
    }

    @Override
    public long getItemId(int linha) {
        return mapa.get(linha);
    }

    @Override
    public View getView(int linha, View view, ViewGroup viewGroup) {
        LinearLayout layout;

        if(view == null) {
            Context ctx = viewGroup.getContext();
            LayoutInflater svc = (LayoutInflater)ctx.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            layout = new LinearLayout(ctx);
            svc.inflate(R.layout.perguntas_adapter, layout);
        } else {
            layout = (LinearLayout)view;
        }

        Questao obj = dao.localizar(mapa.get(linha));
        TextView tvTitulo = layout.findViewById(R.id.tvTitulo);
        tvTitulo.setText(obj.getTitulo());

        return layout;
    }
}

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
import br.senai.sp.informatica.ibmyoung.repository.AprendizRepo;

/**
 * Created by pena on 27/03/2018.
 */

public class ClassificacaoAdapter extends BaseAdapter {
    private AprendizRepo dao = AprendizRepo.dao;
    private SparseLongArray mapa;

    public ClassificacaoAdapter() {
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
            svc.inflate(R.layout.classificacao_adapter, layout);
        } else {
            layout = (LinearLayout)view;
        }

        Aprendiz obj = dao.localizar(mapa.get(linha));
        ImageView ivFoto = layout.findViewById(R.id.ivFoto);
    //TODO: Implementar a conversão da foto com Glide
    // https://opensource.googleblog.com/2014/09/glide-30-media-management-library-for.html
    // https://inthecheesefactory.com/blog/get-to-know-glide-recommended-by-google/en
        TextView tvNome = layout.findViewById(R.id.tvTitulo);
        tvNome.setText(obj.getNome());
        TextView tvNivel = layout.findViewById(R.id.tvNivel);
        tvNivel.setText(obj.getNivel().toString());

        return layout;
    }
}

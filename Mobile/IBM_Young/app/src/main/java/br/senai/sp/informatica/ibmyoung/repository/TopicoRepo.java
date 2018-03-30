package br.senai.sp.informatica.ibmyoung.repository;

import java.util.ArrayList;
import java.util.List;

import br.senai.sp.informatica.ibmyoung.model.Aprendiz;
import br.senai.sp.informatica.ibmyoung.model.Topico;

public class TopicoRepo {
    public static TopicoRepo dao = new TopicoRepo();

    public List<Long> getIds() {
        return new ArrayList<>();
    }

    public Topico localizar(long id) {
        return new Topico();
    }
}

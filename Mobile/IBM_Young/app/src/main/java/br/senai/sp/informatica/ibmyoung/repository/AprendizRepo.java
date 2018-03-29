package br.senai.sp.informatica.ibmyoung.repository;

import java.util.ArrayList;
import java.util.List;

import br.senai.sp.informatica.ibmyoung.model.Aprendiz;

public class AprendizRepo {
    public static AprendizRepo dao = new AprendizRepo();

    public List<Long> getIds() {
        return new ArrayList<>();
    }

    public Aprendiz localizar(long id) {
        return new Aprendiz();
    }
}

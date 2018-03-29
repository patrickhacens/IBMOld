package br.senai.sp.informatica.ibmyoung.repository;

import java.util.ArrayList;
import java.util.List;

import br.senai.sp.informatica.ibmyoung.model.Aprendiz;
import br.senai.sp.informatica.ibmyoung.model.Questao;

public class QuestaoRepo {
    public static QuestaoRepo dao = new QuestaoRepo();

    public List<Long> getIds() {
        return new ArrayList<>();
    }

    public Questao localizar(long id) {
        return new Questao();
    }
}

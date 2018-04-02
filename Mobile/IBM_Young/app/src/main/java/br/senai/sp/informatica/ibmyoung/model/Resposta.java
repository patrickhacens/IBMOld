package br.senai.sp.informatica.ibmyoung.model;

/**
 * Created by pena on 02/04/2018.
 */

public class Resposta {
    private int alternativaId;

    public Resposta() {
    }

    public Resposta(int alternativaId) {
        this.alternativaId = alternativaId;
    }

    public int getAlternativaId() {
        return alternativaId;
    }

    public void setAlternativaId(int alternativaId) {
        this.alternativaId = alternativaId;
    }
}

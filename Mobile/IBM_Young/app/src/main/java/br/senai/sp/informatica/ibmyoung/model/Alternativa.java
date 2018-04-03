package br.senai.sp.informatica.ibmyoung.model;

/**
 * Created by pena on 31/03/2018.
 */

public class Alternativa {
    private Integer id;
    private String textoAlternativa;
    private boolean correta;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getTextoAlternativa() {
        return textoAlternativa;
    }

    public void setTextoAlternativa(String textoAlternativa) {
        this.textoAlternativa = textoAlternativa;
    }

    public boolean isCorreta() {
        return correta;
    }

    public void setCorreta(boolean correta) {
        this.correta = correta;
    }
}

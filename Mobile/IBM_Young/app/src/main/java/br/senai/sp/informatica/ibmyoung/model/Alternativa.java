package br.senai.sp.informatica.ibmyoung.model;


public class Alternativa {
    private Integer Id;
    private String textoAlternativa;
    private Questao questao;

    public Integer getId() {
        return Id;
    }

    public void setId(Integer id) {
        Id = id;
    }

    public String getTextoAlternativa() {
        return textoAlternativa;
    }

    public void setTextoAlternativa(String textoAlternativa) {
        this.textoAlternativa = textoAlternativa;
    }

    public Questao getQuestao() {
        return questao;
    }

    public void setQuestao(Questao questao) {
        this.questao = questao;
    }
}

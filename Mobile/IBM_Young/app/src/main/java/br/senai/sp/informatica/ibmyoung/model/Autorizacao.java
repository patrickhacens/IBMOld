package br.senai.sp.informatica.ibmyoung.model;


import java.util.Date;

public class Autorizacao {
    private String token;
    private Date expitation;
    private String discriminator;
    private int id;

    public String getToken() {
        return token;
    }

    public void setToken(String token) {
        this.token = token;
    }

    public Date getExpitation() {
        return expitation;
    }

    public void setExpitation(Date expitation) {
        this.expitation = expitation;
    }

    public String getDiscriminator() {
        return discriminator;
    }

    public void setDiscriminator(String discriminator) {
        this.discriminator = discriminator;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }
}

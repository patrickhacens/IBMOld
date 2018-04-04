package br.senai.sp.informatica.ibmyoung.model;


import java.util.Date;

public class Autorizacao {
    private String token;
    private Date expiration;
    private String discriminator;
    private int id;

    public String getToken() {
        return token;
    }

    public void setToken(String token) {
        this.token = token;
    }

    public Date getExpiration() {
        return expiration;
    }

    public void setExpiration(Date expiration) {
        this.expiration = expiration;
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

    public boolean isValid() {
        return token != null &&
           discriminator != null &&
           id != -1 &&
           expiration.after(new Date(0l));
    }
}
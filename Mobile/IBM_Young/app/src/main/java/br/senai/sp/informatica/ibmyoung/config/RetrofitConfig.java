package br.senai.sp.informatica.ibmyoung.config;

import br.senai.sp.informatica.ibmyoung.service.LoginService;
import br.senai.sp.informatica.ibmyoung.service.TarefaService;
import retrofit2.Retrofit;
import retrofit2.converter.jackson.JacksonConverterFactory;

public class RetrofitConfig {
    private static RetrofitConfig instance;
    private final Retrofit retrofit;

    public static RetrofitConfig getInstance() {
        if(instance == null)
          instance = new RetrofitConfig();
        return instance;
    }

    private RetrofitConfig() {
        this.retrofit = new Retrofit.Builder()
                .baseUrl(AppUtils.API_BASE_URL)
                .addConverterFactory(JacksonConverterFactory.create())
                .build();
    }

    public LoginService getLoginService() {
        return this.retrofit.create(LoginService.class);
    }

    public TarefaService getTarefaService() {
        return this.retrofit.create(TarefaService.class);
    }

}
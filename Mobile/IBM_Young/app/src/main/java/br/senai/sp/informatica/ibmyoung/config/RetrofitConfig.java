package br.senai.sp.informatica.ibmyoung.config;

import java.io.IOException;

import br.senai.sp.informatica.ibmyoung.service.AprendizService;
import br.senai.sp.informatica.ibmyoung.service.LoginService;
import br.senai.sp.informatica.ibmyoung.service.QuestaoService;
import br.senai.sp.informatica.ibmyoung.service.ReplicaService;
import br.senai.sp.informatica.ibmyoung.service.TarefaService;
import br.senai.sp.informatica.ibmyoung.service.TopicoService;
import okhttp3.Interceptor;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import retrofit2.Retrofit;
import retrofit2.converter.jackson.JacksonConverterFactory;

public class RetrofitConfig {
    private static RetrofitConfig instance;
    private Retrofit retrofit;
    private String token;

    public static RetrofitConfig getInstance() {
        if(instance == null)
            instance = new RetrofitConfig();

        instance.makeConfig();
        return instance;
    }

    private void makeConfig() {
        Retrofit.Builder builder = new Retrofit.Builder()
                .baseUrl(AppUtils.API_BASE_URL)
                .addConverterFactory(JacksonConverterFactory.create());

        if(token != null && !token.isEmpty())
            builder.client(new OkHttpClient.Builder().addInterceptor(new Interceptor() {
                @Override
                public Response intercept(Chain chain) throws IOException {
                    Request.Builder request = chain.request().newBuilder();
                    request.addHeader("Accept", "application/json");
                    request.addHeader("Authorization", "Bearer " + token);
                    return chain.proceed(request.build());
                }
            }).build());

        this.retrofit = builder.build();
    }

    public void setToken(String token) {
        this.token = token;
    }

    public LoginService getLoginService() {
        return this.retrofit.create(LoginService.class);
    }

    public AprendizService getAprendizService() {
        return this.retrofit.create(AprendizService.class);
    }

    public TopicoService getTopicoService() {
        return this.retrofit.create(TopicoService.class);
    }

    public ReplicaService getReplicaService() {
        return this.retrofit.create(ReplicaService.class);
    }

    public TarefaService getTarefaService() {
        return this.retrofit.create(TarefaService.class);
    }

    public QuestaoService getQuestaoService() {
        return this.retrofit.create(QuestaoService.class);
    }
}
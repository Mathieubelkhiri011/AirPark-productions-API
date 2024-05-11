package com.airparkproductionsapi.AirParkproductionsAPI.service.impl;

import com.airparkproductionsapi.AirParkproductionsAPI.service.InstagramService;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpMethod;
import org.springframework.http.MediaType;
import org.springframework.web.util.UriComponentsBuilder;

@Service
public class InstagramServiceImpl implements InstagramService {

    private final String CLIENT_ID = "745135637795996";
    private final String CLIENT_SECRET = "d7a8e960ab9a3ca7a9838356047f110d  ";
    private final String ACCESS_TOKEN = "votre_access_token";

    private final RestTemplate restTemplate;

    public InstagramServiceImpl(RestTemplate restTemplate) {
        this.restTemplate = restTemplate;
    }

    @Override
    public ResponseEntity<String> getInstagramPosts(String userId, int count) {
        // Construire l'URL pour récupérer les publications de l'utilisateur spécifié
        String url = "https://graph.instagram.com/" + userId + "/media";

        // Paramètres de requête
        HttpHeaders headers = new HttpHeaders();
        headers.set("Authorization", "Bearer " + ACCESS_TOKEN);
        headers.setContentType(MediaType.APPLICATION_JSON);

        // Construction de l'URI avec les paramètres de requête
        UriComponentsBuilder builder = UriComponentsBuilder.fromHttpUrl(url)
                .queryParam("fields", "id,caption,media_type,media_url,permalink,timestamp")
                .queryParam("limit", count);

        // Effectuer la requête GET à l'API Instagram

        return restTemplate.exchange(
                builder.toUriString(),
                HttpMethod.GET,
                null,
                String.class
        );
    }
}

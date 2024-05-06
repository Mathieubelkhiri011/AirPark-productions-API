package com.airparkproductionsapi.AirParkproductionsAPI.repository;


import com.airparkproductionsapi.AirParkproductionsAPI.entity.Media;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface MediaRepository extends JpaRepository<Media, Long> {

    @Query("""
            SELECT me FROM Media me
            JOIN Category ca ON me.category = ca
            WHERE me.displayHomePage = true
            AND me.status = true
            AND ca.codeCategory = "CODE_IMAGE"
            ORDER BY me.orderNumber
            """)
    List<Media> getListHomeImages();
}

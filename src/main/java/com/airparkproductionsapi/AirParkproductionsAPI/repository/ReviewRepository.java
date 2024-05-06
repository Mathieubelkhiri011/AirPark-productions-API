package com.airparkproductionsapi.AirParkproductionsAPI.repository;


import com.airparkproductionsapi.AirParkproductionsAPI.entity.Review;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ReviewRepository extends JpaRepository<Review, Long> {

}

package com.airparkproductionsapi.AirParkproductionsAPI.repository;


import com.airparkproductionsapi.AirParkproductionsAPI.model.Product;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ProductRepository extends JpaRepository<Product, Long> {
}

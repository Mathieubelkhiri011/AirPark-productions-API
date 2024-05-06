package com.airparkproductionsapi.AirParkproductionsAPI.repository;


import com.airparkproductionsapi.AirParkproductionsAPI.entity.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface UserRepository extends JpaRepository<User, Long> {

    User findByEmail(String email);

    void deleteByEmail(String email);
}

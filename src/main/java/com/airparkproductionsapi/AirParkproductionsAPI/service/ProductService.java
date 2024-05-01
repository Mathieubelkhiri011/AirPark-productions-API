package com.airparkproductionsapi.AirParkproductionsAPI.service;

import com.airparkproductionsapi.AirParkproductionsAPI.model.Product;

import java.util.List;
import java.util.Optional;

public interface ProductService {

    public List<Product> getAllProducts();

    public Product getProductById(Long id);

    public Product addProduct(Product product);

    public Product updateProduct(Long id, Product product);

    public void deleteProduct(Long id);
}

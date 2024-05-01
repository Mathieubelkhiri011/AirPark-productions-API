package com.airparkproductionsapi.AirParkproductionsAPI.service;

import com.airparkproductionsapi.AirParkproductionsAPI.model.Product;
import com.airparkproductionsapi.AirParkproductionsAPI.repository.ProductRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.NoSuchElementException;
import java.util.Optional;

@Service
public class ProductServiceImpl implements ProductService{

    private final ProductRepository productRepository;

    public ProductServiceImpl(ProductRepository productRepository) {
        this.productRepository = productRepository;
    }

    @Override
    public List<Product> getAllProducts() {
        return this.productRepository.findAll();
    }

    @Override
    public Product getProductById(Long id) {
        return this.productRepository.findById(id).orElseThrow(() -> new RuntimeException("Product " + id + " not found"));
    }

    @Override
    public Product addProduct(Product product) {
        return this.productRepository.saveAndFlush(product);
    }

    @Override
    public Product updateProduct(Long id, Product product) {
        return this.productRepository.findById(id)
                .map(p -> {
                    p.setName(product.getName());
                    p.setDescription(product.getDescription());
                    p.setPrice(product.getPrice());
                    return this.productRepository.saveAndFlush(p);
                })
                .orElseThrow(() -> new NoSuchElementException("Product with id " + id + " not found"));
    }

    @Override
    public void deleteProduct(Long id) {
        this.productRepository.deleteById(id);
    }
}

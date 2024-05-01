package com.airparkproductionsapi.AirParkproductionsAPI.controller;

import com.airparkproductionsapi.AirParkproductionsAPI.model.Product;
import com.airparkproductionsapi.AirParkproductionsAPI.service.ProductService;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("api/product")
public class ProductController {

    private final ProductService productService;

    public ProductController(ProductService productService) {
        this.productService = productService;
    }

    @GetMapping
    public List<Product> products() {
        return this.productService.getAllProducts();
    }

    @GetMapping("/{id}")
    public Product productById(@PathVariable Long id) {
        return this.productService.getProductById(id);
    }

    @PostMapping
    public Product create(@RequestBody Product product) {
        return this.productService.addProduct(product);
    }

    @PutMapping("/{id}")
    public Product updateProduct(@PathVariable Long id, @RequestBody Product product) {
        return this.productService.updateProduct(id,product);
    }

    @DeleteMapping("/{id}")
    public void deleteById(@PathVariable Long id) {
        this.productService.deleteProduct(id);
    }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from './product';
import { Paging } from '../shared/data/paging';
import { GridPaging } from '../shared/data/grid-paging';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  constructor(private http: HttpClient) { }

  getProducts(gridPaging: GridPaging): Observable<Paging<Product>> {
    return this.http.get<Paging<Product>>(`api/products?pageNumber=${gridPaging.pageNumber || ''}&pageSize=${gridPaging.pageSize || ''}&orderBy=${gridPaging.orderBy}&filter=${gridPaging.filter}&desc=${gridPaging.isDescending}`);
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`api/products/${id}`);
  }

  createProduct(product: Product) {
    return this.http.post('api/products', product);
  }

  updateProduct(product: Product) {
    return this.http.put(`api/products/${product.id}`, product);
  }

  deleteProduct(id: number) {
    return this.http.delete(`api/products/${id}`);
  }
}

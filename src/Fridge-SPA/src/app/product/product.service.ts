import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

import { Product } from "../model/product";
import { environment } from "src/environments/environment";
import { Category } from "../model/category";

@Injectable()
export class ProductService {
    productUrl = environment.baseUrl + 'api/products';

    constructor(private http: HttpClient) { }

    getProductsFromServer(): Observable<Product[]> {
        return this.http.get<Product[]>(this.productUrl);
    }

    addProductToServer(product: Product): Observable<Product> {
        return this.http.post<Product>(this.productUrl, product);
    }

    deleteProductFromServer(id: number): Observable<any> {
        const url = this.productUrl + '/' + id;
        return this.http.delete(url);
    }

    updateProductToServer(product: Product): Observable<Product> {
        return this.http.put<Product>(this.productUrl + '/' + product.id, product);
    }

    getCategoriesFromServer(): Observable<Category[]> {
        return this.http.get<Category[]>(environment.baseUrl + 'api/categories');
    }
}
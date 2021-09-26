import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

import { Category } from "../model/category";
import { environment } from "src/environments/environment";

@Injectable()
export class CategoryService {
    categoryUrl = environment.baseUrl + 'api/categories';

    constructor(private http: HttpClient) { }

    getCategoriesFromServer(): Observable<Category[]> {
        return this.http.get<Category[]>(this.categoryUrl);
    }

    addCategoryToServer(category: Category): Observable<Category> {
        return this.http.post<Category>(this.categoryUrl, category);
    }

    deleteCategoryFromServer(id: number): Observable<any> {
        const url = this.categoryUrl + '/' + id;
        return this.http.delete(url);
    }
}
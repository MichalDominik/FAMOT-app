import { Component, OnInit } from '@angular/core';
import { Category } from '../model/category';

import { Product } from '../model/product';
import { ProductService } from './product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  providers: [ProductService],
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  products: Product[] = [];
  categories: Category[] = [];

  productForEdit: Product | undefined;

  productToAdd = new Product(-1, '', -1, '');
  categoryToAdd = new String('');

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getCategories();
  }

  getProducts(): void {
    this.productService.getProductsFromServer()
    .subscribe(p => this.products = p);
  }

  getCategories(): void {
    this.productService.getCategoriesFromServer()
    .subscribe(c => this.categories = c);
  }

  getCategoryName(id: number): string {
    const lookup = this.categories.find(c => c.id === id);
    if (lookup !== undefined){
      return lookup.name;
    }
    return 'hello';
  }

  addProduct(): void {
    const category = this.categories.find(c => c.name === this.categoryToAdd);
    const productToPush = new Product(-1, this.productToAdd.name, category ? category.id : -1, this.productToAdd.description);
    this.productService
    .addProductToServer(productToPush)
    .subscribe({
      next: data => {
        this.products.push(data);
      },
      error: error => {
        console.log(error.message);
      }
    });
    this.categoryToAdd = '';
  }

  deleteProduct(product: Product): void {
    this.productService
    .deleteProductFromServer(product.id)
    .subscribe({
      next: data => {
        this.products = this.products.filter(p => p !== product);
      },
      error: error => {

      }
    });
  }

  editProduct(product: Product) {
    this.productForEdit = product;
  }

  update(){
    if (this.productForEdit) {
      this.productService
      .updateProductToServer(this.productForEdit)
      .subscribe( prod => {
        const indx = prod ? this.products.findIndex(p => p.id === prod.id) : -1;
        if (indx > -1) {
          this.products[indx] = prod;
        }
      });
      this.productForEdit = undefined;
    }
  }
}

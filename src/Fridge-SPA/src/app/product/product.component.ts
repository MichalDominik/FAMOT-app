import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

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
  productCategoryEdit = new String('');

  displayedColumns: string[] = ['name', 'category', 'description', 'edit', 'delete'];
  dataSource = new MatTableDataSource<Product>();

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getCategories();
    this.refresh();
  }

  getProducts(): void {
    this.productService.getProductsFromServer()
    .subscribe(p => this.products = p);
  }

  getCategories(): void {
    this.productService.getCategoriesFromServer()
    .subscribe(c => this.categories = c);
  }

  getCategoryName(id: number): String {
    const lookup = this.categories.find(c => c.id === id);
    if (lookup !== undefined) {
      return lookup.name;
    }
    return 'error';
  }

  getCategoryId(name: String): number {
    const lookup = this.categories.find(c => c.name === name);
    if (lookup !== undefined) {
      return lookup.id;
    }
    return -1;
  }

  addProduct(): void {
    const category = this.categories.find(c => c.name === this.categoryToAdd);
    const productToPush = new Product(-1, this.productToAdd.name, category ? category.id : -1, this.productToAdd.description);
    this.productService
    .addProductToServer(productToPush)
    .subscribe({
      next: data => {
        this.products.push(data);
        this.refresh();
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
        this.refresh();
      }
    });
  }

  editProduct(product: Product) {
    this.productForEdit = product;
    this.productCategoryEdit = this.getCategoryName(product.categoryId);
  }

  update() {
    if (this.productForEdit) {
      const categoryCheck = this.getCategoryId(this.productCategoryEdit);
      if (categoryCheck === -1) return;
      this.productForEdit.categoryId = categoryCheck;
      this.productService
      .updateProductToServer(this.productForEdit)
      .subscribe( prod => {
        const indx = prod ? this.products.findIndex(p => p.id === prod.id) : -1;
        if (indx > -1) {
          this.products[indx] = prod;
        };
        this.cancel();
      });
    }
  }

  cancel() {
    this.productForEdit = undefined;
    this.productCategoryEdit = '';
    this.refresh();
  }

  refresh(): void {
    this.productService.getProductsFromServer()
    .subscribe({
      next: data => {
        this.dataSource.data = data;
      }
    })
  }
}

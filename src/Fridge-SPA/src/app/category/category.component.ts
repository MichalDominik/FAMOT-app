import { Component, OnInit } from '@angular/core';

import { Category } from '../model/category';
import { CategoryService } from './category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  providers: [CategoryService],
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  categories: Category[] = [];
  categoryToAdd = new Category(-1, '');

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories(): void {
    this.categoryService.getCategoriesFromServer()
    .subscribe(c => this.categories = c);
  }

  addCategory(): void {
    const categoryToPush = new Category(-1, this.categoryToAdd.name);
    this.categoryService
    .addCategoryToServer(categoryToPush)
    .subscribe({
      next: data => {
        this.categories.push(categoryToPush);
      },
      error: error => {

      }
    });
  }

  deleteCategory(category: Category): void {
    this.categoryService
    .deleteCategoryFromServer(category.id)
    .subscribe({
      next: data => {
        this.categories = this.categories.filter(c => c !== category);
      },
      error: error => {
        
      }
    });
  }
}

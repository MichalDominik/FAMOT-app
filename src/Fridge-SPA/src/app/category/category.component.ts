import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

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

  displayedColumns: string[] = ['name', 'delete'];
  dataSource = new MatTableDataSource<Category>();

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.getCategories();
    this.refresh();
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
        this.categories.push(data);
        this.refresh();
      }
    });
  }

  deleteCategory(category: Category): void {
    this.categoryService
    .deleteCategoryFromServer(category.id)
    .subscribe({
      next: data => {
        this.categories = this.categories.filter(c => c !== category);
        this.refresh();
      }
    });
  }

  refresh(): void {
    this.categoryService.getCategoriesFromServer()
    .subscribe({
      next: data => {
        this.dataSource.data = data;
      }
    })
  }
}

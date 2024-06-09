import { Component, EventEmitter, Output } from '@angular/core';
import { Category } from '../category';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss']
})
export class CategoriesComponent {
  @Output() selectCategoryEmitter = new EventEmitter<Category>();

  selectedCategory: Category;

  listOfCategories: Category[] = 
  [
    {id: 1, name: 'Course'},
    {id: 2, name: 'General'},
    {id: 3, name: 'Laboratory'}
  ]

  selectCategory(selectedCategory: Category)
  {
    this.selectedCategory = selectedCategory;

    this.emitSelectedCategory();
  }

  emitSelectedCategory()
  {
    this.selectCategoryEmitter.emit(this.selectedCategory);
  }

  resetFilters()
  {
    this.selectedCategory = undefined;

    this.emitSelectedCategory();
  }
}

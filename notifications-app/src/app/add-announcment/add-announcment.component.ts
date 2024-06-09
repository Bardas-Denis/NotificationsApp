import { Component } from '@angular/core';
import { Category } from '../category';

@Component({
  selector: 'app-add-announcment',
  templateUrl: './add-announcment.component.html',
  styleUrls: ['./add-announcment.component.scss']
})
export class AddAnnouncmentComponent {

  title:string;
  author:string;
  message:string;
  image_url:string;
  categorySelected:string;


  listOfCategories: Category[] = 
  [
    {id: 1, name: 'Course'},
    {id: 2, name: 'General'},
    {id: 3, name: 'Laboratory'}
  ]

  printInLog()
  {
    console.log("title "+ this.title);
    console.log("author "+ this.author);
    console.log("message "+ this.message);
    console.log("imageUrl "+ this.image_url);
    console.log("selectedCategory "+ this.categorySelected);

  }
}

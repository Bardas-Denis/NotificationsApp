import { Component } from '@angular/core';
import { Announcement } from '../announcement';
import { Category } from '../category';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  title = 'notifications-app';
  
  announcementsFromApp: Announcement[] =
  [ 
    { 
      title: 'un titlu', 
      message: 'salut', 
      author: 'Denis',
      categoryObject: { id: 1, name: 'test category 1' },
      imageUrl: 'google.com',
      id: '1'
    },
    { 
      title: 'alt titlu', 
      message: 'hello world', 
      author: 'Adelin',
      categoryObject: { id: 2, name: 'test category 2' },
      imageUrl: 'youtube.com',
      id: '2'
    },
    { 
      title: 'titlu', 
      message: 'salut', 
      author: 'Denis',
      categoryObject: { id: 3, name: 'test category 3' },
      imageUrl: 'google.com',
      id: '3'
    }

  ]

  filteredAnnouncements: Announcement[] = this.announcementsFromApp;

  filterAnnouncements(selectedCategory: Category)
  {
    // this.announcementsFromApp.filter(announcement =>
    //   {
    //     return announcement.categoryObject.id == selectedCategory.id;
    //   })
    // or
    if(!selectedCategory)
    {
      this.filteredAnnouncements = this.announcementsFromApp;
      
      return;
    }

    this.filteredAnnouncements = this.announcementsFromApp.filter
    (announcement => 
      announcement.categoryObject.id === selectedCategory.id
    );
  }
}

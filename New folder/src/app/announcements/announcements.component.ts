import { Component, Input } from '@angular/core';
import { Announcement } from '../announcement';

@Component({
  selector: 'app-announcements',
  templateUrl: './announcements.component.html',
  //template: '', //cod html
  styleUrls: ['./announcements.component.scss'],
  styles: ['p { color: red;}']
})
export class AnnouncementsComponent {
    //public is by default
    private message: string = 'acesta este un test';
    private title: string = 'test 2';
    private author: string = 'cosmin';

    @Input() announcement: Announcement = 
    {
      title: '',
      message: '',
      author: '',
      categoryObject: { id: 1, name: ''},
      imageUrl: '',
      id: ''
    }
}

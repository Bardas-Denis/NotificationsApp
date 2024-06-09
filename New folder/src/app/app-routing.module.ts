import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AddAnnouncmentComponent } from './add-announcment/add-announcment.component';
import { HomeComponent } from './home/home.component';


const routes:Routes=[{path: 'add', component:AddAnnouncmentComponent},
{path:'home',component:HomeComponent},
{ path:'**', redirectTo:"home"}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ]
})
export class AppRoutingModule { 
  
}

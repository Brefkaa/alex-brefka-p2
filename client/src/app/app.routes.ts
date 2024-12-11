import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ViewPostComponent } from './view-post/view-post.component';
import { CreateTodoComponent } from './create-todo/create-todo.component';
export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'create', component: CreateTodoComponent },
    { path: 'todolist/:id', component: ViewPostComponent },
    { path: '**', component: HomeComponent, pathMatch: "full" }
];

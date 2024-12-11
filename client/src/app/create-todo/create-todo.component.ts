import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-create-todo',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  templateUrl: './create-todo.component.html',
  styleUrl: './create-todo.component.css'
})
export class CreateTodoComponent implements OnInit {
  model: any = {};

  constructor(
    private http: HttpClient,
    private route: Router) { }

  ngOnInit(): void {
  }

  createTodo() {
    this.model.date = new Date();
    this.http.post('http://localhost:5092/api/todolist', this.model).subscribe(
      response => { this.home() },
      error => { console.log(error) }
    );
  }

  cancel() {
    this.home();
  }

  home() {
    this.route.navigate(["/"]);
  }
}

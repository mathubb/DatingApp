import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';

@Component({
  selector: 'app-root',
  imports: [],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit{
  private http = inject(HttpClient);
  protected readonly title = signal('Dating app');
  protected members = signal<any>(null)

  ngOnInit(): void {
    this.http.get('https://localhost:7216/api/members').subscribe({
      next: Response => this.members.set(Response),
      error: err => console.log(err),
      complete: () => console.log('Completed the request.')
    })
  }
}

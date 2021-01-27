import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPageination } from './shared/models/Pageination';
import { IProduct } from './shared/models/Product';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Shose Store';
  products : IProduct[];
  constructor(private http: HttpClient) {

  }
  ngOnInit(): void {
    this.http.get("https://localhost:5001/api/products").subscribe((response: IPageination) => {
      this.products = response.data;
    }, error => {
      console.log(error);

    });
  }

}

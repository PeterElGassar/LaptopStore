import { IBrand } from './../shared/models/Brand';
import { IProductType } from './../shared/models/ProductType';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPageination } from '../shared/models/Pageination';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl: string = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) { }

  getProducts(brandId?: number, typeId?: number, sort?: string) {
    let params = new HttpParams();
    
    if (brandId)
      params = params.append("brandId", brandId.toString());

    if (typeId)
      params = params.append("typeId", typeId.toString());

    if (sort)
      params = params.append("sort", sort);

    return this.http.get<IPageination>(this.baseUrl + 'products?', { observe: "response", params })
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }

  getTypes() {
    return this.http.get<IProductType[]>(this.baseUrl + 'products/brands');
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/types');
  }
}

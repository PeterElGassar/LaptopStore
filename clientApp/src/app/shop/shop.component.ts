import { IProductType } from './../shared/models/ProductType';
import { IBrand } from './../shared/models/Brand';
import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/Product';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  title: string = "Peter El-Gassar";
  products: IProduct[];
  brands: IBrand[];
  types: IProductType[];
  brandIdSelected= 0;
  typeIdSelected=0;
  sortSelected = 'name';
  sortOptions =[
    {name :"Alphabetical" , value :"name"},
    {name :"Price: Low To High" , value :"priceAsc"},
    {name :"Price: High To Low" , value :"priceDesc"}
  ]

  constructor(private shopServ: ShopService) { }

  ngOnInit() {
    this.getBrands();
    this.gettypes();
    this.getProducts();
  }

  getProducts() {
    this.shopServ.getProducts(this.brandIdSelected, this.typeIdSelected ,this.sortSelected).subscribe(response => {
      this.products = response.data;
    }, error => {
      console.log(error);
    });
  };

  getBrands() {
    this.shopServ.getBrands().subscribe(response => {
      this.brands = [{ id: 0, name: 'All' }, ...response];
    }, error => {
      console.log(error);
    })
  };

  gettypes() {
    this.shopServ.getTypes().subscribe(response => {
      this.types = [{ id: 0, name: 'All' }, ...response];
    }, error => {
      console.log(error);
    })
  };

  onBrandSeleted(brandId: number) {
    this.brandIdSelected = brandId;
    //invok
    this.getProducts();
  }
  onTypeSeleted(typeId: number) {
    this.typeIdSelected = typeId;
   //invok
    this.getProducts();
  }

  onSortSelected(sort: string) {
    debugger;
    this.sortSelected = sort;
    //invok
    this.getProducts();
  }
}

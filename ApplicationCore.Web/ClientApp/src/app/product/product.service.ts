import { Injectable, Inject } from '@angular/core';
import { Product } from './product';
import { HttpClient } from "@angular/common/http";
import { AbstractRestService } from '../shared/services/AbstractRestService';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ProductService extends AbstractRestService<Product> {
  constructor(http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    super(http, baseUrl + 'api/SampleData/GetProducts');
  }
  products: Product[] = [];
  public clearForm(): void {

  }

  public save(body) {
    
  }

  public getProducts(): Observable<Product[]> {
    return this.getAll();
  }
}

import { Component, OnInit } from '@angular/core';
import { Product } from './product';
import { NgForm, FormControl, FormGroup } from '@angular/forms';
import { ProductService } from './product.service';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  providers: [ProductService]
})
export class ProductComponent implements OnInit {
  products: Observable<Product[]>;
  constructor(private productService: ProductService) {  }

  model: Product = { id: 0, name: '', code: '', isActive: false, orderNumber: 0 };

  profileForm = new FormGroup({
    id: new FormControl(0),
    name: new FormControl(''),
    isActive: new FormControl(true),
    code: new FormControl(''),
    orderNumber: new FormControl(0)
  });

  ngOnInit() {
    this.products = this.productService.getProducts();
  }

  onSubmit() {
    // TODO: Use EventEmitter with form value
    console.warn(this.profileForm.value);
    if (this.profileForm.valid) {
      this.productService.save(this.profileForm.value);
    }
  }

  private saveProduct(form: NgForm) {
    if (form.invalid) {
      return;
    }
    console.log(form.value);
    this.productService.clearForm();
    this.productService.save(form.value);
  }

}

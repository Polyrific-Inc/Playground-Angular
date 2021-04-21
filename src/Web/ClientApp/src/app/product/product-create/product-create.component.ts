import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Product } from '../product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {
  productForm: FormGroup;
  product: Product;
  submitted = false;
  loading = false;

  constructor(
    private formBuilder: FormBuilder,
    private productService: ProductService,
    private router: Router) { }

  ngOnInit() {
    this.productForm = this.formBuilder.group({
      name: ['', Validators.required],
      price: ['', Validators.required]
    });
  }

  onSubmit() {
    this.submitted = true;
    if (this.productForm.invalid) {
      return;
    }

    this.loading = true;

    const product = Object.assign({}, this.productForm.value);

    this.productService.createProduct(product).subscribe(() => {
      this.loading = false;
      this.router.navigateByUrl('/product');
    }, () => this.loading = false);
  }

  onClickCancelBtn() {
    this.productForm.reset();
    this.router.navigateByUrl("/product");
  }

  // convenience getter for easy access to form fields
  get f() { return this.productForm.controls; }

}

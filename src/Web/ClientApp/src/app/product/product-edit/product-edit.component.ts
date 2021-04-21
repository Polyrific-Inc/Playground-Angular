import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  productForm: FormGroup;
  product: Product;
  submitted = false;
  loading = false;

  constructor(
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private router: Router,
    private productService: ProductService) { }

  ngOnInit() {
    this.productForm = this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      name: ['', Validators.required],
      price: ['', Validators.required]
    });
    const id = this.route.snapshot.params.id;
    this.productService.getProduct(id)
      .subscribe(data => {
        this.product = data;
        this.productForm.patchValue(this.product);
      });
  }

  onSubmit() {
    this.submitted = true;
    if (this.productForm.invalid) {
      return;
    }

    this.loading = true;

    const updatedProduct = Object.assign({}, this.productForm.value);
    updatedProduct.id = this.product.id;

    this.productService.updateProduct(updatedProduct).subscribe(() => {
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

import { Component } from '@angular/core';
import { GridPaging } from '../../shared/data/grid-paging';
import { Product } from '../product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {
  public products: Product[];

  constructor(private productService: ProductService) {
    this.load();
  }

  onDeleteClicked(id: number) {
    this.productService.deleteProduct(id).subscribe(() => {
      this.load();
    });
  }

  private load() {
    this.productService.getProducts(new GridPaging()).subscribe(result => {
      this.products = result.items;
    }, error => console.error(error));
  }

}

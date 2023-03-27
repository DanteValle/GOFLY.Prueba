import { Component } from '@angular/core';
import { ApiProductoService } from "../Services/api-producto.service";

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css']
})
export class ProductoComponent {
  public productos: any[] | undefined;
  constructor(private apiProdcutoService: ApiProductoService) { }
  
  ngOnInit() {
    this.apiProdcutoService.getAllProducts().subscribe(data => {
      this.productos = data
    });
  }
}




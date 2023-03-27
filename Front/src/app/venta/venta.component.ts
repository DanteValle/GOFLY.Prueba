import { Sale } from './../Modelos/Sale';
import { Item } from './../Modelos/Item';
import { ApiProductoService } from './../Services/api-producto.service';
import { Component } from '@angular/core';
import { VentaService } from "../Services/venta.service";
// import * as $ from 'jquery';
// import 'select2';

@Component({
  selector: 'app-venta',
  templateUrl: './venta.component.html',
  styleUrls: ['./venta.component.css']
})
export class VentaComponent {
  public ventas: any[] | undefined;
  public productos: Item[] | undefined;
  public productosSeleccionados: Item[];
  public ventaModel: Sale;
  modalOpen = false;
  constructor(private ventaService: VentaService, private productoService: ApiProductoService) {
    this.productosSeleccionados = [];
    this.ventaModel = {
      client: '',
      totalPrice: 0.00,
      totalItems: 0
    }
    
  }
  openModal() {
    this.modalOpen = true;
    this.productoService.getAllProducts().subscribe(data => {
      this.productos = data
    });
  }
  closeModal() {
    this.modalOpen = false;
    this.obtenerVentas();
  }
  // onSeleccionChange(event: any) {
  //   this.productosSeleccionados.push(event.target.value);
  //   console.log('Elementos seleccionados:', this.productosSeleccionados);
  // }
  agregarVenta() {
    console.log(this.productosSeleccionados.length)
    this.ventaModel.totalPrice = this.productosSeleccionados.reduce((total, producto)=>total + producto.price,0);
    this.ventaModel.listItems = this.productosSeleccionados;
    this.ventaModel.totalItems = this.productosSeleccionados.length
    this.ventaModel.description = "aaa"
    this.ventaService.createSale(this.ventaModel).subscribe(data => {
      console.log(data);
      this.obtenerVentas();
    });
  }
  obtenerVentas(){
    this.ventas =[];
    this.ventaService.getAllSale().subscribe(data => {
      this.ventas = data
    });
  }
  ngOnInit() {
    // $('#multiple-select-field').select2({
    //   theme: "bootstrap-5",
    //   width: $(this).data('width') ? $(this).data('width') : $(this).hasClass('w-100') ? '100%' : 'style',
    //   placeholder: $(this).data('placeholder'),
    //   closeOnSelect: false,
    // });
    this.obtenerVentas();
  }
}

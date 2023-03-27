import { Sale } from './../Modelos/Sale';
import { Item } from './../Modelos/Item';
import { ApiProductoService } from './../Services/api-producto.service';
import { Component } from '@angular/core';
import { UsuarioService } from "../Services/usuario.service";
import { User } from '../Modelos/User';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent {
  public usuarios: any[] | undefined;
  public productos: Item[] | undefined;
  public usuario: User;
  public modoEdicion: boolean = false;
  modalOpen = false;
  constructor(private usuarioService: UsuarioService) {
    this.usuario = {
      name: ''
     
    }
    
  }
  openModal() {
    this.modalOpen = true;
  }
  closeModal() {
    this.modalOpen = false;

  }
  limpiarUsuario(){
    this.usuario = Object.assign({}, this.usuario);
  }
  openModalAgregarUsuario(){
    this.limpiarUsuario();
    this.openModal();
    this.modoEdicion = false;
  }
  openModalModificarUsuario(_usuario :User){
    this.modoEdicion = true;
    this.limpiarUsuario();
    this.usuario = _usuario;
    this.openModal();
  }

  agregarUsuario() {
    this.usuarioService.crearUsuario(this.usuario).subscribe(data => {
      console.log(data);
      this.obtenerUsuarios();
    });
  }
  obtenerUsuarios(){
    this.usuarios =[];
    this.usuarioService.obtenerUsuarios().subscribe(data => {
      this.usuarios = data
    });
  }
  modificarUsuario(_usuario :User){
    
    this.usuarioService.modificarUsuario(this.usuario).subscribe(data => {
      console.log(data);
      this.obtenerUsuarios();
      this.closeModal();
    });
   

  }
  eliminarUsuario(id: number){
    this.usuarioService.eliminarUsuario(id).subscribe(data => {
      console.log(data);
    });
    this.obtenerUsuarios();
  }
  ngOnInit() {
   
    this.obtenerUsuarios();
  }
}

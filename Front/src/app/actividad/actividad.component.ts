import { Activity } from './../Modelos/Activity';
import { User } from './../Modelos/User';
import { ApiProductoService } from './../Services/api-producto.service';
import { Component } from '@angular/core';
import { ActividadService } from "../Services/actividad.service";
import { UsuarioService } from "../Services/usuario.service";

@Component({
  selector: 'app-actividad',
  templateUrl: './actividad.component.html',
  styleUrls: ['./actividad.component.css']
})
export class ActividadComponent {
  public actividades: any[] | undefined;
  public actividad: Activity;
  public modoEdicion: boolean = false;
  public usuarios: any[] | undefined;
  public usuarioSeleccionado: User;
  modalOpen = false;
  constructor(private actividadService: ActividadService, private usuarioService: UsuarioService) {
    this.actividad = {
      activityName: ''
    }
    this.usuarioSeleccionado  ={
      name: ''
    }
  }
  obtenerUsuarios(){
    this.usuarios =[];
    this.usuarioService.obtenerUsuarios().subscribe(data => {
      this.usuarios = data
    });
  }
  openModal() {
    this.modalOpen = true;
  }
  closeModal() {
    this.modalOpen = false;
  }
  limpiarActividad(){
    this.actividad={};
  }
  openModalAgregarActividad(){
    this.limpiarActividad();
    this.obtenerUsuarios();
    this.openModal();
    this.modoEdicion = false;
  }
  openModalModificarActividad(_actividad :Activity){
    this.modoEdicion = true;
    this.limpiarActividad();
    this.obtenerUsuarios();
    this.actividad = _actividad;
    this.openModal();
  }

  agregarActividad() {
    this.actividadService.crearActividad(this.actividad).subscribe(data => {
      console.log(data);
      this.obtenerActividades();
    });
  }
  obtenerActividades(){
    this.actividades =[];
    this.actividadService.obtenerActividades().subscribe(data => {
      this.actividades = data
    });
  }
  modificarActividad(_actividad :Activity){
    
    this.actividadService.modificarActividad(this.actividad).subscribe(data => {
      console.log(data);
      this.obtenerActividades();
      this.closeModal();
    });
   

  }
  eliminarActividad(id: number){
    this.actividadService.eliminarActividad(id).subscribe(data => {
      console.log(data);
    });
    this.obtenerActividades();
  }
  ngOnInit() {
   
    this.obtenerActividades();
  }
}

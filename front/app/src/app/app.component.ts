import { Component } from '@angular/core';
import { Usuario } from './models/usuario';
import { ApiauthService } from './services/apiauth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'app';
  usuario: Usuario;

  constructor(public  apiautService: ApiauthService,
              private router:Router
  ){
    this.apiautService.usuario.subscribe(res => {
      this.usuario = res;
      console.log("cambio el objeto ", res)
    })
  }

  logout(){
    this.apiautService.logout();
    this.router.navigate(['/login']);
  }
}

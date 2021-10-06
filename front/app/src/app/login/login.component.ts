import { OnInit, Component } from '@angular/core';
import { ApiauthService } from '../services/apiauth.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, FormBuilder, Validators} from '@angular/forms'

@Component({templateUrl:'login.component.html'})
export class LoginComponent implements OnInit {

    public loginForm = this.formBuilder.group({
        email:['', Validators.required],
        password:['',Validators.required]
    });

   /* public loginForm = new FormGroup(
        {
        email:new FormControl(''),
        password:new FormControl('')
        });
*/


    //public email: string = "";
    //public password: string = "";

    constructor(public apiauthService:ApiauthService,
                private router: Router,
                private formBuilder:FormBuilder
    ){
        
        if(this.apiauthService.usuarioData  ){
            this.router.navigate(['/']);
        }
    }
    
    ngOnInit(){

    }

    login(){
      
        this.apiauthService.login(this.loginForm.value).subscribe(response => {
           
         console.log("response login",response);
          if(response.succes == 1){
            this.router.navigate(['/home'])
          } 
          else{
              console.log("ERROR EN RESPONSE ", response);
              alert("response");
          }
        });
    }
}        
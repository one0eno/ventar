import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ApiclienteService } from '../../services/apicliente.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Cliente } from '../../models/cliente';
import { inject } from '@angular/core/testing';
@Component({

    templateUrl:"dialogcliente.component.html"
})
export class DialogClienteComponent{

    public nombre: string = "";
    
    constructor(
        public dialogRef: MatDialogRef<DialogClienteComponent>,
        public apiCliente: ApiclienteService,
        public snackBar:MatSnackBar,
        @Inject(MAT_DIALOG_DATA) public cliente: Cliente
    ){

            if(this.cliente != null ){
                this.nombre = cliente.nombre;
            }
                
    }

    close(){
       
        this.dialogRef.close();
    }

    addCliente(){

        const cliente: Cliente = {id:0, nombre: this.nombre,}
        this.apiCliente.add(cliente).subscribe(response => {
           
            if(response.succes === 1)
            {
                this.dialogRef.close();
                this.snackBar.open('Insertado con éxito','',{
                    duration:2000
                });
            }
        });

    }

    editCliente(){

        const cliente: Cliente = {nombre:this.nombre, id:this.cliente.id}
        this.apiCliente.edit(cliente).subscribe(response => {
           
            if(response.succes === 1)
            {
                this.dialogRef.close();
                this.snackBar.open('Editado con éxito','',{
                    duration:2000
                });
            }
        });
    }

    deleteCliente(){
        
    }
}
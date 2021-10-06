import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
//import { DialogClienteComponent } from '../../cliente/dialog/dialogcliente.component';

@Component({
    templateUrl:'dialogdelete.component.html'
})

export class DialogDeleteComponent{

    constructor(
    public dialogRef: MatDialogRef<DialogDeleteComponent>

    ){

    }
}
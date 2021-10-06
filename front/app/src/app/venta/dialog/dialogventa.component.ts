import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormBuilder, Validators } from '@angular/forms';
import { ApiventaService } from '../../services/apiventa.service';
import { Venta } from '../../models/venta';
import { Concepto } from '../../models/concepto';

@Component({
    templateUrl: './dialogventa.component.html',
    
  })

  export class DialogVentaComponent {

        public venta: Venta;
        public conceptos: Concepto[];

        public conceptoForm = this.formBuilder.group({
            cantidad:[0, Validators.required],
            importe:[0, Validators.required],
            idProducto:[0, Validators.required],
            precioUnitario:[0]
        });

        constructor( 
            public dialogRef:MatDialogRef<DialogVentaComponent>,
            public snackBar:MatSnackBar,
            private formBuilder: FormBuilder,
            public apiVenta:ApiventaService
        ){

            this.conceptos = [];
            this.venta = {idCliente:3, conceptos:[]};
        }

        close() {
            
            this.dialogRef.close();
        }

        addConcepto(){
            this.conceptos.push(this.conceptoForm.value);
        }
        addVenta(){

            this.venta.conceptos = this.conceptos;
            this.apiVenta.add(this.venta).subscribe(response => {
                if ( response.succes == 1 )
                {
                    this.dialogRef.close();
                    this.snackBar.open("Venta realizada con éxito",'', {
                        duration:2000
                    });
                }
            })
        }
  }


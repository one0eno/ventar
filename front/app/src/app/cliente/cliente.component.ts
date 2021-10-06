import { Component, OnInit } from '@angular/core';
import { ApiclienteService } from '../services/apicliente.service';
import { Response } from '../models/response';
import { DialogClienteComponent } from './dialog/dialogcliente.component';
import { MatDialog } from '@angular/material/dialog';
import { Cliente } from '../models/cliente';
import { DialogDeleteComponent } from '../common/delete/dialogdelete.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})
export class ClienteComponent implements OnInit {

  public lst:any;
  public columnas: string[] = ['id','nombre','activo','actions']
  readonly width: string = "300px";
  constructor(
    private apiCliente: ApiclienteService,
    private dialog: MatDialog,
    public snackBar:MatSnackBar
  ) 
  { 
    
  }

  ngOnInit(): void {

    this.getClientes();
  }

  getClientes(){
    console.log("apicliente", this.apiCliente);
    this.apiCliente.getClientes().subscribe(response => {
      this.lst = response.data;
    });
  
  }

  openAdd(){
    const dialogRef = this.dialog.open(DialogClienteComponent,{
      width:this.width
    });

    //ELEMENT_DATA.push({position: 1, name: this.value1, weight: 1.0079, symbol: 'H'})
    //this.dataSource = new MatTableDataSource(ELEMENT_DATA);

    dialogRef.afterClosed().subscribe(resutl => {
       this.getClientes();
    })
  }

  openEdit(cliente: Cliente){
 
    const dialogRef = this.dialog.open(DialogClienteComponent,{
      width:this.width,
      data:cliente
    });

    dialogRef.afterClosed().subscribe(resutl => {
      this.getClientes();
    });
  }

  delete(cliente:Cliente){
    const dialogRef = this.dialog.open(DialogDeleteComponent,{
      width:this.width,
      data:cliente
    });

    dialogRef.afterClosed().subscribe(result => {
      //this.getClientes();
      if(result){
        this.apiCliente.delete(cliente.id).subscribe(response => {
          if(response.succes == 1)
          {
            this.snackBar.open("Cliente Eliminado", '', {
              duration:2000
            })
            this.getClientes();
          }
        })
      }
    });        
  }
}

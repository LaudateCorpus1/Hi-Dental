import { Component, OnInit } from '@angular/core';
import { TableService } from 'src/app/shared/services/table.service';

@Component({
  selector: 'app-usuario-listado',
  templateUrl: './usuario-listado.component.html',
  styleUrls: ['./usuario-listado.component.css']
})
export class UsuarioListadoComponent implements OnInit {

  constructor(private tableSvc : TableService) {
      this.displayData = this.ordersList
  }

  allChecked: boolean = false;
  indeterminate: boolean = false;
  search : any;
  displayData = [];

  ordersList = [
      {
          id: 5331,
          name: 'Erin Gonzales',
          Email: 'eringGonzales@gmail.com',
          avatar: 'assets/images/avatars/thumb-1.jpg',
          date: '8 May 2019',
          TipoUsuario: 'Doctor',
          status: 'approved',
          checked : false
      },
      {
          id: 5375,
          name: 'Darryl Day',
          Email: 'eringGonzales@gmail.com',
          avatar: 'assets/images/avatars/thumb-2.jpg',
          date: '6 May 2019',
          TipoUsuario: 'Doctor',
          status: 'approved',
          checked : false
      },
      {
          id: 5762,
          name: 'Marshall Nichols',
          Email: 'eringGonzales@gmail.com',
          avatar: 'assets/images/avatars/thumb-3.jpg',
          date: '1 May 2019',
          TipoUsuario: 'Doctor',
          status: 'approved',
          checked : false
      },
      {
          id: 5865,
          name: 'Virgil Gonzales',
          Email: 'eringGonzales@gmail.com',
          avatar: 'assets/images/avatars/thumb-4.jpg',
          date: '28 April 2019',
          TipoUsuario: 'Doctor',
          status: 'pending',
          checked : false
      },
      {
          id: 5213,
          name: 'Nicole Wyne',
          Email: 'eringGonzales@gmail.com',
          avatar: 'assets/images/avatars/thumb-5.jpg',
          date: '28 April 2019',
          TipoUsuario: 'Doctor',
          status: 'approved',
          checked : false
      },
      {
          id: 5311,
          name: 'Riley Newman',
          Email: 'eringGonzales@gmail.com',
          avatar: 'assets/images/avatars/thumb-6.jpg',
          date: '19 April 2019',
          TipoUsuario: 'Doctor',
          status: 'rejected',
          checked : false
      },

      {
          id: 5390,
          name: 'Pamela Wanda',
          Email: 'eringGonzales@gmail.com',
          avatar: 'assets/images/avatars/thumb-7.jpg',
          date: '16 April 2019',
          TipoUsuario: 'Doctor',
          status: 'pending',
          checked : false
      },

      {
          id: 5291,
          name: 'Victor Terry',
          Email: 'eringGonzales@gmail.com',
          avatar: 'assets/images/avatars/thumb-9.jpg',
          date: '10 April 2019',
          TipoUsuario: 'Doctor',
          status: 'approved',
          checked : false
      },

  ]
  ngOnInit(): void {
   console.log("s")
  }

  sort(sortAttribute: any) {
      this.displayData = this.tableSvc.sort(sortAttribute, this.ordersList);
  }

  currentPageDataChange($event: Array<{ 
      id: number; 
      name: string;
      avatar: string;
      date: string;
      amount: number;
      status: string;
      checked: boolean; 
  }>): void {
      this.displayData = $event;
      this.refreshStatus();
  }

  refreshStatus(): void {
      const allChecked = this.displayData.every(value => value.checked === true);
      const allUnChecked = this.displayData.every(value => !value.checked);
      this.allChecked = allChecked;
      this.indeterminate = (!allChecked) && (!allUnChecked);
  }

  checkAll(value: boolean): void {
      this.displayData.forEach(data => {
          data.checked = value;
      });
      this.refreshStatus();
  }
}

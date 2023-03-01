import { Subject, Observable } from 'rxjs';
import { Injectable } from '@angular/core';

import Swal, { SweetAlertResult } from 'sweetalert2';
import { SweetAlertIcon } from 'sweetalert2';

@Injectable({
  providedIn: 'root',
})
export class MessageSwalService {

  types: string[] = ['error', 'info', 'success', 'warning'];

  constructor() {}

  onShowConfirmMessage( text: string, type : SweetAlertIcon) :  Observable<SweetAlertResult<any>> {
    const obs = new Subject<SweetAlertResult<any>>();

    Swal.fire({
      title: 'CDB Calc',
      text: text,
      icon: type,
      showCancelButton: true,
      cancelButtonText: 'Cencelar',
      confirmButtonColor: '#2884EF',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Sim',
    }).then((result) => {
      obs.next(result)
    });

    return obs;
  }

  ShowMessage( text: string, type : SweetAlertIcon) {
    Swal.fire({
      title: 'CDB Calc',
      text: text,
      icon: type,
      confirmButtonText: 'Ok!',
    });
  }
}

import { Component } from '@angular/core';
import { AdministratorGet, AdministratorAddUpdateRequest, administratorService } from 'services/administrator.service';


@Component({
  selector: 'app-apple',
  templateUrl: './apple.component.html',
  providers: [administratorService],
  styleUrls: ['./apple.component.css']
})
export class AppleComponent {
  //interface

  //declaration
  getAllAdmins: AdministratorGet[] | undefined = undefined;
  getOneAdmin: AdministratorGet | undefined = undefined;


  constructor(private administratorService: administratorService) {
    this.getAll();
  }

  setContent(data: any) {
    this.getAllAdmins = data;
  }

  modify(guid: string, Administrator: AdministratorAddUpdateRequest) {
    this.administratorService.updateOne(guid, Administrator)
      .subscribe();
    this.getModifieable(guid);
  }

  modifySeparateParam(guid: string, name: string | null, email: string | null, authorotyId: string | null) {
    if (!name || !email || !authorotyId) {
      window.prompt("A mezők nem lehetnek üresek!");
      return;
    }
    let Administrator: AdministratorAddUpdateRequest = { originalSendTime: Date().toString(), name: name, email: email, authorotyId: authorotyId };
    this.administratorService.updateOne(guid, Administrator)
      .subscribe();
    this.getModifieable(guid);
  }

  create(Administrator: AdministratorAddUpdateRequest) {
    this.administratorService.addOne(Administrator)
      .subscribe();
  }

  createSeparateParam(name: string | null, email: string | null, authorotyId: string | null) {
    if (!name || !email || !authorotyId) {
      window.prompt("A mezők nem lehetnek üresek!");
      return;
    }
    let Administrator: AdministratorAddUpdateRequest = { originalSendTime: Date().toString(), name: name, email: email, authorotyId: authorotyId };
    this.administratorService.addOne( Administrator)
      .subscribe();
  }

  getModifieable(modifyId: string) {
    if (!modifyId) {

    }
    this.administratorService.getOne(modifyId!)
      .subscribe((data) => {
        this.getOneAdmin = data;
      });
  }
  getAll() {
    this.administratorService.getAll()
      .subscribe((data) => {
        this.getAllAdmins = data;
      });
  }
}

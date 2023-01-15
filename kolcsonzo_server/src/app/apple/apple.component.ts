import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {appleSevice} from 'src/app/apple/apple.service'

interface person {
  card_owner_id: number;
  nev: string;
  email: string;
  neptun_kod?: string;
  torzsszam?: string;
  igazolvany_tipus: string;
  kartyabirtokos_tipusa: string;
  kartyabirtokos_statusz: string;
  kartyaszam: string;
  kartyatipus: string;
  kartyastatusz: string;
  ad_username?: string;
}

@Component({
  selector: 'app-apple',
  templateUrl: './apple.component.html',
  providers: [ appleSevice ],
  styleUrls: ['./apple.component.css']
})
export class AppleComponent {
  //interface

  //declaration
  content:any = "unset";
 
  constructor(private appleServices: appleSevice,private http:HttpClient) {
   }

   setContent(data:any){
    this.content = data;
   }


   person: person = {card_owner_id: 0, nev: "",email: "", neptun_kod: "", torzsszam: "", igazolvany_tipus: "", kartyabirtokos_tipusa: "", kartyabirtokos_statusz: "", kartyaszam: "", kartyatipus: "", kartyastatusz: "", ad_username: ""};

   persons: person[]=[];

  getContent(){
    this.appleServices.getConfig()
      .subscribe((data) => {

        this.content = data;
        // console.log(typeof(this.content));
        // this.persons = [];

        // for(let index =0; index<this.content.length; index++){
        //   const element = this.content[index];
        //   this.persons.push({
        //     card_owner_id: element.card_owner_id,
        //     nev: element.nev,
        //     email: element.email,
        //     neptun_kod: element.neptun_kod,
        //     torzsszam: element.torzsszam,
        //     igazolvany_tipus: element.igazolvany_tipus,
        //     kartyabirtokos_tipusa: element.kartyabirtokos_tipusa,
        //     kartyabirtokos_statusz: element.kartyabirtokos_statusz,
        //     kartyaszam: element.kartyaszam,
        //     kartyatipus: element.kartyatipus,
        //     kartyastatusz: element.kartyastatusz,
        //     ad_username: element.ad_username
        //   })
        // }

        // console.log("finished");

})
    console.log(typeof this.content);
  }
}

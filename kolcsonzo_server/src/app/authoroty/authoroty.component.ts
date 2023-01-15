import { Component, OnInit } from '@angular/core';
import { oktato } from '../models/oktato.model';

@Component({
  selector: 'app-authoroty',
  templateUrl: './authoroty.component.html',
  styleUrls: ['./authoroty.component.css']
})
export class AuthorotyComponent implements OnInit {

  oktatok:oktato[]= [];
  constructor() { }

  ngOnInit(): void {
    this.oktatok.push()
  }

}

import { Component, OnInit } from '@angular/core';
import { Router} from '@angular/router';
import { IUser } from 'src/app/models/interface';

@Component({
  selector: 'pro-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  userActive:string | null = localStorage.getItem("usuario");

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  logoff(){
    localStorage.clear();
    this.router.navigate(['']);
  }

}

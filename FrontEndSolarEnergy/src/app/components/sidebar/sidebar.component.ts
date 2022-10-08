import { Component, OnInit } from '@angular/core';
import { Router} from '@angular/router';

@Component({
  selector: 'pro-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  logoff(){
    localStorage.clear();
    this.router.navigate(['']);
  }

}

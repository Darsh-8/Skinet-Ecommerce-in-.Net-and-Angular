import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-paging-header',
  templateUrl: './paging-header.component.html',
  styleUrls: ['./paging-header.component.scss'] // Corrected property name
})
export class PagingHeaderComponent implements OnInit {
  @Input() pageNumber!: number; // Using non-null assertion operator
  @Input() pageSize!: number; // Using non-null assertion operator
  @Input() totalCount!: number; // Using non-null assertion operator

  constructor() { }

  ngOnInit() {
    // Any initialization logic can go here
  }
}

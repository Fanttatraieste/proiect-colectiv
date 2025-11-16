import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BaseModel } from 'src/app/models/base/BaseModel';
import { IService } from 'src/app/services/interfaces/IService';

@Component({
    selector: 'app-shared-table',
    templateUrl: './shared-table.component.html',
    styleUrls: ['./shared-table.component.css'],
    standalone: false
})
export class SharedTableComponent<T = BaseModel> implements OnInit {
  @Input() service!: IService<T, T>;
  @Input() tableTitle?: string;

  private route = '';

  public tableHeaders: string[] = [];
  public entities: T[] = [];

  constructor(private router: Router) {
    this.route = this.router.url;
  }

  ngOnInit(): void {
    this.refresh();
  }

  public create(): void {
    this.router.navigate([this.route, 'create']);
  }

  public read(id: any): void {
    this.router.navigate([this.route, 'detail', id]);
  }

  public update(id: any): void {
    this.router.navigate([this.route, 'update', id]);
  }

  public delete(id: string): void {
    this.service.delete(id).subscribe(() => {
      console.log('deleted');
      this.refresh();
    });
  }

  private refresh(): void {
    this.service.getAll().subscribe((items: T[]) => {
      this.entities = items;
      if (items && items.length > 0) {
        this.tableHeaders = Object.keys(items[0] as any);
      } else {
        this.tableHeaders = [];
      }
    });
  }
}

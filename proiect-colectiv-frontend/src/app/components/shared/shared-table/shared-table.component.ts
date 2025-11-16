import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { BaseModel } from 'src/app/models/base/BaseModel';
import { IService } from 'src/app/services/interfaces/IService';

@Component({
  selector: 'app-shared-table',
  templateUrl: './shared-table.component.html',
  styleUrls: ['./shared-table.component.css'],
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
})
export class SharedTableComponent<T extends BaseModel> implements OnInit {
  @Input() service!: IService<T, T>;
  @Input() tableTitle?: string;

  private route = '';

  public loading = false;
  public tableHeaders: string[] = [];
  public entities: T[] = [];
  public modalOpen = false;
  public modalMode: 'create' | 'update' | null = null;
  public modalItem: Partial<T> = {};
  public fieldTypes: Record<string, 'number' | 'string'> = {};
  public formControls: { [key: string]: FormControl } = {};

  constructor(private router: Router) {
    this.route = this.router.url;
  }

  ngOnInit(): void {
    this.refresh();
  }

  public create(): void {
    this.modalMode = 'create';
    this.modalItem = {} as Partial<T>;
    this.modalOpen = true;
  }

  public read(id: any): void {
    this.router.navigate([this.route, 'detail', id]);
  }

  public update(id: any): void {
    const item = this.entities.find(e => (e as any).id === id);
    if (item) {
      this.modalMode = 'update';
      this.modalItem = { ...(item as any) } as Partial<T>;
      this.modalOpen = true;
    }
  }

  public delete(id: string): void {
    this.service.delete(id).subscribe(() => {
      console.log('deleted');
      this.refresh();
    });
  }

  public getPropertyValue(item: T, key: string): any {
    return (item as any)[key];
  }

  public cancelModal(): void {
    this.modalOpen = false;
    this.modalMode = null;
    this.modalItem = {};
  }

  public saveModal(): void {
    this.tableHeaders.forEach(header => {
      (this.modalItem as any)[header] = this.formControls[header].value;
    });

    if (this.modalMode === 'create') {
      this.service.create(this.modalItem as T).subscribe(res => {
        this.refresh();
        this.cancelModal();
      });
    } else if (this.modalMode === 'update') {
      this.service.update(this.modalItem as T).subscribe(res => {
        this.refresh();
        this.cancelModal();
      });
    }
  }

  private refresh(): void {
    this.loading = true;
    this.service.getAll().subscribe((items: T[]) => {
      this.entities = items;
      this.loading = false;

      if (items && items.length > 0) {
        this.tableHeaders = Object.keys(items[0] as any);

        this.fieldTypes = {};
        const first = items[0] as any;
        this.tableHeaders.forEach(h => {
          const val = first[h];
          this.fieldTypes[h] = typeof val === 'string' ? 'string' : 'number';
        });

        this.tableHeaders.forEach(header => {
          this.formControls[header] = new FormControl(
            this.getModalValue(header)
          );
        });
      } else {
        this.tableHeaders = [];
      }
    });
  }

  public getModalValue(header: string): any {
    return (this.modalItem as any)[header] || (this.entities[0] as any)[header];
  }

  public setModalValue(header: string, value: any): void {
    (this.modalItem as any)[header] = value;
  }

  public getFormControl(header: string): FormControl {
    return this.formControls[header];
  }
}

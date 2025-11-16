import { Observable } from 'rxjs';
import BaseService from '../base/BaseService';
import { IService } from '../interfaces/IService';
import { SPECIALIZATION_ENDPOINT } from '../utility/constants';
import { SpecializationModel } from 'src/app/models/specialisations/SpecializationModel';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class SpecializationService
  extends BaseService
  implements IService<SpecializationModel, SpecializationModel>
{
  constructor(http: HttpClient) {
    super(SPECIALIZATION_ENDPOINT, http);
  }

  public getById(id: string): Observable<SpecializationModel> {
    return this.http.get<SpecializationModel>(
      `${this.baseUrl}/${this.baseEndpoint}/${id}`
    );
  }

  public getAll(): Observable<SpecializationModel[]> {
    throw new Error('Method not implemented.');
  }

  public create(data: SpecializationModel): Observable<SpecializationModel> {
    throw new Error('Method not implemented.');
  }

  public update(data: SpecializationModel): Observable<SpecializationModel> {
    throw new Error('Method not implemented.');
  }

  public delete(id: string): Observable<void> {
    throw new Error('Method not implemented.');
  }
}

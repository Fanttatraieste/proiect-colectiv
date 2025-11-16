import { Observable } from 'rxjs';
import BaseService from '../base/BaseService';
import { IService } from '../interfaces/IService';
import { SpecialisationModel } from 'src/app/models/specialisations/SpecialisationModel';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SPECIALIZATION_ENDPOINT } from 'src/app/utility/constants';

@Injectable({ providedIn: 'root' })
export class SpecialisationService
  extends BaseService
  implements IService<SpecialisationModel, SpecialisationModel>
{
  constructor(http: HttpClient) {
    super(SPECIALIZATION_ENDPOINT, http);
  }

  public getById(id: string): Observable<SpecialisationModel> {
    return this.http.get<SpecialisationModel>(
      `${this.baseUrl}/${this.baseEndpoint}/${id}`
    );
  }

  public getAll(): Observable<SpecialisationModel[]> {
    return this.http.get<SpecialisationModel[]>(
      `${this.baseUrl}/${this.baseEndpoint}`
    );
  }

  public create(data: SpecialisationModel): Observable<SpecialisationModel> {
    return this.http.post<SpecialisationModel>(
      `${this.baseUrl}/${this.baseEndpoint}`,
      data
    );
  }

  public update(data: SpecialisationModel): Observable<SpecialisationModel> {
    throw new Error('Method not implemented.');
  }

  public delete(id: string): Observable<void> {
    throw new Error('Method not implemented.');
  }
}

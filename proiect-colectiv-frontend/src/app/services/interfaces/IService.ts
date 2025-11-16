import { Observable } from 'rxjs';

export interface IService<T, P> {
  getById(id: string): Observable<T>;
  getAll(): Observable<P[]>;
  create(data: T): Observable<T>;
  update(data: T): Observable<T>;
  delete(id: string): Observable<void>;
}

import { HttpClient } from '@angular/common/http';

export default abstract class BaseService {
  protected baseUrl = 'http://localhost:3000/api'; // this will be replaced with environment variables later
  protected baseEndpoint: string;
  protected http: HttpClient;

  constructor(baseEndpoint: string, http: HttpClient) {
    this.baseEndpoint = baseEndpoint;
    this.http = http;
  }
}

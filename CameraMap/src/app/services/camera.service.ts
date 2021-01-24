import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { baseURL } from '../shared/baseurl';
import { CameraData } from '../shared/CameraData';


@Injectable({
  providedIn: 'root'
})

export class CameraService {

  cameras3: CameraData[] = [];
  cameras35: CameraData[] = [];
  cameras5: CameraData[] = [];
  cameras4: CameraData[] = [];
  camerasall: CameraData[] = [];

  constructor(private http: HttpClient) { }

  getCameraData() {
    return this.http.get<CameraData[]>(baseURL + 'cameraData').subscribe(data => this.parseData(data));
  }

  private parseData(data: CameraData[]) {
    for (let i = 0; i < data.length; i++) {
      this.camerasall.push(data[i]);
      if (data[i].number % 3 == 0 && data[i].number % 5 == 0) {
        this.cameras35.push(data[i]);
        this.cameras3.push(data[i]);
        this.cameras5.push(data[i]);
        continue;
      }
      if (data[i].number % 3 == 0) {
        this.cameras3.push(data[i]);
        continue;
      }
      if (data[i].number % 5 == 0) {
        this.cameras5.push(data[i]);
        continue;
      }
      if (data[i].number % 3 != 0 && data[i].number % 5 != 0) {
        this.cameras4.push(data[i]);
        continue;
      }
    }
  }
}

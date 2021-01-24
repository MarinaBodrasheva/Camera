import { Component, OnInit, Inject, Renderer2 } from '@angular/core';
import { } from 'googlemaps';
import { CameraService } from "../services/camera.service"
import { CameraData } from '../shared/cameradata';
import { DOCUMENT } from '@angular/common';


@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})


export class MapComponent implements OnInit {

  cameras3: CameraData[];
  cameras5: CameraData[];
  cameras35: CameraData[];
  cameras4: CameraData[];


  constructor(@Inject(DOCUMENT) private document: Document,
    private renderer2: Renderer2, private service: CameraService,) { }

  ngOnInit() {
    this.loadData();

    const url = 'https://maps.googleapis.com/maps/api/js?key=AIzaSyBFPx0ttP836exrhUtFPA83npHmludQZLM';

    this.loadScript(url).then(() => {
      this.loadMap()
    });
  }

  private loadData() {
    this.service.getCameraData();
    this.cameras3 = this.service.cameras3;
    this.cameras35 = this.service.cameras35;
    this.cameras5 = this.service.cameras5;
    this.cameras4 = this.service.cameras4;
  }
  private loadMap() {

    if (this.service.camerasall[0]) {
      const center: google.maps.LatLngLiteral = { lat: this.service.camerasall[0].latitude, lng: this.service.camerasall[0].longitude };
      let map = new google.maps.Map(document.getElementById("map") as HTMLElement, {
        center,
        zoom: 16
      });

      for (const data of this.service.camerasall) {
        var marker = new google.maps.Marker({
          position: { lat: data.latitude, lng: data.longitude },
          map: map,
          title: 'cameras'
        });
      }
    }
  }

  private loadScript(url) {
    return new Promise((resolve, reject) => {
      const script = this.renderer2.createElement('script');
      script.type = 'text/javascript';
      script.src = url;
      script.text = ``;
      script.onload = resolve;
      script.onerror = reject;
      this.renderer2.appendChild(this.document.head, script);
    })
  }
}
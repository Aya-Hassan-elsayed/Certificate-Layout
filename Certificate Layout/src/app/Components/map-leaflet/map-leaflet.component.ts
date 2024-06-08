import { Component, OnInit } from '@angular/core';
import * as L from 'leaflet';
import { ICertificateLayout } from 'src/app/Interfaces/icertificate-layout';
import { CertificateServicesService } from 'src/app/Services/certificate-services.service';

@Component({
  selector: 'app-map-leaflet',
  templateUrl: './map-leaflet.component.html',
  styleUrls: ['./map-leaflet.component.scss']
})
export class MapLeafletComponent  implements OnInit {
  Data: ICertificateLayout = {} as ICertificateLayout;
  map: any;

  constructor(private _CertificateServicesService : CertificateServicesService){}
  ngOnInit(): void {
    this.Data = this._CertificateServicesService.Data
    this.initializeMap();

  }



  initializeMap(): void {
    // Create a Leaflet map centered at latitude 33.00 and longitude 20.5, with an initial zoom level of 10
    var map = L.map('map').setView([33.00, 20.5], 10);

    // Add a Google Maps tile layer with Arabic language
    L.tileLayer('http://{s}.google.com/vt/lyrs=s&x={x}&y={y}&z={z}', {
        maxZoom: 20,
        subdomains: ['mt0', 'mt1', 'mt2', 'mt3']
    }).addTo(map).bringToBack();

    // Parse the GeoJSON data (assuming `this.Data.geom` is a variable containing valid GeoJSON data)
    var geoJsonData = JSON.parse(this.Data.geom);
    var pattern = '<svg xmlns="http://www.w3.org/2000/svg" width="8" height="8" viewBox="0 0 8 8">' +
    '<rect width="8" height="8" fill="black"/>' +
    '<path d="M0,4 8,4" stroke="red" stroke-width="2"/>' +
 '</svg>';

    var geoJsonLayer = L.geoJSON(geoJsonData, {
        onEachFeature: function (feature, layer) {
        },
        style: {
            fillColor: "black",
            color: "red", // Red color for edges
            weight: 1 ,// Width of the edges,
        }
    }).addTo(map);

    map.fitBounds(geoJsonLayer.getBounds());
}
}
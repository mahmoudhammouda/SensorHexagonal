import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  //public forecasts: WeatherForecast[] = [];

  public meseaureHistories: Measure[] = [];
  public state: State = { sourceId: 0, indicatorId: 0, value: '' };;



  /*constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'api/weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }*/


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Measure[]>(baseUrl + 'api/measures?historyCount=15').subscribe(result => {
      this.meseaureHistories = result;
    }, error => console.error(error));


    http.get<State>(baseUrl + 'api/states/source/0/indicator/0').subscribe(result => {
      this.state = result;
    }, error => console.error(error));




  }
}

interface Measure {
  id:number;
  indicatorId:number;
  sourceId:number;
  value: number;
  unity:string;
  observationTime: string;
}

interface State {
  sourceId: number;
  indicatorId: number;
  value: string;
}

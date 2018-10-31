import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { compare } from 'fast-json-patch';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
    const patch = compare(this.previousFormModel(), this.prepareFormModel());
    http.patch<any>(baseUrl + 'api/SampleData/UpdateModelWithJsonPatch/1', patch).subscribe(result => {
      console.log(result);
    }, error => console.error(error));;

    http.patch<any>(baseUrl + 'api/SampleData/UpdateModelWithOutJsonPatch/1', this.prepareFormModel()).subscribe(result => {
      console.log(result);
    }, error => console.error(error));;

  }
  previousFormModel() {
    //const formModel = this.testForm.value;

    const retVal: any = {
      title: "t2" as string,
      comment: "c2" as string,
      qualified: false as boolean
    };

    return retVal;
  }

  prepareFormModel() {
    //const formModel = this.testForm.value;

    const retVal: any = {
      title: "t1" as string,
      comment: "c1" as string,
      qualified: true as boolean
    };

    return retVal;
  }
}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

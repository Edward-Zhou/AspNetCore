import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { compare } from 'fast-json-patch';
import { calcBindingFlags } from '@angular/core/src/view/util';
import { Observable } from 'rxjs/Observable';
import { catchError, map, tap } from 'rxjs/operators';
@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  private http: HttpClient;
  private baseUrl: string;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.http = http;
    this.baseUrl = baseUrl;
    var email = "test@outlook.com";
    var password = "pwd";
    http.post<LoginUser>(this.baseUrl + "api/SampleData/Authenticate", {
      email,
      password
    }).subscribe(result => {

      });

    let subDirectory: string = "folder1/folder2/folder3";
    let id: number = 6;
    this.http.get(this.baseUrl + 'api/SampleData/' + id + "/")
      .subscribe(result => { });
    //this.http.get(this.baseUrl + 'api/SampleData/' + id + "?subDirectotry=" + subDirectory)
    //  .subscribe(result => { });

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
    this.changeActive();
    this.LoadData();
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

  changeActive() {
      var data = new IUser();
      data.id = 1;
      data.name = "Tom";
    this.Active(data).subscribe(result => {
      console.log(result);
    });
    }
  public Active(user: IUser): Observable<IUser>{
    console.log("we get data from component");
    console.log(user);
    return this.http.post<IUser>(this.baseUrl + 'api/SampleData/Active', user, { headers: null })
      .pipe(tap((user: IUser) => console.log(`Active user w/ email=${user}`)))
      ;
    //this.http.post<IUser>(this.baseUrl + 'api/SampleData/Active', user).subscribe(result => {
    //  console.log(result);
    //}, error => console.error(error));
  }

  public getArtistsList(): Observable<Artist[]> {
    return this.http.get<Artist[]>(this.baseUrl +
      'api/SAMPLEDATA/ListArtists');
  }

  public LoadData() {
    this.getArtistsList().subscribe((d) => {
      console.log("this is loaddata");
      console.log(d);
      var artists: Array<Artist>;
      artists = d;
      console.log(artists);
    });
  }

}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

class IUser {
  id: number;
  name: string;
}

class LoginUser {
  email: string;
  password: string;
}

class Artist {
  id: number;
  name: string;
  date_of_birth: Date;
  all_songs: Song[];
  greatest_hits: Song[];
  image_url: string;
  band_members: BandMember[];
}
export class Song {
  id: number;
  name: string;
  lyrics: string;
  date_released: Date;
}
export class BandMember {
  id: number;
  member: string;
} 

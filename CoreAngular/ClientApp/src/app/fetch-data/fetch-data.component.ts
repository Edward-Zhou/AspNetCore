import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { compare } from 'fast-json-patch';
import { calcBindingFlags } from '@angular/core/src/view/util';
import { Observable } from 'rxjs/Observable';
import { catchError, map, tap } from 'rxjs/operators';
import axios, { AxiosInstance } from 'axios';
import * as qs from 'qs';
@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  private axiosClient: AxiosInstance;
  public forecasts: WeatherForecast[];
  private http: HttpClient;
  private baseUrl: string;
  private apiURL = this.baseUrl + "api/My/Generate";
  private shortener: Shortn //= { url:""};
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.axiosClient = axios.create({
      timeout: 3000,
      headers: {
        "X-Initialized-At": Date.now().toString()
      },
      paramsSerializer: function (params) {
        return qs.stringify(params, { encode: true });
      }
    });
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
    this.RequestShortn();

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
  selectedFile : File = null;
  onSelectedFile(e){
    this.selectedFile = e.target.files[0];
  }
  linkItem(){
    var formData = new FormData();
    formData.append("file", this.selectedFile, this.selectedFile.name)
    this.LinkItemToIcon(1, formData).subscribe(
      r => console.log(r),
      err => console.log(err)
    )
  }
  LinkItemToIcon(id, formData) {
    return this.http.put(`api/SampleData/LinkItemToIcon/` + id, formData);
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
  public getItems() {
    axios.get(this.baseUrl + 'api/SampleData/GetItems', {
      params: {
        filter: {
          isActive: true,
          name: 'test123'
        },
        pagination: {
          page: 5,
          itemsPerPage: 10
        }
      }
    })
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
  public RequestShortn() {
    this.shortenUrl2(this.apiURL).toPromise()
      .then(res => this.shortener = res as Shortn);
  }
  shortenUrl2(url: string): Observable<Shortn> {
    //alert("desde servicio: " + url);
    let shortener = { Url: url };
    return this.http.post<Shortn>("https://localhost:44320/api/My/Generate", shortener);
  }

}
export interface Shortn {

  url: string;
}
interface UploadFile {
  id: number;
  file: File;
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

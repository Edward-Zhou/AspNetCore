import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpHeaders, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  public values: object[];

  User: User = new User();
  constructor(private http: HttpClient) {
    
  }
  Add(regForm: NgForm) {
    this.User = new User();
    this.User.UserName = regForm.value.UserName;

    this.AddUser(this.User).subscribe(res => {
      alert("User Added successfully");
    }
    )
  }

  AddUser(user: User) {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      UserName: user.UserName
    }

    console.log("User: " + body.UserName);

    return this.http.post<User>('/api/values', body, { headers });
  } 
}

export class User {
  public UserName: string;
}

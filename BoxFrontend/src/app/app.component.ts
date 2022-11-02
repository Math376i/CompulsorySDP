import {Component, OnInit} from '@angular/core';
import {HttpService} from "../services/http.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  boxName: string = "";
  boxes: any;
  boxHeight: number = 0;
  boxLength: number = 0;
  boxWidth: number = 0;
  boxId: number = -1;



  constructor(private http: HttpService) {

  }

  async ngOnInit() {
    const boxes = await this.http.getBoxes();
    this.boxes = boxes;
  }

  async createBox(){
    let dto = {
      name: this.boxName,
      height: this.boxHeight,
      length : this.boxLength,
      width: this.boxWidth
    }
    const result = await this.http.createBox(dto)
    this.boxes.push(result)
  }

  deleteBox(id: any) {
    this.http.deleteBox(id);
  }
}

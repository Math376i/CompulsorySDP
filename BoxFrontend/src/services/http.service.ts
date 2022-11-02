import { Injectable } from '@angular/core';
import axios from "axios";

export const customAxios = axios.create({baseURL: 'http://localhost:5104/'})

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }

    async getBoxes(){
    const httpResponse = await customAxios.get<any>('box/GetAllBoxes')
      return httpResponse.data;
  }

  async createBox(dto: { name: string, height: number, length: number, width: number }) {
    const httpresult = await customAxios.post('box', dto);
    return httpresult.data;
  }

  async deleteBox(id: any) {
    const httpResult = await customAxios.delete('box/'+id)
    return httpResult.data;
  }
}

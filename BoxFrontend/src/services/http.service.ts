import { Injectable } from '@angular/core';
import axios from "axios";

export const customAxios = axios.create({baseURL: 'http://http://localhost:4200/'})

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }

    async getProducts(){
    const httpResponse = await customAxios.get('product')
    return httpResponse.data;
  }

}

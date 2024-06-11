import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TApiResponse } from '@utilities/interfaces';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { environment } from '../../environments/environment'; // Adjust the import path if needed

@Injectable({
  providedIn: 'root',
})
export class ApiHelperService {
  private baseUrl = environment.baseApiUrl; // Ensure this is set correctly in your environment file

  constructor(
    private readonly http: HttpClient,
    private readonly loaderService: NgxUiLoaderService
  ) {}

  private get apiHeaders() {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      Accept: 'application/json',
    });
  }

  private buildUrl(url: string): string {
    if (!url.startsWith('/')) {
      url = `/${url}`;
    }
    return `${this.baseUrl}${url}`;
  }

  async get<T>(url: string, params?: Record<string, string | number | boolean>): Promise<TApiResponse<T>> {
    try {
      const fullUrl = this.buildUrl(url);
      console.log(`Making GET request to: ${fullUrl}`);
      this.loaderService.start();
      const response = await this.http
        .get<T>(fullUrl, {
          headers: this.apiHeaders,
          params,
        })
        .toPromise();

      setTimeout(() => {
        this.loaderService.stop();
      }, 500);
      return {
        isSuccess: true,
        data: response,
        statusCode: 200,
      };
    } catch (error: any) {
      console.error('Error in GET request:', error);
      setTimeout(() => {
        this.loaderService.stop();
      }, 500);
      return {
        isSuccess: false,
        message: error?.error?.message ?? 'Unknown error occurred',
        statusCode: error?.status,
        stackTrace: error?.error,
      };
    }
  }

  async post<T>(url: string, body?: unknown, params?: Record<string, string | number | boolean>): Promise<TApiResponse<T>> {
    try {
      const fullUrl = this.buildUrl(url);
      console.log(`Making POST request to: ${fullUrl}`);
      this.loaderService.start();
      const response = await this.http
        .post<T>(fullUrl, body, {
          headers: this.apiHeaders,
          params,
        })
        .toPromise();

      setTimeout(() => {
        this.loaderService.stop();
      }, 500);

      return {
        isSuccess: true,
        data: response,
        statusCode: 200,
      };
    } catch (error: any) {
      console.error('Error in POST request:', error);
      setTimeout(() => {
        this.loaderService.stop();
      }, 500);

      return {
        isSuccess: false,
        message: error?.error?.message ?? 'Unknown error occurred',
        statusCode: error?.status,
        stackTrace: error?.error,
      };
    }
  }

  async postFiles<T>(url: string, body?: unknown, params?: Record<string, string | number | boolean>): Promise<TApiResponse<T>> {
    try {
      const fullUrl = this.buildUrl(url);
      console.log(`Making POST FILES request to: ${fullUrl}`);
      this.loaderService.start();
      const response = await this.http.post<T>(fullUrl, body, { params }).toPromise();

      setTimeout(() => {
        this.loaderService.stop();
      }, 500);
      return {
        isSuccess: true,
        data: response,
        statusCode: 200,
      };
    } catch (error: any) {
      console.error('Error in POST FILES request:', error);
      setTimeout(() => {
        this.loaderService.stop();
      }, 500);
      return {
        isSuccess: false,
        message: error?.error?.message ?? 'Unknown error occurred',
        statusCode: error?.status,
        stackTrace: error?.error,
      };
    }
  }

  async put<T>(url: string, body?: unknown, params?: Record<string, string | number | boolean>): Promise<TApiResponse<T>> {
    try {
      const fullUrl = this.buildUrl(url);
      console.log(`Making PUT request to: ${fullUrl}`);
      this.loaderService.start();
      const response = await this.http
        .put<T>(fullUrl, body, {
          headers: this.apiHeaders,
          params,
        })
        .toPromise();

      setTimeout(() => {
        this.loaderService.stop();
      }, 500);
      return {
        isSuccess: true,
        data: response,
        statusCode: 200,
      };
    } catch (error: any) {
      console.error('Error in PUT request:', error);
      setTimeout(() => {
        this.loaderService.stop();
      }, 500);
      return {
        isSuccess: false,
        message: error?.error?.message ?? 'Unknown error occurred',
        statusCode: error?.status,
        stackTrace: error?.error,
      };
    }
  }

  async delete<T>(url: string, params?: Record<string, string | number | boolean>): Promise<TApiResponse<T>> {
    try {
      const fullUrl = this.buildUrl(url);
      console.log(`Making DELETE request to: ${fullUrl}`);
      this.loaderService.start();
      const response = await this.http
        .delete<T>(fullUrl, {
          headers: this.apiHeaders,
          params,
        })
        .toPromise();

      setTimeout(() => {
        this.loaderService.stop();
      }, 500);
      return {
        isSuccess: true,
        data: response,
        statusCode: 200,
      };
    } catch (error: any) {
      console.error('Error in DELETE request:', error);
      setTimeout(() => {
        this.loaderService.stop();
      }, 500);
      return {
        isSuccess: false,
        message: error?.error?.message ?? 'Unknown error occurred',
        statusCode: error?.status,
        stackTrace: error?.error,
      };
    }
  }
}

/* eslint-disable @typescript-eslint/no-explicit-any */
export interface IObject {
 [key: string]: any;
}

export interface IActionResult {
 isSuccess: boolean;
 message?: string;
 statusCode?: number;
 data?: IObject[] | IObject | any;
 errors?: IObject[] | IObject | any | Record<string, string[]>;
}

export interface IHeaders {
 headers: {
  Authorization?: string;
  'Content-type'?: string;
  Accept?: string;
  Cookie?: string;
 };
 params?: any;
}

export type TApiResponse<T = unknown> = {
 isSuccess: boolean;
 message?: string;
 statusCode?: number;
 data?: T;
 stackTrace?: IObject[] | IObject | any | Record<string, string[]>;
};

export interface ISelect {
 id: number | string;
 name: string;
 description?: string;
}

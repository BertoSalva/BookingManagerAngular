export interface IBookingCreate {
  requestID: number;
  childID: number;
  psychologistID: number;
  preferredDateTime: Date;
  status: string;
  comments?: string;
}

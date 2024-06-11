export interface IBookingList {
  requestID: number;
  parentID: number;
  childID: number;
  psychologistID: number;
  requestDate: string;
  preferredDateTime: string;
  status: string;
  comments: string;
  parent: {
    parentID: number;
    parentName: string;
  };
  child: {
    childID: number;
    childName: string;
  };
  psychologist: {
    psychologistID: number;
    psychologistName: string;
  };
}

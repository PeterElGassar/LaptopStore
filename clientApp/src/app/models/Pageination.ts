import { IProduct } from './Product';

export interface IPageination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: IProduct[];
}
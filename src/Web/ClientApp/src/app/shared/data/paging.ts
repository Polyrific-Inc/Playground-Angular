export interface Paging<T> {
  items: T[];
  totalCount: number;
  page: number;
  pageSize: number;
}

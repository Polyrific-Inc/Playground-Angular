/**
 * An object used to get page information from the server
 */
export class GridPaging {
  // The number of elements in the page
  pageSize: number;
  // The total number of elements
  totalElements = 0;
  // The current page number
  pageNumber = 1;
  // For sorting
  orderBy = "";
  // For filter
  filter = "";
  // sorting direction, default value will always ascending, set true for descending
  isDescending = false;
}


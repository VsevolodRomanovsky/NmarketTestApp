  export interface Region {
    id: string;
    regionId: number;
    name: string;
    districts?: any;
  }

  export interface District {
    id: string;
    districtId: number;
    name: string;
    buildings?: any;
    regionId: number;
    region: Region;
  }

  export interface Building {
    id: string;
    buildingId: number;
    name: string;
    queue: number;
    housing: string;
    districtId: number;
    flats?: any;
    district: District;
  }

  export interface Flat {
    id: string;
    flatId: number;
    roomsCount: number;
    totalArea: number;
    kitchenArea: number;
    floor: number;
    buildingId: number;
    price: number;
    building: Building;
  }

  export interface IResult {
    results: Flat[];
    currentPage: number;
    pageCount: number;
    pageSize: number;
    rowCount: number;
    firstRowOnPage: number;
    lastRowOnPage: number;
  }

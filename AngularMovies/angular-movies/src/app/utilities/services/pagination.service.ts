import {Injectable} from "@angular/core"
import { Subject } from "rxjs";
import { Pagination } from "src/app/model/pagination.model"

@Injectable({
    providedIn:"root"
})
export class PaginationService{
    private pagedData : Pagination = {page: 1, pageSize: 10, totalAmountOfRecords: 10}; //initial Value
    public pagedDataChanged: Subject<Pagination> = new Subject<Pagination>();

    public getPagedData(){
        return this.pagedData;
        
    }

    public setPagedData(_pagedData: Pagination){
        this.pagedData = _pagedData;
        
        this.pagedDataChanged.next(this.pagedData);
    }

    public updatePagedData(_page: number, _pageSize: number){
        this.pagedData.page = _page;
        this.pagedData.pageSize = _pageSize;
        this.pagedDataChanged.next(this.pagedData);
        
    } 
}
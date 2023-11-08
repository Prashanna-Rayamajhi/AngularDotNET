

export interface IMultipleSelector{
    _id: number,
    value: string,
    isChecked: boolean
}

export class MultipleSelectorVM implements IMultipleSelector{
    _id: number;
    value: string;
    isChecked: boolean;

    constructor(_id: number, value: string, isChecked: boolean){
        this._id = _id;
        this.value = value;
        this.isChecked = isChecked;
    }



    

}


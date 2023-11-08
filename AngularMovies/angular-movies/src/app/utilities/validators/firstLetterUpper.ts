import {ValidatorFn, AbstractControl} from "@angular/forms";

export function FirstLetterUpper(): ValidatorFn | any{
  return (control: AbstractControl) => {
    const value = <string>control.value;
    if(!value) return;
    if(value.length == 0) return;

    const firstLetter = value[0];
    if(firstLetter !== firstLetter.toUpperCase()){
        return {
            FirstLetterUpper:{
                message: 'The first letter must be upper case'
            }
        }
    }
    return;
  }
}


export function toBase64(file : File): Promise<string>  {
    return new Promise((resolve, reject)=>{
        const fileReader: FileReader = new FileReader();
        fileReader.readAsDataURL(file);
        fileReader.onload= ()=>{resolve(<string>fileReader.result)};
        fileReader.onerror = (error)=>{reject(error)};
    });
};

export function parseWebApiErrors(response: any): string[]{
    const result: string[] = [];

    if(response.errro){
        if(typeof(response.error) === 'string'){
            result.push(response.error);
        }else if(Array.isArray(response.error)){
            response.error.forEach((value: { description: string; }) => result.push(value.description));
        }
        else{
            const mapErrors = response.error.errors;
            const entries = Object.entries(mapErrors);
            entries.forEach((arr: any[]) => {
                const field = arr[0];
                arr[1].forEach((errorMessage: any) =>{
                    result.push(`${field}: ${errorMessage}`);
                })
            })
        }
    }

    return result;
}

export function formatDateFormData(date: Date){
    date = new Date(date);
    const format  = new Intl.DateTimeFormat('en', {
        year:  'numeric',
        month: '2-digit',
        day: '2-digit'
    });
    const [
        {value: month},,
        {value: day},,
        {value: year}
    ] = format.formatToParts(date);

    return `${year}-${month}-${day}`;
}
export interface IAPIResponse
{
    message:string | null;
    status:boolean;
    validateErrors:string[] | null;
}
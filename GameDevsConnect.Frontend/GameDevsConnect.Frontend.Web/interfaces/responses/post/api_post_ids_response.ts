import { IAPIResponse } from "../api_response";

export interface IAPIPostIdsResponse extends IAPIResponse
{
    ids:string[]
}
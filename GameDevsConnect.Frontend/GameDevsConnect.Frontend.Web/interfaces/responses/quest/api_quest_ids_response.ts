import { IAPIResponse } from "../api_response";

export interface IAPIQuestIdsResponse extends IAPIResponse
{
    ids:string[];
}
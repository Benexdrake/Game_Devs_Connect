import { ITag } from "@/interfaces/tag";
import { IAPIResponse } from "../api_response";

export interface IAPITagsResponse extends IAPIResponse
{
    tags:ITag[];
}
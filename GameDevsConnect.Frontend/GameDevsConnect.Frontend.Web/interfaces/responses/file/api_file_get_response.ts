import { IFile } from "@/interfaces/file";
import { IAPIResponse } from "../api_response";

export interface IAPIFileGetResponse extends IAPIResponse
{
    file:IFile
}
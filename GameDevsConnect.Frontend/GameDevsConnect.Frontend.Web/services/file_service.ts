import { IFile } from "@/interfaces/file"
import { IAPIFileAddResponse } from "@/interfaces/responses/file/api_file_add_response"
import { IAPIFileGetResponse } from "@/interfaces/responses/file/api_file_get_response"
import { getUrl } from "@/lib/api"
import axios from "axios"

const url = getUrl('json','file')

export const getFileByIdAsync = async (fileId:string) =>
{
    return await axios.get<IAPIFileGetResponse>(`${url}/${fileId}`).then(x => x.data);
}

export const addFileAsync = async (file:IFile) =>
{
    return await axios.post<IAPIFileAddResponse>(`${url}/add`, file).then(x => x.data);
}
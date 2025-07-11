import { IFile } from "@/interfaces/file"
import { IAPIFileAddResponse } from "@/interfaces/responses/file/api_file_add_response"
import { IAPIFileGetResponse } from "@/interfaces/responses/file/api_file_get_response"
import { url } from "@/lib/api"
import axios from "axios"




const getUrl = url('get','file')
const postUrl = url('post','file')
const putUrl = url('put','file')
const deleteUrl = url('delete','file')



export const getFileByIdAsync = async (fileId:string) =>
{
    return await axios.get<IAPIFileGetResponse>(`${getUrl}/${fileId}`).then(x => x.data);
}

export const addFileAsync = async (file:IFile) =>
{
    return await axios.post<IAPIFileAddResponse>(`${postUrl}/add`, file).then(x => x.data);
}
import { IUpsertPostRequest } from "@/interfaces/requests/post/api_add_post_request"
import { IAPIResponse } from "@/interfaces/responses/api_response"
import { IAPIPostAddResponse } from "@/interfaces/responses/post/api_post_add_response"
import { IAPIPostIdsResponse } from "@/interfaces/responses/post/api_post_ids_response"
import { IAPIPostResponse } from "@/interfaces/responses/post/api_post_response"
import { getUrl } from "@/lib/api"
import axios from "axios"

const url = getUrl('json','post')

export const getPostIdsAsync = async (page:number=1, pageSize:number=10, searchTerm:string='', parentId:string='') =>
{   
    return await axios.get<IAPIPostIdsResponse>(`${url}?page=${page}&pageSize=${pageSize}&parentId=${parentId}&searchTerm=${searchTerm}`).then(x => x.data)
}

export const getPostAsync = async (id:string) =>
{
    return await axios.get<IAPIPostResponse>(`${url}/full/${id}`).then(x => x.data)
}

export const getPostIdsByUserIdAsync = async (id:string='') =>
{   
    return await axios.get<IAPIPostIdsResponse>(`${url}/user/${id}`).then(x => x.data)
}

export const addPostAsync = async (addPost:IUpsertPostRequest) =>
{
    return await axios.post<IAPIPostAddResponse>(`${url}/add`, addPost).then(x => x.data)
}

export const updatePost = async (updatePost:IUpsertPostRequest) =>
{
    return await axios.put<IAPIResponse>(`${url}/update`, updatePost).then(x => x.data)
}

export const deletePost = async (id:string) =>
{
    return await axios.delete<IAPIResponse>(`${url}/delete/${id}`)
}
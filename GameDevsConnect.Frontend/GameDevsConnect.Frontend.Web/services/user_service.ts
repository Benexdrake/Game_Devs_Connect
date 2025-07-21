import { IAPIResponse } from "@/interfaces/responses/api_response";
import { IAPIUserIdResponse } from "@/interfaces/responses/user/api_user_id_response";
import { IAPIUserResponse } from "@/interfaces/responses/user/api_user_response";
import { IUser } from "@/interfaces/user";
import { url } from "@/lib/api";
import axios from "axios";

const getUrl = url('get','user')
const postUrl = url('post','user')
const putUrl = url('put','user')
const deleteUrl = url('delete','user')

export const getUserAsync = async (id:string) =>
{
    return await axios.get<IAPIUserResponse>(`${getUrl}/${id}`).then(x => x.data)
}

export const addUserAsync = async (user:IUser) =>
{
    return await axios.post<IAPIUserIdResponse>(`${postUrl}/add`, user).then(x => x.data)
}

export const updateUserAsync = async (user:IUser) =>
{
    return await axios.put<IAPIResponse>(`${putUrl}/update`, user).then(x => x.data)
}

export const deleteUserAsync = async (id:string) =>
{
    return await axios.delete<IAPIResponse>(`${deleteUrl}/delete/${id}`).then(x => x.data)
}

export const existUser = async (id:string) =>
{
    return await axios.get<IAPIUserIdResponse>(`${getUrl}/exist/${id}`).then(x => x.data)
}
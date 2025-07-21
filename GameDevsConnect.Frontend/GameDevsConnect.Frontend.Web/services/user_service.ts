import { IAPIResponse } from "@/interfaces/responses/api_response";
import { IAPIUserIdResponse } from "@/interfaces/responses/user/api_user_id_response";
import { IAPIUserResponse } from "@/interfaces/responses/user/api_user_response";
import { IUser } from "@/interfaces/user";
import { getUrl } from "@/lib/api"

import axios from "axios";

const url = getUrl('json','user')

export const getUserAsync = async (id:string) =>
{
    return await axios.get<IAPIUserResponse>(`${url}/${id}`).then(x => x.data)
}

export const addUserAsync = async (user:IUser) =>
{
    return await axios.post<IAPIUserIdResponse>(`${url}/add`, user).then(x => x.data)
}

export const updateUserAsync = async (user:IUser) =>
{
    return await axios.put<IAPIResponse>(`${url}/update`, user).then(x => x.data)
}

export const deleteUserAsync = async (id:string) =>
{
    return await axios.delete<IAPIResponse>(`${url}/delete/${id}`).then(x => x.data)
}

export const existUser = async (id:string) =>
{
    return await axios.get<IAPIUserIdResponse>(`${url}/exist/${id}`).then(x => x.data)
}
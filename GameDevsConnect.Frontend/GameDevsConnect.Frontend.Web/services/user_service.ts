import { IAPIResponse } from "@/interfaces/responses/api_response";
import { IAPIUserResponse } from "@/interfaces/responses/user/api_user_response";
import { IUser } from "@/interfaces/user";
import axios from "axios";

const getUrl = `${process.env.NEXT_PUBLIC_URL}/api/get/api/v1/user`;
const postUrl = `${process.env.NEXT_PUBLIC_URL}/api/post/api/v1/user`;
const putUrl = `${process.env.NEXT_PUBLIC_URL}/api/put/api/v1/user`;
const deleteUrl = `${process.env.NEXT_PUBLIC_URL}/api/delete/api/v1/user`;

export const getUserAsync = async (id:string) =>
{
    return await axios.get<IAPIUserResponse>(`${getUrl}/${id}`).then(x => x.data)
}

export const addUserAsync = async (user:IUser) =>
{
    return await axios.post<IAPIResponse>(`${postUrl}/add`, user).then(x => x.data)
}

export const updateUserAsync = async (user:IUser) =>
{
    return await axios.put<IAPIResponse>(`${putUrl}/update`, user).then(x => x.data)
}

export const deleteUserAsync = async (id:string) =>
{
    return await axios.delete<IAPIResponse>(`${deleteUrl}/${id}`).then(x => x.data)
}

export const existUser = async (id:string) =>
{
    return await axios.get<IAPIResponse>(`${getUrl}/exist/${id}`).then(x => x.data)
}
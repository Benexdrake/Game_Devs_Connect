import { IAPIResponse } from "@/interfaces/responses/api_response";
import axios from "axios";
import { IProfile } from "@/interfaces/profile";

const getUrl = `${process.env.NEXT_PUBLIC_URL}/api/get/api/v1/profile`;
const postUrl = `${process.env.NEXT_PUBLIC_URL}/api/post/api/v1/profile`;
const putUrl = `${process.env.NEXT_PUBLIC_URL}/api/put/api/v1/profile`;

export const getProfileAsync = async (id:string) =>
{
    return await axios.get<IAPIResponse>(`${getUrl}/${id}`).then(x => x.data)
}

export const getFullProfileAsync = async (id:string) =>
{
    return await axios.get<IAPIResponse>(`${getUrl}/full/${id}`).then(x => x.data)
}

export const addProfileAsync = async (profile:IProfile) =>
{
    return await axios.post<IAPIResponse>(`${postUrl}/add`, profile).then(x => x.data)
}

export const updateProfileAsync = async (profile:IProfile) =>
{
    return await axios.put<IAPIResponse>(`${putUrl}/update`, profile).then(x => x.data)
}
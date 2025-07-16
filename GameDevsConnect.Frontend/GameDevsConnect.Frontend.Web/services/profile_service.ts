import { IAPIResponse } from "@/interfaces/responses/api_response";
import axios from "axios";
import { IProfile } from "@/interfaces/profile";
import { url } from "@/lib/api";
import { IAPIProfileFullResponse } from "@/interfaces/responses/profile/api_profile_full_response";

const getUrl = url('get','profile')
const postUrl = url('post','profile')
const putUrl = url('put','profile')

export const getProfileAsync = async (id:string) =>
{
    return await axios.get<IAPIResponse>(`${getUrl}/${id}`).then(x => x.data)
}

export const getFullProfileAsync = async (id:string) =>
{
    return await axios.get<IAPIProfileFullResponse>(`${getUrl}/full/${id}`).then(x => x.data)
}

export const addProfileAsync = async (profile:IProfile) =>
{
    return await axios.post<IAPIResponse>(`${postUrl}/add`, profile).then(x => x.data)
}

export const updateProfileAsync = async (profile:IProfile) =>
{
    return await axios.put<IAPIResponse>(`${putUrl}/update`, profile).then(x => x.data)
}
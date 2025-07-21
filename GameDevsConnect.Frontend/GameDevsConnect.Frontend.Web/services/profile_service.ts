import { IAPIResponse } from "@/interfaces/responses/api_response";
import axios from "axios";
import { IProfile } from "@/interfaces/profile";
import { IAPIProfileFullResponse } from "@/interfaces/responses/profile/api_profile_full_response";
import { getUrl } from "@/lib/api"

const url = getUrl('json','profile')

export const getProfileAsync = async (id:string) =>
{
    return await axios.get<IAPIResponse>(`${url}/${id}`).then(x => x.data)
}

export const getFullProfileAsync = async (id:string) =>
{
    return await axios.get<IAPIProfileFullResponse>(`${url}/full/${id}`).then(x => x.data)
}

export const addProfileAsync = async (profile:IProfile) =>
{
    return await axios.post<IAPIResponse>(`${url}/add`, profile).then(x => x.data)
}

export const updateProfileAsync = async (profile:IProfile) =>
{
    return await axios.put<IAPIResponse>(`${url}/update`, profile).then(x => x.data)
}
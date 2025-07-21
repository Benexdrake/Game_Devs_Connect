import { IQuest } from "@/interfaces/quest";
import { IAPIUpsertFavoriteRequest } from "@/interfaces/requests/quest/api_upsert_favorite_request";
import { IAPIResponse } from "@/interfaces/responses/api_response";
import { IAPIQuestIdsResponse } from "@/interfaces/responses/quest/api_quest_ids_response";
import { IAPIQuestResponse } from "@/interfaces/responses/quest/api_quest_response";
import { getUrl } from "@/lib/api"

import axios from "axios";

const url = getUrl('json','quest')

export const getQuestAsync = async (id:string, userId:string='') =>
{
    return await axios.get<IAPIQuestResponse>(`${url}/${id}?userId=${userId}`).then(x => x.data)
}

export const getQuestIdsByPostIdAsync = async (id:string) =>
{
    return await axios.get<IAPIQuestIdsResponse>(`${url}/post/${id}`).then(x => x.data)
}

export const getFavoritedQuestIdsAsync = async (userId:string, page:number=1, pageSize:number=10, searchTerm:string='') =>
{
    return await axios.get<IAPIQuestIdsResponse>(`${url}/favorites?page=${page}&pageSize=${pageSize}&userId=${userId}&searchTerm=${searchTerm}`).then(x => x.data)
}

export const addQuestAsync = async (quest:IQuest) =>
{
    return await axios.post<IAPIResponse>(`${url}/add`, quest).then(x => x.data)
}

export const updateQuestAsync = async (quest:IQuest) =>
{
    return await axios.put<IAPIResponse>(`${url}/update`, quest).then(x => x.data)
}

export const deleteQuestAsync = async (id:string) =>
{
    return await axios.delete<IAPIResponse>(`${url}/delete/${id}`).then(x => x.data)
}

export const upsertFavoriteQuestAsync = async (upsertFavorite:IAPIUpsertFavoriteRequest) =>
{
    return await axios.post<IAPIResponse>(`${url}/favorite`, upsertFavorite).then(x => x.data)
}
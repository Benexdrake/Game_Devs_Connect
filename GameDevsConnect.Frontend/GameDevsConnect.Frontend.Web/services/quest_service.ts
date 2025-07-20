import { IQuest } from "@/interfaces/quest";
import { IAPIUpsertFavoriteRequest } from "@/interfaces/requests/quest/api_upsert_favorite_request";
import { IAPIResponse } from "@/interfaces/responses/api_response";
import { IAPIQuestIdsResponse } from "@/interfaces/responses/quest/api_quest_ids_response";
import { IAPIQuestResponse } from "@/interfaces/responses/quest/api_quest_response";
import { url } from "@/lib/api";
import axios from "axios";

const getUrl = url('get','quest')
const postUrl = url('post','quest')
const putUrl = url('put','quest')
const deleteUrl = url('delete','quest')

export const getQuestAsync = async (id:string, userId:string='') =>
{
    return await axios.get<IAPIQuestResponse>(`${getUrl}/${id}?userId=${userId}`).then(x => x.data)
}

export const getQuestIdsByPostIdAsync = async (id:string) =>
{
    return await axios.get<IAPIQuestIdsResponse>(`${getUrl}/post/${id}`).then(x => x.data)
}

export const addQuestAsync = async (quest:IQuest) =>
{
    return await axios.post<IAPIResponse>(`${postUrl}/add`, quest).then(x => x.data)
}

export const updateQuestAsync = async (quest:IQuest) =>
{
    return await axios.put<IAPIResponse>(`${putUrl}/update`, quest).then(x => x.data)
}

export const deleteQuestAsync = async (id:string) =>
{
    return await axios.delete<IAPIResponse>(`${deleteUrl}/delete/${id}`).then(x => x.data)
}

export const upsertFavoriteQuestAsync = async (upsertFavorite:IAPIUpsertFavoriteRequest) =>
{
    return await axios.post<IAPIResponse>(`${postUrl}/favorite`, upsertFavorite).then(x => x.data)
}
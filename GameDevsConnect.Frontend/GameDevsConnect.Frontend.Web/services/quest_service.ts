import { IQuest } from "@/interfaces/quest";
import { IAPIResponse } from "@/interfaces/responses/api_response";
import { IAPIQuestIdsResponse } from "@/interfaces/responses/quest/api_quest_ids_response";
import { IAPIQuestResponse } from "@/interfaces/responses/quest/api_quest_response";
import axios from "axios";

const getUrl = `${process.env.NEXT_PUBLIC_URL}/api/get/api/v1/quest`;
const postUrl = `${process.env.NEXT_PUBLIC_URL}/api/post/api/v1/quest`;
const putUrl = `${process.env.NEXT_PUBLIC_URL}/api/put/api/v1/quest`;
const deleteUrl = `${process.env.NEXT_PUBLIC_URL}/api/delete/api/v1/quest`;

export const getQuestAsync = async (id:string) =>
{
    return await axios.get<IAPIQuestResponse>(`${getUrl}/${id}`).then(x => x.data)
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
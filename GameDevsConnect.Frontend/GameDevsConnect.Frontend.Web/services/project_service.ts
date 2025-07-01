import { IAPIResponse } from "@/interfaces/responses/api_response";
import axios from "axios";
import { IProject } from "@/interfaces/project";
import { url } from "@/lib/api";

const getUrl = url('get','project')
const postUrl = url('post','project')
const putUrl = url('put','project')
const deleteUrl = url('delete','project')

export const getProjectAsync = async (id:string) =>
{
    return await axios.get<IAPIResponse>(`${getUrl}/${id}`).then(x => x.data)
}

export const addProjectAsync = async (project:IProject) =>
{
    return await axios.post<IAPIResponse>(`${postUrl}/add`, project).then(x => x.data)
}

export const updateProjectAsync = async (project: IProject) =>
{
    return await axios.put<IAPIResponse>(`${putUrl}/update`, project).then(x => x.data)
}

export const deleteProjectAsync = async (id:string) =>
{
    return await axios.delete<IAPIResponse>(`${deleteUrl}/delete/${id}`).then(x => x.data)
}
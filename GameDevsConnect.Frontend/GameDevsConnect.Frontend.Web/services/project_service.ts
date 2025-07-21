import { IAPIResponse } from "@/interfaces/responses/api_response";
import axios from "axios";
import { IProject } from "@/interfaces/project";
import { getUrl } from "@/lib/api"

const url = getUrl('json','project')

export const getProjectAsync = async (id:string) =>
{
    return await axios.get<IAPIResponse>(`${url}/${id}`).then(x => x.data)
}

export const addProjectAsync = async (project:IProject) =>
{
    return await axios.post<IAPIResponse>(`${url}/add`, project).then(x => x.data)
}

export const updateProjectAsync = async (project: IProject) =>
{
    return await axios.put<IAPIResponse>(`${url}/update`, project).then(x => x.data)
}

export const deleteProjectAsync = async (id:string) =>
{
    return await axios.delete<IAPIResponse>(`${url}/delete/${id}`).then(x => x.data)
}
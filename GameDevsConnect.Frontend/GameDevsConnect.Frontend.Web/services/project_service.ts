import { IAPIResponse } from "@/interfaces/responses/api_response";
import axios from "axios";
import { IProject } from "@/interfaces/project";

const getUrl = `${process.env.NEXT_PUBLIC_URL}/api/get/api/v1/project`;
const postUrl = `${process.env.NEXT_PUBLIC_URL}/api/post/api/v1/project`;
const putUrl = `${process.env.NEXT_PUBLIC_URL}/api/put/api/v1/project`;
const deleteUrl = `${process.env.NEXT_PUBLIC_URL}/api/delete/api/v1/project`;

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
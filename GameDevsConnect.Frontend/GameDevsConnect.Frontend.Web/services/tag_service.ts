import { IAPITagsResponse } from "@/interfaces/responses/tag/api_tag_response";
import { url } from "@/lib/api";
import axios from "axios";

const getUrl = url('get','tag')

export const getTags = async () =>
{
    return await axios.get<IAPITagsResponse>(`${getUrl}`).then(x => x.data)
}
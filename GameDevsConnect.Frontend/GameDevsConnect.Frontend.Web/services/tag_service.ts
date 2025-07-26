import { IAPITagsResponse } from "@/interfaces/responses/tag/api_tag_response";
import { getUrl } from "@/lib/api"
import axios from "axios";

const url = getUrl('json','tag')

export const getTags = async () =>
{
    return await axios.get<IAPITagsResponse>(`${url}`).then(x => x.data)
}
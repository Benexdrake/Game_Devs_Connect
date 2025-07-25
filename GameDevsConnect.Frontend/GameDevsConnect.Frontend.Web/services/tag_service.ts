import { IAPITagsResponse } from "@/interfaces/responses/tag/api_tag_response";
import { getUrl } from "@/lib/api"
import axios from "axios";


export const getTags = async () =>
{
    const url = getUrl('json','tag')
    console.log('URL', url);
    
    return await axios.get<IAPITagsResponse>(`${url}`).then(x => x.data)
}
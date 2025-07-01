import { url } from "@/lib/api";
import axios from "axios";

const getUrl = url('get','tag')

export const getTags = async () =>
{
    return await axios.get(`${getUrl}`).then(x => x.data)
}
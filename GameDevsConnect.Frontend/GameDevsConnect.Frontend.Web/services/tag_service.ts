import axios from "axios";

const getUrl = `${process.env.NEXT_PUBLIC_URL}/api/get/api/v1/tag`;

export const getTags = async () =>
{
    return await axios.get(`${getUrl}`).then(x => x.data)
}
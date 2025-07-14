import { getAxiosInstance } from "@/lib/axios_config";
import type { NextApiRequest, NextApiResponse } from "next";

export default async function handler(req: NextApiRequest, res: NextApiResponse) 
{
    if(req.method !== 'GET')
    {
        res.status(400).send('Access Denied!');
        return;
    }
    let paths = req.query.path as string[]; 

    if(paths.length < 3)
    {
        res.status(400).send('Wrong path');
        return;
    }

    let params = '';
    
    let url = `${process.env.BACKEND_URL}/${paths.join('/')}`
    
    const urlSplit = req.url?.split('?') as string[]
    if(urlSplit?.length === 2)
        params = `?${urlSplit[1]}`

    let response =  await (await getAxiosInstance()).get(`${url}${params}`).then(x => x.data)

    res.status(200).json(response);
}

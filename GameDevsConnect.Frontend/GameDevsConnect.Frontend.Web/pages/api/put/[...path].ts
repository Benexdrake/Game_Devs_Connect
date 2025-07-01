import { getAxiosInstance } from "@/lib/axios_config";
import type { NextApiRequest, NextApiResponse } from "next";

export default async function handler(req: NextApiRequest, res: NextApiResponse) 
{
    if(req.method !== 'PUT')
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

    if(!req.body)
    {
        res.status(400).send('Where is the body?');
        return;
    }
    
    let url = `${process.env.BACKEND_URL}/${paths.join('/')}`

    let response =  await (await getAxiosInstance()).put(url, req.body).then(x => x.data)

    res.status(200).json(response);
}
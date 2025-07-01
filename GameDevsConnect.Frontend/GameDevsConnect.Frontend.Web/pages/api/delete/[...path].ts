import { getAxiosInstance } from "@/lib/axios_config";
import type { NextApiRequest, NextApiResponse } from "next";

export default async function handler(req: NextApiRequest, res: NextApiResponse) 
{
    if(req.method != 'DELETE')
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
    
    let url = `${process.env.BACKEND_URL}/${paths.join('/')}`

    let response =  await (await getAxiosInstance()).delete(url).then(x => x.data)

    res.status(200).json(response);
}

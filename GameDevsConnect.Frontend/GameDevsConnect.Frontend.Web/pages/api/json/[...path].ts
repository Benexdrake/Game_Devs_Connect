import { getAxiosInstance } from "@/lib/axios_config";
import type { NextApiRequest, NextApiResponse } from "next";

export default async function handler(req: NextApiRequest, res: NextApiResponse) 
{
    let paths = req.query.path as string[];
    
    if(paths.length < 3)
    {
        res.status(400).send('Wrong path');
        return;
    }
    
    let url = `${process.env.BACKEND_URL}/${paths.join('/')}`
        
    let response = undefined;

    switch(req.method)
    {
        case "GET":
            response =  await (await getAxiosInstance()).get(url).then(x => x.data)
            break;

        case "POST":
            response =  await (await getAxiosInstance()).post(url, req.body).then(x => x.data)
            break;

        case "PUT":
            response =  await (await getAxiosInstance()).put(url, req.body).then(x => x.data)
            break;

        case "DELETE":
            response =  await (await getAxiosInstance()).delete(url, req.body).then(x => x.data)
            break;

        default:
            res.status(400).send("Wrong Method")
            break;
    }

    res.status(200).json(response);
}
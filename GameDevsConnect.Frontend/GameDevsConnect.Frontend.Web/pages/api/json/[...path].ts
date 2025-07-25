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

    if(!process.env.BACKEND_URL)
    {
        res.status(400).send('Missing Backend Url');
        return;
    }
    
    console.log("BACKEND URL",process.env.BACKEND_URL);
    

    let url = `${process.env.BACKEND_URL}/${paths.join('/')}`

    console.log("URL",url);
    
        
    let response = undefined;

    const instance = await getAxiosInstance();

    switch(req.method)
    {
        case "GET":
            response =  await instance.get(url).then(x => x.data)
            break;

        case "POST":
            response =  await instance.post(url, req.body).then(x => x.data)
            break;

        case "PUT":
            response =  await instance.put(url, req.body).then(x => x.data)
            break;

        case "DELETE":
            response =  await instance.delete(url, req.body).then(x => x.data)
            break;

        default:
            res.status(400).send("Wrong Method")
            break;
    }

    res.status(200).json(response);
}
import { getAxiosInstance } from "@/lib/axios_config";
import type { NextApiRequest, NextApiResponse } from "next";

export default async function handler(req: NextApiRequest, res: NextApiResponse) 
{ 
    try 
    {
        if(req.method !== 'POST')
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

        let instance = await getAxiosInstance()

        let response = await instance.post(url, req.body).then(x => x.data)
            
        res.status(200).json(response);
    } 
    catch (error) 
    {
        console.log(error);
        
    }
    
    res.status(200).json('');
}

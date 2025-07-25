"use server";

import axios, { AxiosError } from "axios";
import https from 'https';

function getAxiosConfig()
{
    const httpsAgent = new https.Agent({  
        rejectUnauthorized: false
    });

    const axiosConfig = axios.create({
        httpsAgent,
        headers: {
            "X-Access-Key" : process.env.X_ACCESS_KEY
        }
    });
    
    return axiosConfig;
}

export async function getAxiosInstance()
{
    let axiosInstance = getAxiosConfig();
    try
    {
        let login = await getAxiosConfig().get(`${process.env.BACKEND_URL}/login`).then(x => x.data)

        axiosInstance.defaults.headers.common['Authorization'] = `Bearer ${login.accessToken}`
    }
    catch(error)
    {
        console.error("ERROR:",error)
    }

    axiosInstance.interceptors.response.use( response => 
        { return response; },
        (error: AxiosError) => {
            if (axios.isAxiosError(error)) 
            {
                console.error('[Axios Error]', 
                {
                    url: error.config?.url,
                    method: error.config?.method,
                    status: error.response?.status,
                    data: error.response?.data,
                });
            } 
            else 
            {
                console.error('[Unbekannter Fehler]', error);
            }
            return Promise.reject(error);
        });
    
    return axiosInstance;
}
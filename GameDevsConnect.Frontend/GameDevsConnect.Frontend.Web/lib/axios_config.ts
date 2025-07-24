"use server";

import axios from "axios";
import https from 'https';

function getAxiosConfig()
{
    const httpsAgent = new https.Agent({  
        rejectUnauthorized: process.env.NODE_ENV === 'development' ? false : true
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

    let login = await axiosInstance.get(`${process.env.BACKEND_URL}/login`).then(x => x.data)

    axiosInstance.defaults.headers.common['Authorization'] = `Bearer ${login.accessToken}`
    return axiosInstance;
}
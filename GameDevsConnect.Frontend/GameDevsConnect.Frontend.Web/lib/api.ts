import { PUBLIC_API_URL } from "./constant";

export const getUrl = (methode:string, endpoint:string) => 
{
    console.log("NEXTJS BACKEND URL1",`${PUBLIC_API_URL}/api/${methode}/api/v1/${endpoint}`);
    console.log("NEXTJS BACKEND URL2",`${process.env.NEXT_PUBLIC_URL}`);
    
    return `${PUBLIC_API_URL}/api/${methode}/api/v1/${endpoint}`;
};
import { PUBLIC_API_URL } from "./constant";

export const getUrl = (methode:string, endpoint:string) => 
{
    console.log("NEXTJS BACKEND URL",`${PUBLIC_API_URL}/api/${methode}/api/v1/${endpoint}`);
    
    return `${PUBLIC_API_URL}/api/${methode}/api/v1/${endpoint}`;
};
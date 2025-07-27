import { PUBLIC_API_URL } from "./constant";

export const getUrl = (methode:string, endpoint:string) => 
{
    return `${PUBLIC_API_URL}/api/${methode}/api/v1/${endpoint}`;
};
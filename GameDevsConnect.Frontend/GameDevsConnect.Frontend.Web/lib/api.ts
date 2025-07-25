export const getUrl = (methode:string, endpoint:string) => 
{
    console.log("NEXTJS BACKEND URL",`${process.env.NEXT_PUBLIC_URL}/api/${methode}/api/v1/${endpoint}`);
    
    return `${process.env.NEXT_PUBLIC_URL}/api/${methode}/api/v1/${endpoint}`
};
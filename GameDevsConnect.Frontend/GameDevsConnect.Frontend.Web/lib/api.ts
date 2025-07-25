export const getUrl = (methode:string, endpoint:string) => 
{
    console.log("NEXTJS BACKEND URL",process.env.NEXT_PUBLIC_URL);
    
    return `${process.env.NEXT_PUBLIC_URL}/api/${methode}/api/v1/${endpoint}`
};
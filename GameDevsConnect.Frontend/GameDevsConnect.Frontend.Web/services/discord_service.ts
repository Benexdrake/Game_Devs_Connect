import { IUser } from "../interfaces/user";
import axios from "axios";

export async function getDiscordUser(token:any)
{
    try 
    {
        const config = {
            headers: { Authorization: `Bearer ${token.accessToken}` }
        };
        const d = await axios.get('https://discord.com/api/users/@me', config).then(x => { return x.data})
        
        let avatar = '/discordblue.png'
        
        if(d.avatar)
            avatar = `https://cdn.discordapp.com/avatars/${d.id}/${d.avatar}`;
        
        let username = d.global_name;
        if(!username)
            username = d.username;
    
        const user:IUser = {id:d.id, username, avatar, accountType:'discord'}
        
        return user;
    } 
    catch (error) 
    {
        console.log(error);  
    }
}
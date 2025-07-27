import { getQuestAsync } from '@/services/quest_service';
import { useEffect, useState } from 'react';
import PreviewQuest from './preview_quest';
import { IAPIQuestResponse } from '@/interfaces/responses/quest/api_quest_response';
import { useSession } from 'next-auth/react';
import { IUser } from '@/interfaces/user';

export default function ShowQuest({id, index, userId=""}:{id:string, index:number, userId:string})
{
    const [response, setResponse] = useState<IAPIQuestResponse>(null!)

    useEffect(() => {
        const get = async () =>
        {
            const r = await getQuestAsync(id, userId)
            
            if(r.status)
                setResponse(r)
        }

        get();
    },[])

    if(response)
        return (
            <PreviewQuest quest={response.quest} favorited={response.favoritedQuest} preview={false} onQuestDeleteHandler={null} index={index}/>
        )
    else
        return <div>LOADING...</div>
}
import { IQuest } from '@/interfaces/quest';
import { getQuestAsync } from '@/services/quest_service';
import styles from '@/styles/quest/quest.module.css'
import { useEffect, useState } from 'react';
import PreviewQuest from './preview_quest';

export default function ShowQuest({id, onQuestDeleteHandler}:{id:string, onQuestDeleteHandler:Function | null})
{
    const [quest, setQuest] = useState<IQuest>()

    useEffect(() => {
        const get = async () =>
        {
            const response = await getQuestAsync(id)
            if(response.status)
                setQuest(response.quest)
        }

        get();
    },[])

    if(quest)
        return (
            <PreviewQuest quest={quest} preview={false} onQuestDeleteHandler={null}/>
        )
    else
        return <div>LOADING...</div>
}
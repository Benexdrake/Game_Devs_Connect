import { IQuest } from '@/interfaces/quest';
import { getQuestAsync } from '@/services/quest_service';
import styles from '@/styles/quest/quest.module.css'
import { useEffect, useState } from 'react';
import PreviewQuest from './preview_quest';

export default function ShowQuest(props:any)
{
    const {id} = props;

    const [quest, setQuest] = useState<IQuest>()

    const lorem = 'Lorem ipsum dolor sit amet consectetur, adipisicing elit. Dolorem quos distinctio, voluptate aliquid laboriosam reprehenderit magni quae velit? Cupiditate repellat saepe, veritatis magnam dolorem ex perferendis sed aperiam. Quibusdam, corrupti.';

    useEffect(() => {
        const get = async () =>
        {
            const response = await getQuestAsync(id)
            if(response.status)
                setQuest(response.quest)
        }

        get();
    },[])

    return (
        <PreviewQuest quest={quest} preview={false}/>
    )
}
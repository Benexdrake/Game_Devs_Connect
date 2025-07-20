import { IQuest } from '@/interfaces/quest'
import { IUser } from '@/interfaces/user';
import { upsertLikeQuestAsync } from '@/services/quest_service';
import styles from '@/styles/quest/quest.module.css'
import { useSession } from 'next-auth/react';
import { useRouter } from 'next/router';
import React, { useState } from 'react';

export default function PreviewQuest({quest, favorited, onQuestDeleteHandler, preview, index}:{quest:IQuest, favorited:boolean, onQuestDeleteHandler:Function | null, preview:boolean, index:number})
{
    const [favorite, setFavorite] = useState<boolean>(favorited)
    const {data:session} = useSession();
    const user = session?.user as IUser;
    const router = useRouter();

    const onRouteQuestHandler = (e:React.MouseEvent) =>
    {
        e.stopPropagation();

        if(!preview)
            router.push(`/quest/${quest.id}`)   
    }

    const stopClick = (e: React.MouseEvent) => 
    {
        e.stopPropagation();
    };

    const onFavoriteHandler = async (e: React.MouseEvent) =>
    {
        e.stopPropagation();
        setFavorite(prev => !prev);
        console.log(!favorite);
        

        const response = await upsertLikeQuestAsync({questId:quest.id, userId:user.id})
        console.log(response);   
    }

    return (
        <div className={styles.main} onClick={onRouteQuestHandler}>
            <article>
                <div className={styles.main_content}>
                    <div className={styles.content}>
                        <div className={styles.content_title}>
                            <p># {index} </p>
                            <p>{quest?.title}</p>
                            <p>{quest.difficulty}</p>
                        </div>
                        <div className={styles.content_message} onClick={stopClick}>
                            <p>
                                {quest?.description}
                            </p>
                        </div>
                    </div>
                </div>
                {!preview && ( 
                    <div className={styles.buttons}>
                        <div className={styles.button} onClick={onFavoriteHandler}>
                            <i className={`fa-${favorite ? 'solid':'regular'} fa-star`}></i>
                        </div>
                    </div>
                    
                    )}
                {preview &&  onQuestDeleteHandler && (
                    <div className={styles.buttons}>
                        <div className={styles.button} ><i className="fa-solid fa-pen"></i></div>
                        <div className={styles.button} onClick={() => onQuestDeleteHandler(quest)}><i className="fa-solid fa-trash-can"></i></div>
                    </div>
                )}
            </article>
        </div>
    )
}
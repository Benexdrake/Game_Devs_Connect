import styles from '@/styles/post/post.module.css'
import PostContent from "./post_content";
import { useRouter } from "next/router";
import { ITag } from '@/interfaces/tag';
import { useEffect, useState } from 'react';
import { IAPIPostResponse } from '@/interfaces/responses/post/api_post_response';
import { getPostAsync } from '@/services/post_service';

export default function ShowPost({ id, page }:{ id:string, page:boolean }) 
{
    const [response, setResponse] = useState<IAPIPostResponse>();
    
    const router = useRouter();

    useEffect(() =>
    {
        const get = async () =>
        {
            const r = await getPostAsync(id);
            if(r.status)
                setResponse(r)
        }

        get();
    }, [])

    const stopClick = (e: React.MouseEvent) => 
    {
        e.stopPropagation();
    };

    const routeProfileHandler = (e: React.MouseEvent) => 
    {
        e.stopPropagation();
        router.push(`/profile/${response?.owner.id}`)
    };
    
    
    return (
        <div className={styles.main} style={{ backgroundColor: `${response?.post.hasQuest ? response.post.completed ? 'var(--color3)' : '#FFD700' : 'var(--color1)'}` }}>
            {response && (
            <article >
                <div className={styles.project_name}>
                    {response?.projectTitle && (
                        <p>{response.projectTitle}</p>
                    )}
                </div>
                <header className={styles.header}>
                    <div>
                        <p>{response?.owner.username}</p>
                    </div>
                    <div>
                        <p>{new Date(response?.post.created!).toLocaleDateString('en-us', { year: "numeric", month: "short", day: "numeric" })}</p>
                    </div>
                </header>
                <div className={styles.content}>
                    <div>
                        <div className={styles.content_left} onClick={routeProfileHandler} style={{float:'left'}}>
                        <div className={styles.avatar}>
                            <img src={response?.owner.avatar} alt="" />
                        </div>
                        { response?.projectTitle && (
                            <div className={styles.team_position}>
                                <p>Owner</p>
                            </div>
                        )}
                        <div className={styles.avatar_level}>
                            <p>Lv. 10</p>
                        </div>
                    </div>
                        <div className={styles.content_right} onClick={stopClick}>
                        <p className={styles.message}>
                            { page ? 
                                response?.post.message 
                                :
                                response.post.message.length > 300 ?
                                    response?.post.message.slice(0, 300) + ' ...' 
                                    :
                                    response?.post.message }
                        </p>
                    </div>
                    </div>
                    <div>
                        {response.files.map(x => (
                            <div onClick={stopClick}>
                                <PostContent file={x} />
                            </div>
                        ))}
                    </div>
                    {/* {response?.file &&
                        (
                            <div onClick={stopClick}>
                                <PostContent file={response.file} />
                            </div>
                        )} */}
                    <div className={styles.tags}>
                        {response?.tags?.map((x: ITag) => { return <span key={x.tag + response.post.id} className={styles.tag} onClick={stopClick}>{x.tag}</span> })}
                    </div>
                </div>
                <div className={styles.info_bar}>
                    <div className={styles.buttons}>
                        {response.post.hasQuest && (
                            <div className={styles.button}>
                                <i className="fa-solid fa-clipboard-question"></i> {response.questCount}
                            </div>
                        )}
                        {response.post.parentId === '' && (
                            <div className={styles.button}><i className="fa-solid fa-comment"></i> {response?.comments}</div>
                        )}
                        <div className={styles.button}><i className="fa-solid fa-heart"></i> {response?.likes}</div>
                        {/* 
                            Download Button for Rar/Zip File
                        {response?.files && (
                            <div className={styles.button}><i className="fa-solid fa-cloud-arrow-down"></i></div>
                        )}
                        */}
                    </div> 
                </div>
            </article>
              )}
        </div>
    )
}
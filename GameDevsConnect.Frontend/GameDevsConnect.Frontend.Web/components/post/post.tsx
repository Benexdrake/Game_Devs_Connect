import { IAPIPostResponse } from "@/interfaces/responses/post/api_post_response";
import styles from '@/styles/post/post.module.css'
import PostContent from "./post_content";
import { useEffect, useState } from "react";
import { getPostAsync } from "@/services/post_service";

export default function Post(props:any)
{
  const {id} = props;

  const [response, setResponse] = useState<IAPIPostResponse>()

  useEffect(() => 
  {
    const getPost = async () =>
    {
       const responseFull = await getPostAsync(id);

       if(responseFull)
          setResponse(responseFull)
    }

    getPost();
  }, [])

  if(response?.status)
  return (
    <>
      <div className={styles.main} style={{backgroundColor:`${response.post.hasQuest?response.post.completed?'var(--color3)':'#FFD700':'var(--color1)'}`}}>
          <article>
            <div className={styles.project_name}>
              {response.projectTitle && (
                    <p>{response.projectTitle}</p>
                )}
            </div>
            <header className={styles.header}>
              <div>
                <p>{ response.owner.username}</p>
            </div>
              <div>
                <p>{new Date(response.post.created).toLocaleDateString('en-us', { year: "numeric", month: "short", day: "numeric" })}</p>
              </div>
            </header>
            <div className={styles.content}>
              <div className={styles.content_left}>
                <div className={styles.avatar}>
                  <img src={response?.owner.avatar} alt="" />
                </div>
                {response.projectTitle && (
                  <div className={styles.team_position}>
                    <p>Owner</p>
                  </div>
                )}
                <div className={styles.avatar_level}>
                  <p>Lv. 10</p>
                </div>
              </div>
              <div className={styles.content_right}>
                <p>{ response.post.message.slice(0,300)}</p>
              </div>
              <div className={styles.file}>
                { response.file && (
                  <PostContent file={response.file} />
                )}
              </div>
            </div>
            <div className={styles.info_bar}>
                <div className={styles.tags}>
                  { response.tags?.map(x => {return <span className={styles.tag}>{x.tag}</span>})}
                </div>
                <div className={styles.buttons}>
                  <div><i className="fa-solid fa-comment"></i> {response.comments}</div>
                  <div><i className="fa-solid fa-heart"></i> {response.likes}</div>
                  { response.file?.type === 'zip' && (
                    <div><i className="fa-solid fa-cloud-arrow-down"></i></div>
                  )}
                </div>
            </div>

          </article>
      </div>
    </>
  )
}
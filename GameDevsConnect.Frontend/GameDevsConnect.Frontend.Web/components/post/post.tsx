import { IFile } from "@/interfaces/file";
import { IPost } from "@/interfaces/post";
import { IAPIPostResponse } from "@/interfaces/responses/post/api_post_response";
import { ITag } from "@/interfaces/tag";
import { IUser } from "@/interfaces/user";

import styles from '@/styles/post/post.module.css'
import PostContent from "./post_content";

export default function Post(props:any)
{
      const user = props.user as IUser;
    
      const message = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.";
    
      const post:IPost = {id: "1", parentId:null, hasQuest:false, message, created:"12/24/2024", projectId:"111", ownerId:user.id, fileId:"111", isDeleted:false, completed:false}
      const file: IFile = {id:"111", url:"https://hollowknight.wiki.fextralife.com/file/Hollow-Knight/greenpath-map-hollow-knight-wiki-guide.png", type:'image', size:12345, ownerId:user.id, created:"12/24/2025"}
      const tags: ITag[] = [{id:1, tag:"2D"}, {id:1, tag:"3D"}, {id:1, tag:"LP"}]
    
      const response : IAPIPostResponse = {post, projectTitle:"", file, owner:user, tags, status:true, message:"", validateErrors:null}
    
        return (
    <>
      <div className={styles.main}>
          <article>
            <header className={styles.header}>
              <div>
                <p>{user.username}</p>
            </div>
              <div>
                <p>{response.post.created}</p>
              </div>
            </header>
            <div className={styles.content}>
              <div className={styles.content_left}>
                <div className={styles.avatar}>
                  <img src={user.avatar} alt="" />
                </div>
                <div className={styles.avatar_level}>
                  Lv. 10
                </div>
              </div>
              <div className={styles.content_right}>
                <p>{response.post.message.slice(0,300)}</p>
              </div>
              <div className={styles.file}>
                <PostContent file={file} />
              </div>
            </div>
            <div className={styles.info_bar}>
              {/* <div>
                <div className={styles.tags}>
                  {tags.map(x => {return <span className={styles.tag}>{x.tag}</span>})}
                </div>
              </div>
              <div className="">
                <div><i className="fa-solid fa-comment"></i> 1</div>
                <div><i className="fa-solid fa-heart"></i> 5</div>
                <div><i className="fa-solid fa-cloud-arrow-down"></i></div>
              </div> */}

                <div className={styles.tags}>
                  {tags.map(x => {return <span className={styles.tag}>{x.tag}</span>})}
                </div>
                <div className={styles.buttons}>
                  <div><i className="fa-solid fa-comment"></i> 100</div>
                  <div><i className="fa-solid fa-heart"></i> 5</div>
                  <div><i className="fa-solid fa-cloud-arrow-down"></i></div>
                </div>


            </div>

          </article>
      </div>
    </>
  )
}
import ShowPost from "@/components/post/show_post";
import { GetServerSidePropsContext } from "next";
import { getSession, useSession } from "next-auth/react";
import AddComment from "@/components/post/add_comment";
import { IUser } from "@/interfaces/user";
import { getPostIdsAsync } from "@/services/post_service";
import { getQuestIdsByPostIdAsync } from "@/services/quest_service";
import ShowQuest from "@/components/quest/show_quest";
import ShowElement from "@/components/show_element";
import { useState } from "react";
import InfiniteScrollPosts from "@/components/infinite_scroll_posts";

export default function Post({id, commentIds, questIds, fileIds}:{id:string, commentIds:string[], questIds:string[], fileIds:string[]})
{
    const {data:session} = useSession();
    const user = session?.user as IUser;
    const [showQuest, setShowQuest] = useState<boolean>(false);
    const [showComments, setShowComments] = useState<boolean>(false);
    const [showFiles, setShowFiles] = useState<boolean>(false);

    if(session)
    return (
        <div style={{display:"grid", gap:'8px', margin:'16px 0'}}>
            { id && (
                <div>
                    <ShowPost id={id} page={true}/>
                </div>
            )}
            { questIds && questIds.length > 0 && 
                (
                    <ShowElement title='Quests' show={showQuest} setShow={setShowQuest}> 
                        <div style={{display:"grid", gap:'8px', marginTop:'8px'}}>
                            {questIds.map((x:string, index) => <ShowQuest id={x} index={index + 1} key={x} userId={user.id}/>)} 
                        </div>
                    </ShowElement>
                )
            }
            { fileIds && fileIds.length > 0 && 
                (
                    <ShowElement title='Files' show={showFiles} setShow={setShowFiles}>
                        { fileIds.map((x:string) => <>Show Files</>) }
                    </ShowElement>
                )
            }
            <AddComment userId={user.id} postId={id}/>
            {commentIds && commentIds.length > 0 && (
                <ShowElement title='Comments' show={showComments} setShow={setShowComments}>
                    <div style={{display:"grid", gap:'8px', marginTop:'8px'}}>
                        <InfiniteScrollPosts initialIds={commentIds} search="" parentId={id}/>
                    </div> 
                </ShowElement>
            )}
        </div>
    )
}

export async function getServerSideProps(context:GetServerSidePropsContext)
{
    const session = await getSession(context)
    const {id} = context.query;
    
    if(!session)
    {
        return {
            redirect: {
                destination: '/login',
                permanent: false
            }
        }
    }

    if(!id)
      return {
            redirect: {
                destination: '/',
                permanent: false
            }
        }
    
    const responseComments = await getPostIdsAsync(1,10,'',id as string);
    const responseQuestIds = await getQuestIdsByPostIdAsync(id as string);
    
    return {
        props: {
            id,
            commentIds:responseComments.status ? responseComments.ids : [],
            questIds: responseQuestIds.status ? responseQuestIds.ids : []
        }
    }
}
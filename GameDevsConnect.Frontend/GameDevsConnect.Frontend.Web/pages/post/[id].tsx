import ShowPost from "@/components/post/show_post";
import { GetServerSidePropsContext } from "next";
import { getSession, useSession } from "next-auth/react";
import AddPost from "@/components/post/add_post";
import { IUser } from "@/interfaces/user";
import { getPostIdsAsync } from "@/services/post_service";

export default function Post(props:any)
{
    const {id, commentIds} = props;

    const {data:session} = useSession();
    const user = session?.user as IUser;

    console.log(commentIds);
    

    if(session)
    return (
        <div>
            {id && (
                <div>
                    <ShowPost id={id} page={true}/>
                </div>
            )}
            <div>
                FILES
            </div>
            <div>
                <AddPost userId={user.id} postId={id}/>
            </div>
            <div>
                {commentIds && commentIds.map((x:string) => <ShowPost id={x} page={false}/>)}
            </div>
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
    

    const response = await getPostIdsAsync(1,10,'',id as string);
    console.log(response.ids);

    
    return {
        props: {
            id,
            commentIds:response.status ? response.ids : ''
        }
    }
}
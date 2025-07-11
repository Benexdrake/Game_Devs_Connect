import { IUser } from "@/interfaces/user";
import { GetServerSidePropsContext } from "next";
import { useSession, getSession } from "next-auth/react";
import Post from "@/components/post/post";
import { getPostIdsAsync } from "@/services/post_service";
import AddPost from "@/components/post/add_post";

export default function Home(props:any) 
{
  const {data:session} = useSession();
  const user = session?.user as IUser;

  const ids = props.ids as string[];

  return (
    <>
    { session && (
      <>
        <AddPost userId={user.id}/>
        { ids && ids.map(x => <Post id={x} key={x}/> )}
      </>
    )}
    </>
  )
}

export async function getServerSideProps(context:GetServerSidePropsContext)
{
  const session = await getSession(context)
  
  if(!session)
  {
      return {
          redirect: {
              destination: '/login',
              permanent: false
          }
      }
  }

  const response = await getPostIdsAsync();
    
  return {
    props: {
      ids: response.ids || []
    }
  }
}
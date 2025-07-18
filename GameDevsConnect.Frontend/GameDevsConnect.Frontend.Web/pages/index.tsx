import { IUser } from "@/interfaces/user";
import { GetServerSidePropsContext } from "next";
import { useSession, getSession } from "next-auth/react";
import { getPostIdsAsync } from "@/services/post_service";
import AddPost from "@/components/post/add_post";
import ShowPost from "@/components/post/show_post";
import { useRouter } from "next/router";
import Modal from "@/components/modal/modal";
import { useState } from "react";

export default function Home(props:any) 
{
  const {data:session} = useSession();
  const user = session?.user as IUser;
  const router = useRouter();
  const ids = props.ids as string[];

  

  return (
    <>
    { session && (
      <>
        { 
          ids && ids.map(x => {
            return (
              <div onClick={() =>router.push(`/post/${x}`)} style={{margin:'8px 0'}}>
                <ShowPost id={x} page={false} key={x}/>
              </div>
        )
      })
    }
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
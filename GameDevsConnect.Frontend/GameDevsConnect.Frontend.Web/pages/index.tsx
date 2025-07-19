import { GetServerSidePropsContext } from "next";
import { useSession, getSession } from "next-auth/react";
import { getPostIdsAsync } from "@/services/post_service";
import InfiniteScrollPosts from "@/components/infinite_scroll_posts";

export default function Home({ids}: {ids:string[]}) 
{
  const {data:session} = useSession();

  return (
    <>
    { session && (
      <InfiniteScrollPosts initialIds={ids} search="" parentId=""/>
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
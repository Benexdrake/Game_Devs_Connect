import { IUser } from "@/interfaces/user";
import { GetServerSidePropsContext } from "next";
import { useSession, getSession } from "next-auth/react";
import Post from "@/components/post/post";

export default function Home(props:any) 
{
  const {data:session} = useSession();
  const user = session?.user as IUser;

  return (
    <>
      <Post user= {user}/>
      <Post user= {user}/>
      <Post user= {user}/>
      <Post user= {user}/>
      <Post user= {user}/>
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
  
  return {
    props: {
    }
  }
}
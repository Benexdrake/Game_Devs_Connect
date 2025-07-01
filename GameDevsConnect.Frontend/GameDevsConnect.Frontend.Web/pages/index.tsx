import { IUser } from "@/interfaces/user";
import { GetServerSidePropsContext } from "next";
import { useSession, signIn, signOut, getSession } from "next-auth/react";

export default function Home(props:any) 
{
  const {data:session} = useSession();

  console.log(props.user);
  

  if(session)
    return <button onClick={() => signOut()}>Logout</button>
  else
    return <button onClick={() => signIn()}>Login</button>
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
      user: session.user as IUser
    }
  }
}
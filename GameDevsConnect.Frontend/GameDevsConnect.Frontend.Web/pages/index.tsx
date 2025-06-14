import axios from "axios";
import { GetServerSidePropsContext } from "next";
import { useSession, signIn, signOut } from "next-auth/react";

export default function Home() 
{

  const {data:session} = useSession();

      if(session)
        return <button onClick={() => signOut()}>Logout</button>
      else
        return <button onClick={() => signIn()}>Login</button>
}

// export async function getServerSideProps(context:GetServerSidePropsContext)
// {
//   const tags = await axios.get('')
// }
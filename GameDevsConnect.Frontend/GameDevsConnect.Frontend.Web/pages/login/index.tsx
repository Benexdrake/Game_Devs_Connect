import Head from 'next/head'
import { getSession, signIn, useSession } from "next-auth/react";
import { GetServerSidePropsContext } from 'next';

// import styles from '@/styles/modules/login.module.css'

export default function Login() 
{
  return (
    <div >
      <Head>
        <title>GDC - Login</title>
      </Head>
      <h1>Please log in to get access</h1>
      <h1>{process.env.NEXT_PUBLIC_URL}</h1>
      <br />
      <button onClick={() => signIn()}>Login</button>
    </div>
  );
}

export async function getServerSideProps(context:GetServerSidePropsContext)
{
 const session = await getSession(context)
 
     if(session)
     {
         return {
             redirect: {
                 destination: '/',
                 permanent: false
             }
         }
     }

     return {
        props: {}
     }
}
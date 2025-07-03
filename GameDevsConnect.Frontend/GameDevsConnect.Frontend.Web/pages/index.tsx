import { IFile } from "@/interfaces/file";
import { IPost } from "@/interfaces/post";
import { IAPIPostResponse } from "@/interfaces/responses/post/api_post_response";
import { ITag } from "@/interfaces/tag";
import { IUser } from "@/interfaces/user";
import { GetServerSidePropsContext } from "next";
import { useSession, signIn, signOut, getSession } from "next-auth/react";

import styles from '@/styles/post/post.module.css'
import Post from "@/components/post/post";

export default function Home(props:any) 
{
  const {data:session} = useSession();
  const user = session?.user as IUser;

  const message = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.";

  const post:IPost = {id: "1", parentId:null, hasQuest:false, message, created:"12/24/2024", projectId:"111", ownerId:user.id, fileId:"111", isDeleted:false, completed:false}
  const file: IFile = {id:"111", name:"", size:12345, ownerId:user.id, created:"12/24/2025"}
  const tags: ITag[] = [{id:1, tag:"2D"}, {id:1, tag:"3D"}, {id:1, tag:"LP"}]

  const response : IAPIPostResponse = {post, projectTitle:"", file, owner:user, tags, status:true, message:"", validateErrors:null}

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
      // user: session.user as IUser
    }
  }
}
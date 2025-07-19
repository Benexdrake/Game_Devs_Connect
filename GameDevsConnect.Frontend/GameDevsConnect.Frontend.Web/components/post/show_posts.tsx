import { useRouter } from "next/router";
import ShowPost from "./show_post";
import { IPost } from "@/interfaces/post";

export default function ShowPosts({ids, comment}: {ids:string[], comment:boolean})
{
    const router = useRouter();

    const onClickHandler = (id:string) =>
    {
      if(!comment)
        router.push(`/post/${id}`)
    }

    return (
        <>
            { 
              ids.map(x => {
                return (
                  <div onClick={() => onClickHandler(x)} style={{margin:'8px 0'}}>
                    <ShowPost id={x} page={false} key={x}/>
                  </div>
                )
              })
            }
        </>
    )
}
import { useRouter } from "next/router";
import ShowPost from "./show_post";

export default function ShowPosts(props:any)
{
    const ids = props.ids as string[];
    const comment = props.comment;

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
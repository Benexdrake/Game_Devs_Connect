import { getPostIdsAsync } from "@/services/post_service";
import { useEffect, useState } from "react";
import { useInView } from "react-intersection-observer";
import ShowPosts from "./post/show_posts";

export default function InfiniteScrollPosts({initialIds, search, parentId}: {initialIds:string[], search:string, parentId:string})
{
    const [ids, setIds] = useState<string[]>(initialIds)
    const [page, setPage] = useState<number>(1);
    const [ref, inView] = useInView();

    const loadMoreIds = async () =>
    {
        const next = page + 1;
        const response = await getPostIdsAsync(next, 5, search, parentId);
        
        if(response.status && response.ids.length > 0)
        {
            setPage(next)
            setIds(prev => [...[...new Set([...prev, ...response.ids])]])
        }
    }

    useEffect(() => {
        if(inView)
            loadMoreIds();
    }, [inView])

    return (
        <div>
            <ShowPosts ids={ids} comment={parentId !== ''}/>
            <div ref={ref}>
                LOADING ...
            </div>
        </div>
    )
}
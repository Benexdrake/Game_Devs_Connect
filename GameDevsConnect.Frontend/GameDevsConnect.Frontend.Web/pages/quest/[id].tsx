import { IQuest } from "@/interfaces/quest";
import { getQuestAsync } from "@/services/quest_service";
import { GetServerSidePropsContext } from "next";
import { getSession } from "next-auth/react";

export default function Quest({quest}:{quest:IQuest})
{
    return (
        <div>
            {quest.title}
        </div>
    )
}

export async function getServerSideProps(context:GetServerSidePropsContext)
{
    const session = await getSession(context)
    const {id} = context.query;
    
    if(!session)
        return {
            redirect: {
                destination: '/login',
                permanent: false
            }
        }

    if(!id)
        return {
            redirect: {
                destination: '/',
                permanent: false
            }
        }
    
    const response = await getQuestAsync(id as string);
        
    if(!response.status)
    return {
        redirect: {
            destination: '/',
            permanent: false
        }
    }

    return {
        props: {
            quest:response.quest
        }
    }
}
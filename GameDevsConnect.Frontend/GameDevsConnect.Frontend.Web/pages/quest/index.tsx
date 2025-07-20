import InfiniteScrollQuests from "@/components/quest/infinite_scroll_quests";
import { IUser } from "@/interfaces/user";
import { getFavoritedQuestIdsAsync } from "@/services/quest_service";
import { GetServerSidePropsContext } from "next";
import { getSession } from "next-auth/react";

export default function Quests({ids, userId}: {ids:string[], userId:string})
{

    return (
        <div>
            <InfiniteScrollQuests initialIds={ids} userId={userId} search=""/>
        </div>
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

      const user = session.user as IUser;

      const response = await getFavoritedQuestIdsAsync(user.id)
      console.log(response);
      

      return {
        props: {
            ids: response.ids,
            userId:user.id
        }
      }
}